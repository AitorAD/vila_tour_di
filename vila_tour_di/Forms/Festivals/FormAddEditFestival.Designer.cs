
namespace vila_tour_di {
    partial class FormAddEditFestival {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddEditFestival));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.txtBoxDesciption = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.txtBoxName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCoordinate = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.comboBoxCoordinates = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAddCoordinate = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel24 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2HtmlLabelIng = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.DateTimePickerFinal = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel4 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.DateTimePickerStart = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.tableLayoutPanel20 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddFestival = new Guna.UI2.WinForms.Guna2Button();
            this.imageSlider = new vila_tour_di.Forms.Commons.ImageSlider();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel24.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel20.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel10, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel9, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel24, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel20, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.imageSlider, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.99173F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.52269F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.3595F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.55439F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.33202F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.23967F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(640, 880);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.LightSeaGreen;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTitle, 3);
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(634, 59);
            this.lblTitle.TabIndex = 34;
            this.lblTitle.Text = "Añadir/Editar Festival o Tradición";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 2;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel10.Controls.Add(this.txtBoxDesciption, 0, 0);
            this.tableLayoutPanel10.Controls.Add(this.guna2HtmlLabel3, 0, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(23, 519);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 1;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(594, 106);
            this.tableLayoutPanel10.TabIndex = 39;
            // 
            // txtBoxDesciption
            // 
            this.txtBoxDesciption.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxDesciption.DefaultText = "";
            this.txtBoxDesciption.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBoxDesciption.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBoxDesciption.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxDesciption.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxDesciption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxDesciption.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxDesciption.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBoxDesciption.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxDesciption.Location = new System.Drawing.Point(240, 3);
            this.txtBoxDesciption.Multiline = true;
            this.txtBoxDesciption.Name = "txtBoxDesciption";
            this.txtBoxDesciption.PasswordChar = '\0';
            this.txtBoxDesciption.PlaceholderText = "";
            this.txtBoxDesciption.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBoxDesciption.SelectedText = "";
            this.txtBoxDesciption.Size = new System.Drawing.Size(351, 100);
            this.txtBoxDesciption.TabIndex = 4;
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(40, 39);
            this.guna2HtmlLabel3.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(122, 27);
            this.guna2HtmlLabel3.TabIndex = 2;
            this.guna2HtmlLabel3.Text = "Descripción:";
            this.guna2HtmlLabel3.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel6.Controls.Add(this.guna2HtmlLabel2, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.txtBoxName, 1, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(23, 462);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(594, 51);
            this.tableLayoutPanel6.TabIndex = 35;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(40, 12);
            this.guna2HtmlLabel2.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(84, 27);
            this.guna2HtmlLabel2.TabIndex = 2;
            this.guna2HtmlLabel2.Text = "Nombre:";
            this.guna2HtmlLabel2.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // txtBoxName
            // 
            this.txtBoxName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxName.DefaultText = "";
            this.txtBoxName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtBoxName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtBoxName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtBoxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBoxName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtBoxName.Location = new System.Drawing.Point(240, 3);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.PasswordChar = '\0';
            this.txtBoxName.PlaceholderText = "";
            this.txtBoxName.SelectedText = "";
            this.txtBoxName.Size = new System.Drawing.Size(351, 45);
            this.txtBoxName.TabIndex = 3;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel9.Controls.Add(this.lblCoordinate, 0, 0);
            this.tableLayoutPanel9.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(23, 631);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(594, 65);
            this.tableLayoutPanel9.TabIndex = 45;
            // 
            // lblCoordinate
            // 
            this.lblCoordinate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCoordinate.BackColor = System.Drawing.Color.Transparent;
            this.lblCoordinate.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.lblCoordinate.Location = new System.Drawing.Point(40, 19);
            this.lblCoordinate.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.lblCoordinate.Name = "lblCoordinate";
            this.lblCoordinate.Size = new System.Drawing.Size(64, 27);
            this.lblCoordinate.TabIndex = 1;
            this.lblCoordinate.Text = "Lugar:";
            this.lblCoordinate.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.comboBoxCoordinates, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnAddCoordinate, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(240, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(351, 59);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // comboBoxCoordinates
            // 
            this.comboBoxCoordinates.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxCoordinates.BackColor = System.Drawing.Color.Transparent;
            this.comboBoxCoordinates.BorderRadius = 15;
            this.comboBoxCoordinates.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxCoordinates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCoordinates.FillColor = System.Drawing.Color.LightSeaGreen;
            this.comboBoxCoordinates.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxCoordinates.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBoxCoordinates.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBoxCoordinates.ForeColor = System.Drawing.Color.White;
            this.comboBoxCoordinates.ItemHeight = 30;
            this.comboBoxCoordinates.Location = new System.Drawing.Point(3, 11);
            this.comboBoxCoordinates.Name = "comboBoxCoordinates";
            this.comboBoxCoordinates.Size = new System.Drawing.Size(274, 36);
            this.comboBoxCoordinates.TabIndex = 2;
            // 
            // btnAddCoordinate
            // 
            this.btnAddCoordinate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnAddCoordinate.Animated = true;
            this.btnAddCoordinate.BorderRadius = 25;
            this.btnAddCoordinate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddCoordinate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddCoordinate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddCoordinate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddCoordinate.FillColor = System.Drawing.Color.LightSeaGreen;
            this.btnAddCoordinate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddCoordinate.ForeColor = System.Drawing.Color.White;
            this.btnAddCoordinate.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCoordinate.Image")));
            this.btnAddCoordinate.Location = new System.Drawing.Point(298, 4);
            this.btnAddCoordinate.Name = "btnAddCoordinate";
            this.btnAddCoordinate.Size = new System.Drawing.Size(50, 50);
            this.btnAddCoordinate.TabIndex = 46;
            this.btnAddCoordinate.Click += new System.EventHandler(this.btnAddCoordinate_Click);
            // 
            // tableLayoutPanel24
            // 
            this.tableLayoutPanel24.ColumnCount = 2;
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel24.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel24.Controls.Add(this.guna2HtmlLabelIng, 0, 0);
            this.tableLayoutPanel24.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel24.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel24.Location = new System.Drawing.Point(23, 702);
            this.tableLayoutPanel24.Name = "tableLayoutPanel24";
            this.tableLayoutPanel24.RowCount = 1;
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel24.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel24.Size = new System.Drawing.Size(594, 78);
            this.tableLayoutPanel24.TabIndex = 12;
            // 
            // guna2HtmlLabelIng
            // 
            this.guna2HtmlLabelIng.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.guna2HtmlLabelIng.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabelIng.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.guna2HtmlLabelIng.Location = new System.Drawing.Point(40, 25);
            this.guna2HtmlLabelIng.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
            this.guna2HtmlLabelIng.Name = "guna2HtmlLabelIng";
            this.guna2HtmlLabelIng.Size = new System.Drawing.Size(80, 27);
            this.guna2HtmlLabelIng.TabIndex = 1;
            this.guna2HtmlLabelIng.Text = "Fechas:";
            this.guna2HtmlLabelIng.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.DateTimePickerFinal, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.guna2HtmlLabel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.guna2HtmlLabel4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.DateTimePickerStart, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(240, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(351, 72);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // DateTimePickerFinal
            // 
            this.DateTimePickerFinal.AutoRoundedCorners = true;
            this.DateTimePickerFinal.BorderRadius = 14;
            this.DateTimePickerFinal.Checked = true;
            this.DateTimePickerFinal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateTimePickerFinal.FillColor = System.Drawing.Color.LightSeaGreen;
            this.DateTimePickerFinal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DateTimePickerFinal.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DateTimePickerFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimePickerFinal.Location = new System.Drawing.Point(178, 39);
            this.DateTimePickerFinal.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DateTimePickerFinal.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DateTimePickerFinal.Name = "DateTimePickerFinal";
            this.DateTimePickerFinal.Size = new System.Drawing.Size(170, 30);
            this.DateTimePickerFinal.TabIndex = 5;
            this.DateTimePickerFinal.Value = new System.DateTime(2024, 11, 20, 9, 48, 38, 478);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(58, 4);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(59, 27);
            this.guna2HtmlLabel1.TabIndex = 2;
            this.guna2HtmlLabel1.Text = "Inicio:";
            this.guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // guna2HtmlLabel4
            // 
            this.guna2HtmlLabel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel4.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.guna2HtmlLabel4.Location = new System.Drawing.Point(235, 4);
            this.guna2HtmlLabel4.Name = "guna2HtmlLabel4";
            this.guna2HtmlLabel4.Size = new System.Drawing.Size(56, 27);
            this.guna2HtmlLabel4.TabIndex = 3;
            this.guna2HtmlLabel4.Text = "Final:";
            this.guna2HtmlLabel4.TextAlignment = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // DateTimePickerStart
            // 
            this.DateTimePickerStart.AutoRoundedCorners = true;
            this.DateTimePickerStart.BorderRadius = 14;
            this.DateTimePickerStart.Checked = true;
            this.DateTimePickerStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DateTimePickerStart.FillColor = System.Drawing.Color.LightSeaGreen;
            this.DateTimePickerStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.DateTimePickerStart.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateTimePickerStart.Location = new System.Drawing.Point(3, 39);
            this.DateTimePickerStart.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.DateTimePickerStart.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.DateTimePickerStart.Name = "DateTimePickerStart";
            this.DateTimePickerStart.Size = new System.Drawing.Size(169, 30);
            this.DateTimePickerStart.TabIndex = 4;
            this.DateTimePickerStart.Value = new System.DateTime(2024, 11, 20, 9, 53, 48, 561);
            // 
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.ColumnCount = 2;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel20.Controls.Add(this.btnClose, 0, 0);
            this.tableLayoutPanel20.Controls.Add(this.btnAddFestival, 1, 0);
            this.tableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel20.Location = new System.Drawing.Point(23, 786);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 1;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.Size = new System.Drawing.Size(594, 68);
            this.tableLayoutPanel20.TabIndex = 33;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.Animated = true;
            this.btnClose.BorderRadius = 25;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Crimson;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(123, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(50, 50);
            this.btnClose.TabIndex = 24;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddFestival
            // 
            this.btnAddFestival.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddFestival.Animated = true;
            this.btnAddFestival.BorderRadius = 25;
            this.btnAddFestival.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddFestival.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddFestival.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddFestival.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddFestival.FillColor = System.Drawing.Color.LightSeaGreen;
            this.btnAddFestival.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddFestival.ForeColor = System.Drawing.Color.White;
            this.btnAddFestival.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFestival.Image")));
            this.btnAddFestival.Location = new System.Drawing.Point(420, 9);
            this.btnAddFestival.Name = "btnAddFestival";
            this.btnAddFestival.Size = new System.Drawing.Size(50, 50);
            this.btnAddFestival.TabIndex = 27;
            this.btnAddFestival.Click += new System.EventHandler(this.btnAddFestival_Click);
            // 
            // imageSlider
            // 
            this.imageSlider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageSlider.images = null;
            this.imageSlider.Location = new System.Drawing.Point(23, 62);
            this.imageSlider.Name = "imageSlider";
            this.imageSlider.Size = new System.Drawing.Size(594, 394);
            this.imageSlider.TabIndex = 46;
            // 
            // FormAddEditFestival
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 880);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAddEditFestival";
            this.Text = "Festival";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel24.ResumeLayout(false);
            this.tableLayoutPanel24.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel20.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel10;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxDesciption;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel20;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnAddFestival;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel24;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabelIng;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2TextBox txtBoxName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCoordinate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel4;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateTimePickerFinal;
        private Guna.UI2.WinForms.Guna2DateTimePicker DateTimePickerStart;
        private Guna.UI2.WinForms.Guna2ComboBox comboBoxCoordinates;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Guna.UI2.WinForms.Guna2Button btnAddCoordinate;
        private Forms.Commons.ImageSlider imageSlider;
    }
}
