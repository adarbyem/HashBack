using System;
using System.Windows.Forms;

namespace HashBack
{
    public partial class InputDialog : Form
    {
        //Global Variables
        public string name;
        Form mainform = HashBack.Main.ActiveForm;

        public InputDialog()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            //Verify text was entered
            if (textBoxName.Text == "")
            {
                MessageBox.Show("That is an invalid name.");
            }
            else
            {
                name = textBoxName.Text;
                this.Visible = false;
                mainform.Enabled = true;
                mainform.Focus();
            }
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {
            try
            {
                mainform.Enabled = false;
            }
            catch
            {
            }
        }
    }
}
