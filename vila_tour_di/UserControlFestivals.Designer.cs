
namespace vila_tour_di {
    partial class panelFiestas {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent() {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDelFiesta = new System.Windows.Forms.Button();
            this.buttonSeeFiesta = new System.Windows.Forms.Button();
            this.buttonModdFiesta = new System.Windows.Forms.Button();
            this.labelFiestas = new System.Windows.Forms.Label();
            this.buttonAddFiesta = new System.Windows.Forms.Button();
            this.dataGridViewFestivals = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFestivals)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.buttonDelFiesta, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonSeeFiesta, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonModdFiesta, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelFiestas, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddFiesta, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewFestivals, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(576, 555);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonDelFiesta
            // 
            this.buttonDelFiesta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelFiesta.Location = new System.Drawing.Point(423, 463);
            this.buttonDelFiesta.Margin = new System.Windows.Forms.Padding(20);
            this.buttonDelFiesta.Name = "buttonDelFiesta";
            this.buttonDelFiesta.Size = new System.Drawing.Size(133, 72);
            this.buttonDelFiesta.TabIndex = 8;
            this.buttonDelFiesta.Text = "Elimninar Fiesta/Tradicion";
            this.buttonDelFiesta.UseVisualStyleBackColor = true;
            this.buttonDelFiesta.Click += new System.EventHandler(this.buttonDelFiesta_Click);
            // 
            // buttonSeeFiesta
            // 
            this.buttonSeeFiesta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSeeFiesta.Location = new System.Drawing.Point(423, 352);
            this.buttonSeeFiesta.Margin = new System.Windows.Forms.Padding(20);
            this.buttonSeeFiesta.Name = "buttonSeeFiesta";
            this.buttonSeeFiesta.Size = new System.Drawing.Size(133, 71);
            this.buttonSeeFiesta.TabIndex = 6;
            this.buttonSeeFiesta.Text = "Ver Fiesta/Tradicion";
            this.buttonSeeFiesta.UseVisualStyleBackColor = true;
            this.buttonSeeFiesta.Click += new System.EventHandler(this.buttonSeeFiesta_Click);
            // 
            // buttonModdFiesta
            // 
            this.buttonModdFiesta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonModdFiesta.Location = new System.Drawing.Point(423, 241);
            this.buttonModdFiesta.Margin = new System.Windows.Forms.Padding(20);
            this.buttonModdFiesta.Name = "buttonModdFiesta";
            this.buttonModdFiesta.Size = new System.Drawing.Size(133, 71);
            this.buttonModdFiesta.TabIndex = 4;
            this.buttonModdFiesta.Text = "Modificar Fiesta/Tradicion";
            this.buttonModdFiesta.UseVisualStyleBackColor = true;
            this.buttonModdFiesta.Click += new System.EventHandler(this.buttonModdFiesta_Click);
            // 
            // labelFiestas
            // 
            this.labelFiestas.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelFiestas, 2);
            this.labelFiestas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelFiestas.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFiestas.Location = new System.Drawing.Point(3, 0);
            this.labelFiestas.Name = "labelFiestas";
            this.labelFiestas.Size = new System.Drawing.Size(570, 55);
            this.labelFiestas.TabIndex = 0;
            this.labelFiestas.Text = "Fietas y Tradiciones";
            this.labelFiestas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAddFiesta
            // 
            this.buttonAddFiesta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddFiesta.Location = new System.Drawing.Point(423, 130);
            this.buttonAddFiesta.Margin = new System.Windows.Forms.Padding(20);
            this.buttonAddFiesta.Name = "buttonAddFiesta";
            this.buttonAddFiesta.Size = new System.Drawing.Size(133, 71);
            this.buttonAddFiesta.TabIndex = 1;
            this.buttonAddFiesta.Text = "Añadir Fiesta/Tradicion";
            this.buttonAddFiesta.UseVisualStyleBackColor = true;
            this.buttonAddFiesta.Click += new System.EventHandler(this.buttonAddFiesta_Click);
            // 
            // dataGridViewFestivals
            // 
            this.dataGridViewFestivals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFestivals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFestivals.Location = new System.Drawing.Point(3, 113);
            this.dataGridViewFestivals.Name = "dataGridViewFestivals";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridViewFestivals, 4);
            this.dataGridViewFestivals.Size = new System.Drawing.Size(397, 439);
            this.dataGridViewFestivals.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 58);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(397, 49);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(53, 43);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(77, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(302, 20);
            this.textBox1.TabIndex = 1;
            // 
            // panelFiestas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "panelFiestas";
            this.Size = new System.Drawing.Size(576, 555);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFestivals)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelFiestas;
        private System.Windows.Forms.Button buttonAddFiesta;
        private System.Windows.Forms.Button buttonDelFiesta;
        private System.Windows.Forms.Button buttonSeeFiesta;
        private System.Windows.Forms.Button buttonModdFiesta;
        private System.Windows.Forms.DataGridView dataGridViewFestivals;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}
