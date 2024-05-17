using FlowerShopMVVM.Model.Repository;
using MVC_FlowerShop.Model.Language;
using MVC_FlowerShop.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using FlowerShopMVVM.Model;
using System.Data;

namespace MVC_FlowerShop.Controller
{
    public class ControllerVAdministrator
    {
        private VAdministrator vAdministrator;
        private VLogin vLogin;
        private UserRepository userRepository;
        private Repository repository;
        private LangHelper lang;
        private int index;

        public ControllerVAdministrator(int index)
        {
            //LangHelper.ChangeLanguage(language);
            this.vAdministrator = new VAdministrator(index);
            this.vLogin = new VLogin(index);
            this.userRepository = new UserRepository();
            this.repository = Repository.GetInstance();
            this.index = index;

            this.lang = new LangHelper();
            this.lang.Add(this.vAdministrator);

            this.eventsManagement();
        }
        public VAdministrator GetView()
        {
            this.vAdministrator.Show();
            return this.vAdministrator;
        }

        private void eventsManagement()
        {
            this.vAdministrator.FormClosed += new FormClosedEventHandler(exitApplication);
            this.vAdministrator.GetAddButton().Click += new EventHandler(addUser);
            this.vAdministrator.GetUpdateButton().Click += new EventHandler(updateUser);
            this.vAdministrator.GetDeleteButton().Click += new EventHandler(deleteUser);
            this.vAdministrator.GetSearchButton().Click += new EventHandler(searchUser);
            this.vAdministrator.GetViewAllButton().Click += new EventHandler(viewAllUsers);
            this.vAdministrator.GetLogoutButton().Click += new EventHandler(logout);
            this.vAdministrator.GetUserTable().RowStateChanged += new DataGridViewRowStateChangedEventHandler(setUserControls);
            this.vAdministrator.GetLanguageBox().SelectedIndexChanged += new EventHandler(changeLanguage);
        }

