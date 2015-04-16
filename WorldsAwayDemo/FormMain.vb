Imports System.Text

Public Class FormMain

    <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.FunctionPtr)> _
    Private ProcessAckDataCallback As New ProcessAckDataDelegate(AddressOf ProcessAckData)

    <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.FunctionPtr)> _
    Private ProcessReceiveDataCallback As New ProcessReceiveDataDelegate(AddressOf ProcessReceiveData)

    <System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.FunctionPtr)> _
    Private ProcessGetAllTextCallback As New ProcessGetAllTextDelegate(AddressOf ProcessGetAllText)

    Private Delegate Sub AvatarList_AddHandler(ByVal text As String)

    Enum Communicate
        Speak
        Think
        ESP
    End Enum

    Dim Mode As Communicate = Communicate.Speak

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' prepare control properties and appearence styles
        txtChat.ReadOnly = True
        txtChat.BackColor = Color.White

        txtSend.AutoSize = False
        txtSend.Height = 21

        Change_Communication_Mode(Communicate.Speak)
        txtChat.Text = Application.ProductName

        ' initialize dde
        Dim rslt As Integer = InitDDE(Application.ProductName, ProcessAckDataCallback, ProcessReceiveDataCallback, ProcessGetAllTextCallback)

        ' register application with wa client
        DapiRegister(Application.ProductName)
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' verify close form user action
        Dim rslt As MsgBoxResult
        rslt = MsgBox("Are you sure you wish to exit?", MsgBoxStyle.OkCancel)
        If (rslt = MsgBoxResult.Cancel) Then
            e.Cancel = True ' close action cancel
        Else
            ' closing application
            ' unregister application from wa client
            DapiUnregister(Application.ProductName)
            ' unintialize dde
            KillDDE()
            '' application closed!
        End If
    End Sub

    Private Sub ProcessAckData(ByVal sAckData As String)

    End Sub

    Private Sub ProcessReceiveData(ByVal sAvatar As String, ByVal nDataLen As Integer, ByVal sData As String)

    End Sub

    Private Sub ProcessGetAllText(ByVal text As String)
        txtChat.Text = text
    End Sub

    Private Sub Change_Communication_Mode(Mode As Communicate)
        Me.Mode = Mode
        If (Mode = Communicate.ESP) Then
            txtSend.Location = New Point(170, txtSend.Location.Y)
            txtSend.Width = 294
        Else
            txtSend.Location = New Point(12, txtSend.Location.Y)
            txtSend.Width = 450
        End If
        txtSend.Focus()
    End Sub

    Private Sub radMode1_CheckedChanged(sender As Object, e As EventArgs) Handles radMode1.CheckedChanged
        Change_Communication_Mode(Communicate.Speak)
    End Sub

    Private Sub radMode2_CheckedChanged(sender As Object, e As EventArgs) Handles radMode2.CheckedChanged
        Change_Communication_Mode(Communicate.Think)
    End Sub

    Private Sub radMode3_CheckedChanged(sender As Object, e As EventArgs) Handles radMode3.CheckedChanged
        Change_Communication_Mode(Communicate.ESP)
    End Sub

    Private Sub txtSend_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSend.KeyDown
        If (e.KeyCode = Keys.Enter) Then
            e.SuppressKeyPress = True   ' Prevent CRLF (Carriage Return + Line Feed)
            If sender.Text = "" Then Exit Sub ' Prevent sending nothing
            Dim Avatar As String = "" ' Dim Avatar and initialize to empty string
            If (Mode = Communicate.ESP) Then    ' If ESP Mode...
                Avatar = selAvatar.Text ' Populate Avatar Variable
            End If
            DapiCommunicate(Application.ProductName, Mode, Avatar, sender.Text)
            sender.Text = ""    ' Clears Text
        End If
    End Sub

    Private Sub AlwaysOnTopToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AlwaysOnTopToolStripMenuItem.Click
        If (sender.checked = False) Then
            sender.checked = True
            Me.TopMost = True
        Else
            sender.checked = False
            Me.TopMost = False
        End If
    End Sub

    Private Sub selAvatar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles selAvatar.SelectedIndexChanged
        Dim this As ComboBox = sender
        If (this.SelectedItem = "<< Friends >>") Then
            this.Text = Nothing
        End If
    End Sub

    Private Sub AvatarList_Add(ByVal text As String)
        For Each avatar As String In selAvatar.Items
            ' if duplicate avatar name found in AvatarList
            If text.ToLower() = avatar.ToLower() Then
                Exit Sub ' duplicate not added
            End If
        Next
        selAvatar.Items.Add(text) ' unique avatar name added
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        FormAbout.Visible = True
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ImportFriends(ByRef cb As AvatarList_AddHandler)
        ' imports friends list and add avatar names to avatar list

        Dim result, count, position As Integer
        Dim sb As StringBuilder = New StringBuilder(500)

        result = GetPrivateProfileString("Friends", "cFriends", "", sb, sb.Capacity, "c:\wa20\metrowa.ini")
        ' Debug.WriteLine("Friends Count : " & sb.ToString())
        count = sb.ToString
        If count > 0 Then
            cb("<< Friends >>")
            Do While count > position
                position += 1
                GetPrivateProfileString("Friends", position, "", sb, sb.Capacity, "c:\wa20\metrowa.ini")
                cb(sb.ToString())
                ' Debug.WriteLine("Friend #" & position & ": " & sb.ToString())
            Loop
        End If

    End Sub

    Private Sub ParseChat_PrivateMessages(ByRef text As String)
        ' Function Parses Chat for Sent & Received Private Messages
        ' Avatar Name of Sender/Receiver are Added to AvatarList
        ' Message portion of the private message is not used.
        Dim sender, message As String
        Dim position As Integer
        Dim lines As String() = text.Split(vbNewLine)
        For Each line In lines
            line = line.Trim()
            position = line.IndexOf(":")
            If position < 0 Then Continue For
            sender = line.Substring(0, position)
            message = line.Substring(position + 2)
            If sender = "<system>" Then Continue For
            If sender.StartsWith("ESP") Then
                If sender.StartsWith("ESP to") Then
                    sender = sender.Substring(7)
                ElseIf sender.StartsWith("ESP from") Then
                    sender = sender.Substring(9)
                End If
                AvatarList_Add(sender)
            End If
        Next
    End Sub

    Private Sub AvatarList_Refresh()
        selAvatar.Items.Clear() ' clear avatar list
        ParseChat_PrivateMessages(txtChat.Text) ' add avatar names from recent private messages
        ImportFriends(AddressOf AvatarList_Add) ' add friends list
    End Sub

    Private Sub btnGetAllText_Click(sender As Object, e As EventArgs) Handles btnGetAllText.Click
        DapiGetAllText(Application.ProductName)
        AvatarList_Refresh()
    End Sub
End Class
