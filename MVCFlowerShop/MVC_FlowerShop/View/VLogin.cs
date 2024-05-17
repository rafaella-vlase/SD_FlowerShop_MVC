using MVC_FlowerShop.Model;
using MVC_FlowerShop.Model.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC_FlowerShop.View
{
    public partial class VLogin : Form, Observable
    {
        public VLogin(int index)
        {
            InitializeComponent();
            this.textBoxUsername.Text = string.Empty;
            this.textBoxPassword.Text = string.Empty;
            this.comboBoxLanguage.SelectedIndex = index;
        }

        public ComboBox GetLanguageBox()
        {
            return this.comboBoxLanguage;
        }

        public TextBox GetUsername()
        {
            return this.textBoxUsername;
        }

        public TextBox GetPassword()
        {
            return this.textBoxPassword;
        }

        public Button GetLoginButton()
        {
            return this.buttonLogin;
        }

        public void Update(Subject obs)
        {
            LangHelper lang = (LangHelper)obs;

            this.labelFlowerShop.Text = lang.GetString("labelFlowerName");
            this.labelUsername.Text = lang.GetString("labelUsername");
            this.labelPassword.Text = lang.GetString("labelPassword");
            this.labelSelectLanguage.Text = lang.GetString("labelSelectLanguage");
        }
    }
}
