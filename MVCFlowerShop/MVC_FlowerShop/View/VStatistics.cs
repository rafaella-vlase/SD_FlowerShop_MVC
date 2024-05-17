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
using System.Windows.Forms.DataVisualization.Charting;

namespace MVC_FlowerShop.View
{
    public partial class VStatistics : Form, Observable
    {
        public VStatistics()
        {
            InitializeComponent();
        }

        public Label GetCriterionLabel()
        {
            return this.labelCriterion;
        }

        public Label GetFlowerShopLabel()
        {
            return this.labelChangeLanguage;
        }

        public ComboBox GetCriterionBox()
        {
            return this.comboBoxCriterion;
        }

        public ComboBox GetLanguageBox()
        {
            return this.comboBoxChangeLanguage;
        }

        public Chart GetFlowerChart()
        {
            return this.chartFlowers;
        }

        public Button GetBackButton()
        {
            return this.buttonBack;
        }

        public Button GetStatisticsButton()
        {
            return this.buttonStatistics;
        }

        public void Update(Subject obs)
        {
            LangHelper lang = (LangHelper)obs;

            this.labelCriterion.Text = lang.GetString("labelCriterion");
            this.labelChangeLanguage.Text = lang.GetString("labelChangeLanguage");
        }
    }
}
