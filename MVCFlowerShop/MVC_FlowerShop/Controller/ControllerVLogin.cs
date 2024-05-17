using FlowerShopMVVM.Model.Repository;
using MVC_FlowerShop.Model.Language;
using MVC_FlowerShop.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVC_FlowerShop.Controller
{
    public class ControllerVLogin
    {
        private VLogin vLogin;
        private UserRepository userRepository;
        private LangHelper lang;

        public ControllerVLogin(int index)
        {
            this.vLogin = new VLogin(index);
            this.userRepository = new UserRepository();
            this.lang = new LangHelper();
            this.lang.Add(this.vLogin);

            this.eventsManagement();
        }

        public VLogin GetView()
        {
            this.vLogin.Show();
            return this.vLogin;
        }

        private void eventsManagement()
        {
            this.vLogin.FormClosed += new FormClosedEventHandler(exitApplication);
            this.vLogin.GetLoginButton().Click += new EventHandler(login);
            this.vLogin.GetLanguageBox().SelectedIndexChanged += new EventHandler(changeLanguage);
        }

        private void exitApplication(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void changeLanguage(object sender, EventArgs e)
        {
            if (this.vLogin.GetLanguageBox().SelectedIndex == 0)
            {
                this.lang.ChangeLanguage("en");
            }
            else if (this.vLogin.GetLanguageBox().SelectedIndex == 1)
            {
                this.lang.ChangeLanguage("fr");
            }
            else if (this.vLogin.GetLanguageBox().SelectedIndex == 2)
            {
                this.lang.ChangeLanguage("it");
            }
        }

        private void login(object sender, EventArgs e)
        {
            try
            {
                string username = this.vLogin.GetUsername().Text;
                string password = this.vLogin.GetPassword().Text;

                if (username.Length > 0 && password.Length > 0)
                {
                    bool result = this.userRepository.LoginUser(username, password);
                    if (result == true)
                    {
                        string role = userRepository.GetRole(username, password);
                        if (role.Equals("Employee"))
                        {
                            this.vLogin.Hide();
                            ControllerVEmployee em = new ControllerVEmployee(username, this.vLogin.GetLanguageBox().SelectedIndex);
                            em.GetView();
                        }
                        else if (role.Equals("Manager"))
                        {
                            this.vLogin.Hide();
                            ControllerVManager ma = new ControllerVManager(this.vLogin.GetLanguageBox().SelectedIndex);
                            ma.GetView();
                        }
                        else if (role.Equals("Administrator"))
                        {
                            this.vLogin.Hide();
                            ControllerVAdministrator ad = new ControllerVAdministrator(this.vLogin.GetLanguageBox().SelectedIndex);
                            ad.GetView();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
