using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Communi;
using Xdgk.Communi.SPU;
using Xdgk.Communi.DPU;

namespace Communi
{
    public partial class frmPlug : Form
    {
        public frmPlug()
        {
            InitializeComponent();
        }

        private void frmPlug_Load(object sender, EventArgs e)
        {
            CommuniSoft soft = (CommuniApp.Default as CommuniApp ). CommuniSoft;
            //foreach (IHardwareFactory f in soft.HardwareFactoryManager.HardwareFactoryCollection)
            //{
            //    this.listBox1.Items.Add(f.ToString());
            //}

            //foreach (ISPU spu in soft.SPUManager.SPUCollection)
            //{
            //    this.listBox1.Items.Add(spu.ToString());
            //}
            //foreach (IDPU dpu in soft.DPUManager.DPUCollection)
            //{
            //    this.listBox1.Items.Add(dpu.ToString());
            //}
            //object obj = soft.HardwareManager;

        }
    }
}
