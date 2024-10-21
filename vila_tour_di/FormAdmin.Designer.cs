
namespace vila_tour_di
{
    partial class FormAdmin
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnAdminUsers = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAdminPlace = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAdminRoutes = new System.Windows.Forms.Button();
            this.btnAdminRecipes = new System.Windows.Forms.Button();
            this.btnAdminTraditions = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.btnAdminUsers, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnExit, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnAdminPlace, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblWelcome, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnAdminRoutes, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnAdminRecipes, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAdminTraditions, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.34483F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.94253F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.94253F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.94253F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.94253F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.94253F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.94253F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 561);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnAdminUsers
            // 
            this.btnAdminUsers.AutoSize = true;
            this.btnAdminUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdminUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminUsers.Location = new System.Drawing.Point(10, 400);
            this.btnAdminUsers.Margin = new System.Windows.Forms.Padding(10);
            this.btnAdminUsers.Name = "btnAdminUsers";
            this.btnAdminUsers.Size = new System.Drawing.Size(176, 63);
            this.btnAdminUsers.TabIndex = 6;
            this.btnAdminUsers.Text = "Usuarios";
            this.btnAdminUsers.UseVisualStyleBackColor = true;
            this.btnAdminUsers.Click += new System.EventHandler(this.btnAdminUsers_Click);
            // 
            // btnExit
            // 
            this.btnExit.AutoSize = true;
            this.btnExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(10, 483);
            this.btnExit.Margin = new System.Windows.Forms.Padding(10);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(176, 68);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAdminPlace
            // 
            this.btnAdminPlace.AutoSize = true;
            this.btnAdminPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdminPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminPlace.Location = new System.Drawing.Point(10, 68);
            this.btnAdminPlace.Margin = new System.Windows.Forms.Padding(10);
            this.btnAdminPlace.Name = "btnAdminPlace";
            this.btnAdminPlace.Size = new System.Drawing.Size(176, 63);
            this.btnAdminPlace.TabIndex = 0;
            this.btnAdminPlace.Text = "Lugares";
            this.btnAdminPlace.UseVisualStyleBackColor = true;
            this.btnAdminPlace.Click += new System.EventHandler(this.btnAdminPlace_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWelcome.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Location = new System.Drawing.Point(3, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(190, 58);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Bienvenido, XXX";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(199, 3);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 7);
            this.panel1.Size = new System.Drawing.Size(582, 555);
            this.panel1.TabIndex = 0;
            // 
            // btnAdminRoutes
            // 
            this.btnAdminRoutes.AutoSize = true;
            this.btnAdminRoutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdminRoutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminRoutes.Location = new System.Drawing.Point(10, 317);
            this.btnAdminRoutes.Margin = new System.Windows.Forms.Padding(10);
            this.btnAdminRoutes.Name = "btnAdminRoutes";
            this.btnAdminRoutes.Size = new System.Drawing.Size(176, 63);
            this.btnAdminRoutes.TabIndex = 3;
            this.btnAdminRoutes.Text = "Rutas";
            this.btnAdminRoutes.UseVisualStyleBackColor = true;
            this.btnAdminRoutes.Click += new System.EventHandler(this.btnAdminRoutes_Click);
            // 
            // btnAdminRecipes
            // 
            this.btnAdminRecipes.AutoSize = true;
            this.btnAdminRecipes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdminRecipes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminRecipes.Location = new System.Drawing.Point(10, 234);
            this.btnAdminRecipes.Margin = new System.Windows.Forms.Padding(10);
            this.btnAdminRecipes.Name = "btnAdminRecipes";
            this.btnAdminRecipes.Size = new System.Drawing.Size(176, 63);
            this.btnAdminRecipes.TabIndex = 2;
            this.btnAdminRecipes.Text = "Recetas";
            this.btnAdminRecipes.UseVisualStyleBackColor = true;
            this.btnAdminRecipes.Click += new System.EventHandler(this.btnAdminRecipes_Click);
            // 
            // btnAdminTraditions
            // 
            this.btnAdminTraditions.AutoSize = true;
            this.btnAdminTraditions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAdminTraditions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdminTraditions.Location = new System.Drawing.Point(10, 151);
            this.btnAdminTraditions.Margin = new System.Windows.Forms.Padding(10);
            this.btnAdminTraditions.Name = "btnAdminTraditions";
            this.btnAdminTraditions.Size = new System.Drawing.Size(176, 63);
            this.btnAdminTraditions.TabIndex = 1;
            this.btnAdminTraditions.Text = "Fiestas y tradiciones";
            this.btnAdminTraditions.UseVisualStyleBackColor = true;
            this.btnAdminTraditions.Click += new System.EventHandler(this.btnAdminTraditions_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form3";
            this.Text = "Administrador";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAdminPlace;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAdminRoutes;
        private System.Windows.Forms.Button btnAdminRecipes;
        private System.Windows.Forms.Button btnAdminTraditions;
        private System.Windows.Forms.Button btnAdminUsers;
        private System.Windows.Forms.Button btnExit;
    }
}