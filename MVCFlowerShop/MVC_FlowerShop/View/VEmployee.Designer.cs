namespace MVC_FlowerShop.View
{
    partial class VEmployee
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VEmployee));
            this.pictureBoxBubble = new System.Windows.Forms.PictureBox();
            this.pictureBoxAvatar = new System.Windows.Forms.PictureBox();
            this.labelSearch = new System.Windows.Forms.Label();
            this.numericUpDownFlowerID = new System.Windows.Forms.NumericUpDown();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.textBoxColor = new System.Windows.Forms.TextBox();
            this.textBoxFlowerName = new System.Windows.Forms.TextBox();
            this.labelStock = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.labelColor = new System.Windows.Forms.Label();
            this.labelFlowerName = new System.Windows.Forms.Label();
            this.labelFlowerID = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonViewAll = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.dataGridViewFlowers = new System.Windows.Forms.DataGridView();
            this.textBoxStock = new System.Windows.Forms.TextBox();
            this.buttonSaveJSON = new System.Windows.Forms.Button();
            this.buttonSaveCSV = new System.Windows.Forms.Button();
            this.buttonSaveDOC = new System.Windows.Forms.Button();
            this.buttonSaveXML = new System.Windows.Forms.Button();
            this.comboBoxFilterBy = new System.Windows.Forms.ComboBox();
            this.comboBoxOrderBy = new System.Windows.Forms.ComboBox();
            this.labelOrderBy = new System.Windows.Forms.Label();
            this.labelFilterBy = new System.Windows.Forms.Label();
            this.pictureBoxFlowers = new System.Windows.Forms.PictureBox();
            this.labelChangeLanguage = new System.Windows.Forms.Label();
            this.comboBoxChangeLanguage = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBubble)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFlowerID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlowers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFlowers)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBubble
            // 
            this.pictureBoxBubble.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBubble.BackgroundImage = global::MVC_FlowerShop.Properties.Resources.employee_bubble;
            this.pictureBoxBubble.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxBubble.Location = new System.Drawing.Point(63, 100);
            this.pictureBoxBubble.Name = "pictureBoxBubble";
            this.pictureBoxBubble.Size = new System.Drawing.Size(282, 49);
            this.pictureBoxBubble.TabIndex = 42;
            this.pictureBoxBubble.TabStop = false;
            // 
            // pictureBoxAvatar
            // 
            this.pictureBoxAvatar.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxAvatar.BackgroundImage = global::MVC_FlowerShop.Properties.Resources.avatar;
            this.pictureBoxAvatar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxAvatar.InitialImage = global::MVC_FlowerShop.Properties.Resources.avatar;
            this.pictureBoxAvatar.Location = new System.Drawing.Point(36, 155);
            this.pictureBoxAvatar.Name = "pictureBoxAvatar";
            this.pictureBoxAvatar.Size = new System.Drawing.Size(144, 120);
            this.pictureBoxAvatar.TabIndex = 41;
            this.pictureBoxAvatar.TabStop = false;
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.BackColor = System.Drawing.Color.Transparent;
            this.labelSearch.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold);
            this.labelSearch.Location = new System.Drawing.Point(488, 342);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(264, 33);
            this.labelSearch.TabIndex = 40;
            this.labelSearch.Text = "Search Flower By Name";
            // 
            // numericUpDownFlowerID
            // 
            this.numericUpDownFlowerID.Location = new System.Drawing.Point(527, 56);
            this.numericUpDownFlowerID.Maximum = new decimal(new int[] {
            4000000,
            0,
            0,
            0});
            this.numericUpDownFlowerID.Name = "numericUpDownFlowerID";
            this.numericUpDownFlowerID.Size = new System.Drawing.Size(184, 20);
            this.numericUpDownFlowerID.TabIndex = 38;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(527, 179);
            this.textBoxPrice.Multiline = true;
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(184, 22);
            this.textBoxPrice.TabIndex = 37;
            // 
            // textBoxColor
            // 
            this.textBoxColor.Location = new System.Drawing.Point(527, 138);
            this.textBoxColor.Multiline = true;
            this.textBoxColor.Name = "textBoxColor";
            this.textBoxColor.Size = new System.Drawing.Size(184, 22);
            this.textBoxColor.TabIndex = 36;
            // 
            // textBoxFlowerName
            // 
            this.textBoxFlowerName.Location = new System.Drawing.Point(527, 95);
            this.textBoxFlowerName.Multiline = true;
            this.textBoxFlowerName.Name = "textBoxFlowerName";
            this.textBoxFlowerName.Size = new System.Drawing.Size(184, 22);
            this.textBoxFlowerName.TabIndex = 35;
            // 
            // labelStock
            // 
            this.labelStock.AutoSize = true;
            this.labelStock.BackColor = System.Drawing.Color.Transparent;
            this.labelStock.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold);
            this.labelStock.Location = new System.Drawing.Point(362, 214);
            this.labelStock.Name = "labelStock";
            this.labelStock.Size = new System.Drawing.Size(71, 33);
            this.labelStock.TabIndex = 34;
            this.labelStock.Text = "Stock";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.BackColor = System.Drawing.Color.Transparent;
            this.labelPrice.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold);
            this.labelPrice.Location = new System.Drawing.Point(362, 174);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(71, 33);
            this.labelPrice.TabIndex = 33;
            this.labelPrice.Text = "Price";
            // 
            // labelColor
            // 
            this.labelColor.AutoSize = true;
            this.labelColor.BackColor = System.Drawing.Color.Transparent;
            this.labelColor.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold);
            this.labelColor.Location = new System.Drawing.Point(362, 132);
            this.labelColor.Name = "labelColor";
            this.labelColor.Size = new System.Drawing.Size(73, 33);
            this.labelColor.TabIndex = 32;
            this.labelColor.Text = "Color";
            // 
            // labelFlowerName
            // 
            this.labelFlowerName.AutoSize = true;
            this.labelFlowerName.BackColor = System.Drawing.Color.Transparent;
            this.labelFlowerName.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold);
            this.labelFlowerName.Location = new System.Drawing.Point(362, 91);
            this.labelFlowerName.Name = "labelFlowerName";
            this.labelFlowerName.Size = new System.Drawing.Size(153, 33);
            this.labelFlowerName.TabIndex = 31;
            this.labelFlowerName.Text = "Flower Name";
            // 
            // labelFlowerID
            // 
            this.labelFlowerID.AutoSize = true;
            this.labelFlowerID.BackColor = System.Drawing.Color.Transparent;
            this.labelFlowerID.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold);
            this.labelFlowerID.Location = new System.Drawing.Point(362, 52);
            this.labelFlowerID.Name = "labelFlowerID";
            this.labelFlowerID.Size = new System.Drawing.Size(117, 33);
            this.labelFlowerID.TabIndex = 30;
            this.labelFlowerID.Text = "Flower ID";
            // 
            // buttonLogout
            // 
            this.buttonLogout.BackColor = System.Drawing.Color.MistyRose;
            this.buttonLogout.Location = new System.Drawing.Point(63, 281);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(86, 34);
            this.buttonLogout.TabIndex = 29;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = false;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(488, 378);
            this.textBoxSearch.Multiline = true;
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(288, 34);
            this.textBoxSearch.TabIndex = 28;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.Color.MistyRose;
            this.buttonDelete.Location = new System.Drawing.Point(625, 281);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(86, 34);
            this.buttonDelete.TabIndex = 27;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.MistyRose;
            this.buttonUpdate.Location = new System.Drawing.Point(493, 281);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(86, 34);
            this.buttonUpdate.TabIndex = 26;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackColor = System.Drawing.Color.MistyRose;
            this.buttonAdd.Location = new System.Drawing.Point(362, 281);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(86, 34);
            this.buttonAdd.TabIndex = 25;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = false;
            // 
            // buttonViewAll
            // 
            this.buttonViewAll.BackColor = System.Drawing.Color.MistyRose;
            this.buttonViewAll.Location = new System.Drawing.Point(887, 378);
            this.buttonViewAll.Name = "buttonViewAll";
            this.buttonViewAll.Size = new System.Drawing.Size(86, 34);
            this.buttonViewAll.TabIndex = 24;
            this.buttonViewAll.Text = "View All";
            this.buttonViewAll.UseVisualStyleBackColor = false;
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackColor = System.Drawing.Color.MistyRose;
            this.buttonSearch.Location = new System.Drawing.Point(789, 378);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(86, 34);
            this.buttonSearch.TabIndex = 23;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = false;
            // 
            // dataGridViewFlowers
            // 
            this.dataGridViewFlowers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewFlowers.BackgroundColor = System.Drawing.Color.MistyRose;
            this.dataGridViewFlowers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFlowers.Location = new System.Drawing.Point(29, 418);
            this.dataGridViewFlowers.Name = "dataGridViewFlowers";
            this.dataGridViewFlowers.Size = new System.Drawing.Size(944, 356);
            this.dataGridViewFlowers.TabIndex = 22;
            // 
            // textBoxStock
            // 
            this.textBoxStock.Location = new System.Drawing.Point(527, 223);
            this.textBoxStock.Multiline = true;
            this.textBoxStock.Name = "textBoxStock";
            this.textBoxStock.Size = new System.Drawing.Size(184, 22);
            this.textBoxStock.TabIndex = 43;
            // 
            // buttonSaveJSON
            // 
            this.buttonSaveJSON.BackColor = System.Drawing.Color.MistyRose;
            this.buttonSaveJSON.Location = new System.Drawing.Point(869, 56);
            this.buttonSaveJSON.Name = "buttonSaveJSON";
            this.buttonSaveJSON.Size = new System.Drawing.Size(86, 34);
            this.buttonSaveJSON.TabIndex = 45;
            this.buttonSaveJSON.Text = "Save JSON";
            this.buttonSaveJSON.UseVisualStyleBackColor = false;
            // 
            // buttonSaveCSV
            // 
            this.buttonSaveCSV.BackColor = System.Drawing.Color.MistyRose;
            this.buttonSaveCSV.Location = new System.Drawing.Point(771, 56);
            this.buttonSaveCSV.Name = "buttonSaveCSV";
            this.buttonSaveCSV.Size = new System.Drawing.Size(86, 34);
            this.buttonSaveCSV.TabIndex = 44;
            this.buttonSaveCSV.Text = "Save CSV";
            this.buttonSaveCSV.UseVisualStyleBackColor = false;
            // 
            // buttonSaveDOC
            // 
            this.buttonSaveDOC.BackColor = System.Drawing.Color.MistyRose;
            this.buttonSaveDOC.Location = new System.Drawing.Point(869, 96);
            this.buttonSaveDOC.Name = "buttonSaveDOC";
            this.buttonSaveDOC.Size = new System.Drawing.Size(86, 34);
            this.buttonSaveDOC.TabIndex = 47;
            this.buttonSaveDOC.Text = "Save DOC";
            this.buttonSaveDOC.UseVisualStyleBackColor = false;
            // 
            // buttonSaveXML
            // 
            this.buttonSaveXML.BackColor = System.Drawing.Color.MistyRose;
            this.buttonSaveXML.Location = new System.Drawing.Point(771, 96);
            this.buttonSaveXML.Name = "buttonSaveXML";
            this.buttonSaveXML.Size = new System.Drawing.Size(86, 34);
            this.buttonSaveXML.TabIndex = 46;
            this.buttonSaveXML.Text = "Save XML";
            this.buttonSaveXML.UseVisualStyleBackColor = false;
            // 
            // comboBoxFilterBy
            // 
            this.comboBoxFilterBy.FormattingEnabled = true;
            this.comboBoxFilterBy.Items.AddRange(new object[] {
            "",
            "Stock",
            "Price",
            "Color",
            "Availability"});
            this.comboBoxFilterBy.Location = new System.Drawing.Point(281, 391);
            this.comboBoxFilterBy.Name = "comboBoxFilterBy";
            this.comboBoxFilterBy.Size = new System.Drawing.Size(194, 21);
            this.comboBoxFilterBy.TabIndex = 48;
            // 
            // comboBoxOrderBy
            // 
            this.comboBoxOrderBy.FormattingEnabled = true;
            this.comboBoxOrderBy.Items.AddRange(new object[] {
            "",
            "None",
            "Color and Price"});
            this.comboBoxOrderBy.Location = new System.Drawing.Point(29, 391);
            this.comboBoxOrderBy.Name = "comboBoxOrderBy";
            this.comboBoxOrderBy.Size = new System.Drawing.Size(194, 21);
            this.comboBoxOrderBy.TabIndex = 49;
            // 
            // labelOrderBy
            // 
            this.labelOrderBy.AutoSize = true;
            this.labelOrderBy.BackColor = System.Drawing.Color.Transparent;
            this.labelOrderBy.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold);
            this.labelOrderBy.Location = new System.Drawing.Point(30, 355);
            this.labelOrderBy.Name = "labelOrderBy";
            this.labelOrderBy.Size = new System.Drawing.Size(111, 33);
            this.labelOrderBy.TabIndex = 50;
            this.labelOrderBy.Text = "Order By";
            // 
            // labelFilterBy
            // 
            this.labelFilterBy.AutoSize = true;
            this.labelFilterBy.BackColor = System.Drawing.Color.Transparent;
            this.labelFilterBy.Font = new System.Drawing.Font("Segoe Script", 15F, System.Drawing.FontStyle.Bold);
            this.labelFilterBy.Location = new System.Drawing.Point(282, 355);
            this.labelFilterBy.Name = "labelFilterBy";
            this.labelFilterBy.Size = new System.Drawing.Size(101, 33);
            this.labelFilterBy.TabIndex = 51;
            this.labelFilterBy.Text = "FilterBy";
            // 
            // pictureBoxFlowers
            // 
            this.pictureBoxFlowers.Location = new System.Drawing.Point(1009, 52);
            this.pictureBoxFlowers.Name = "pictureBoxFlowers";
            this.pictureBoxFlowers.Size = new System.Drawing.Size(398, 722);
            this.pictureBoxFlowers.TabIndex = 85;
            this.pictureBoxFlowers.TabStop = false;
            // 
            // labelChangeLanguage
            // 
            this.labelChangeLanguage.AutoSize = true;
            this.labelChangeLanguage.BackColor = System.Drawing.Color.Transparent;
            this.labelChangeLanguage.Font = new System.Drawing.Font("Segoe Script", 13F, System.Drawing.FontStyle.Bold);
            this.labelChangeLanguage.Location = new System.Drawing.Point(774, 138);
            this.labelChangeLanguage.Name = "labelChangeLanguage";
            this.labelChangeLanguage.Size = new System.Drawing.Size(180, 30);
            this.labelChangeLanguage.TabIndex = 87;
            this.labelChangeLanguage.Text = "Change Language";
            // 
            // comboBoxChangeLanguage
            // 
            this.comboBoxChangeLanguage.FormattingEnabled = true;
            this.comboBoxChangeLanguage.Items.AddRange(new object[] {
            "English",
            "French",
            "Italian"});
            this.comboBoxChangeLanguage.Location = new System.Drawing.Point(773, 174);
            this.comboBoxChangeLanguage.Name = "comboBoxChangeLanguage";
            this.comboBoxChangeLanguage.Size = new System.Drawing.Size(194, 21);
            this.comboBoxChangeLanguage.TabIndex = 86;
            // 
            // VEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.BackgroundImage = global::MVC_FlowerShop.Properties.Resources.defaultBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1442, 793);
            this.Controls.Add(this.labelChangeLanguage);
            this.Controls.Add(this.comboBoxChangeLanguage);
            this.Controls.Add(this.pictureBoxFlowers);
            this.Controls.Add(this.labelFilterBy);
            this.Controls.Add(this.labelOrderBy);
            this.Controls.Add(this.comboBoxOrderBy);
            this.Controls.Add(this.comboBoxFilterBy);
            this.Controls.Add(this.buttonSaveDOC);
            this.Controls.Add(this.buttonSaveXML);
            this.Controls.Add(this.buttonSaveJSON);
            this.Controls.Add(this.buttonSaveCSV);
            this.Controls.Add(this.textBoxStock);
            this.Controls.Add(this.pictureBoxBubble);
            this.Controls.Add(this.pictureBoxAvatar);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.numericUpDownFlowerID);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxColor);
            this.Controls.Add(this.textBoxFlowerName);
            this.Controls.Add(this.labelStock);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelColor);
            this.Controls.Add(this.labelFlowerName);
            this.Controls.Add(this.labelFlowerID);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonViewAll);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.dataGridViewFlowers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "VEmployee";
            this.Text = "[EMPLOYEE] Flower Shop";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBubble)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFlowerID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFlowers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFlowers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBubble;
        private System.Windows.Forms.PictureBox pictureBoxAvatar;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.NumericUpDown numericUpDownFlowerID;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.TextBox textBoxColor;
        private System.Windows.Forms.TextBox textBoxFlowerName;
        private System.Windows.Forms.Label labelStock;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.Label labelColor;
        private System.Windows.Forms.Label labelFlowerName;
        private System.Windows.Forms.Label labelFlowerID;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonViewAll;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.DataGridView dataGridViewFlowers;
        private System.Windows.Forms.TextBox textBoxStock;
        private System.Windows.Forms.Button buttonSaveJSON;
        private System.Windows.Forms.Button buttonSaveCSV;
        private System.Windows.Forms.Button buttonSaveDOC;
        private System.Windows.Forms.Button buttonSaveXML;
        private System.Windows.Forms.ComboBox comboBoxFilterBy;
        private System.Windows.Forms.ComboBox comboBoxOrderBy;
        private System.Windows.Forms.Label labelOrderBy;
        private System.Windows.Forms.Label labelFilterBy;
        private System.Windows.Forms.PictureBox pictureBoxFlowers;
        private System.Windows.Forms.Label labelChangeLanguage;
        private System.Windows.Forms.ComboBox comboBoxChangeLanguage;
    }
}