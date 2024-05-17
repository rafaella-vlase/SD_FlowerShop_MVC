using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Packaging;
using FlowerShopMVVM.Model;
using FlowerShopMVVM.Model.Repository;
using static System.Net.Mime.MediaTypeNames;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
using MVC_FlowerShop.View;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DocumentFormat.OpenXml.Wordprocessing;
using MVC_FlowerShop.Model.Language;

namespace MVC_FlowerShop.Controller
{
    public class ControllerVEmployee
    {
        private VEmployee vEmployee;
        private VLogin vLogin;
        private FlowerRepository flowerRepository;
        private Repository repository;
        private UserRepository userRepository;
        private string username;
        private uint shopIDEmployee;
        private LangHelper lang;
        private int index;

        public ControllerVEmployee(string username, int index)
        {
            this.vEmployee = new VEmployee(index);
            this.flowerRepository = new FlowerRepository();
            this.userRepository = new UserRepository();
            this.repository = Repository.GetInstance();
            this.index = index;

            this.lang = new LangHelper();
            this.lang.Add(this.vEmployee);

            this.username = username;
            this.shopIDEmployee = Convert.ToUInt32(userRepository.GetShopID(username));

            this.eventsManagement();
        }

        public VEmployee GetView()
        {
            this.vEmployee.Show();
            return this.vEmployee;
        }

        private void eventsManagement()
        {
            this.vEmployee.FormClosed += new FormClosedEventHandler(exitApplication);
            this.vEmployee.GetAddButton().Click += new EventHandler(addFlower);
            this.vEmployee.GetUpdateButton().Click += new EventHandler(updateFlower);
            this.vEmployee.GetDeleteButton().Click += new EventHandler(deleteFlower);
            this.vEmployee.GetSearchButton().Click += new EventHandler(searchBy);
            this.vEmployee.GetFilterByBox().SelectedIndexChanged += new EventHandler(filterBy);
            this.vEmployee.GetOrderByBox().SelectedIndexChanged += new EventHandler(orderBy);
            this.vEmployee.GetViewAllButton().Click += new EventHandler(viewAll);
            this.vEmployee.GetSaveCSVButton().Click += new EventHandler(saveCSV);
            this.vEmployee.GetSaveJSONButton().Click += new EventHandler(saveJSON);
            this.vEmployee.GetSaveXMLButton().Click += new EventHandler(saveXML);
            this.vEmployee.GetSaveDOCButton().Click += new EventHandler(saveDOC);
            this.vEmployee.GetLogoutButton().Click += new EventHandler(logout);
            this.vEmployee.GetFlowerTable().RowStateChanged += new DataGridViewRowStateChangedEventHandler(setFlowerControls);
            this.vEmployee.GetLanguageBox().SelectedIndexChanged += new EventHandler(changeLanguage);
        }

