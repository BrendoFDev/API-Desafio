namespace WindowsFormsAppp
{
    partial class Login
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
            email = new TextBox();
            senha = new TextBox();
            Entrar = new Button();
            linkLabel1 = new LinkLabel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // email
            // 
            email.Location = new Point(434, 189);
            email.Name = "email";
            email.Size = new Size(181, 23);
            email.TabIndex = 0;
            // 
            // senha
            // 
            senha.Location = new Point(434, 249);
            senha.Name = "senha";
            senha.Size = new Size(181, 23);
            senha.TabIndex = 1;
            // 
            // Entrar
            // 
            Entrar.Location = new Point(482, 319);
            Entrar.Name = "Entrar";
            Entrar.Size = new Size(75, 23);
            Entrar.TabIndex = 2;
            Entrar.Text = "Entrar";
            Entrar.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(404, 376);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(244, 15);
            linkLabel1.TabIndex = 3;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Não possui conta? Clique aqui para cadastrar";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Ravie", 70F);
            label1.Location = new Point(136, 35);
            label1.Name = "label1";
            label1.Size = new Size(726, 126);
            label1.TabIndex = 4;
            label1.Text = "JPVeículos";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(435, 171);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 5;
            label2.Text = "email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(435, 231);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 6;
            label3.Text = "cenha";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1092, 562);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(linkLabel1);
            Controls.Add(Entrar);
            Controls.Add(senha);
            Controls.Add(email);
            Font = new Font("Segoe UI", 9F);
            Name = "Login";
            Text = "Login";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox email;
        private TextBox senha;
        private Button Entrar;
        private LinkLabel linkLabel1;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
