using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Communi
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            _test = new Test();
        }


        Test _test;
        private void button1_Click(object sender, EventArgs e)
        {
            frmPlug f = new frmPlug();
            f.ShowDialog();
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
