Public Class Changelog
    Public Sub Loading() Handles MyBase.Shown
        Dim changelog As String = New Net.WebClient().DownloadString("https://www.dropbox.com/s/by2ovqnx8q45fcq/WhatsNew.txt?dl=1")
        Dim lines() As String = changelog.Split(New String() {Environment.NewLine},
                                       StringSplitOptions.None)
        Dim roots As Int16 = -1
        For i = 0 To lines.Length - 1
            If lines(i).StartsWith("V") Then
                Dim root = New TreeNode(lines(i))
                TreeView2.Nodes.Add(root)
                roots = roots + 1
            ElseIf lines(i).StartsWith("-") Then
                TreeView2.Nodes(roots).Nodes.Add(New TreeNode(lines(i)))
            Else
            End If
        Next
    End Sub

    Private Sub FlatButton1_Click(sender As Object, e As EventArgs) Handles FlatButton1.Click
        Close()
    End Sub
End Class