using ABISoft.TelephoneBookAppAdoNet.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABISoft.TelephoneBookAppAdoNet
{
    public partial class LoginForm : Form
    {
        BusinessLogicLayer bll;
        public LoginForm()
        {
            InitializeComponent();
            bll = new BusinessLogicLayer();
        }

        private void button_Enter_Click(object sender, EventArgs e)
        {
            int result = bll.UserControl(textBox_Username.Text, textBox_Password.Text);
            if(result > 0)
            {
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else if(result == -100)
            {
                MessageBox.Show("Missing Parameter Error Code", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(result == 0)
            {
                MessageBox.Show("There is no any suitable user");
            }
        }
    }
}