        private void exitApplication(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void changeLanguage(object sender, EventArgs e)
        {
            if(this.vEmployee.GetLanguageBox().SelectedIndex == 0)
            {
                this.lang.ChangeLanguage("en");
            } else if(this.vEmployee.GetLanguageBox().SelectedIndex == 1)
            {
                this.lang.ChangeLanguage("fr");
            } else if(this.vEmployee.GetLanguageBox().SelectedIndex == 2) 
            {
                this.lang.ChangeLanguage("it");
            }
        }

        private void addFlower(object sender, EventArgs e)
        {
            try
            {
                Flower flower = this.validInformation();
                if(flower != null)
                {
                    bool result = this.flowerRepository.AddFlower(flower);
                    if (result == true)
                    {
                        MessageBox.Show(lang.GetString("messageBoxAddSuccess"));

                        if (this.vEmployee.GetFlowerTable().Columns.Contains("shopID"))
                        {
                            this.vEmployee.GetFlowerTable().Columns.Remove("shopID");
                        }

                        this.resetGUIControls();

                        if (this.vEmployee.GetFlowerTable() == null)
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

        private void updateFlower(object sender, EventArgs e) 
        {
            try
            {
                Flower flower = this.validInformation();

                if(flower != null)
                {
                    bool result = this.flowerRepository.UpdateFlower(flower);

                    if (result == true)
                    {
                        MessageBox.Show(lang.GetString("messageBoxUpdateSuccess"));
                        if (this.vEmployee.GetFlowerTable().Columns.Contains("shopID"))
                            this.vEmployee.GetFlowerTable().Columns.Remove("shopID");
                        this.resetGUIControls();

                        if (this.vEmployee.GetFlowerTable() == null)
                            MessageBox.Show(lang.GetString("messageBoxNoData"));
                    }
                    else MessageBox.Show(lang.GetString("messageBoxUpdateFail"));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void deleteFlower(object sender, EventArgs e) 
        {
            try
            {
                if (Convert.ToBoolean(this.vEmployee.GetFlowerID().Value))
                {
                    bool result = this.flowerRepository.DeleteFlower(Convert.ToUInt32(this.vEmployee.GetFlowerID().Value), shopIDEmployee);

                    if (result == true)
                    {
                        MessageBox.Show(lang.GetString("messageBoxDeleteSuccess"));
                        if (this.vEmployee.GetFlowerTable().Columns.Contains("shopID"))
                            this.vEmployee.GetFlowerTable().Columns.Remove("shopID");
                        this.resetGUIControls();

                        if (this.vEmployee.GetFlowerTable() == null)
                            MessageBox.Show(lang.GetString("messageBoxNoData"));
                    }
                    else MessageBox.Show(lang.GetString("messageBoxDeleteFail"));
                }
                else MessageBox.Show(lang.GetString("messageBoxNoFlowerSelected"));
            }
            catch( Exception ex )
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void searchBy(object sender, EventArgs e)
        {
            try
            {
                if (this.vEmployee.GetFlowerTable() != null)
                {
                    this.vEmployee.GetFlowerTable().DataSource = this.flowerRepository.FlowerTableEmpty();
                }
                if (this.vEmployee.GetSearch().Text.Length > 0)
                {
                    string searchedFlower = this.vEmployee.GetSearch().Text;
                    List<Flower> list = this.flowerRepository.SearchFlowerByType(searchedFlower);

                    System.Data.DataTable dt = new System.Data.DataTable();
                    dt.Columns.Add("flowerID", typeof(uint));
                    dt.Columns.Add("flowerName", typeof(string));
                    dt.Columns.Add("color", typeof(string));
                    dt.Columns.Add("price", typeof(float));
                    dt.Columns.Add("stock", typeof(int));
                    dt.Columns.Add("shopID", typeof(uint));


                    if (list != null && list.Count > 0)
                    {
                        foreach (Flower f in list)
                        {
                            DataRow row = dt.NewRow();

                            row["flowerID"] = f.FlowerID;
                            row["flowerName"] = f.FlowerName;
                            row["color"] = f.Color;
                            row["price"] = f.Price;
                            row["stock"] = f.Stock;
                            row["shopID"] = f.ShopID;

                            dt.Rows.Add(row);
                        }

                        this.vEmployee.GetFlowerTable().DataSource = dt;
                    }
                    else MessageBox.Show(lang.GetString("messageBoxNoFlowerDesiredName"));
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void filterBy(object sender, EventArgs e)
        {
            try
            {
                string selectedOption = this.vEmployee.GetFilterByBox().SelectedItem.ToString();

                if (this.vEmployee.GetFlowerTable() != null)
                    this.vEmployee.GetFlowerTable().DataSource = this.flowerRepository.FlowerTableEmpty();
                if (selectedOption.Length > 0)
                {
                    if (selectedOption.ToUpper() == "AVAILABILITY")
                    {
                        List<Flower> list = this.flowerRepository.FlowerList_Availability(shopIDEmployee);

                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Columns.Add("flowerID", typeof(uint));
                        dt.Columns.Add("flowerName", typeof(string));
                        dt.Columns.Add("color", typeof(string));
                        dt.Columns.Add("price", typeof(float));
                        dt.Columns.Add("stock", typeof(int));

                        if (list != null && list.Count > 0)
                        {
                            foreach (Flower f in list)
                            {
                                DataRow row = dt.NewRow();

                                row["flowerID"] = f.FlowerID;
                                row["flowerName"] = f.FlowerName;
                                row["color"] = f.Color;
                                row["price"] = f.Price;
                                row["stock"] = f.Stock;

                                dt.Rows.Add(row);
                            }

                            this.vEmployee.GetFlowerTable().DataSource = dt;
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoFlowerAvailable"));
                    }
                    else if (selectedOption.ToUpper() == "PRICE")
                    {
                        Debug.WriteLine(this.vEmployee.GetPrice().ToString());
                        List<Flower> list = this.flowerRepository.FlowerList_Price(this.vEmployee.GetPrice().Text, shopIDEmployee);

                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Columns.Add("flowerID", typeof(uint));
                        dt.Columns.Add("flowerName", typeof(string));
                        dt.Columns.Add("color", typeof(string));
                        dt.Columns.Add("price", typeof(float));
                        dt.Columns.Add("stock", typeof(int));

                        if (list != null && list.Count > 0)
                        {
                            foreach (Flower f in list)
                            {
                                DataRow row = dt.NewRow();

                                row["flowerID"] = f.FlowerID;
                                row["flowerName"] = f.FlowerName;
                                row["color"] = f.Color;
                                row["price"] = f.Price;
                                row["stock"] = f.Stock;

                                dt.Rows.Add(row);
                            }

                            this.vEmployee.GetFlowerTable().DataSource = dt;
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoFlowerAvailable"));
                    }
                    else if (selectedOption.ToUpper() == "COLOR")
                    {
                        List<Flower> list = this.flowerRepository.FlowerList_Color(this.vEmployee.GetColor().Text, shopIDEmployee);

                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Columns.Add("flowerID", typeof(uint));
                        dt.Columns.Add("flowerName", typeof(string));
                        dt.Columns.Add("color", typeof(string));
                        dt.Columns.Add("price", typeof(float));
                        dt.Columns.Add("stock", typeof(int));

                        if (list != null && list.Count > 0)
                        {
                            foreach (Flower f in list)
                            {
                                DataRow row = dt.NewRow();

                                row["flowerID"] = f.FlowerID;
                                row["flowerName"] = f.FlowerName;
                                row["color"] = f.Color;
                                row["price"] = f.Price;
                                row["stock"] = f.Stock;

                                dt.Rows.Add(row);
                            }

                            this.vEmployee.GetFlowerTable().DataSource = dt;
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoFlowerAvailable"));
                    }
                    else if (selectedOption.ToUpper() == "STOCK")
                    {
                        List<Flower> list = this.flowerRepository.FlowerList_Stock(this.vEmployee.GetStock().Text, shopIDEmployee);

                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Columns.Add("flowerID", typeof(uint));
                        dt.Columns.Add("flowerName", typeof(string));
                        dt.Columns.Add("color", typeof(string));
                        dt.Columns.Add("price", typeof(float));
                        dt.Columns.Add("stock", typeof(int));

                        if (list != null && list.Count > 0)
                        {
                            foreach (Flower f in list)
                            {
                                DataRow row = dt.NewRow();

                                row["flowerID"] = f.FlowerID;
                                row["flowerName"] = f.FlowerName;
                                row["color"] = f.Color;
                                row["price"] = f.Price;
                                row["stock"] = f.Stock;

                                dt.Rows.Add(row);
                            }

                            this.vEmployee.GetFlowerTable().DataSource = dt;
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoFlowerAvailable"));
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void orderBy(object sender, EventArgs e)
        {
            try
            {
                if (this.vEmployee.GetFlowerTable() != null)
                    this.vEmployee.GetFlowerTable().DataSource = this.flowerRepository.FlowerTableEmpty();

                string selectedOption = this.vEmployee.GetOrderByBox().SelectedItem.ToString();
                if (selectedOption.Length > 0)
                {
                    if (selectedOption.ToUpper() == "NONE")
                    {
                        this.vEmployee.GetFlowerTable().DataSource = this.flowerRepository.FlowerTableEmployee(shopIDEmployee);
                    }
                    else if (selectedOption.ToUpper() == "COLOR AND PRICE")
                    {
                        List<Flower> list = this.flowerRepository.FlowerList_ColorPrice(shopIDEmployee);

                        System.Data.DataTable dt = new System.Data.DataTable();
                        dt.Columns.Add("flowerID", typeof(uint));
                        dt.Columns.Add("flowerName", typeof(string));
                        dt.Columns.Add("color", typeof(string));
                        dt.Columns.Add("price", typeof(float));
                        dt.Columns.Add("stock", typeof(int));

                        if (list != null && list.Count > 0)
                        {
                            foreach (Flower f in list)
                            {
                                DataRow row = dt.NewRow();

                                row["flowerID"] = f.FlowerID;
                                row["flowerName"] = f.FlowerName;
                                row["color"] = f.Color;
                                row["price"] = f.Price;
                                row["stock"] = f.Stock;

                                dt.Rows.Add(row);
                            }

                            this.vEmployee.GetFlowerTable().DataSource = dt;
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoData"));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void viewAll(object sender, EventArgs e)
        {
            try
            {
                if (this.vEmployee.GetFlowerTable() != null)
                {
                    this.vEmployee.GetFlowerTable().DataSource = this.flowerRepository.FlowerTableEmpty();
                    this.vEmployee.GetFlowerTable().DataSource = this.flowerRepository.FlowerTableEmployee(shopIDEmployee);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void saveCSV(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = this.vEmployee.GetFlowerTable();
                if (dgv != null)
                {
                    StringBuilder sb = new StringBuilder();

                    // Get the column names from the DataGridView.
                    IEnumerable<string> columnNames = dgv.Columns.Cast<DataGridViewColumn>().Select(column => column.Name);
                    sb.AppendLine(string.Join(",", columnNames));

                    // Iterate over the rows in the DataGridView.
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        // Get the values from each cell in the row.
                        IEnumerable<string> fields = row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value != null ? cell.Value.ToString() : "");
                        sb.AppendLine(string.Join(",", fields));
                    }

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveFileDialog.FileName, sb.ToString());
                        MessageBox.Show(lang.GetString("messageBoxFileSaveSuccess"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void saveJSON(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = this.vEmployee.GetFlowerTable();
                if (dgv != null)
                {
                    // Create a list to hold dictionaries.
                    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();

                    // Iterate over the rows in the DataGridView.
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        // Create a dictionary for this row.
                        Dictionary<string, object> dictRow = new Dictionary<string, object>();

                        // Iterate over the cells in the row.
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            // Add the cell's value to the dictionary.
                            dictRow[dgv.Columns[cell.ColumnIndex].Name] = cell.Value;
                        }

                        // Add the dictionary to the list.
                        rows.Add(dictRow);
                    }

                    // Now we can serialize the list of dictionaries.
                    JsonSerializer serializer = new JsonSerializer
                    {
                        Formatting = Newtonsoft.Json.Formatting.Indented
                    };

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "JSON Files (*.json)|*.json";
                    saveFileDialog.DefaultExt = "json";
                    saveFileDialog.AddExtension = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                        using (JsonTextWriter writer = new JsonTextWriter(sw))
                        {
                            serializer.Serialize(writer, rows);
                        }
                        MessageBox.Show(lang.GetString("messageBoxFileSaveSuccess"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void saveXML(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = this.vEmployee.GetFlowerTable();
                if (dgv != null)
                {
                    // Create a new DataTable.
                    System.Data.DataTable dt = new System.Data.DataTable();

                    // Add columns to the DataTable.
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        dt.Columns.Add(column.Name, column.ValueType);
                    }

                    // Add rows to the DataTable.
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        dt.Rows.Add(row.Cells.Cast<DataGridViewCell>().Select(cell => cell.Value).ToArray());
                    }

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
                    saveFileDialog.DefaultExt = "xml";
                    saveFileDialog.AddExtension = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        dt.TableName = "Flowers"; // Set the table name.
                        dt.WriteXml(saveFileDialog.FileName); // Write the DataTable to an XML file.
                        MessageBox.Show(lang.GetString("messageBoxFileSaveSuccess"));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void saveDOC(object sender, EventArgs e)
        {
            try
            {
                DataGridView dgv = this.vEmployee.GetFlowerTable();
                if (dgv != null && dgv.Rows.Count > 0)
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Word Documents (*.docx)|*.docx";
                    saveFileDialog.DefaultExt = "docx";
                    saveFileDialog.AddExtension = true;

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (WordprocessingDocument document = WordprocessingDocument.Create(saveFileDialog.FileName, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                        {
                            MainDocumentPart mainPart = document.AddMainDocumentPart();
                            mainPart.Document = new DocumentFormat.OpenXml.Wordprocessing.Document();
                            DocumentFormat.OpenXml.Wordprocessing.Body body = mainPart.Document.AppendChild(new DocumentFormat.OpenXml.Wordprocessing.Body());

                            Table t = new Table();

                            for (int i = 0; i < dgv.Rows.Count; i++)
                            {
                                TableRow row = new TableRow();

                                for (int j = 0; j < dgv.Columns.Count; j++)
                                {
                                    TableCell cell = new TableCell();
                                    if (dgv.Rows[i].Cells[j].Value != null)
                                    {
                                        cell.Append(new Paragraph(new Run(new Text(dgv.Rows[i].Cells[j].Value.ToString()))));
                                    }
                                    else
                                    {
                                        cell.Append(new Paragraph(new Run(new Text(""))));
                                    }
                                    row.Append(cell);
                                }

                                t.Append(row);
                            }

                            body.Append(t);
                            document.Save();
                            MessageBox.Show(lang.GetString("messageBoxFileSaveSuccess"));
                        }
                    }
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
                ControllerVLogin login = new ControllerVLogin(index);
                login.GetView();
                this.vEmployee.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void setFlowerControls(object sender, EventArgs e)
        {
            try
            {
                if (this.vEmployee.GetFlowerTable().SelectedRows.Count > 0)
                {
                    DataGridViewRow drvr = this.vEmployee.GetFlowerTable().SelectedRows[0];

                    uint flowerID = Convert.ToUInt32(drvr.Cells[0].Value);
                    this.vEmployee.GetFlowerID().Value = flowerID;

                    string flowerName = drvr.Cells[1].Value.ToString();
                    this.vEmployee.GetFlowerName().Text = flowerName;

                    string color = drvr.Cells[2].Value.ToString();
                    this.vEmployee.GetColor().Text = color;

                    string price = drvr.Cells[3].Value.ToString();
                    this.vEmployee.GetPrice().Text = price.ToString();

                    string stock = drvr.Cells[4].Value.ToString();
                    this.vEmployee.GetStock().Text = stock.ToString();

                    string imageName = flowerName + "_" + color;

                    string workingDirectory = Environment.CurrentDirectory;
                    workingDirectory = workingDirectory.Substring(0, workingDirectory.Length - 9);

                    string path = workingDirectory + "resources\\flowers\\" + imageName + ".jpg";
                    string secondPath = workingDirectory + "resources\\flowers\\noFlowerFound.jpg";

                    try
                    {
                        this.vEmployee.GetPictureBox().Image = System.Drawing.Image.FromFile(path);
                    }
                    catch
                    {
                        this.vEmployee.GetPictureBox().Image = System.Drawing.Image.FromFile(secondPath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void resetGUIControls()
        {
            this.vEmployee.GetFlowerID().Value = 1;
            this.vEmployee.GetFlowerName().Text = string.Empty;
            this.vEmployee.GetColor().Text = string.Empty;
            this.vEmployee.GetPrice().Text = string.Empty;
            this.vEmployee.GetStock().Text = string.Empty;
            this.vEmployee.GetOrderByBox().SelectedIndex = 0;
            this.vEmployee.GetFilterByBox().SelectedIndex = 0;
            this.vEmployee.GetSearch().Text = string.Empty;
            this.vEmployee.GetFlowerTable().DataSource = this.flowerRepository.FlowerTableEmpty();
            this.vEmployee.GetFlowerTable().DataSource = flowerRepository.FlowerTableEmployee(shopIDEmployee);
        }

        private Flower validInformation()
        {
            uint flowerID = (uint)this.vEmployee.GetFlowerID().Value;
            if (flowerID == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxFlowerIDNonZero"));
                return null;
            }

            string flowerName = this.vEmployee.GetFlowerName().Text;
            if (flowerName == null || flowerName.Length == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxFlowerNameEmpty"));
                return null;
            }

            string color = this.vEmployee.GetColor().Text;
            if (flowerName == null || flowerName.Length == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxColorEmpty"));
                return null;
            }

            float price = (float)Convert.ToDouble(this.vEmployee.GetPrice().Text);
            if (price <= 0)
            {
                MessageBox.Show(lang.GetString("messageBoxPriceHigher"));
                return null;
            }

            int stock = Convert.ToInt32(this.vEmployee.GetStock().Text);
            if (stock < 0)
            {
                MessageBox.Show(lang.GetString("messageBoxStockMinZero"));
                return null;
            }

            string shopIDString = userRepository.GetShopID(username);
            uint shopID = Convert.ToUInt32(shopIDString);
            if (shopID == 0)
            {
                MessageBox.Show(lang.GetString("messageBoxShopIDNonZero"));
                return null;
            }
            return new Flower(flowerID, shopID, flowerName, color, price, stock);
        }
    }
}
