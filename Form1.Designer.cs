namespace pryLopezEtapa5
{
    partial class frmVahiculos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAuto = new Button();
            btnAvion = new Button();
            btnBarco = new Button();
            SuspendLayout();
            // 
            // btnAuto
            // 
            btnAuto.Location = new Point(395, 431);
            btnAuto.Name = "btnAuto";
            btnAuto.Size = new Size(94, 29);
            btnAuto.TabIndex = 0;
            btnAuto.Text = "Auto";
            btnAuto.UseVisualStyleBackColor = true;
            btnAuto.Click += button1_Click;
            // 
            // btnAvion
            // 
            btnAvion.Location = new Point(278, 431);
            btnAvion.Name = "btnAvion";
            btnAvion.Size = new Size(94, 29);
            btnAvion.TabIndex = 1;
            btnAvion.Text = "Avion";
            btnAvion.UseVisualStyleBackColor = true;
            btnAvion.Click += button2_Click;
            // 
            // btnBarco
            // 
            btnBarco.Location = new Point(508, 431);
            btnBarco.Name = "btnBarco";
            btnBarco.Size = new Size(94, 29);
            btnBarco.TabIndex = 2;
            btnBarco.Text = "Barco";
            btnBarco.UseVisualStyleBackColor = true;
            btnBarco.Click += button3_Click;
            // 
            // frmVahiculos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(910, 472);
            Controls.Add(btnBarco);
            Controls.Add(btnAvion);
            Controls.Add(btnAuto);
            Name = "frmVahiculos";
            Text = "Vehiculos";
            ResumeLayout(false);
        }

        #endregion

        private Button btnAuto;
        private Button btnAvion;
        private Button btnBarco;
    }
}
