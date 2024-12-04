
namespace vila_tour_di
{
    partial class FormAddEditCoordinate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddEditCoordinate));
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.bttbAddIngredient = new Guna.UI2.WinForms.Guna2Button();
            this.bttnSalir = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2TextBoxName = new Guna.UI2.WinForms.Guna2TextBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLat = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblLong = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(72, 119);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(549, 257);
            this.gMapControl1.TabIndex = 0;
            this.gMapControl1.Zoom = 0D;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gMapControl1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.63636F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.545455F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.90909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.63636F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.63636F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.545455F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(694, 643);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.BackColor = System.Drawing.Color.LightSeaGreen;
            this.tableLayoutPanel1.SetColumnSpan(this.labelTitle, 3);
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(3, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(688, 87);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "Añadir/Editar/Detalles Lugar";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.bttbAddIngredient, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.bttnSalir, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(72, 527);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(549, 81);
            this.tableLayoutPanel4.TabIndex = 25;
            // 
            // bttbAddIngredient
            // 
            this.bttbAddIngredient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bttbAddIngredient.Animated = true;
            this.bttbAddIngredient.BorderRadius = 25;
            this.bttbAddIngredient.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bttbAddIngredient.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bttbAddIngredient.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bttbAddIngredient.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bttbAddIngredient.FillColor = System.Drawing.Color.LightSeaGreen;
            this.bttbAddIngredient.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bttbAddIngredient.ForeColor = System.Drawing.Color.White;
            this.bttbAddIngredient.Image = ((System.Drawing.Image)(resources.GetObject("bttbAddIngredient.Image")));
            this.bttbAddIngredient.Location = new System.Drawing.Point(386, 15);
            this.bttbAddIngredient.Name = "bttbAddIngredient";
            this.bttbAddIngredient.Size = new System.Drawing.Size(50, 50);
            this.bttbAddIngredient.TabIndex = 22;
            // 
            // bttnSalir
            // 
            this.bttnSalir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bttnSalir.Animated = true;
            this.bttnSalir.BorderRadius = 25;
            this.bttnSalir.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.bttnSalir.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.bttnSalir.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.bttnSalir.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.bttnSalir.FillColor = System.Drawing.Color.Crimson;
            this.bttnSalir.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bttnSalir.ForeColor = System.Drawing.Color.White;
            this.bttnSalir.Image = ((System.Drawing.Image)(resources.GetObject("bttnSalir.Image")));
            this.bttnSalir.Location = new System.Drawing.Point(112, 15);
            this.bttnSalir.Name = "bttnSalir";
            this.bttnSalir.Size = new System.Drawing.Size(50, 50);
            this.bttnSalir.TabIndex = 21;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Controls.Add(this.guna2HtmlLabel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.guna2TextBoxName, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(72, 382);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(549, 81);
            this.tableLayoutPanel2.TabIndex = 26;
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F);
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(132, 25);
            this.guna2HtmlLabel1.Margin = new System.Windows.Forms.Padding(40, 0, 3, 3);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(84, 27);
            this.guna2HtmlLabel1.TabIndex = 0;
            this.guna2HtmlLabel1.Text = "Nombre:";
            // 
            // guna2TextBoxName
            // 
            this.guna2TextBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2TextBoxName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBoxName.DefaultText = "";
            this.guna2TextBoxName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBoxName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBoxName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBoxName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBoxName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBoxName.Location = new System.Drawing.Point(222, 22);
            this.guna2TextBoxName.Name = "guna2TextBoxName";
            this.guna2TextBoxName.PasswordChar = '\0';
            this.guna2TextBoxName.PlaceholderText = "";
            this.guna2TextBoxName.SelectedText = "";
            this.guna2TextBoxName.Size = new System.Drawing.Size(324, 36);
            this.guna2TextBoxName.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lblLat, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblLong, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(72, 469);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(549, 52);
            this.tableLayoutPanel3.TabIndex = 27;
            // 
            // lblLat
            // 
            this.lblLat.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLat.BackColor = System.Drawing.Color.Transparent;
            this.lblLat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLat.Location = new System.Drawing.Point(3, 12);
            this.lblLat.Name = "lblLat";
            this.lblLat.Size = new System.Drawing.Size(67, 27);
            this.lblLat.TabIndex = 0;
            this.lblLat.Text = "Latitud: ";
            // 
            // lblLong
            // 
            this.lblLong.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLong.BackColor = System.Drawing.Color.Transparent;
            this.lblLong.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLong.Location = new System.Drawing.Point(277, 12);
            this.lblLong.Name = "lblLong";
            this.lblLong.Size = new System.Drawing.Size(84, 27);
            this.lblLong.TabIndex = 1;
            this.lblLong.Text = "Longitud: ";
            // 
            // FormAddEditCoordinate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 643);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormAddEditCoordinate";
            this.Text = "Coordenada";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private Guna.UI2.WinForms.Guna2Button bttbAddIngredient;
        private Guna.UI2.WinForms.Guna2Button bttnSalir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBoxName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLat;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblLong;
    }
}