
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
            this.lblLugares = new System.Windows.Forms.Label();
            this.buttonAddPlace = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.buttonDelPlace, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonSeePlace, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonModPLace, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLugares, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddPlace, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(576, 555);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonDelPlace
            // 
            this.buttonDelPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelPlace.Location = new System.Drawing.Point(423, 464);
            this.buttonDelPlace.Margin = new System.Windows.Forms.Padding(20);
            this.buttonDelPlace.Name = "buttonDelPlace";
            this.buttonDelPlace.Size = new System.Drawing.Size(133, 71);
            this.buttonDelPlace.TabIndex = 8;
            this.buttonDelPlace.Text = "Eliminar Lugar";
            this.buttonDelPlace.UseVisualStyleBackColor = true;
            // 
            // buttonSeePlace
            // 
            this.buttonSeePlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSeePlace.Location = new System.Drawing.Point(423, 353);
            this.buttonSeePlace.Margin = new System.Windows.Forms.Padding(20);
            this.buttonSeePlace.Name = "buttonSeePlace";
            this.buttonSeePlace.Size = new System.Drawing.Size(133, 71);
            this.buttonSeePlace.TabIndex = 6;
            this.buttonSeePlace.Text = "Ver detalles del Lugar";
            this.buttonSeePlace.UseVisualStyleBackColor = true;
            // 
            // buttonModPLace
            // 
            this.buttonModPLace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonModPLace.Location = new System.Drawing.Point(423, 242);
            this.buttonModPLace.Margin = new System.Windows.Forms.Padding(20);
            this.buttonModPLace.Name = "buttonModPLace";
            this.buttonModPLace.Size = new System.Drawing.Size(133, 71);
            this.buttonModPLace.TabIndex = 4;
            this.buttonModPLace.Text = "Modificar Lugar";
            this.buttonModPLace.UseVisualStyleBackColor = true;
            // 
            // lblLugares
            // 
            this.lblLugares.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblLugares, 2);
            this.lblLugares.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.lblLugares.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLugares.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLugares.Location = new System.Drawing.Point(3, 0);
            this.lblLugares.Name = "lblLugares";
            this.lblLugares.Size = new System.Drawing.Size(570, 111);
            this.lblLugares.TabIndex = 0;
            this.lblLugares.Text = "Lugares";
            this.lblLugares.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonAddPlace
            // 
            this.buttonAddPlace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddPlace.Location = new System.Drawing.Point(423, 131);
            this.buttonAddPlace.Margin = new System.Windows.Forms.Padding(20);
            this.buttonAddPlace.Name = "buttonAddPlace";
            this.buttonAddPlace.Size = new System.Drawing.Size(133, 71);
            this.buttonAddPlace.TabIndex = 1;
            this.buttonAddPlace.Text = "Añadir Lugar";
            this.buttonAddPlace.UseVisualStyleBackColor = true;
            // 
            // panelLugares
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "panelLugares";
            this.Size = new System.Drawing.Size(576, 555);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonDelPlace;
        private System.Windows.Forms.Button buttonSeePlace;
        private System.Windows.Forms.Button buttonModPLace;
        private System.Windows.Forms.Label lblLugares;
        private System.Windows.Forms.Button buttonAddPlace;
    }
}
