using System;
using System.Collections;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace DNS_Latency
{
    public partial class MainForm
    {
        public MainForm()
        {
            InitializeComponent();
            _ListView1.Name = "ListView1";
            _Button1.Name = "Button1";
        }
        // Private WithEvents MyDns As DNS_Latency.DNS
        private static int threadcount = 0;
        private ArrayList WorkPool;
        private Stopwatch WorkStopWatch = new Stopwatch();

        public struct WorkItem
        {
            public string Server;
            public string Host;
            public string Key;
        }

        private ListViewColumnSorter lvwColumnSorter;

        private void ThreadTimer_Tick(object sender, EventArgs e)
        {
            // Keep count of new threads per tick, only add a few per tick to keep UI responsive
            int NewThreads = 0;
            while (threadcount < MaxWorkersUpDown.Value & WorkPool.Count > 0 & NewThreads < 5)
            {
                WorkItem WorkItem = (WorkItem)WorkPool[0];
                var MyDns = new classDNS();
                MyDns.DNSServer = WorkItem.Server;
                MyDns.Host = WorkItem.Host;
                MyDns.Key = WorkItem.Key;
                MyDns.QPS = (int)QueriesPerServerUpDown.Value;
                MyDns.ReQueryDelay = (int)ReQueryDelayUpDown.Value;
                MyDns.DnsDelegate = DnsDone;

                // Remove workitem from pool
                WorkPool.RemoveAt(0);

                // track thread count

                Interlocked.Increment(ref threadcount);
                long localRead() { long arglocation = threadcount; var ret = Interlocked.Read(ref arglocation); return ret; }

                ThreadCountLabel.Text = "Threads: " + localRead().ToString();
                try
                {
                    // create thread for each query
                    var DnsThread = new Thread(MyDns.LookupHost);
                    DnsThread.IsBackground = true;
                    DnsThread.Priority = ThreadPriority.BelowNormal;
                    DnsThread.Start();
                    NewThreads += 1;
                }
                catch (Exception ex)
                {
                    Interaction.MsgBox(ex.Message);
                }
            }

            if (WorkPool.Count == 0 & threadcount == 0)
                ThreadTimer.Enabled = false;
            WorkersElapsedLabel.Text = "Elapsed: " + new DateTime().Add(WorkStopWatch.Elapsed).ToString("HH:mm:ss");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Start Worker stopwatch
            WorkStopWatch.Reset();
            WorkStopWatch.Start();


            // Lock buttons
            Controls_Lock();

            // Clear old results
            Clear_Results();

            // Reset progress bar
            WorkerProgressBar.Value = 0;
            WorkerProgressBar.Visible = true;
            WorkerProgressBar.Maximum = ListView1.Items.Count;

            // Populate worker pool
            WorkPool = new ArrayList();
            foreach (ListViewItem item in ListView1.Items)
            {
                if (item.Text.Trim(new char[]{' ','_'}) != "") {
                    var WorkItem = new WorkItem();
                    WorkItem.Server = item.Text;
                    WorkItem.Host = HostTextBox.Text;
                    WorkItem.Key = item.Text;
                    WorkPool.Add(WorkItem);
                }
            }

            // Start timer for worker pool
            ThreadTimer.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThreadTimer.Interval = 20;
            var Servers = ("192.168.0.1," + "192.168.1.1," + "192.168.50.1," + "68.105.28.11," + "68.105.29.11," + "68.105.28.12," + "208.67.222.222," + "208.67.220.220," + "24.116.0.201," + "24.116.0.202," + "8.8.8.8," + "8.8.4.4," + "4.2.2.2," + "151.164.1.7," + "151.164.1.8," + "151.164.11.201," + "151.164.14.201," + "151.164.67.201," + "151.164.8.201," + "151.202.0.84," + "199.45.32.43," + "204.60.203.179," + "205.171.3.65," + "206.13.28.12," + "206.13.29.12," + "206.13.30.12," + "206.13.31.12," + "206.141.192.60," + "206.141.193.55," + "64.81.79.2," + "66.73.20.40," + "67.36.128.26," + "68.94.156.1," + "68.94.157.1," + "").Split(',');

            // Column Names set in design time do not carry over to runtime. 
            // Set tag in design time to use as name in runtime so we can reference a column by name.
            foreach (ColumnHeader column in ListView1.Columns)
            {
                column.Name = column.Tag.ToString();
            }                
                

            // Add DNS Servers
            foreach (string Server in Servers)
            {
                var item = ListView1.Items.Add(Server, Server, "");
                for (int i = 1, loopTo = ListView1.Columns.Count; i <= loopTo; i++)
                    item.SubItems.Add("");
            }

            // Resize Server Column
            ListView1.AutoResizeColumn(ListView1.Columns["Server"].Index, ColumnHeaderAutoResizeStyle.ColumnContent);
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            ListView1.ListViewItemSorter = lvwColumnSorter;
        }

        public void DnsDone(DnsResponse Response, IPAddress[] IPs)
        {
            if (ListView1.InvokeRequired)
            {
                ListView1.Invoke(new DnsClassDelegate(UpdateResult), new object[] { Response, IPs });
            }
            else
            {
                UpdateResult(Response, IPs);
            }
        }

        public void UpdateResult(DnsResponse Response, IPAddress[] IPs)
        {
            try
            {
                if (IPs == null)
                {                                 
                    ListView1.Items[Response.Key].SubItems[ListView1.Columns["Result"].Index].Text = "-";
                    ListView1.Items[Response.Key].SubItems[ListView1.Columns["Min"].Index].Text = "-";
                    ListView1.Items[Response.Key].SubItems[ListView1.Columns["Max"].Index].Text = "-";
                    ListView1.Items[Response.Key].SubItems[ListView1.Columns["Avg"].Index].Text = "-";
                }
                else
                {
                    ListView1.Items[Response.Key].SubItems[ListView1.Columns["Result"].Index].Text = IpArrayToString(IPs);
                    ListView1.Items[Response.Key].SubItems[ListView1.Columns["Min"].Index].Text = Response.Min.ToString();
                    ListView1.Items[Response.Key].SubItems[ListView1.Columns["Max"].Index].Text = Response.Max.ToString();
                    ListView1.Items[Response.Key].SubItems[ListView1.Columns["Avg"].Index].Text = Response.Avg.ToString();
                }

                Interlocked.Decrement(ref threadcount);
                // Console.WriteLine("Threads: " & threadcount)
                ThreadCountLabel.Text = "Threads: " + threadcount;
                ListView1.AutoResizeColumn(ListView1.Columns["Result"].Index, ColumnHeaderAutoResizeStyle.ColumnContent);
                if (threadcount <= 0 & WorkPool.Count == 0)
                {
                    WorkComplete();
                    Controls_UnLock();
                    ThreadCountLabel.Text = "Ready";
                    if ((Response.Host ?? "") == (HostTextBox.Text ?? ""))
                        HostTextBox.SelectAll();
                    WorkerProgressBar.Visible = false;
                }

                UpdateProgressBar();
            }
            // Console.WriteLine("Pong..")
            catch (Exception ex)
            {
            }

        }

        private void UpdateProgressBar()
        {
            WorkerProgressBar.Value = WorkerProgressBar.Maximum - (WorkPool.Count + threadcount);
        }

        private string IpArrayToString(IPAddress[] IPs)
        {
            string Addresses = string.Empty;
            foreach (IPAddress ip in IPs)
            {
                if (Addresses.Length > 0)
                    Addresses += ", ";
                Addresses += ip.ToString();
            }

            return Addresses;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Controls_UnLock();
            GC.Collect();
            // Dim Key As String = "151.164.1.8"
            // Console.WriteLine("working on " & ListView1.Items(Key).Text)

        }

        private void WorkComplete()
        {
            WorkStopWatch.Stop();
        }

        private void Controls_Lock()
        {
            foreach (Control Control in Controls)
            {
                if (Control is Button & Control.Name != "Button2")
                    Control.Enabled = false;
                // If Control.Name.ToLower <> "listview1" And Control.Name.ToLower <> "button2" Then Control.Enabled = False
            }

            Refresh();
        }

        private void Controls_UnLock()
        {
            foreach (Control Control in Controls)
                Control.Enabled = true;
            Refresh();
        }

        private void Clear_Results()
        {
            foreach (ListViewItem item in ListView1.Items)
            {
                for (int i = 2, loopTo = item.SubItems.Count; i <= loopTo; i++)
                    item.SubItems[i - 1].Text = "";
            }

            ListView1.Refresh();
        }

        private void ListView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            Debug.Print("Column Clicked: " + e.Column);
            // Determine if the clicked column is already the column that is 
            // being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            ListView1.Sort();
        }

        private void ListView1_ColumnReordered(object sender, ColumnReorderedEventArgs e)
        {
            Debug.Print("Column Reordered");
        }

        private void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        public class ListViewColumnSorter : IComparer
        {
            private int ColumnToSort;
            private SortOrder OrderOfSort;
            private CaseInsensitiveComparer ObjectCompare;

            public ListViewColumnSorter()
            {
                // Initialize the column to '0'.
                ColumnToSort = 0;

                // Initialize the sort order to 'none'.
                OrderOfSort = SortOrder.None;

                // Initialize the CaseInsensitiveComparer object.
                ObjectCompare = new CaseInsensitiveComparer();
            }

            public int Compare(object x, object y)
            {
                int compareResult;
                ListViewItem listviewX;
                ListViewItem listviewY;

                // Cast the objects to be compared to ListViewItem objects.
                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;

                // Compare the two items.
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

                // Calculate the correct return value based on the object 
                // comparison.
                if (OrderOfSort == SortOrder.Ascending)
                {
                    // Ascending sort is selected, return typical result of 
                    // compare operation.
                    return compareResult;
                }
                else if (OrderOfSort == SortOrder.Descending)
                {
                    // Descending sort is selected, return negative result of 
                    // compare operation.
                    return -compareResult;
                }
                else
                {
                    // Return '0' to indicate that they are equal.
                    return 0;
                }
            }

            public int SortColumn
            {
                set
                {
                    ColumnToSort = value;
                }

                get
                {
                    return ColumnToSort;
                }
            }

            public SortOrder Order
            {
                set
                {
                    OrderOfSort = value;
                }

                get
                {
                    return OrderOfSort;
                }
            }
        }
    }
}