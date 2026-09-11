namespace WindowsFormsAppp.Gets
{
    partial class GetCliente
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
            listView1 = new ListView();
            Deletar = new Button();
            Criar = new Button();
            Atualizar = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 12);
            listView1.Name = "listView1";
            listView1.Size = new Size(778, 623);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Deletar
            // 
            Deletar.Location = new Point(906, 353);
            Deletar.Name = "Deletar";
            Deletar.Size = new Size(111, 36);
            Deletar.TabIndex = 8;
            Deletar.Text = "Deletar";
            Deletar.UseVisualStyleBackColor = true;
            // 
            // Criar
            // 
            Criar.Location = new Point(906, 241);
            Criar.Name = "Criar";
            Criar.Size = new Size(111, 36);
            Criar.TabIndex = 7;
            Criar.Text = "Criar";
            Criar.UseVisualStyleBackColor = true;
            Criar.Click += Criar_Click;
            // 
            // Atualizar
            // 
            Atualizar.Location = new Point(906, 297);
            Atualizar.Name = "Atualizar";
            Atualizar.Size = new Size(111, 36);
            Atualizar.TabIndex = 6;
            Atualizar.Text = "Atualizar";
            Atualizar.UseVisualStyleBackColor = true;
            Atualizar.Click += Atualizar_Click;
            // 
            // GetCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 641);
            Controls.Add(Deletar);
            Controls.Add(Criar);
            Controls.Add(Atualizar);
            Controls.Add(listView1);
            Name = "GetCliente";
            Text = "GetClientes";
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private Button Deletar;
        private Button Criar;
        private Button Atualizar;
    }
}