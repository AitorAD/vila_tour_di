
namespace vila_tour_di {
    partial class formIngredient {
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
            this.buttonDelIngredient = new System.Windows.Forms.Button();
            this.buttonSeeIngredient = new System.Windows.Forms.Button();
            this.buttonModIngredient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonAddIngredient = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.buttonClose, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonDelIngredient, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonSeeIngredient, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonModIngredient, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddIngredient, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 485);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonDelIngredient
            // 
            this.buttonDelIngredient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelIngredient.Location = new System.Drawing.Point(365, 324);
            this.buttonDelIngredient.Margin = new System.Windows.Forms.Padding(15);
            this.buttonDelIngredient.Name = "buttonDelIngredient";
            this.buttonDelIngredient.Size = new System.Drawing.Size(120, 57);
            this.buttonDelIngredient.TabIndex = 5;
            this.buttonDelIngredient.Text = "Eliminar Ingrediente";
            this.buttonDelIngredient.UseVisualStyleBackColor = true;
            this.buttonDelIngredient.Click += new System.EventHandler(this.buttonDelIngredient_Click);
            // 
            // buttonSeeIngredient
            // 
            this.buttonSeeIngredient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSeeIngredient.Location = new System.Drawing.Point(365, 237);
            this.buttonSeeIngredient.Margin = new System.Windows.Forms.Padding(15);
            this.buttonSeeIngredient.Name = "buttonSeeIngredient";
            this.buttonSeeIngredient.Size = new System.Drawing.Size(120, 57);
            this.buttonSeeIngredient.TabIndex = 4;
            this.buttonSeeIngredient.Text = "Ver Ingrediente";
            this.buttonSeeIngredient.UseVisualStyleBackColor = true;
            this.buttonSeeIngredient.Click += new System.EventHandler(this.buttonSeeIngredient_Click);
            // 
            // buttonModIngredient
            // 
            this.buttonModIngredient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonModIngredient.Location = new System.Drawing.Point(365, 150);
            this.buttonModIngredient.Margin = new System.Windows.Forms.Padding(15);
            this.buttonModIngredient.Name = "buttonModIngredient";
            this.buttonModIngredient.Size = new System.Drawing.Size(120, 57);
            this.buttonModIngredient.TabIndex = 3;
            this.buttonModIngredient.Text = "Modificar Ingrediente";
            this.buttonModIngredient.UseVisualStyleBackColor = true;
            this.buttonModIngredient.Click += new System.EventHandler(this.buttonModIngredient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(494, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingredientes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 51);
            this.dataGridView1.Name = "dataGridView1";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 5);
            this.dataGridView1.Size = new System.Drawing.Size(344, 431);
            this.dataGridView1.TabIndex = 1;
            // 
            // buttonAddIngredient
            // 
            this.buttonAddIngredient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddIngredient.Location = new System.Drawing.Point(365, 63);
            this.buttonAddIngredient.Margin = new System.Windows.Forms.Padding(15);
            this.buttonAddIngredient.Name = "buttonAddIngredient";
            this.buttonAddIngredient.Size = new System.Drawing.Size(120, 57);
            this.buttonAddIngredient.TabIndex = 2;
            this.buttonAddIngredient.Text = "Añadir Ingrediente";
            this.buttonAddIngredient.UseVisualStyleBackColor = true;
            this.buttonAddIngredient.Click += new System.EventHandler(this.buttonAddIngredient_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClose.Location = new System.Drawing.Point(365, 411);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(15);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(120, 59);
            this.buttonClose.TabIndex = 6;
            this.buttonClose.Text = "Cerrar";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // formIngredient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 485);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "formIngredient";
            this.Text = "Ingredientes";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDelIngredient;
        private System.Windows.Forms.Button buttonSeeIngredient;
        private System.Windows.Forms.Button buttonModIngredient;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonAddIngredient;
        private System.Windows.Forms.Button buttonClose;
    }
}