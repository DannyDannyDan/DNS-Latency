using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using JHSoftware;

namespace DNS_Latency
{
    public delegate void DnsDelegate(string id);

    public delegate void DnsClassDelegate(DnsResponse Response, IPAddress[] IPs);

    public struct DnsResponse
    {
        public string DNSServer;
        public string Host;
        public string Key;
        public double Min;
        public double Max;
        public double Avg;
    }

    public class classDNS
    {
        public string DNSServer;
        public string Host;
        public string Key;
        public int QPS;
        public int ReQueryDelay;
        private DnsResponse Response = new DnsResponse();
        private double Elapsed;
        public DnsClassDelegate DnsDelegate;
        // Public Event Complete(ByVal IPs As IPAddress(), ByVal Key As String)
        public void LookupHost()
        {
            // Console.WriteLine(vbCrLf & "DnsServer: " & DNSServer & ", Host: " & Host)
            Response.DNSServer = DNSServer;
            Response.Host = Host;
            Response.Key = Key;
            Response.Max = double.MinValue;
            Response.Min = double.MaxValue;
            try
            {
                var Options = new DnsClient.RequestOptions();
                Options.DnsServers = new IPAddress[] { IPAddress.Parse(DNSServer) };
                IPAddress[] IPs = null;
                var swatch = new Stopwatch();
                double TotalElapsed = 0d;
                int iCount;
                var loopTo = QPS;
                for (iCount = 1; iCount <= loopTo; iCount++)
                {
                    swatch.Start();
                    IPs = DnsClient.LookupHost(Host, DnsClient.IPVersion.IPv4, Options);
                    swatch.Stop();
                    Response.Min = Math.Min(swatch.ElapsedMilliseconds, Response.Min);
                    Response.Max = Math.Max(swatch.ElapsedMilliseconds, Response.Max);
                    TotalElapsed += swatch.ElapsedMilliseconds;
                    swatch.Reset();
                    Thread.Sleep(ReQueryDelay);
                }

                Response.Avg = Math.Round(TotalElapsed / QPS, 0);
                DnsDelegate(Response, IPs);
            }
            // RaiseEvent Complete(IPs, Key)
            // Console.WriteLine("DnsServer: " & DNSServer & ", Host: " & Host & " - Success - " & IPs(0).ToString)
            catch (Exception ex)
            {
                DnsDelegate(Response, null);
                // MsgBox(ex.Message)
                // Console.WriteLine("DnsServer: " & DNSServer & ", Host: " & Host & " - Failed - ")
            }
        }
    }
}