namespace WindowsFormsAppp.Posts.SubCarros
{
    partial class PostCliente
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
            button1 = new Button();
            nome = new TextBox();
            label1 = new Label();
            label2 = new Label();
            cpf = new MaskedTextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(97, 333);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Enviar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // nome
            // 
            nome.Location = new Point(72, 91);
            nome.Name = "nome";
            nome.Size = new Size(100, 23);
            nome.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(72, 73);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 5;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 145);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 6;
            label2.Text = "CPF";
            // 
            // cpf
            // 
            cpf.ForeColor = SystemColors.WindowText;
            cpf.Location = new Point(72, 175);
            cpf.Mask = "000,000,000-00";
            cpf.Name = "cpf";
            cpf.Size = new Size(100, 23);
            cpf.TabIndex = 7;
            // 
            // PostCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(287, 450);
            Controls.Add(cpf);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(nome);
            Controls.Add(button1);
            Name = "PostCliente";
            Text = "PostCliente";
            Load += PostCliente_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox nome;
        private Label label1;
        private Label label2;
        private MaskedTextBox cpf;
    }
}