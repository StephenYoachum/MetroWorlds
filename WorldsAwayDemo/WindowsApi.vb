Imports System.Runtime.InteropServices
Imports System.Text

Module WindowsApi

    Public Declare Auto Function GetPrivateProfileString Lib "kernel32" (ByVal lpAppName As String, _
        ByVal lpKeyName As String, _
        ByVal lpDefault As String, _
        ByVal lpReturnedString As StringBuilder, _
        ByVal nSize As Integer, _
        ByVal lpFileName As String) As Integer

End Module
