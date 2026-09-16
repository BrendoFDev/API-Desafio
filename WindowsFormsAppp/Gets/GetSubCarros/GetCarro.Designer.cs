namespace WindowsFormsAppp.Gets.GetSubCarros
{
    partial class GetCarro
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
            Deletar = new Button();
            Criar = new Button();
            Atualizar = new Button();
            listaCarro = new ListView();
            Voltar = new Button();
            SuspendLayout();
            // 
            // Deletar
            // 
            Deletar.Location = new Point(906, 352);
            Deletar.Name = "Deletar";
            Deletar.Size = new Size(111, 36);
            Deletar.TabIndex = 7;
            Deletar.Text = "Deletar";
            Deletar.UseVisualStyleBackColor = true;
            Deletar.Click += Deletar_Click;
            // 
            // Criar
            // 
            Criar.Location = new Point(906, 241);
            Criar.Name = "Criar";
            Criar.Size = new Size(111, 36);
            Criar.TabIndex = 6;
            Criar.Text = "Criar";
            Criar.UseVisualStyleBackColor = true;
            Criar.Click += Criar_Click;
            // 
            // Atualizar
            // 
            Atualizar.Location = new Point(906, 295);
            Atualizar.Name = "Atualizar";
            Atualizar.Size = new Size(111, 36);
            Atualizar.TabIndex = 5;
            Atualizar.Text = "Atualizar";
            Atualizar.UseVisualStyleBackColor = true;
            Atualizar.Click += Atualizar_Click;
            // 
            // listaCarro
            // 
            listaCarro.Location = new Point(12, 12);
            listaCarro.Name = "listaCarro";
            listaCarro.Size = new Size(778, 623);
            listaCarro.TabIndex = 4;
            listaCarro.UseCompatibleStateImageBehavior = false;
            listaCarro.View = View.Details;
            // 
            // Voltar
            // 
            Voltar.Location = new Point(1010, 12);
            Voltar.Name = "Voltar";
            Voltar.Size = new Size(75, 23);
            Voltar.TabIndex = 8;
            Voltar.Text = "Voltar";
            Voltar.UseVisualStyleBackColor = true;
            Voltar.Click += Voltar_Click;
            // 
            // GetCarro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1097, 647);
            Controls.Add(Voltar);
            Controls.Add(Deletar);
            Controls.Add(Criar);
            Controls.Add(Atualizar);
            Controls.Add(listaCarro);
            Name = "GetCarro";
            Text = "GetCarro";
            Load += GetCarro_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button Deletar;
        private Button Criar;
        private Button Atualizar;
        private ListView listaCarro;
        private Button Voltar;
    }
}