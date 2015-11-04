Imports Nini.Config
Imports System.IO

Public Class Settings

    Property SettingsFile As String
    Property DB_Path As String
    Property Vaid As Boolean = True
    Property ErrorMessage As String



    Dim iParser As IniFile

    Public Sub New()
        LoadSettings()
        ValidateSettings()

    End Sub


    Private Sub LoadSettings()
        Dim _iniData As New IniConfigSource("Settings.ini")

        If Not IsNothing(_iniData.Configs("DERP")) Then
            Try
                DB_Path = _iniData.Configs("DERP").Get("Database")
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub ValidateSettings()
        If Not File.Exists(DB_Path) Then
            Me.Vaid = False
            Me.ErrorMessage = Me.ErrorMessage & "The database file, " & DB_Path & " does not exist."
        End If
    End Sub
    Public Function GetConnectionString() As String
        If File.Exists(DB_Path) Then
            Return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DB_Path
        Else
            Return ""
        End If
    End Function



End Class
