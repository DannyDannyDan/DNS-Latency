﻿using System.Diagnostics;
using System.Windows.Forms;

namespace DNS_Latency
{
    [Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    public partial class EasySortListView : ListView
    {

        // UserControl overrides dispose to clean up the component list.
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
            components = new System.ComponentModel.Container();
            // Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        }
    }
}