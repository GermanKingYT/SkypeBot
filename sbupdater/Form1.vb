Public Class Form1
    Dim CommandLineArgs As System.Collections.ObjectModel.ReadOnlyCollection(Of String) = My.Application.CommandLineArgs
    Dim download_size As Long
    Dim w As New Net.WebClient
    Dim downloaded_size As Long
    Private Sub a()
        Threading.Thread.Sleep(2000)
        IO.File.Delete(CommandLineArgs(0))
        If IO.File.Exists(IO.Directory.GetCurrentDirectory & "\SkypeBot.exe") Then IO.File.Delete(IO.Directory.GetCurrentDirectory & "\SkypeBot.exe")
        w.DownloadFile("https://www.dropbox.com/s/t84e5wvjsev61a9/SkypeBot.exe?dl=1", CommandLineArgs(0))
        Process.Start(CommandLineArgs(0))
        Application.Exit()
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        a()
    End Sub

    Private Sub Download_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles Download.DoWork

    End Sub
End Class
