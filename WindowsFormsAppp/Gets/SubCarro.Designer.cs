namespace WindowsFormsAppp.Gets
{
    partial class SubCarro
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
            label1 = new Label();
            Marca = new Button();
            Carro = new Button();
            Modelo = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Viner Hand ITC", 72F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(241, 76);
            label1.Name = "label1";
            label1.Size = new Size(548, 155);
            label1.TabIndex = 2;
            label1.Text = "JPVeículos";
            // 
            // Marca
            // 
            Marca.Font = new Font("Segoe UI", 9F);
            Marca.Location = new Point(203, 353);
            Marca.Name = "Marca";
            Marca.Size = new Size(169, 47);
            Marca.TabIndex = 6;
            Marca.Text = "Marca";
            Marca.UseVisualStyleBackColor = true;
            Marca.Click += Marca_Click;
            // 
            // Carro
            // 
            Carro.Font = new Font("Segoe UI", 9F);
            Carro.Location = new Point(481, 299);
            Carro.Name = "Carro";
            Carro.Size = new Size(169, 47);
            Carro.TabIndex = 7;
            Carro.Text = "Carro";
            Carro.UseVisualStyleBackColor = true;
            Carro.Click += Carro_Click;
            // 
            // Modelo
            // 
            Modelo.Font = new Font("Segoe UI", 9F);
            Modelo.Location = new Point(772, 353);
            Modelo.Name = "Modelo";
            Modelo.Size = new Size(169, 47);
            Modelo.TabIndex = 8;
            Modelo.Text = "Modelo";
            Modelo.UseVisualStyleBackColor = true;
            Modelo.Click += Modelo_Click;
            // 
            // SubCarro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1095, 646);
            Controls.Add(Modelo);
            Controls.Add(Carro);
            Controls.Add(Marca);
            Controls.Add(label1);
            Name = "SubCarro";
            Text = "SubCarro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button Marca;
        private Button Carro;
        private Button Modelo;
    }
}