using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Xdgk.Communi;

namespace Xdgk.Communi.UITest
{
    public partial class Form1 : Form
    {
        //private UITestLogic _test = new UITestLogic(new Communi.CommuniSoft());
        private UITestLogic _test = new UITestLogic();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            //NUnit.Core.NTrace.Info("info"+DateTime.Now );
            this.propertyGrid1.SelectedObject = this._test.Soft.CommuniPortManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            _test.Listen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this._test.Soft.TaskManager.Doit();
        }
    }
}
