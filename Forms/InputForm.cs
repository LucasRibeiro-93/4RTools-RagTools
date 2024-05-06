using System;
using System.Windows.Forms;
using _4RTools.Utils;
using _4RTools.Model;
using System.Windows.Input;

namespace _4RTools.Forms
{
    public partial class InputForm : Form
    {

        public InputForm(string label)
        {
            InitializeComponent();
            this.lblInput.Text = label;
        }

        public string inputValue
        {
            get { return this.txtInput.Text; }
        }

        private void btnCancelInput_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelInput_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
