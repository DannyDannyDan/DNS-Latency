using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;

namespace DNS_Latency
{
    [DesignerGenerated()]
    public partial class MainForm : Form
    {

        // Form overrides dispose to clean up the component list.
        [DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components is object)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this._ListView1 = new System.Windows.Forms.ListView();
            this.Server = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Avg = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Min = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Max = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this._Button1 = new System.Windows.Forms.Button();
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ThreadCountLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.WorkerProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.WorkersElapsedLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.HostTextBox = new System.Windows.Forms.TextBox();
            this._ThreadTimer = new System.Windows.Forms.Timer(this.components);
            this.MaxWorkersUpDown = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.QueriesPerServerUpDown = new System.Windows.Forms.NumericUpDown();
            this.Label4 = new System.Windows.Forms.Label();
            this.ReQueryDelayUpDown = new System.Windows.Forms.NumericUpDown();
            this.StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxWorkersUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueriesPerServerUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReQueryDelayUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // _ListView1
            // 
            this._ListView1.AllowColumnReorder = true;
            this._ListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._ListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Server,
            this.Avg,
            this.Min,
            this.Max,
            this.Result});
            this._ListView1.FullRowSelect = true;
            this._ListView1.HideSelection = false;
            this._ListView1.Location = new System.Drawing.Point(0, 75);
            this._ListView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._ListView1.Name = "_ListView1";
            this._ListView1.Size = new System.Drawing.Size(720, 342);
            this._ListView1.TabIndex = 0;
            this._ListView1.UseCompatibleStateImageBehavior = false;
            this._ListView1.View = System.Windows.Forms.View.Details;
            this._ListView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ListView1_ColumnClick);
            this._ListView1.ColumnReordered += new System.Windows.Forms.ColumnReorderedEventHandler(this.ListView1_ColumnReordered);
            this._ListView1.SelectedIndexChanged += new System.EventHandler(this.ListView1_SelectedIndexChanged);
            // 
            // Server
            // 
            this.Server.Tag = "Server";
            this.Server.Text = "Server";
            // 
            // Avg
            // 
            this.Avg.Tag = "Avg";
            this.Avg.Text = "Avg";
            // 
            // Min
            // 
            this.Min.Tag = "Min";
            this.Min.Text = "Min";
            // 
            // Max
            // 
            this.Max.Tag = "Max";
            this.Max.Text = "Max";
            // 
            // Result
            // 
            this.Result.Tag = "Result";
            this.Result.Text = "Result";
            // 
            // _Button1
            // 
            this._Button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._Button1.Location = new System.Drawing.Point(632, 38);
            this._Button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this._Button1.Name = "_Button1";
            this._Button1.Size = new System.Drawing.Size(80, 31);
            this._Button1.TabIndex = 1;
            this._Button1.Text = "Start";
            this._Button1.UseVisualStyleBackColor = true;
            this._Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ThreadCountLabel,
            this.WorkerProgressBar,
            this.WorkersElapsedLabel});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 436);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.StatusStrip1.Size = new System.Drawing.Size(722, 22);
            this.StatusStrip1.TabIndex = 3;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // ThreadCountLabel
            // 
            this.ThreadCountLabel.Name = "ThreadCountLabel";
            this.ThreadCountLabel.Size = new System.Drawing.Size(39, 17);
            this.ThreadCountLabel.Text = "Ready";
            // 
            // WorkerProgressBar
            // 
            this.WorkerProgressBar.Name = "WorkerProgressBar";
            this.WorkerProgressBar.Size = new System.Drawing.Size(150, 25);
            this.WorkerProgressBar.Visible = false;
            // 
            // WorkersElapsedLabel
            // 
            this.WorkersElapsedLabel.Name = "WorkersElapsedLabel";
            this.WorkersElapsedLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // HostTextBox
            // 
            this.HostTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HostTextBox.Location = new System.Drawing.Point(87, 3);
            this.HostTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.HostTextBox.Name = "HostTextBox";
            this.HostTextBox.Size = new System.Drawing.Size(631, 26);
            this.HostTextBox.TabIndex = 4;
            this.HostTextBox.Text = "www.lowes.com";
            // 
            // _ThreadTimer
            // 
            this._ThreadTimer.Tick += new System.EventHandler(this.ThreadTimer_Tick);
            // 
            // MaxWorkersUpDown
            // 
            this.MaxWorkersUpDown.Location = new System.Drawing.Point(87, 42);
            this.MaxWorkersUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaxWorkersUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxWorkersUpDown.Name = "MaxWorkersUpDown";
            this.MaxWorkersUpDown.Size = new System.Drawing.Size(62, 26);
            this.MaxWorkersUpDown.TabIndex = 5;
            this.MaxWorkersUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(8, 45);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(72, 20);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Workers:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(8, 9);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(47, 20);
            this.Label2.TabIndex = 7;
            this.Label2.Text = "Host:";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(158, 45);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(118, 20);
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Queries/Server:";
            // 
            // QueriesPerServerUpDown
            // 
            this.QueriesPerServerUpDown.Location = new System.Drawing.Point(285, 38);
            this.QueriesPerServerUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.QueriesPerServerUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.QueriesPerServerUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.QueriesPerServerUpDown.Name = "QueriesPerServerUpDown";
            this.QueriesPerServerUpDown.Size = new System.Drawing.Size(62, 26);
            this.QueriesPerServerUpDown.TabIndex = 5;
            this.QueriesPerServerUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(356, 45);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(125, 20);
            this.Label4.TabIndex = 9;
            this.Label4.Text = "Re-Query Delay:";
            // 
            // ReQueryDelayUpDown
            // 
            this.ReQueryDelayUpDown.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.ReQueryDelayUpDown.Location = new System.Drawing.Point(488, 38);
            this.ReQueryDelayUpDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ReQueryDelayUpDown.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.ReQueryDelayUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.ReQueryDelayUpDown.Name = "ReQueryDelayUpDown";
            this.ReQueryDelayUpDown.Size = new System.Drawing.Size(62, 26);
            this.ReQueryDelayUpDown.TabIndex = 5;
            this.ReQueryDelayUpDown.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // MainForm
            // 
            this.AcceptButton = this._Button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 458);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.ReQueryDelayUpDown);
            this.Controls.Add(this.QueriesPerServerUpDown);
            this.Controls.Add(this.MaxWorkersUpDown);
            this.Controls.Add(this.HostTextBox);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this._Button1);
            this.Controls.Add(this._ListView1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(644, 210);
            this.Name = "MainForm";
            this.Text = "DNS Query";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxWorkersUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueriesPerServerUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReQueryDelayUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private ListView _ListView1;

        internal ListView ListView1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ListView1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ListView1 != null)
                {
                    _ListView1.ColumnClick -= ListView1_ColumnClick;
                    _ListView1.ColumnReordered -= ListView1_ColumnReordered;
                    _ListView1.SelectedIndexChanged -= ListView1_SelectedIndexChanged;
                }

                _ListView1 = value;
                if (_ListView1 != null)
                {
                    _ListView1.ColumnClick += ListView1_ColumnClick;
                    _ListView1.ColumnReordered += ListView1_ColumnReordered;
                    _ListView1.SelectedIndexChanged += ListView1_SelectedIndexChanged;
                }
            }
        }

        internal ColumnHeader Server;
        internal ColumnHeader Min;
        internal ColumnHeader Max;
        internal ColumnHeader Avg;
        private Button _Button1;

        internal Button Button1
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _Button1;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_Button1 != null)
                {
                    _Button1.Click -= Button1_Click;
                }

                _Button1 = value;
                if (_Button1 != null)
                {
                    _Button1.Click += Button1_Click;
                }
            }
        }

        internal StatusStrip StatusStrip1;
        internal ToolStripStatusLabel ThreadCountLabel;
        internal ColumnHeader Result;
        internal TextBox HostTextBox;
        private Timer _ThreadTimer;

        internal Timer ThreadTimer
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _ThreadTimer;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_ThreadTimer != null)
                {
                    _ThreadTimer.Tick -= ThreadTimer_Tick;
                }

                _ThreadTimer = value;
                if (_ThreadTimer != null)
                {
                    _ThreadTimer.Tick += ThreadTimer_Tick;
                }
            }
        }

        internal NumericUpDown MaxWorkersUpDown;
        internal Label Label1;
        internal Label Label2;
        internal ToolStripProgressBar WorkerProgressBar;
        internal ToolStripStatusLabel WorkersElapsedLabel;
        internal Label Label3;
        internal NumericUpDown QueriesPerServerUpDown;
        internal Label Label4;
        internal NumericUpDown ReQueryDelayUpDown;
    }
}