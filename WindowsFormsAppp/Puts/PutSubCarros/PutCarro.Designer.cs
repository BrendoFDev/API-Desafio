namespace WindowsFormsAppp.Puts.PutSubCarros
{
    partial class PutCarro
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
            label2 = new Label();
            txtId = new TextBox();
            label1 = new Label();
            txtAno = new TextBox();
            txtPreco = new TextBox();
            txtCor = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 31);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 7;
            label2.Text = "Digite o ID do Carro";
            // 
            // txtId
            // 
            txtId.Location = new Point(77, 50);
            txtId.Name = "txtId";
            txtId.PlaceholderText = "Id";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(54, 87);
            label1.Name = "label1";
            label1.Size = new Size(155, 15);
            label1.TabIndex = 9;
            label1.Text = "O que você deseja atualizar?";
            // 
            // txtAno
            // 
            txtAno.Location = new Point(77, 178);
            txtAno.Name = "txtAno";
            txtAno.PlaceholderText = "Ano";
            txtAno.Size = new Size(100, 23);
            txtAno.TabIndex = 10;
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(77, 149);
            txtPreco.Name = "txtPreco";
            txtPreco.PlaceholderText = "Preço";
            txtPreco.Size = new Size(100, 23);
            txtPreco.TabIndex = 11;
            // 
            // txtCor
            // 
            txtCor.Location = new Point(77, 120);
            txtCor.Name = "txtCor";
            txtCor.PlaceholderText = "Cor";
            txtCor.Size = new Size(100, 23);
            txtCor.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(88, 220);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "Atualizar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PutCarro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 379);
            Controls.Add(button1);
            Controls.Add(txtCor);
            Controls.Add(txtPreco);
            Controls.Add(txtAno);
            Controls.Add(label1);
            Controls.Add(txtId);
            Controls.Add(label2);
            Name = "PutCarro";
            Text = "PutCarro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox txtId;
        private Label label1;
        private TextBox txtAno;
        private TextBox txtPreco;
        private TextBox txtCor;
        private Button button1;
    }
}