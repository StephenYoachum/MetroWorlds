Imports System.Runtime.InteropServices

Module WorldsAwayDapi

    <DllImport("wadapi", SetLastError:=True, CharSet:=CharSet.Ansi)> _
    Public Function IsWaThere() As Integer
    End Function

    <DllImport("wadapi", SetLastError:=True, CharSet:=CharSet.Ansi)> _
    Public Function InitDDE(ByVal name As String, ByVal ProcessAckData As ProcessAckDataDelegate, ByVal pfnProcessReceiveData As ProcessReceiveDataDelegate, ByVal ProcessGetAllText As ProcessGetAllTextDelegate) As Integer

    End Function

    <DllImport("wadapi", SetLastError:=True, CharSet:=CharSet.Ansi)> _
    Public Sub KillDDE()

    End Sub

    <DllImport("wadapi", SetLastError:=True, CharSet:=CharSet.Ansi)> _
    Public Sub DapiRegister(ByVal name As String)

    End Sub
    <DllImport("wadapi", SetLastError:=True, CharSet:=CharSet.Ansi)> _
    Public Sub DapiUnregister(ByVal name As String)

    End Sub

    <DllImport("wadapi", SetLastError:=True, CharSet:=CharSet.Ansi)> _
    Public Sub DapiCommunicate(ByVal name As String, ByVal mode As Integer, ByVal avatar As String, ByVal text As String)

    End Sub
    '<DllImport("wadapi", SetLastError:=True, CharSet:=CharSet.Ansi)> _
    'Public Function DapiGetAllText(ByVal name As String) As <MarshalAs(UnmanagedType.LPStr)> System.Text.StringBuilder

    'End Function

    <DllImport("wadapi", SetLastError:=True, CharSet:=CharSet.Ansi)> _
    Public Sub DapiGetAllText(ByVal name As String)

    End Sub

    <DllImport("wadapi", SetLastError:=True, CharSet:=CharSet.Ansi)> _
    Public Sub DapiSend(ByVal name As String, ByVal avatar As String, ByVal length As Integer, ByVal text As String)

    End Sub

    Public Delegate Sub ProcessAckDataDelegate(ByVal sAckData As String)
    Public Delegate Sub ProcessReceiveDataDelegate(ByVal sAvatar As String, ByVal nDataLen As Integer, ByVal sData As String)
    Public Delegate Sub ProcessGetAllTextDelegate(ByVal sTextData As String)

End Module
