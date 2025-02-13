
namespace vila_tour_di.Forms.Commons {
    partial class FormReport {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReport));
            this.axAcroPDF = new AxAcroPDFLib.AxAcroPDF();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtName = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeleteFilter = new Guna.UI2.WinForms.Guna2Button();
            this.lblCat = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.comboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnAddFilter = new Guna.UI2.WinForms.Guna2Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.btnCrear = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // axAcroPDF
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.axAcroPDF, 2);
            this.axAcroPDF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcroPDF.Enabled = true;
            this.axAcroPDF.Location = new System.Drawing.Point(23, 163);
            this.axAcroPDF.Name = "axAcroPDF";
            this.axAcroPDF.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcroPDF.OcxState")));
            this.axAcroPDF.Size = new System.Drawing.Size(601, 517);
            this.axAcroPDF.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Controls.Add(this.axAcroPDF, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtName, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.guna2HtmlLabel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.listBox, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCrear, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.366984F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.09823F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.53479F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(654, 754);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtName.DefaultText = "";
            this.txtName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtName.Location = new System.Drawing.Point(254, 7);
            this.txtName.Name = "txtName";
            this.txtName.PasswordChar = '\0';
            this.txtName.PlaceholderText = "";
            this.txtName.SelectedText = "";
            this.txtName.Size = new System.Drawing.Size(320, 36);
            this.txtName.TabIndex = 2;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(89, 17);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(43, 15);
            this.guna2HtmlLabel1.TabIndex = 3;
            this.guna2HtmlLabel1.Text = "Nombre:";
            this.guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnDeleteFilter, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblCat, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnAddFilter, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(23, 53);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(176, 104);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // btnDeleteFilter
            // 
            this.btnDeleteFilter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDeleteFilter.Animated = true;
            this.btnDeleteFilter.BorderRadius = 25;
            this.btnDeleteFilter.CustomizableEdges.BottomLeft = false;
            this.btnDeleteFilter.CustomizableEdges.BottomRight = false;
            this.btnDeleteFilter.CustomizableEdges.TopLeft = false;
            this.btnDeleteFilter.CustomizableEdges.TopRight = false;
            this.btnDeleteFilter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteFilter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeleteFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeleteFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeleteFilter.FillColor = System.Drawing.Color.Crimson;
            this.btnDeleteFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDeleteFilter.ForeColor = System.Drawing.Color.White;
            this.btnDeleteFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteFilter.Image")));
            this.btnDeleteFilter.Location = new System.Drawing.Point(18, 78);
            this.btnDeleteFilter.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnDeleteFilter.Name = "btnDeleteFilter";
            this.btnDeleteFilter.Size = new System.Drawing.Size(52, 23);
            this.btnDeleteFilter.TabIndex = 8;
            this.btnDeleteFilter.Click += new System.EventHandler(this.btnDeleteFilter_Click);
            // 
            // lblCat
            // 
            this.lblCat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCat.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.SetColumnSpan(this.lblCat, 2);
            this.lblCat.Location = new System.Drawing.Point(66, 9);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(43, 15);
            this.lblCat.TabIndex = 5;
            this.lblCat.Text = "Nombre:";
            this.lblCat.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox
            // 
            this.comboBox.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.SetColumnSpan(this.comboBox, 2);
            this.comboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.comboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.comboBox.ItemHeight = 30;
            this.comboBox.Location = new System.Drawing.Point(3, 37);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(170, 36);
            this.comboBox.TabIndex = 6;
            // 
            // btnAddFilter
            // 
            this.btnAddFilter.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddFilter.Animated = true;
            this.btnAddFilter.BorderRadius = 25;
            this.btnAddFilter.CustomizableEdges.BottomLeft = false;
            this.btnAddFilter.CustomizableEdges.BottomRight = false;
            this.btnAddFilter.CustomizableEdges.TopLeft = false;
            this.btnAddFilter.CustomizableEdges.TopRight = false;
            this.btnAddFilter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddFilter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddFilter.FillColor = System.Drawing.Color.LightSeaGreen;
            this.btnAddFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddFilter.ForeColor = System.Drawing.Color.White;
            this.btnAddFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFilter.Image")));
            this.btnAddFilter.Location = new System.Drawing.Point(107, 78);
            this.btnAddFilter.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnAddFilter.Name = "btnAddFilter";
            this.btnAddFilter.Size = new System.Drawing.Size(50, 23);
            this.btnAddFilter.TabIndex = 7;
            this.btnAddFilter.Click += new System.EventHandler(this.btnAddFilter_Click);
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.HorizontalScrollbar = true;
            this.listBox.Location = new System.Drawing.Point(257, 75);
            this.listBox.Margin = new System.Windows.Forms.Padding(55, 25, 25, 25);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(319, 56);
            this.listBox.TabIndex = 8;
            // 
            // btnCrear
            // 
            this.btnCrear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCrear.Animated = true;
            this.btnCrear.BorderRadius = 25;
            this.btnCrear.CustomizableEdges.BottomLeft = false;
            this.btnCrear.CustomizableEdges.BottomRight = false;
            this.btnCrear.CustomizableEdges.TopLeft = false;
            this.btnCrear.CustomizableEdges.TopRight = false;
            this.btnCrear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCrear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCrear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCrear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCrear.FillColor = System.Drawing.Color.LightSeaGreen;
            this.btnCrear.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCrear.ForeColor = System.Drawing.Color.White;
            this.btnCrear.Image = ((System.Drawing.Image)(resources.GetObject("btnCrear.Image")));
            this.btnCrear.Location = new System.Drawing.Point(389, 693);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(50, 23);
            this.btnCrear.TabIndex = 9;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 754);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReport";
            this.Text = "Informes";
            ((System.ComponentModel.ISupportInitialize)(this.axAcroPDF)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF axAcroPDF;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2TextBox txtName;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblCat;
        private Guna.UI2.WinForms.Guna2ComboBox comboBox;
        private Guna.UI2.WinForms.Guna2Button btnAddFilter;
        private Guna.UI2.WinForms.Guna2Button btnDeleteFilter;
        private System.Windows.Forms.ListBox listBox;
        private Guna.UI2.WinForms.Guna2Button btnCrear;
    }
}