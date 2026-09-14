namespace WindowsFormsAppp.Posts.PostSubCarros
{
    partial class PostCarro
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
            modelo = new ComboBox();
            label1 = new Label();
            Ano = new TextBox();
            preco = new TextBox();
            Cor = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // modelo
            // 
            modelo.FormattingEnabled = true;
            modelo.Location = new Point(72, 83);
            modelo.Name = "modelo";
            modelo.Size = new Size(121, 23);
            modelo.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 65);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 2;
            label1.Text = "Selecione o Modelo";
            // 
            // Ano
            // 
            Ano.Location = new Point(72, 141);
            Ano.Name = "Ano";
            Ano.Size = new Size(100, 23);
            Ano.TabIndex = 3;
            // 
            // preco
            // 
            preco.Location = new Point(72, 283);
            preco.Name = "preco";
            preco.Size = new Size(100, 23);
            preco.TabIndex = 4;
            // 
            // Cor
            // 
            Cor.Location = new Point(72, 214);
            Cor.Name = "Cor";
            Cor.Size = new Size(100, 23);
            Cor.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 123);
            label2.Name = "label2";
            label2.Size = new Size(120, 15);
            label2.TabIndex = 6;
            label2.Text = "Digite o ano do Carro";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 196);
            label3.Name = "label3";
            label3.Size = new Size(114, 15);
            label3.TabIndex = 7;
            label3.Text = "Digite a cor do carro";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(72, 265);
            label4.Name = "label4";
            label4.Size = new Size(128, 15);
            label4.TabIndex = 8;
            label4.Text = "Digite o preço do carro";
            // 
            // button1
            // 
            button1.Location = new Point(83, 326);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 9;
            button1.Text = "Enviar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PostCarro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 379);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(Cor);
            Controls.Add(preco);
            Controls.Add(Ano);
            Controls.Add(label1);
            Controls.Add(modelo);
            Name = "PostCarro";
            Text = "PostCarro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox modelo;
        private Label label1;
        private TextBox Ano;
        private TextBox preco;
        private TextBox Cor;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button1;
    }
}