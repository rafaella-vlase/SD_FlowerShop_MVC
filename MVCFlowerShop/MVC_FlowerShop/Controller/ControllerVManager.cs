using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using static System.Net.Mime.MediaTypeNames;
using Text = DocumentFormat.OpenXml.Wordprocessing.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MVC_FlowerShop.View;
using FlowerShopMVVM.Model.Repository;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Data;
using FlowerShopMVVM.Model;
using MVC_FlowerShop.Model.Language;
using Newtonsoft.Json.Bson;

namespace MVC_FlowerShop.Controller
{
    public class ControllerVManager
    {
        private VManager vManager;
        private VLogin vLogin;
        private FlowerRepository flowerRepository;
        private Repository repository;
        private LangHelper lang;
        private int index;

        public ControllerVManager(int index)
        {
            this.vManager = new VManager(index);
            this.vLogin = new VLogin(index);
            this.flowerRepository = new FlowerRepository();
            this.repository = Repository.GetInstance();
            this.index = index;

            this.lang = new LangHelper();
            this.lang.Add(this.vManager);

            this.eventsManagement();
        }

        public VManager GetView()
        {
            this.vManager.Show();
            return this.vManager;
        }

        private void eventsManagement()
        {
            this.vManager.FormClosed += new FormClosedEventHandler(exitApplication);
            this.vManager.GetSearchButton().Click += new EventHandler(searchBy);
            this.vManager.GetFilterByBox().SelectedIndexChanged += new EventHandler(filterBy);
            this.vManager.GetOrderByBox().SelectedIndexChanged += new EventHandler(orderBy);
            this.vManager.GetViewAllButton().Click += new EventHandler(viewAll);
            this.vManager.GetSaveCSVButton().Click += new EventHandler(saveCSV);
            this.vManager.GetSaveJSONButton().Click += new EventHandler(saveJSON);
            this.vManager.GetSaveXMLButton().Click += new EventHandler(saveXML);
            this.vManager.GetSaveDOCButton().Click += new EventHandler(saveDOC);
            this.vManager.GetStatisticsButton().Click += new EventHandler(showStatistics);
            this.vManager.GetLogoutButton().Click += new EventHandler(logout);
            this.vManager.GetFlowerTable().RowStateChanged += new DataGridViewRowStateChangedEventHandler(setFlowerControls);
            this.vManager.GetLanguageBox().SelectedIndexChanged += new EventHandler(changeLanguage);
        }

