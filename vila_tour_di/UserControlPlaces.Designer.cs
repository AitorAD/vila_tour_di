
namespace vila_tour_di {
    partial class panelLugares {
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
            this.buttonDelPlace = new System.Windows.Forms.Button();
            this.buttonSeePlace = new System.Windows.Forms.Button();
            this.buttonModPLace = new System.Windows.Forms.Button();
            this.buttonAddPlace = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.buttonDelPlace, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonSeePlace, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonModPLace, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddPlace, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
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
            // buttonDelPlace
            // 
            this.buttonDelPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelPlace.Location = new System.Drawing.Point(423, 463);
            this.buttonDelPlace.Margin = new System.Windows.Forms.Padding(20);
            this.buttonDelPlace.Name = "buttonDelPlace";
            this.buttonDelPlace.Size = new System.Drawing.Size(133, 72);
            this.buttonDelPlace.TabIndex = 8;
            this.buttonDelPlace.Text = "Eliminar";
            this.buttonDelPlace.UseVisualStyleBackColor = true;
            // 
            // buttonSeePlace
            // 
            this.buttonSeePlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSeePlace.Location = new System.Drawing.Point(423, 352);
            this.buttonSeePlace.Margin = new System.Windows.Forms.Padding(20);
            this.buttonSeePlace.Name = "buttonSeePlace";
            this.buttonSeePlace.Size = new System.Drawing.Size(133, 71);
            this.buttonSeePlace.TabIndex = 6;
            this.buttonSeePlace.Text = "Ver detalles";
            this.buttonSeePlace.UseVisualStyleBackColor = true;
            // 
            // buttonModPLace
            // 
            this.buttonModPLace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonModPLace.Location = new System.Drawing.Point(423, 241);
            this.buttonModPLace.Margin = new System.Windows.Forms.Padding(20);
            this.buttonModPLace.Name = "buttonModPLace";
            this.buttonModPLace.Size = new System.Drawing.Size(133, 71);
            this.buttonModPLace.TabIndex = 4;
            this.buttonModPLace.Text = "Editar";
            this.buttonModPLace.UseVisualStyleBackColor = true;
            // 
            // buttonAddPlace
            // 
            this.buttonAddPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddPlace.Location = new System.Drawing.Point(423, 130);
            this.buttonAddPlace.Margin = new System.Windows.Forms.Padding(20);
            this.buttonAddPlace.Name = "buttonAddPlace";
            this.buttonAddPlace.Size = new System.Drawing.Size(133, 71);
            this.buttonAddPlace.TabIndex = 1;
            this.buttonAddPlace.Text = "Añadir nuevo";
            this.buttonAddPlace.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 4);
            this.dataGridView1.Size = new System.Drawing.Size(397, 439);
            this.dataGridView1.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 58);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(397, 49);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(82, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(312, 20);
            this.textBox1.TabIndex = 0;
            // 
            // panelLugares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "panelLugares";
            this.Size = new System.Drawing.Size(576, 555);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonDelPlace;
        private System.Windows.Forms.Button buttonSeePlace;
        private System.Windows.Forms.Button buttonModPLace;
        private System.Windows.Forms.Button buttonAddPlace;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
