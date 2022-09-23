using ABISoft.TelephoneBookAppAdoNet.Business;
using ABISoft.TelephoneBookAppAdoNet.Entities;
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
    public partial class MainForm : Form
    {
        BusinessLogicLayer bll;
        Guid selectedUserId;
        public MainForm()
        {
            InitializeComponent();
            bll = new BusinessLogicLayer();
        }

        #region Events
        private void button_AddUser_Click(object sender, EventArgs e)
        {
            int result = bll.AddTelephoneBookUser(Guid.NewGuid(), textBoxAdd_Firstname.Text, textBoxAdd_Lastname.Text, textBoxAdd_Phone1.Text,
                textBoxAdd_Phone2.Text, textBoxAdd_Phone3.Text, textBoxAdd_Address.Text, textBoxAdd_Email.Text,
                textBoxAdd_WebsiteUrl.Text, textBoxAdd_Description.Text);
            if(result == 1)
            {
                MessageBox.Show("User was added successfully!");
                FillTelephoneBookListBox();
                ClearUserAddTextBoxes();
            }
            else if (result == -100)
            {
                MessageBox.Show("Missing User Parameter Error!");
            }
            else if (result == 0)
            {
                MessageBox.Show("User was not added!");
            }
        }
        private void button_DeleteUser_Click(object sender, EventArgs e)
        {
            int result = bll.DeleteTelephoneBookUser(selectedUserId);
            if(result == 1)
            {
                MessageBox.Show("User was deleted successfully!");
                FillTelephoneBookListBox();
                ClearUserUpdateDeleteTextBoxes();
            }
            else if(result == -100)
                MessageBox.Show("Missing parameters error!");
            else if (result == 0)
                MessageBox.Show("A suitable user was not found!");
        }
        private void button_UpdateUser_Click(object sender, EventArgs e)
        {
            int result = bll.UpdateTelephoneBookUser(selectedUserId, textBoxUD_Firstname.Text, textBoxUD_Lastname.Text,
                textBoxUD_Phone1.Text, textBoxUD_Phone2.Text, textBoxUD_Phone3.Text, textBoxUD_Address.Text,
                textBoxUD_Email.Text, textBoxUD_Website.Text, textBoxUD_Description.Text);
            if(result == 1)
            {
                MessageBox.Show("User was updated successfully!");
                FillTelephoneBookListBox();
                ClearUserUpdateDeleteTextBoxes();
            }
            else if (result == -100)
                MessageBox.Show("Missing parameters error!");
            else if (result == 0)
                MessageBox.Show("A suitable user was not found!");
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            FillTelephoneBookListBox();
        }
        private void listBox_TelephoneBookUsers_DoubleClick(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)sender; 
            TelephoneBookUser selectedUser = (TelephoneBookUser)listBox.SelectedItem;
            selectedUserId = selectedUser.Id;
            SetUserUpdateDeleteTextBoxes(selectedUser.Firstname, selectedUser.Lastname, selectedUser.PhoneNumber1,
                selectedUser.PhoneNumber2, selectedUser.PhoneNumber3, selectedUser.Email, selectedUser.WebSiteUrl,
                selectedUser.Address, selectedUser.Description);
        }
        #endregion

        #region Normal Methods
        private void ClearUserAddTextBoxes()
        {
            textBoxAdd_Firstname.Text = "";
            textBoxAdd_Lastname.Text = "";
            textBoxAdd_Phone1.Text = "";
            textBoxAdd_Phone2.Text = "";
            textBoxAdd_Phone3.Text = "";
            textBoxAdd_Address.Text = "";
            textBoxAdd_Email.Text = "";
            textBoxAdd_WebsiteUrl.Text = "";
            textBoxAdd_Description.Text = "";
        }
        private void ClearUserUpdateDeleteTextBoxes()
        {
            textBoxUD_Firstname.Text = "";
            textBoxUD_Lastname.Text = "";
            textBoxUD_Phone1.Text = "";
            textBoxUD_Phone2.Text = "";
            textBoxUD_Phone3.Text = "";
            textBoxUD_Address.Text = "";
            textBoxUD_Email.Text = "";
            textBoxUD_Website.Text = "";
            textBoxUD_Description.Text = "";
        }
        private void SetUserUpdateDeleteTextBoxes(string firstname, string lastname, string phone1, string phone2,
            string phone3, string email, string websiteURL, string address, string description)
        {
            textBoxUD_Firstname.Text = firstname;
            textBoxUD_Lastname.Text = lastname;
            textBoxUD_Phone1.Text = phone1;
            textBoxUD_Phone2.Text = phone2;
            textBoxUD_Phone3.Text = phone3;
            textBoxUD_Address.Text = email;
            textBoxUD_Email.Text = websiteURL;
            textBoxUD_Website.Text = address;
            textBoxUD_Description.Text = description;
        }
        private void FillTelephoneBookListBox()
        {
            List<TelephoneBookUser> telephoneBookUsers = new List<TelephoneBookUser>();
            telephoneBookUsers = bll.GetTelephoneBookUsers();
            if (telephoneBookUsers != null && telephoneBookUsers.Count > 0)
                listBox_TelephoneBookUsers.DataSource = telephoneBookUsers;
        }

        #endregion

      
    }
}