        private void exitApplication(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void changeLanguage(object sender, EventArgs e) 
        {
                if (this.vManager.GetLanguageBox().SelectedIndex == 0)
                {
                    this.lang.ChangeLanguage("en");
                }
                else if (this.vManager.GetLanguageBox().SelectedIndex == 1)
                {
                    this.lang.ChangeLanguage("fr");
                }
                else if (this.vManager.GetLanguageBox().SelectedIndex == 2)
                {
                    this.lang.ChangeLanguage("it");
                }
        }

        private void searchBy(object sender, EventArgs e)
        {
            try
            {
                if (this.vManager.GetFlowerTable() != null)
                {
                    this.vManager.GetFlowerTable().DataSource = repository.GetTable("select * from Flowers where 1=0;");
                }
                if (this.vManager.GetSearch().Text.Length > 0)
                {
                    string searchedFlower = this.vManager.GetSearch().Text;
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

                        this.vManager.GetFlowerTable().DataSource = dt;
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
                string selectedOption = this.vManager.GetFilterByBox().SelectedItem.ToString();

                if(this.vManager.GetFlowerTable() != null)
                    this.vManager.GetFlowerTable().DataSource = repository.GetTable("select * from Flowers where 1=0;");
                if (selectedOption.Length > 0)
                {
                    if(selectedOption.ToUpper() == "AVAILABILITY")
                    {
                        List<Flower> list = this.flowerRepository.FlowerList_Availability(0);

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

                            this.vManager.GetFlowerTable().DataSource = dt;
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoFlowerAvailable"));
                    } 
                    else if(selectedOption.ToUpper() == "PRICE")
                    {
                        Debug.WriteLine(this.vManager.GetPrice().ToString());
                        List<Flower> list = this.flowerRepository.FlowerList_Price(this.vManager.GetPrice().Text, 0);

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

                            this.vManager.GetFlowerTable().DataSource = dt;
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoFlowerAvailable"));
                    }
                    else if (selectedOption.ToUpper() == "COLOR")
                    {
                        List<Flower> list = this.flowerRepository.FlowerList_Color(this.vManager.GetColor().Text, 0);

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

                            this.vManager.GetFlowerTable().DataSource = dt;
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoFlowerAvailable"));
                    }
                    else if (selectedOption.ToUpper() == "STOCK")
                    {
                        List<Flower> list = this.flowerRepository.FlowerList_Stock(this.vManager.GetStock().Text, 0);

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

                            this.vManager.GetFlowerTable().DataSource = dt;
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoFlowerAvailable"));
                    }
                    else if (selectedOption.ToUpper() == "FLOWER SHOP")
                    {
                        List<Flower> list = this.flowerRepository.FlowerList_FlowerShop((uint)this.vManager.GetShopID().Value);

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

                            this.vManager.GetFlowerTable().DataSource = dt;
                        }
                        else MessageBox.Show(lang.GetString("messageBoxNoFlowerAvailable"));
                    }
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        private void orderBy(object sender, EventArgs e)
        {
            try
            {
                if (this.vManager.GetFlowerTable() != null)
                    this.vManager.GetFlowerTable().DataSource = repository.GetTable("select * from Flowers where 1=0;");

                string selectedOption = this.vManager.GetOrderByBox().SelectedItem.ToString();
                if (selectedOption.Length > 0)
                {
                    if (selectedOption.ToUpper() == "NONE")
                    {
                        this.vManager.GetFlowerTable().DataSource = this.flowerRepository.FlowerTable();
                    }
                    else if (selectedOption.ToUpper() == "COLOR AND PRICE")
                    {
                        List<Flower> list = this.flowerRepository.FlowerList_ColorPrice(0);

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

                            this.vManager.GetFlowerTable().DataSource = dt;
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
                if (this.vManager.GetFlowerTable() != null)
                {
                    this.vManager.GetFlowerTable().DataSource = repository.GetTable("select * from Flowers where 1=0;");
                    this.vManager.GetFlowerTable().DataSource = this.flowerRepository.FlowerTable();
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
                DataGridView dgv = this.vManager.GetFlowerTable();
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
                DataGridView dgv = this.vManager.GetFlowerTable();
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
                DataGridView dgv = this.vManager.GetFlowerTable();
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
                DataGridView dgv = this.vManager.GetFlowerTable();
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

        private void showStatistics(object sender, EventArgs e)
        {
            try
            {
                ControllerVStatistics statistics = new ControllerVStatistics(index);
                statistics.GetView();
                this.vManager.Hide();
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
                this.vManager.Hide();
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
                if (this.vManager.GetFlowerTable().SelectedRows.Count > 0)
                {
                    DataGridViewRow drvr = this.vManager.GetFlowerTable().SelectedRows[0];

                    uint flowerID = Convert.ToUInt32(drvr.Cells[0].Value);
                    this.vManager.GetFlowerID().Value = flowerID;

                    string flowerName = drvr.Cells[1].Value.ToString();
                    this.vManager.GetFlowerName().Text = flowerName;

                    string color = drvr.Cells[2].Value.ToString();
                    this.vManager.GetColor().Text = color;

                    string price = drvr.Cells[3].Value.ToString();
                    this.vManager.GetPrice().Text = price.ToString();

                    string stock = drvr.Cells[4].Value.ToString();
                    this.vManager.GetStock().Text = stock.ToString();

                    uint shopID = Convert.ToUInt32(drvr.Cells[5].Value);
                    this.vManager.GetShopID().Value = shopID;

                    string imageName = flowerName + "_" + color;

                    string workingDirectory = Environment.CurrentDirectory;
                    workingDirectory = workingDirectory.Substring(0, workingDirectory.Length - 9);

                    string path = workingDirectory + "resources\\flowers\\" + imageName + ".jpg";
                    string secondPath = workingDirectory + "resources\\flowers\\noFlowerFound.jpg";

                    try
                    {
                        this.vManager.GetPictureBox().Image = System.Drawing.Image.FromFile(path);
                    }
                    catch
                    {
                        this.vManager.GetPictureBox().Image = System.Drawing.Image.FromFile(secondPath);
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
