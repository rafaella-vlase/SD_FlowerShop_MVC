using FlowerShopMVVM.Model.Repository;
using MVC_FlowerShop.Model;
using MVC_FlowerShop.Model.Language;
using MVC_FlowerShop.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MVC_FlowerShop.Controller
{
    public class ControllerVStatistics
    {
        private VStatistics vStatistics;
        private FlowerStatistics flowerStatistics;
        private FlowerRepository flowerRepository;
        private Repository repository;
        private LangHelper lang;
        private int index;

        public ControllerVStatistics(int index)
        {
            this.vStatistics = new VStatistics();
            this.flowerRepository = new FlowerRepository();
            this.flowerStatistics = new FlowerStatistics(this.flowerRepository.FlowerTable());
            this.repository = Repository.GetInstance();
            this.index = index;

            this.lang = new LangHelper();
            this.lang.Add(this.vStatistics);

            this.eventsManagement();
        }

        public VStatistics GetView()
        {
            this.vStatistics.Show();
            return this.vStatistics;
        }

        private void eventsManagement()
        {
            this.vStatistics.FormClosed += new System.Windows.Forms.FormClosedEventHandler(exitApplication);
            this.vStatistics.GetBackButton().Click += new EventHandler(backToManager);
            this.vStatistics.GetCriterionBox().SelectedIndexChanged += new EventHandler(showStatistics);
            this.vStatistics.GetLanguageBox().SelectedIndexChanged += new EventHandler(changeLanguage);
        }

        private void exitApplication(object sender, FormClosedEventArgs e) 
        {
            Environment.Exit(0);
        }

        private void changeLanguage(object sender, EventArgs e)
        {
            if (this.vStatistics.GetLanguageBox().SelectedIndex == 0)
            {
                this.lang.ChangeLanguage("en");
            }
            else if (this.vStatistics.GetLanguageBox().SelectedIndex == 1)
            {
                this.lang.ChangeLanguage("fr");
            }
            else if (this.vStatistics.GetLanguageBox().SelectedIndex == 2)
            {
                this.lang.ChangeLanguage("it");
            }
        }

        private void backToManager(object sender, EventArgs e)
        {
            try
            {
                ControllerVManager manager = new ControllerVManager(index);
                manager.GetView();
                this.vStatistics.Hide();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void showStatistics(object sender, EventArgs e)
        {
            string criterion = this.vStatistics.GetCriterionBox().SelectedItem.ToString();

            this.flowerStatistics.Criterion = criterion;
            Dictionary<string, uint> dictionary = this.flowerStatistics.Result;
            if (dictionary != null)
            {
                this.vStatistics.GetFlowerChart().Series.Clear();
                this.vStatistics.GetFlowerChart().Legends.Clear();
                this.vStatistics.GetFlowerChart().Legends.Add(criterion);
                this.vStatistics.GetFlowerChart().Legends[0].LegendStyle = LegendStyle.Table;
                this.vStatistics.GetFlowerChart().Legends[0].Docking = Docking.Bottom;
                this.vStatistics.GetFlowerChart().Legends[0].Alignment = StringAlignment.Center;
                this.vStatistics.GetFlowerChart().Legends[0].Title = criterion;
                this.vStatistics.GetFlowerChart().Legends[0].TitleForeColor = Color.Black;
                this.vStatistics.GetFlowerChart().Legends[0].TitleFont = new Font("Montserrat", 9);
                this.vStatistics.GetFlowerChart().Legends[0].BorderColor = Color.Transparent;
                this.vStatistics.GetFlowerChart().Legends[0].BackColor = Color.Transparent;
                this.vStatistics.GetFlowerChart().Legends[0].ForeColor = Color.Black;
                this.vStatistics.GetFlowerChart().Legends[0].Font = new Font("Montserrat", 9);
                this.vStatistics.GetFlowerChart().Series.Add(criterion);
                this.vStatistics.GetFlowerChart().Series[criterion].ChartType = SeriesChartType.Pie;

                foreach (KeyValuePair<string, uint> pair in dictionary)
                {
                    this.vStatistics.GetFlowerChart().Series[criterion].Points.AddXY(pair.Key, pair.Value);
                }

                foreach (DataPoint p in this.vStatistics.GetFlowerChart().Series[criterion].Points)
                {
                    p.Label = "#PERCENT";
                }

                this.vStatistics.GetFlowerChart().Series[criterion].LegendText = "#VALX";
            }
            else MessageBox.Show("The list of flowers is empty!");

            Debug.WriteLine("Done statistics!");

        }
    }
}
