Imports System.Net
Imports System.Threading
Public Class MainForm
    'Private WithEvents MyDns As DNS_Latency.DNS
    Shared threadcount As Integer = 0
    Dim WorkPool As ArrayList
    Dim WorkStopWatch As New Stopwatch
    Public Structure WorkItem
        Dim Server As String
        Dim Host As String
        Dim Key As String
    End Structure
    Private lvwColumnSorter As ListViewColumnSorter
    Private Sub ThreadTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ThreadTimer.Tick
        ' Keep count of new threads per tick, only add a few per tick to keep UI responsive
        Dim NewThreads As Integer = 0

        While threadcount < MaxWorkersUpDown.Value And WorkPool.Count > 0 And NewThreads < 5
            Dim WorkItem As WorkItem = WorkPool.Item(0)
            Dim MyDns As DNS_Latency.classDNS = New DNS_Latency.classDNS
            MyDns.DNSServer = WorkItem.Server
            MyDns.Host = WorkItem.Host
            MyDns.Key = WorkItem.Key
            MyDns.QPS = QueriesPerServerUpDown.Value
            MyDns.ReQueryDelay = ReQueryDelayUpDown.Value
            MyDns.DnsDelegate = AddressOf DnsDone

            ' Remove workitem from pool
            WorkPool.RemoveAt(0)

            'track thread count

            Interlocked.Increment(threadcount)
            ThreadCountLabel.Text = "Threads: " & Interlocked.Read(threadcount).ToString
            Try
                'create thread for each query
                Dim DnsThread As New Thread(AddressOf MyDns.LookupHost)
                DnsThread.IsBackground = True
                DnsThread.Priority = ThreadPriority.BelowNormal
                DnsThread.Start()
                NewThreads += 1
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End While
        If WorkPool.Count = 0 And threadcount = 0 Then ThreadTimer.Enabled = False
        WorkersElapsedLabel.Text = "Elapsed: " & New Date().Add(WorkStopWatch.Elapsed).ToString("HH:mm:ss")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Start Worker stopwatch
        WorkStopWatch.Reset()
        WorkStopWatch.Start()


        ' Lock buttons
        Controls_Lock()

        ' Clear old results
        Clear_Results()

        ' Reset progress bar
        With WorkerProgressBar
            .Value = 0
            .Visible = True
            .Maximum = ListView1.Items.Count
        End With

        ' Populate worker pool
        WorkPool = New ArrayList
        For Each item As ListViewItem In ListView1.Items
            Dim WorkItem As New WorkItem
            WorkItem.Server = item.Text
            WorkItem.Host = HostTextBox.Text
            WorkItem.Key = item.Text
            WorkPool.Add(WorkItem)
        Next

        ' Start timer for worker pool
        ThreadTimer.Enabled = True

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ThreadTimer.Interval = 20
        Dim Servers As String() = (
                                    "192.168.0.1," &
                                    "192.168.1.1," &
                                    "192.168.50.1," &
                                    "68.105.28.11," &
                                    "68.105.29.11," &
                                    "68.105.28.12," &
                                    "208.67.222.222," &
                                    "208.67.220.220," &
                                    "24.116.0.201," &
                                    "24.116.0.202," &
                                    "8.8.8.8," &
                                    "8.8.4.4," &
                                    "4.2.2.2," &
                                    "151.164.1.7," &
                                    "151.164.1.8," &
                                    "151.164.11.201," &
                                    "151.164.14.201," &
                                    "151.164.67.201," &
                                    "151.164.8.201," &
                                    "151.202.0.84," &
                                    "199.45.32.43," &
                                    "204.60.203.179," &
                                    "205.171.3.65," &
                                    "206.13.28.12," &
                                    "206.13.29.12," &
                                    "206.13.30.12," &
                                    "206.13.31.12," &
                                    "206.141.192.60," &
                                    "206.141.193.55," &
                                    "64.81.79.2," &
                                    "66.73.20.40," &
                                    "67.36.128.26," &
                                    "68.94.156.1," &
                                    "68.94.157.1," &
                                    "").Split(",")

        ' Column Names set in design time do not carry over to runtime. 
        ' Set tag in design time to use as name in runtime so we can reference a column by name.
        For Each column In ListView1.Columns
            column.name = column.tag
        Next

        ' Add DNS Servers
        For Each Server As String In Servers
            Dim item As ListViewItem = ListView1.Items.Add(Server, Server, "")
            For i = 1 To ListView1.Columns.Count
                item.SubItems.Add("")
            Next
        Next

        ' Resize Server Column
        ListView1.AutoResizeColumn(ListView1.Columns.Item("Server").Index, ColumnHeaderAutoResizeStyle.ColumnContent)
        ' Create an instance of a ListView column sorter and assign it 
        ' to the ListView control.
        lvwColumnSorter = New ListViewColumnSorter()
        Me.ListView1.ListViewItemSorter = lvwColumnSorter
    End Sub

    Sub DnsDone(ByVal Response As DnsResponse, ByVal IPs As IPAddress())
        If ListView1.InvokeRequired Then
            ListView1.Invoke(New DnsClassDelegate(AddressOf UpdateResult), New Object() {Response, IPs})
        Else
            UpdateResult(Response, IPs)
        End If
    End Sub

    Sub UpdateResult(ByVal Response As DnsResponse, ByVal IPs As IPAddress())
        Try
            'Console.WriteLine("Ping.." & Response.Key)
            'Console.WriteLine("listview1 has " & ListView1.Items.Count & "items")
            'Console.WriteLine("working on " & ListView1.Items(Response.Key).Text)
            ListView1.Items(Response.Key).SubItems(ListView1.Columns.Item("Result").Index).Text = IpArrayToString(IPs)
            ListView1.Items(Response.Key).SubItems(ListView1.Columns.Item("Min").Index).Text = Response.Min
            ListView1.Items(Response.Key).SubItems(ListView1.Columns.Item("Max").Index).Text = Response.Max
            ListView1.Items(Response.Key).SubItems(ListView1.Columns.Item("Avg").Index).Text = Response.Avg


            'Console.WriteLine("Pong..")
        Catch ex As Exception

        End Try
        Interlocked.Decrement(threadcount)
        'Console.WriteLine("Threads: " & threadcount)
        ThreadCountLabel.Text = "Threads: " & threadcount
        ListView1.AutoResizeColumn(ListView1.Columns.Item("Result").Index, ColumnHeaderAutoResizeStyle.ColumnContent)

        If threadcount <= 0 And WorkPool.Count = 0 Then
            WorkComplete()
            Controls_UnLock()
            ThreadCountLabel.Text = "Ready"
            If Response.Host = HostTextBox.Text Then HostTextBox.SelectAll()
            WorkerProgressBar.Visible = False
        End If
        UpdateProgressBar()
    End Sub
    Private Sub UpdateProgressBar()
        WorkerProgressBar.Value = WorkerProgressBar.Maximum - (WorkPool.Count + threadcount)
    End Sub
    Private Function IpArrayToString(ByVal IPs As IPAddress()) As String
        Dim Addresses As String = String.Empty
        For Each ip As IPAddress In IPs
            If Addresses.Length > 0 Then Addresses += ", "
            Addresses += ip.ToString
        Next
        Return Addresses
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Controls_UnLock()
        GC.Collect()
        'Dim Key As String = "151.164.1.8"
        'Console.WriteLine("working on " & ListView1.Items(Key).Text)

    End Sub
    Private Sub WorkComplete()
        WorkStopWatch.Stop()

    End Sub
    Private Sub Controls_Lock()
        For Each Control As Control In Me.Controls
            If TypeOf Control Is Button And Control.Name <> "Button2" Then Control.Enabled = False
            'If Control.Name.ToLower <> "listview1" And Control.Name.ToLower <> "button2" Then Control.Enabled = False
        Next
        Me.Refresh()
    End Sub
    Private Sub Controls_UnLock()
        For Each Control As Control In Me.Controls
            Control.Enabled = True
        Next
        Me.Refresh()
    End Sub
    Private Sub Clear_Results()
        For Each item As ListViewItem In ListView1.Items
            For i As Integer = 2 To item.SubItems.Count
                item.SubItems(i - 1).Text = ""
            Next
        Next
        ListView1.Refresh()
    End Sub

    Private Sub ListView1_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles ListView1.ColumnClick
        Debug.Print("Column Clicked: " & e.Column)
        ' Determine if the clicked column is already the column that is 
        ' being sorted.
        If (e.Column = lvwColumnSorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            lvwColumnSorter.SortColumn = e.Column
            lvwColumnSorter.Order = SortOrder.Ascending
        End If

        ' Perform the sort with these new sort options.
        Me.ListView1.Sort()

    End Sub

    Private Sub ListView1_ColumnReordered(sender As Object, e As System.Windows.Forms.ColumnReorderedEventArgs) Handles ListView1.ColumnReordered
        Debug.Print("Column Reordered")
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
Public Class ListViewColumnSorter
        Implements System.Collections.IComparer

        Private ColumnToSort As Integer
        Private OrderOfSort As SortOrder
        Private ObjectCompare As CaseInsensitiveComparer

        Public Sub New()
            ' Initialize the column to '0'.
            ColumnToSort = 0

            ' Initialize the sort order to 'none'.
            OrderOfSort = SortOrder.None

            ' Initialize the CaseInsensitiveComparer object.
            ObjectCompare = New CaseInsensitiveComparer()
        End Sub

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
            Dim compareResult As Integer
            Dim listviewX As ListViewItem
            Dim listviewY As ListViewItem

            ' Cast the objects to be compared to ListViewItem objects.
            listviewX = CType(x, ListViewItem)
            listviewY = CType(y, ListViewItem)

            ' Compare the two items.
            compareResult = ObjectCompare.Compare(listviewX.SubItems(ColumnToSort).Text, listviewY.SubItems(ColumnToSort).Text)

            ' Calculate the correct return value based on the object 
            ' comparison.
            If (OrderOfSort = SortOrder.Ascending) Then
                ' Ascending sort is selected, return typical result of 
                ' compare operation.
                Return compareResult
            ElseIf (OrderOfSort = SortOrder.Descending) Then
                ' Descending sort is selected, return negative result of 
                ' compare operation.
                Return (-compareResult)
            Else
                ' Return '0' to indicate that they are equal.
                Return 0
            End If
        End Function

        Public Property SortColumn() As Integer
            Set(ByVal Value As Integer)
                ColumnToSort = Value
            End Set

            Get
                Return ColumnToSort
            End Get
        End Property

        Public Property Order() As SortOrder
            Set(ByVal Value As SortOrder)
                OrderOfSort = Value
            End Set

            Get
                Return OrderOfSort
            End Get
        End Property
    End Class
End Class
