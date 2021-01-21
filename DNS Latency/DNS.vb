Imports JHSoftware
Imports System.Net
Imports System.Threading
Public Delegate Sub DnsDelegate(ByVal id As String)
Public Delegate Sub DnsClassDelegate(ByVal Response As DnsResponse, ByVal IPs As IPAddress())

Public Structure DnsResponse
    Dim DNSServer As String
    Dim Host As String
    Dim Key As String
    Dim Min As Double
    Dim Max As Double
    Dim Avg As Double
End Structure

Public Class classDNS
    Public DNSServer As String
    Public Host As String
    Public Key As String
    Public QPS As Integer
    Public ReQueryDelay As Integer

    Private Response As DnsResponse = New DnsResponse
    Dim Elapsed As Double
    Public DnsDelegate As DnsClassDelegate
    'Public Event Complete(ByVal IPs As IPAddress(), ByVal Key As String)
    Public Sub LookupHost()
        'Console.WriteLine(vbCrLf & "DnsServer: " & DNSServer & ", Host: " & Host)
        Response.DNSServer = DNSServer
        Response.Host = Host
        Response.Key = Key
        Response.Max = Double.MinValue
        Response.Min = Double.MaxValue
        Try
            Dim Options = New JHSoftware.DnsClient.RequestOptions
            Options.DnsServers = New System.Net.IPAddress() { _
               System.Net.IPAddress.Parse(DNSServer)}
            Dim IPs As IPAddress() = Nothing

            Dim swatch As New Stopwatch
            Dim TotalElapsed As Double = 0
            Dim iCount As Integer
            For iCount = 1 To QPS
                swatch.Start()
                IPs = JHSoftware.DnsClient.LookupHost(Host, DnsClient.IPVersion.IPv4, Options)
                swatch.Stop()
                Response.Min = Math.Min(swatch.ElapsedMilliseconds, Response.Min)
                Response.Max = Math.Max(swatch.ElapsedMilliseconds, Response.Max)
                TotalElapsed += swatch.ElapsedMilliseconds
                swatch.Reset()
                Thread.Sleep(ReQueryDelay)
            Next
            Response.Avg = Math.Round(TotalElapsed / QPS, 0)
            DnsDelegate(Response, IPs)
            'RaiseEvent Complete(IPs, Key)
            'Console.WriteLine("DnsServer: " & DNSServer & ", Host: " & Host & " - Success - " & IPs(0).ToString)
        Catch ex As Exception
            DnsDelegate(Response, Nothing)
            'MsgBox(ex.Message)
            'Console.WriteLine("DnsServer: " & DNSServer & ", Host: " & Host & " - Failed - ")
        End Try
    End Sub
End Class
