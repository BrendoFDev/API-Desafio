namespace WindowsFormsAppp.Puts
{
    partial class PutReserva
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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label2 = new Label();
            textBox3 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 65);
            label1.Name = "label1";
            label1.Size = new Size(121, 15);
            label1.TabIndex = 4;
            label1.Text = "Digite o ID da Reserva";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(85, 88);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "ID";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 7;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(83, 146);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "ID Cliente";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 119);
            label2.Name = "label2";
            label2.Size = new Size(160, 15);
            label2.TabIndex = 10;
            label2.Text = "Digite o que deseja atualizar:.";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(83, 175);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "ID Carro";
            textBox3.Size = new Size(100, 23);
            textBox3.TabIndex = 12;
            // 
            // button1
            // 
            button1.Location = new Point(98, 204);
            button1.Name = "button1";
            button1.Size = new Size(72, 23);
            button1.TabIndex = 13;
            button1.Text = "Atualizar ";
            button1.UseVisualStyleBackColor = true;
            // 
            // PutReserva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 379);
            Controls.Add(button1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "PutReserva";
            Text = "PutReserva";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label2;
        private TextBox textBox3;
        private Button button1;
    }
}