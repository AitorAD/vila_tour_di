
namespace vila_tour_di.Forms.Recipes {
    partial class FormApproveRecipes {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormApproveRecipes));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tblUnapprovedRecipes = new Guna.UI2.WinForms.Guna2DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDetails = new Guna.UI2.WinForms.Guna2Button();
            this.btnApprove = new Guna.UI2.WinForms.Guna2Button();
            this.btnDisapprove = new Guna.UI2.WinForms.Guna2Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblUnapprovedRecipes)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.99315F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.00685F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tblUnapprovedRecipes, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(625, 531);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tblUnapprovedRecipes
            // 
            this.tblUnapprovedRecipes.AllowUserToAddRows = false;
            this.tblUnapprovedRecipes.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.tblUnapprovedRecipes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.tblUnapprovedRecipes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tblUnapprovedRecipes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.tblUnapprovedRecipes.ColumnHeadersHeight = 20;
            this.tblUnapprovedRecipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tblUnapprovedRecipes.DefaultCellStyle = dataGridViewCellStyle3;
            this.tblUnapprovedRecipes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblUnapprovedRecipes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tblUnapprovedRecipes.Location = new System.Drawing.Point(23, 28);
            this.tblUnapprovedRecipes.Name = "tblUnapprovedRecipes";
            this.tblUnapprovedRecipes.ReadOnly = true;
            this.tblUnapprovedRecipes.RowHeadersVisible = false;
            this.tblUnapprovedRecipes.Size = new System.Drawing.Size(467, 475);
            this.tblUnapprovedRecipes.TabIndex = 18;
            this.tblUnapprovedRecipes.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.tblUnapprovedRecipes.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.tblUnapprovedRecipes.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.tblUnapprovedRecipes.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.tblUnapprovedRecipes.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.tblUnapprovedRecipes.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.tblUnapprovedRecipes.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tblUnapprovedRecipes.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.tblUnapprovedRecipes.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.tblUnapprovedRecipes.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblUnapprovedRecipes.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.tblUnapprovedRecipes.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.tblUnapprovedRecipes.ThemeStyle.HeaderStyle.Height = 20;
            this.tblUnapprovedRecipes.ThemeStyle.ReadOnly = true;
            this.tblUnapprovedRecipes.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.tblUnapprovedRecipes.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.tblUnapprovedRecipes.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblUnapprovedRecipes.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.tblUnapprovedRecipes.ThemeStyle.RowsStyle.Height = 22;
            this.tblUnapprovedRecipes.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.tblUnapprovedRecipes.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.tblUnapprovedRecipes.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tblUnapprovedRecipes_MouseDoubleClick);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnDisapprove, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btnDetails, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnApprove, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(496, 28);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 183F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(105, 475);
            this.tableLayoutPanel2.TabIndex = 19;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // btnDetails
            // 
            this.btnDetails.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDetails.Animated = true;
            this.btnDetails.BorderRadius = 25;
            this.btnDetails.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDetails.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDetails.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDetails.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDetails.FillColor = System.Drawing.Color.LightSeaGreen;
            this.btnDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDetails.ForeColor = System.Drawing.Color.White;
            this.btnDetails.Image = ((System.Drawing.Image)(resources.GetObject("btnDetails.Image")));
            this.btnDetails.Location = new System.Drawing.Point(27, 48);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(50, 50);
            this.btnDetails.TabIndex = 3;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnApprove.Animated = true;
            this.btnApprove.BorderRadius = 25;
            this.btnApprove.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnApprove.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnApprove.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnApprove.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnApprove.FillColor = System.Drawing.Color.SeaGreen;
            this.btnApprove.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnApprove.ForeColor = System.Drawing.Color.White;
            this.btnApprove.Image = ((System.Drawing.Image)(resources.GetObject("btnApprove.Image")));
            this.btnApprove.ImageSize = new System.Drawing.Size(25, 25);
            this.btnApprove.Location = new System.Drawing.Point(27, 194);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(50, 50);
            this.btnApprove.TabIndex = 4;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnDisapprove
            // 
            this.btnDisapprove.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDisapprove.Animated = true;
            this.btnDisapprove.BorderRadius = 25;
            this.btnDisapprove.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDisapprove.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDisapprove.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDisapprove.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDisapprove.FillColor = System.Drawing.Color.Crimson;
            this.btnDisapprove.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDisapprove.ForeColor = System.Drawing.Color.White;
            this.btnDisapprove.Image = ((System.Drawing.Image)(resources.GetObject("btnDisapprove.Image")));
            this.btnDisapprove.Location = new System.Drawing.Point(27, 358);
            this.btnDisapprove.Name = "btnDisapprove";
            this.btnDisapprove.Size = new System.Drawing.Size(50, 50);
            this.btnDisapprove.TabIndex = 22;
            this.btnDisapprove.Click += new System.EventHandler(this.btnDisapprove_Click);
            // 
            // FormApproveRecipes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 531);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormApproveRecipes";
            this.Text = "FormApproveRecipes";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblUnapprovedRecipes)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Guna.UI2.WinForms.Guna2DataGridView tblUnapprovedRecipes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Guna.UI2.WinForms.Guna2Button btnDetails;
        private Guna.UI2.WinForms.Guna2Button btnApprove;
        private Guna.UI2.WinForms.Guna2Button btnDisapprove;
    }
}