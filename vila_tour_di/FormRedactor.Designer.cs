
namespace vila_tour_di {
    partial class FormRedactor {
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnRecipes = new System.Windows.Forms.Button();
            this.btnFestivals = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnPlaces = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.7732F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.22681F));
            this.tableLayoutPanel1.Controls.Add(this.btnLogOut, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnRecipes, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnFestivals, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblWelcome, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnPlaces, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnLogOut
            // 
            this.btnLogOut.AutoSize = true;
            this.btnLogOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogOut.Location = new System.Drawing.Point(10, 458);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(10);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Padding = new System.Windows.Forms.Padding(25);
            this.btnLogOut.Size = new System.Drawing.Size(182, 93);
            this.btnLogOut.TabIndex = 5;
            this.btnLogOut.Text = "Salir";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnRecipes
            // 
            this.btnRecipes.AutoSize = true;
            this.btnRecipes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecipes.Location = new System.Drawing.Point(10, 346);
            this.btnRecipes.Margin = new System.Windows.Forms.Padding(10);
            this.btnRecipes.Name = "btnRecipes";
            this.btnRecipes.Padding = new System.Windows.Forms.Padding(25);
            this.btnRecipes.Size = new System.Drawing.Size(182, 92);
            this.btnRecipes.TabIndex = 4;
            this.btnRecipes.Text = "Gestionar recetas";
            this.btnRecipes.UseVisualStyleBackColor = true;
            this.btnRecipes.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnFestivals
            // 
            this.btnFestivals.AutoSize = true;
            this.btnFestivals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFestivals.Location = new System.Drawing.Point(10, 234);
            this.btnFestivals.Margin = new System.Windows.Forms.Padding(10);
            this.btnFestivals.Name = "btnFestivals";
            this.btnFestivals.Padding = new System.Windows.Forms.Padding(25);
            this.btnFestivals.Size = new System.Drawing.Size(182, 92);
            this.btnFestivals.TabIndex = 3;
            this.btnFestivals.Text = "Gestionar fiestas y tradiciones";
            this.btnFestivals.UseVisualStyleBackColor = true;
            this.btnFestivals.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(205, 3);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 5);
            this.panel1.Size = new System.Drawing.Size(576, 555);
            this.panel1.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWelcome.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(3, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(196, 112);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Bienvenido XXX:";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPlaces
            // 
            this.btnPlaces.AutoSize = true;
            this.btnPlaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlaces.Location = new System.Drawing.Point(10, 122);
            this.btnPlaces.Margin = new System.Windows.Forms.Padding(10);
            this.btnPlaces.Name = "btnPlaces";
            this.btnPlaces.Padding = new System.Windows.Forms.Padding(25);
            this.btnPlaces.Size = new System.Drawing.Size(182, 92);
            this.btnPlaces.TabIndex = 2;
            this.btnPlaces.Text = "Gestionar lugares";
            this.btnPlaces.UseVisualStyleBackColor = true;
            this.btnPlaces.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormRedactor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FormRedactor";
            this.Text = "Redactor";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnPlaces;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnRecipes;
        private System.Windows.Forms.Button btnFestivals;
    }
}