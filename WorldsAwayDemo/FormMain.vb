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

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim rslt As MsgBoxResult
        rslt = MsgBox("Are you sure you wish to exit?", MsgBoxStyle.OkCancel)
        If (rslt = MsgBoxResult.Cancel) Then
            e.Cancel = True
        Else
            DapiUnregister(Application.ProductName)
            KillDDE()
        End If
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Prepare Control Properties and Appearence Styles
        txtChat.ReadOnly = True
        txtChat.BackColor = Color.White

        txtSend.AutoSize = False
        txtSend.Height = 21

        Change_Communication_Mode(Communicate.Speak)
        txtChat.Text = Application.ProductName

        Dim rslt As Integer = InitDDE(Application.ProductName, ProcessAckDataCallback, ProcessReceiveDataCallback, ProcessGetAllTextCallback)
        DapiRegister(Application.ProductName)

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

    Private Sub ProcessAckData(ByVal sAckData As String)

    End Sub
    Private Sub ProcessReceiveData(ByVal sAvatar As String, ByVal nDataLen As Integer, ByVal sData As String)

    End Sub
    Private Sub ProcessGetAllText(ByVal text As String)
        txtChat.Text = text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (sender.Text = "Start") Then
            sender.Text = "Stop"
            Timer1.Interval = 100
            Timer1.Start()
        Else
            sender.Text = "Start"
            Timer1.Stop()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        DapiGetAllText(Application.ProductName)
        txtChat.SelectionStart = txtChat.TextLength
        txtChat.ScrollToCaret()
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
            If text.ToLower() = avatar.ToLower() Then
                Exit Sub
            End If
        Next
        selAvatar.Items.Add(text)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ImportFriends(AddressOf AvatarList_Add)
        'AvatarList_Add(TextBox1.Text)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        FormAbout.Visible = True
    End Sub

    Private Sub ToolStripComboBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub txtChat_TextChanged(sender As Object, e As EventArgs) Handles txtChat.TextChanged

    End Sub

    Private Sub ImportFriends(ByRef cb As AvatarList_AddHandler)
        '   [Friends]()
        '   cFriends = 1
        '   1=Tobias (World Director)

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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MsgBox(selAvatar.SelectedIndex)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        DapiGetAllText(Application.ProductName)
    End Sub

    Private Sub ParseChat_PrivateMessages(ByRef text As String)
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ParseChat_PrivateMessages(txtChat.Text)
    End Sub
End Class
