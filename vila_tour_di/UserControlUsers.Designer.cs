
namespace vila_tour_di
{
    partial class panelUser
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDeleteUser = new System.Windows.Forms.Button();
            this.buttonDetailsUser = new System.Windows.Forms.Button();
            this.buttonModifyUser = new System.Windows.Forms.Button();
            this.buttonAddUser = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxSearch = new System.Windows.Forms.PictureBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.buttonDeleteUser, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonDetailsUser, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonModifyUser, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddUser, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
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
            // buttonDeleteUser
            // 
            this.buttonDeleteUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDeleteUser.Location = new System.Drawing.Point(423, 463);
            this.buttonDeleteUser.Margin = new System.Windows.Forms.Padding(20);
            this.buttonDeleteUser.Name = "buttonDeleteUser";
            this.buttonDeleteUser.Size = new System.Drawing.Size(133, 72);
            this.buttonDeleteUser.TabIndex = 5;
            this.buttonDeleteUser.Text = "Eliminar";
            this.buttonDeleteUser.UseVisualStyleBackColor = true;
            // 
            // buttonDetailsUser
            // 
            this.buttonDetailsUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDetailsUser.Location = new System.Drawing.Point(423, 352);
            this.buttonDetailsUser.Margin = new System.Windows.Forms.Padding(20);
            this.buttonDetailsUser.Name = "buttonDetailsUser";
            this.buttonDetailsUser.Size = new System.Drawing.Size(133, 71);
            this.buttonDetailsUser.TabIndex = 4;
            this.buttonDetailsUser.Text = "Ver detalles";
            this.buttonDetailsUser.UseVisualStyleBackColor = true;
            // 
            // buttonModifyUser
            // 
            this.buttonModifyUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonModifyUser.Location = new System.Drawing.Point(423, 241);
            this.buttonModifyUser.Margin = new System.Windows.Forms.Padding(20);
            this.buttonModifyUser.Name = "buttonModifyUser";
            this.buttonModifyUser.Size = new System.Drawing.Size(133, 71);
            this.buttonModifyUser.TabIndex = 3;
            this.buttonModifyUser.Text = "Editar";
            this.buttonModifyUser.UseVisualStyleBackColor = true;
            // 
            // buttonAddUser
            // 
            this.buttonAddUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddUser.Location = new System.Drawing.Point(423, 130);
            this.buttonAddUser.Margin = new System.Windows.Forms.Padding(20);
            this.buttonAddUser.Name = "buttonAddUser";
            this.buttonAddUser.Size = new System.Drawing.Size(133, 71);
            this.buttonAddUser.TabIndex = 2;
            this.buttonAddUser.Text = "Añadir nuevo";
            this.buttonAddUser.UseVisualStyleBackColor = true;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelTitle, 2);
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTitle.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(3, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(570, 55);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Gestión de usuarios";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 113);
            this.dataGridView1.Name = "dataGridView1";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 4);
            this.dataGridView1.Size = new System.Drawing.Size(397, 439);
            this.dataGridView1.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel2.Controls.Add(this.textBoxSearch, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.pictureBoxSearch, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 58);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(397, 49);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // pictureBoxSearch
            // 
            this.pictureBoxSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxSearch.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxSearch.Name = "pictureBoxSearch";
            this.pictureBoxSearch.Size = new System.Drawing.Size(73, 43);
            this.pictureBoxSearch.TabIndex = 2;
            this.pictureBoxSearch.TabStop = false;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxSearch.Location = new System.Drawing.Point(82, 14);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(312, 20);
            this.textBoxSearch.TabIndex = 3;
            // 
            // panelUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "panelUser";
            this.Size = new System.Drawing.Size(576, 555);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSearch)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonDetailsUser;
        private System.Windows.Forms.Button buttonModifyUser;
        private System.Windows.Forms.Button buttonAddUser;
        private System.Windows.Forms.Button buttonDeleteUser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBoxSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
    }
}
