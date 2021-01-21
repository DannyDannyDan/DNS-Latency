<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.Server = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Avg = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Min = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Max = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Result = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ThreadCountLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.WorkerProgressBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.WorkersElapsedLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.HostTextBox = New System.Windows.Forms.TextBox()
        Me.ThreadTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MaxWorkersUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.QueriesPerServerUpDown = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ReQueryDelayUpDown = New System.Windows.Forms.NumericUpDown()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.MaxWorkersUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QueriesPerServerUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReQueryDelayUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.AllowColumnReorder = True
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Server, Me.Avg, Me.Min, Me.Max, Me.Result})
        Me.ListView1.FullRowSelect = True
        Me.ListView1.HideSelection = False
        Me.ListView1.Location = New System.Drawing.Point(0, 75)
        Me.ListView1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(720, 342)
        Me.ListView1.TabIndex = 0
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'Server
        '
        Me.Server.Tag = "Server"
        Me.Server.Text = "Server"
        '
        'Avg
        '
        Me.Avg.Tag = "Avg"
        Me.Avg.Text = "Avg"
        '
        'Min
        '
        Me.Min.Tag = "Min"
        Me.Min.Text = "Min"
        '
        'Max
        '
        Me.Max.Tag = "Max"
        Me.Max.Text = "Max"
        '
        'Result
        '
        Me.Result.Tag = "Result"
        Me.Result.Text = "Result"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(632, 38)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 31)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Start"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ThreadCountLabel, Me.WorkerProgressBar, Me.WorkersElapsedLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 436)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(2, 0, 21, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(722, 22)
        Me.StatusStrip1.TabIndex = 3
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ThreadCountLabel
        '
        Me.ThreadCountLabel.Name = "ThreadCountLabel"
        Me.ThreadCountLabel.Size = New System.Drawing.Size(39, 17)
        Me.ThreadCountLabel.Text = "Ready"
        '
        'WorkerProgressBar
        '
        Me.WorkerProgressBar.Name = "WorkerProgressBar"
        Me.WorkerProgressBar.Size = New System.Drawing.Size(150, 25)
        Me.WorkerProgressBar.Visible = False
        '
        'WorkersElapsedLabel
        '
        Me.WorkersElapsedLabel.Name = "WorkersElapsedLabel"
        Me.WorkersElapsedLabel.Size = New System.Drawing.Size(0, 17)
        '
        'HostTextBox
        '
        Me.HostTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HostTextBox.Location = New System.Drawing.Point(87, 3)
        Me.HostTextBox.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.HostTextBox.Name = "HostTextBox"
        Me.HostTextBox.Size = New System.Drawing.Size(631, 26)
        Me.HostTextBox.TabIndex = 4
        Me.HostTextBox.Text = "www.lowes.com"
        '
        'ThreadTimer
        '
        '
        'MaxWorkersUpDown
        '
        Me.MaxWorkersUpDown.Location = New System.Drawing.Point(87, 42)
        Me.MaxWorkersUpDown.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaxWorkersUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.MaxWorkersUpDown.Name = "MaxWorkersUpDown"
        Me.MaxWorkersUpDown.Size = New System.Drawing.Size(62, 26)
        Me.MaxWorkersUpDown.TabIndex = 5
        Me.MaxWorkersUpDown.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 45)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Workers:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 9)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Host:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(158, 45)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Queries/Server:"
        '
        'QueriesPerServerUpDown
        '
        Me.QueriesPerServerUpDown.Location = New System.Drawing.Point(285, 38)
        Me.QueriesPerServerUpDown.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.QueriesPerServerUpDown.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.QueriesPerServerUpDown.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.QueriesPerServerUpDown.Name = "QueriesPerServerUpDown"
        Me.QueriesPerServerUpDown.Size = New System.Drawing.Size(62, 26)
        Me.QueriesPerServerUpDown.TabIndex = 5
        Me.QueriesPerServerUpDown.Value = New Decimal(New Integer() {4, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(356, 45)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Re-Query Delay:"
        '
        'ReQueryDelayUpDown
        '
        Me.ReQueryDelayUpDown.Increment = New Decimal(New Integer() {50, 0, 0, 0})
        Me.ReQueryDelayUpDown.Location = New System.Drawing.Point(488, 38)
        Me.ReQueryDelayUpDown.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ReQueryDelayUpDown.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.ReQueryDelayUpDown.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.ReQueryDelayUpDown.Name = "ReQueryDelayUpDown"
        Me.ReQueryDelayUpDown.Size = New System.Drawing.Size(62, 26)
        Me.ReQueryDelayUpDown.TabIndex = 5
        Me.ReQueryDelayUpDown.Value = New Decimal(New Integer() {250, 0, 0, 0})
        '
        'MainForm
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(722, 458)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ReQueryDelayUpDown)
        Me.Controls.Add(Me.QueriesPerServerUpDown)
        Me.Controls.Add(Me.MaxWorkersUpDown)
        Me.Controls.Add(Me.HostTextBox)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ListView1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimumSize = New System.Drawing.Size(644, 210)
        Me.Name = "MainForm"
        Me.Text = "DNS Query"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.MaxWorkersUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QueriesPerServerUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReQueryDelayUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents Server As System.Windows.Forms.ColumnHeader
    Friend WithEvents Min As System.Windows.Forms.ColumnHeader
    Friend WithEvents Max As System.Windows.Forms.ColumnHeader
    Friend WithEvents Avg As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ThreadCountLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Result As System.Windows.Forms.ColumnHeader
    Friend WithEvents HostTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ThreadTimer As System.Windows.Forms.Timer
    Friend WithEvents MaxWorkersUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents WorkerProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents WorkersElapsedLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents QueriesPerServerUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ReQueryDelayUpDown As System.Windows.Forms.NumericUpDown

End Class
