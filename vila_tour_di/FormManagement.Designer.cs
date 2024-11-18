namespace vila_tour_di {
    partial class FormManagement {
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
            System.Windows.Forms.PictureBox vila_tour_logo;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManagement));
            this.sidePanel = new System.Windows.Forms.Panel();
            this.txtWelcome = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnPlaces = new Guna.UI2.WinForms.Guna2Button();
            this.btnRecipes = new Guna.UI2.WinForms.Guna2Button();
            this.btnUsers = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogOut = new Guna.UI2.WinForms.Guna2Button();
            this.btnFestivals = new Guna.UI2.WinForms.Guna2Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            vila_tour_logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(vila_tour_logo)).BeginInit();
            this.sidePanel.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // vila_tour_logo
            // 
            vila_tour_logo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            vila_tour_logo.Image = ((System.Drawing.Image)(resources.GetObject("vila_tour_logo.Image")));
            vila_tour_logo.Location = new System.Drawing.Point(8, 165);
            vila_tour_logo.Margin = new System.Windows.Forms.Padding(4);
            vila_tour_logo.Name = "vila_tour_logo";
            vila_tour_logo.Size = new System.Drawing.Size(1037, 332);
            vila_tour_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            vila_tour_logo.TabIndex = 1;
            vila_tour_logo.TabStop = false;
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.LightSeaGreen;
            this.sidePanel.Controls.Add(this.txtWelcome);
            this.sidePanel.Controls.Add(this.btnPlaces);
            this.sidePanel.Controls.Add(this.btnRecipes);
            this.sidePanel.Controls.Add(this.btnUsers);
            this.sidePanel.Controls.Add(this.btnLogOut);
            this.sidePanel.Controls.Add(this.btnFestivals);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Margin = new System.Windows.Forms.Padding(4);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(303, 690);
            this.sidePanel.TabIndex = 0;
            // 
            // txtWelcome
            // 
            this.txtWelcome.BackColor = System.Drawing.Color.Transparent;
            this.txtWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWelcome.ForeColor = System.Drawing.Color.White;
            this.txtWelcome.Location = new System.Drawing.Point(51, 30);
            this.txtWelcome.Margin = new System.Windows.Forms.Padding(4);
            this.txtWelcome.Name = "txtWelcome";
            this.txtWelcome.Size = new System.Drawing.Size(201, 31);
            this.txtWelcome.TabIndex = 13;
            this.txtWelcome.Text = "Bienvenido/a XXX";
            // 
            // btnPlaces
            // 
            this.btnPlaces.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnPlaces.Animated = true;
            this.btnPlaces.AutoRoundedCorners = true;
            this.btnPlaces.BackColor = System.Drawing.Color.Transparent;
            this.btnPlaces.BorderColor = System.Drawing.Color.Transparent;
            this.btnPlaces.BorderRadius = 30;
            this.btnPlaces.BorderThickness = 2;
            this.btnPlaces.CustomizableEdges.BottomRight = false;
            this.btnPlaces.CustomizableEdges.TopRight = false;
            this.btnPlaces.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPlaces.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPlaces.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPlaces.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPlaces.FillColor = System.Drawing.Color.Teal;
            this.btnPlaces.FocusedColor = System.Drawing.Color.White;
            this.btnPlaces.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnPlaces.ForeColor = System.Drawing.Color.White;
            this.btnPlaces.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnPlaces.HoverState.CustomBorderColor = System.Drawing.Color.White;
            this.btnPlaces.HoverState.FillColor = System.Drawing.Color.Turquoise;
            this.btnPlaces.Location = new System.Drawing.Point(51, 127);
            this.btnPlaces.Margin = new System.Windows.Forms.Padding(4);
            this.btnPlaces.Name = "btnPlaces";
            this.btnPlaces.PressedColor = System.Drawing.Color.White;
            this.btnPlaces.Size = new System.Drawing.Size(264, 62);
            this.btnPlaces.TabIndex = 11;
            this.btnPlaces.Text = "Lugares";
            this.btnPlaces.Click += new System.EventHandler(this.btnPlaces_Click);
            // 
            // btnRecipes
            // 
            this.btnRecipes.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnRecipes.Animated = true;
            this.btnRecipes.AutoRoundedCorners = true;
            this.btnRecipes.BackColor = System.Drawing.Color.Transparent;
            this.btnRecipes.BorderColor = System.Drawing.Color.Transparent;
            this.btnRecipes.BorderRadius = 30;
            this.btnRecipes.BorderThickness = 2;
            this.btnRecipes.CustomizableEdges.BottomRight = false;
            this.btnRecipes.CustomizableEdges.TopRight = false;
            this.btnRecipes.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRecipes.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRecipes.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRecipes.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRecipes.FillColor = System.Drawing.Color.Teal;
            this.btnRecipes.FocusedColor = System.Drawing.Color.White;
            this.btnRecipes.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnRecipes.ForeColor = System.Drawing.Color.White;
            this.btnRecipes.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnRecipes.HoverState.CustomBorderColor = System.Drawing.Color.White;
            this.btnRecipes.HoverState.FillColor = System.Drawing.Color.Turquoise;
            this.btnRecipes.Location = new System.Drawing.Point(51, 287);
            this.btnRecipes.Margin = new System.Windows.Forms.Padding(4);
            this.btnRecipes.Name = "btnRecipes";
            this.btnRecipes.PressedColor = System.Drawing.Color.White;
            this.btnRecipes.Size = new System.Drawing.Size(264, 62);
            this.btnRecipes.TabIndex = 15;
            this.btnRecipes.Text = "Recetas";
            this.btnRecipes.Click += new System.EventHandler(this.btnRecipes_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnUsers.Animated = true;
            this.btnUsers.AutoRoundedCorners = true;
            this.btnUsers.BackColor = System.Drawing.Color.Transparent;
            this.btnUsers.BorderColor = System.Drawing.Color.Transparent;
            this.btnUsers.BorderRadius = 30;
            this.btnUsers.BorderThickness = 2;
            this.btnUsers.CustomizableEdges.BottomRight = false;
            this.btnUsers.CustomizableEdges.TopRight = false;
            this.btnUsers.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUsers.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUsers.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUsers.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUsers.FillColor = System.Drawing.Color.Teal;
            this.btnUsers.FocusedColor = System.Drawing.Color.White;
            this.btnUsers.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnUsers.HoverState.CustomBorderColor = System.Drawing.Color.White;
            this.btnUsers.HoverState.FillColor = System.Drawing.Color.Turquoise;
            this.btnUsers.Location = new System.Drawing.Point(51, 367);
            this.btnUsers.Margin = new System.Windows.Forms.Padding(4);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.PressedColor = System.Drawing.Color.White;
            this.btnUsers.Size = new System.Drawing.Size(264, 62);
            this.btnUsers.TabIndex = 12;
            this.btnUsers.Text = "Usuarios";
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.Animated = true;
            this.btnLogOut.AutoRoundedCorners = true;
            this.btnLogOut.BackColor = System.Drawing.Color.Transparent;
            this.btnLogOut.BorderColor = System.Drawing.Color.Transparent;
            this.btnLogOut.BorderRadius = 30;
            this.btnLogOut.BorderThickness = 2;
            this.btnLogOut.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogOut.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogOut.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogOut.FillColor = System.Drawing.Color.Teal;
            this.btnLogOut.FocusedColor = System.Drawing.Color.White;
            this.btnLogOut.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnLogOut.HoverState.CustomBorderColor = System.Drawing.Color.White;
            this.btnLogOut.HoverState.FillColor = System.Drawing.Color.LightSeaGreen;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.Location = new System.Drawing.Point(16, 615);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(47, 43, 47, 43);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.PressedColor = System.Drawing.Color.White;
            this.btnLogOut.Size = new System.Drawing.Size(67, 62);
            this.btnLogOut.TabIndex = 16;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnFestivals
            // 
            this.btnFestivals.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnFestivals.Animated = true;
            this.btnFestivals.AutoRoundedCorners = true;
            this.btnFestivals.BackColor = System.Drawing.Color.Transparent;
            this.btnFestivals.BorderColor = System.Drawing.Color.Transparent;
            this.btnFestivals.BorderRadius = 30;
            this.btnFestivals.BorderThickness = 2;
            this.btnFestivals.CustomizableEdges.BottomRight = false;
            this.btnFestivals.CustomizableEdges.TopRight = false;
            this.btnFestivals.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFestivals.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFestivals.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFestivals.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFestivals.FillColor = System.Drawing.Color.Teal;
            this.btnFestivals.FocusedColor = System.Drawing.Color.White;
            this.btnFestivals.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.btnFestivals.ForeColor = System.Drawing.Color.White;
            this.btnFestivals.HoverState.BorderColor = System.Drawing.Color.White;
            this.btnFestivals.HoverState.CustomBorderColor = System.Drawing.Color.White;
            this.btnFestivals.HoverState.FillColor = System.Drawing.Color.Turquoise;
            this.btnFestivals.Location = new System.Drawing.Point(51, 207);
            this.btnFestivals.Margin = new System.Windows.Forms.Padding(4);
            this.btnFestivals.Name = "btnFestivals";
            this.btnFestivals.PressedColor = System.Drawing.Color.White;
            this.btnFestivals.Size = new System.Drawing.Size(264, 62);
            this.btnFestivals.TabIndex = 14;
            this.btnFestivals.Text = "Festivales y Tradiciones";
            this.btnFestivals.Click += new System.EventHandler(this.btnFestivals_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Controls.Add(vila_tour_logo);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(303, 0);
            this.mainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1061, 690);
            this.mainPanel.TabIndex = 1;
            // 
            // FormManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1364, 690);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.sidePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormManagement_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(vila_tour_logo)).EndInit();
            this.sidePanel.ResumeLayout(false);
            this.sidePanel.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Panel mainPanel;
        private Guna.UI2.WinForms.Guna2HtmlLabel txtWelcome;
        private Guna.UI2.WinForms.Guna2Button btnPlaces;
        private Guna.UI2.WinForms.Guna2Button btnRecipes;
        private Guna.UI2.WinForms.Guna2Button btnUsers;
        private Guna.UI2.WinForms.Guna2Button btnLogOut;
        private Guna.UI2.WinForms.Guna2Button btnFestivals;
    }
}