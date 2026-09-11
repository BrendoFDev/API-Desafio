namespace WindowsFormsAppp.Gets
{
    partial class Index
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
            Cliente = new Button();
            label2 = new Label();
            Carro = new Button();
            Reserva = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Viner Hand ITC", 72F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(252, 62);
            label1.Name = "label1";
            label1.Size = new Size(548, 155);
            label1.TabIndex = 1;
            label1.Text = "JPVeículos";
            // 
            // Cliente
            // 
            Cliente.Font = new Font("Segoe UI", 9F);
            Cliente.Location = new Point(458, 292);
            Cliente.Name = "Cliente";
            Cliente.Size = new Size(169, 47);
            Cliente.TabIndex = 3;
            Cliente.Text = "Cliente";
            Cliente.UseVisualStyleBackColor = true;
            Cliente.Click += Cliente_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Snap ITC", 21.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(232, 217);
            label2.Name = "label2";
            label2.Size = new Size(608, 37);
            label2.TabIndex = 5;
            label2.Text = "Selecione uma opção para visualizar";
            // 
            // Carro
            // 
            Carro.Font = new Font("Segoe UI", 9F);
            Carro.Location = new Point(458, 354);
            Carro.Name = "Carro";
            Carro.Size = new Size(169, 47);
            Carro.TabIndex = 6;
            Carro.Text = "Carro";
            Carro.UseVisualStyleBackColor = true;
            Carro.Click += Carro_Click;
            // 
            // Reserva
            // 
            Reserva.Font = new Font("Segoe UI", 9F);
            Reserva.Location = new Point(458, 421);
            Reserva.Name = "Reserva";
            Reserva.Size = new Size(169, 47);
            Reserva.TabIndex = 7;
            Reserva.Text = "Reserva";
            Reserva.UseVisualStyleBackColor = true;
            Reserva.Click += Reserva_Click;
            // 
            // Index
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1096, 646);
            Controls.Add(Reserva);
            Controls.Add(Carro);
            Controls.Add(label2);
            Controls.Add(Cliente);
            Controls.Add(label1);
            Name = "Index";
            Text = "Index";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button Cliente;
        private Button button2;
        private Label label2;
        private Button Carro;
        private Button Reserva;
    }
}