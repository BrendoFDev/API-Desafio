namespace WindowsFormsAppp
{
    partial class Cadastro
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
            emailCAD = new TextBox();
            userCAD = new TextBox();
            senhaCAD = new TextBox();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Ravie", 69.75F);
            label1.Location = new Point(237, 54);
            label1.Name = "label1";
            label1.Size = new Size(629, 125);
            label1.TabIndex = 0;
            label1.Text = "Cadastro";
            // 
            // emailCAD
            // 
            emailCAD.Location = new Point(481, 295);
            emailCAD.Name = "emailCAD";
            emailCAD.Size = new Size(100, 23);
            emailCAD.TabIndex = 1;
            // 
            // userCAD
            // 
            userCAD.Location = new Point(481, 240);
            userCAD.Name = "userCAD";
            userCAD.Size = new Size(100, 23);
            userCAD.TabIndex = 2;
            userCAD.TextChanged += textBox2_TextChanged;
            // 
            // senhaCAD
            // 
            senhaCAD.Location = new Point(481, 350);
            senhaCAD.Name = "senhaCAD";
            senhaCAD.Size = new Size(100, 23);
            senhaCAD.TabIndex = 3;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(494, 416);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Cadastrar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(482, 217);
            label2.Name = "label2";
            label2.Size = new Size(98, 15);
            label2.TabIndex = 5;
            label2.Text = "Nome de usuário";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(483, 277);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 6;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(483, 332);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 7;
            label4.Text = "Senha";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(482, 389);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(103, 15);
            linkLabel1.TabIndex = 8;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Voltar para o login";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Cadastro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1107, 576);
            Controls.Add(linkLabel1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(senhaCAD);
            Controls.Add(userCAD);
            Controls.Add(emailCAD);
            Controls.Add(label1);
            Name = "Cadastro";
            Text = "Cadastro";
            Load += Cadastro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox emailCAD;
        private TextBox userCAD;
        private TextBox senhaCAD;
        private Button button1;
        private Label label2;
        private Label label3;
        private Label label4;
        private LinkLabel linkLabel1;
    }
}