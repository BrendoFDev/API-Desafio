namespace WindowsFormsAppp.Puts
{
    partial class PutCliente
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
            txtId = new TextBox();
            label2 = new Label();
            txtNome = new TextBox();
            txtCpf = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 48);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 7;
            label1.Text = "Digite o ID do cliente";
            // 
            // txtId
            // 
            txtId.Location = new Point(75, 70);
            txtId.Name = "txtId";
            txtId.PlaceholderText = "ID";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(54, 101);
            label2.Name = "label2";
            label2.Size = new Size(157, 15);
            label2.TabIndex = 8;
            label2.Text = "Digite o que deseja atualizar:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(75, 128);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Nome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 9;
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(75, 170);
            txtCpf.Name = "txtCpf";
            txtCpf.PlaceholderText = "CPF";
            txtCpf.Size = new Size(100, 23);
            txtCpf.TabIndex = 10;
            // 
            // button1
            // 
            button1.Location = new Point(87, 205);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "Atualizar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PutCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 379);
            Controls.Add(button1);
            Controls.Add(txtCpf);
            Controls.Add(txtNome);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtId);
            Name = "PutCliente";
            Text = "PutCliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtId;
        private Label label2;
        private TextBox txtNome;
        private TextBox txtCpf;
        private Button button1;
    }
}