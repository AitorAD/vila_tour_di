
namespace vila_tour_di {
    partial class panelRecipes {
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
            this.buttonDelRecipe = new System.Windows.Forms.Button();
            this.buttonSeeRecipe = new System.Windows.Forms.Button();
            this.buttonModRecipe = new System.Windows.Forms.Button();
            this.labelRecipes = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonAddRecipe = new System.Windows.Forms.Button();
            this.buttonIngredients = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.buttonDelRecipe, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.buttonSeeRecipe, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonModRecipe, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.labelRecipes, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonAddRecipe, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonIngredients, 1, 1);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(576, 555);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // buttonDelRecipe
            // 
            this.buttonDelRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelRecipe.Location = new System.Drawing.Point(418, 466);
            this.buttonDelRecipe.Margin = new System.Windows.Forms.Padding(15);
            this.buttonDelRecipe.Name = "buttonDelRecipe";
            this.buttonDelRecipe.Size = new System.Drawing.Size(143, 74);
            this.buttonDelRecipe.TabIndex = 5;
            this.buttonDelRecipe.Text = "Eliminar Receta";
            this.buttonDelRecipe.UseVisualStyleBackColor = true;
            this.buttonDelRecipe.Click += new System.EventHandler(this.buttonDelRecipe_Click);
            // 
            // buttonSeeRecipe
            // 
            this.buttonSeeRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSeeRecipe.Location = new System.Drawing.Point(418, 367);
            this.buttonSeeRecipe.Margin = new System.Windows.Forms.Padding(15);
            this.buttonSeeRecipe.Name = "buttonSeeRecipe";
            this.buttonSeeRecipe.Size = new System.Drawing.Size(143, 69);
            this.buttonSeeRecipe.TabIndex = 4;
            this.buttonSeeRecipe.Text = "Ver Receta";
            this.buttonSeeRecipe.UseVisualStyleBackColor = true;
            this.buttonSeeRecipe.Click += new System.EventHandler(this.buttonSeeRecipe_Click);
            // 
            // buttonModRecipe
            // 
            this.buttonModRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonModRecipe.Location = new System.Drawing.Point(418, 268);
            this.buttonModRecipe.Margin = new System.Windows.Forms.Padding(15);
            this.buttonModRecipe.Name = "buttonModRecipe";
            this.buttonModRecipe.Size = new System.Drawing.Size(143, 69);
            this.buttonModRecipe.TabIndex = 3;
            this.buttonModRecipe.Text = "Modificar Receta";
            this.buttonModRecipe.UseVisualStyleBackColor = true;
            this.buttonModRecipe.Click += new System.EventHandler(this.buttonModRecipe_Click);
            // 
            // labelRecipes
            // 
            this.labelRecipes.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.labelRecipes, 2);
            this.labelRecipes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRecipes.Font = new System.Drawing.Font("Times New Roman", 14.25F);
            this.labelRecipes.Location = new System.Drawing.Point(3, 0);
            this.labelRecipes.Name = "labelRecipes";
            this.labelRecipes.Size = new System.Drawing.Size(570, 55);
            this.labelRecipes.TabIndex = 0;
            this.labelRecipes.Text = "Recetas";
            this.labelRecipes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.tableLayoutPanel1.SetRowSpan(this.dataGridView1, 5);
            this.dataGridView1.Size = new System.Drawing.Size(397, 494);
            this.dataGridView1.TabIndex = 1;
            // 
            // buttonAddRecipe
            // 
            this.buttonAddRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddRecipe.Location = new System.Drawing.Point(418, 169);
            this.buttonAddRecipe.Margin = new System.Windows.Forms.Padding(15);
            this.buttonAddRecipe.Name = "buttonAddRecipe";
            this.buttonAddRecipe.Size = new System.Drawing.Size(143, 69);
            this.buttonAddRecipe.TabIndex = 2;
            this.buttonAddRecipe.Text = "Añadir Receta";
            this.buttonAddRecipe.UseVisualStyleBackColor = true;
            this.buttonAddRecipe.Click += new System.EventHandler(this.buttonAddRecipe_Click);
            // 
            // buttonIngredients
            // 
            this.buttonIngredients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonIngredients.Location = new System.Drawing.Point(418, 70);
            this.buttonIngredients.Margin = new System.Windows.Forms.Padding(15);
            this.buttonIngredients.Name = "buttonIngredients";
            this.buttonIngredients.Size = new System.Drawing.Size(143, 69);
            this.buttonIngredients.TabIndex = 6;
            this.buttonIngredients.Text = "Gestionar Ingredientes";
            this.buttonIngredients.UseVisualStyleBackColor = true;
            this.buttonIngredients.Click += new System.EventHandler(this.buttonIngredients_Click);
            // 
            // panelRecipes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "panelRecipes";
            this.Size = new System.Drawing.Size(576, 555);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelRecipes;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonDelRecipe;
        private System.Windows.Forms.Button buttonSeeRecipe;
        private System.Windows.Forms.Button buttonModRecipe;
        private System.Windows.Forms.Button buttonAddRecipe;
        private System.Windows.Forms.Button buttonIngredients;
    }
}