        private void exitApplication(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void changeLanguage(object sender, EventArgs e)
        {
            if (this.vAdministrator.GetLanguageBox().SelectedIndex == 0)
            {
                this.lang.ChangeLanguage("en");
            }
            else if (this.vAdministrator.GetLanguageBox().SelectedIndex == 1)
            {
                this.lang.ChangeLanguage("fr");
            }
            else if (this.vAdministrator.GetLanguageBox().SelectedIndex == 2)
            {
                this.lang.ChangeLanguage("it");
            }
        }

        private void addUser(object sender, EventArgs e)
        {
            try
            {
                User user = this.validInformation();

                if (user != null)
                {
                    bool result = this.userRepository.AddUser(user);
                    if (result == true)
                    {
                        MessageBox.Show(lang.GetString("messageBoxAddSuccess"));
                        this.resetGUIControls();

                        if (this.vAdministrator.GetUserTable() == null)
                            MessageBox.Show(lang.GetString("messageBoxNoData"));

                    }
                    else MessageBox.Show(lang.GetString("messageBoxAddFail"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void updateUser(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToBoolean(this.vAdministrator.GetUserID().Value))
                {
                    User user = this.validInformation();
                    if (user != null)
                    {
                        bool result = this.userRepository.UpdateUser(user);
                        if (result)
                        {
                            MessageBox.Show(lang.GetString("messageBoxUpdateSuccess"));
                            this.resetGUIControls();
                        }
                        else MessageBox.Show(lang.GetString("messageBoxUpdateFail"));
                    }
                }
                else MessageBox.Show(lang.GetString("messageBoxNoUserSelected"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void deleteUser(object sender, EventArgs e)
        {
            try
            {
                User user = this.validInformation();

                if (user != null)
                {
                    bool result = this.userRepository.DeleteUser((uint)this.vAdministrator.GetUserID().Value);
                    if (result == true)
                    {
                        MessageBox.Show(lang.GetString("messageBoxDeleteSuccess"));
                        this.resetGUIControls();

                        if (this.vAdministrator.GetUserTable() == null)
                        {
                            MessageBox.Show(lang.GetString("messageBoxNoData"));
                        }
                    }
                    else MessageBox.Show(lang.GetString("messageBoxDeleteFail"));
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void searchUser(object sender, EventArgs e)
        {
            try
            {
                if (this.vAdministrator.GetUserTable() != null)
                    this.vAdministrator.GetUserTable().DataSource = repository.GetTable("select * from [Users] where 1=0;");
                if (this.vAdministrator.GetSearch().Text != null && this.vAdministrator.GetSearch().Text.Length > 0)
                {

                    List<User> list = this.userRepository.SearchUserByRole(this.vAdministrator.GetSearch().Text);

                    if (list == null)
                    {
                        MessageBox.Show(lang.GetString("messageBoxNoUserDesiredRole"));
                    }
                    else
                    {

                        DataTable dt = new DataTable();

                        dt.Columns.Add("userID", typeof(uint));
                        dt.Columns.Add("username", typeof(string));
                        dt.Columns.Add("password", typeof(string));
                        dt.Columns.Add("role", typeof(string));
                        dt.Columns.Add("shopID", typeof(uint));


                        foreach (User user in list)
                        {
                            DataRow row = dt.NewRow();

                            row["userID"] = user.UserID;
                            row["username"] = user.Username;
                            row["password"] = user.Password;
                            row["role"] = user.Role;
                            row["shopID"] = user.ShopID;

                            dt.Rows.Add(row);
                        }

                        this.vAdministrator.GetUserTable().DataSource = dt;
                    }

                }
                else MessageBox.Show(lang.GetString("messageBoxSearchEmpty"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void viewAllUsers(object sender, EventArgs e)
        {
            try
            {
                if (this.vAdministrator.GetUserTable() != null)
                {
                    this.vAdministrator.GetUserTable().DataSource = repository.GetTable("select * from [Users] where 1=0;");
                    this.vAdministrator.GetUserTable().DataSource = this.repository.GetTable("SELECT * FROM [Users]");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void logout(object sender, EventArgs e)
        {
            try
            {
                ControllerVLogin login = new ControllerVLogin(0);
                login.GetView();
                this.vAdministrator.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void setUserControls(object sender, EventArgs e)
        {
            try
            {
                if (this.vAdministrator.GetUserTable().SelectedRows.Count > 0)
                {
                    DataGridViewRow drvr = this.vAdministrator.GetUserTable().SelectedRows[0];

                    uint userID = Convert.ToUInt32(drvr.Cells[0].Value);
                    this.vAdministrator.GetUserID().Value = userID;

                    string username = drvr.Cells[1].Value.ToString();
                    this.vAdministrator.GetUsername().Text = username;

                    string password = drvr.Cells[2].Value.ToString();
                    this.vAdministrator.GetPassword().Text = password;

                    string role = drvr.Cells[3].Value.ToString();
                    this.vAdministrator.GetRole().Text = role;

                    uint shopID;
                    if (drvr.Cells[4].Value == DBNull.Value)
                    {
                        shopID = 1;
                        this.vAdministrator.GetShopID().Value = shopID;
                    }
                    else if (drvr.Cells[4].Value != null)
                    {
                        shopID = Convert.ToUInt32(drvr.Cells[4].Value);
                        this.vAdministrator.GetShopID().Value = shopID;
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private User validInformation()
        {
            if (this.vAdministrator.GetUserID().Value == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxUserIDNonZero"));
                return null;
            }

            if (this.vAdministrator.GetUsername().Text == null || this.vAdministrator.GetUsername().Text.Length == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxUsernameEmpty"));
                return null;
            }

            if (this.vAdministrator.GetPassword().Text == null || this.vAdministrator.GetPassword().Text.Length == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxPasswordEmpty"));
                return null;
            }

            if (this.vAdministrator.GetRole().Text == null || this.vAdministrator.GetRole().Text.Length == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxRoleEmpty"));
                return null;
            }

            if(this.vAdministrator.GetShopID().Value == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxShopIDNonZero"));
                return null;
            }
            return new User((uint)this.vAdministrator.GetUserID().Value, this.vAdministrator.GetUsername().Text, this.vAdministrator.GetPassword().Text, this.vAdministrator.GetRole().Text, (uint)this.vAdministrator.GetShopID().Value);
        }

        private void resetGUIControls()
        {
            this.vAdministrator.GetUserID().Value = 1;
            this.vAdministrator.GetUsername().Text = string.Empty;
            this.vAdministrator.GetPassword().Text = string.Empty;
            this.vAdministrator.GetRole().Text = string.Empty;
            this.vAdministrator.GetSearch().Text = string.Empty;
            this.vAdministrator.GetUserTable().DataSource = repository.GetTable("SELECT * FROM [Users]");
        }


    }
}
