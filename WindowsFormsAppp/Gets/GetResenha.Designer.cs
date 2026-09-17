namespace WindowsFormsAppp.Gets
{
    partial class GetResenha
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
            listaReserva = new ListView();
            Criar = new Button();
            Atualizar = new Button();
            Deletar = new Button();
            Voltar = new Button();
            recarrega = new Button();
            SuspendLayout();
            // 
            // listaReserva
            // 
            listaReserva.Location = new Point(12, 12);
            listaReserva.Name = "listaReserva";
            listaReserva.Size = new Size(778, 623);
            listaReserva.TabIndex = 2;
            listaReserva.UseCompatibleStateImageBehavior = false;
            // 
            // Criar
            // 
            Criar.Location = new Point(906, 241);
            Criar.Name = "Criar";
            Criar.Size = new Size(111, 36);
            Criar.TabIndex = 8;
            Criar.Text = "Criar";
            Criar.UseVisualStyleBackColor = true;
            Criar.Click += Criar_Click;
            // 
            // Atualizar
            // 
            Atualizar.Location = new Point(906, 297);
            Atualizar.Name = "Atualizar";
            Atualizar.Size = new Size(111, 36);
            Atualizar.TabIndex = 9;
            Atualizar.Text = "Atualizar";
            Atualizar.UseVisualStyleBackColor = true;
            Atualizar.Click += Atualizar_Click;
            // 
            // Deletar
            // 
            Deletar.Location = new Point(906, 353);
            Deletar.Name = "Deletar";
            Deletar.Size = new Size(111, 36);
            Deletar.TabIndex = 10;
            Deletar.Text = "Deletar";
            Deletar.UseVisualStyleBackColor = true;
            Deletar.Click += Deletar_Click;
            // 
            // Voltar
            // 
            Voltar.Location = new Point(1009, 21);
            Voltar.Name = "Voltar";
            Voltar.Size = new Size(75, 23);
            Voltar.TabIndex = 11;
            Voltar.Text = "Voltar";
            Voltar.UseVisualStyleBackColor = true;
            Voltar.Click += Voltar_Click;
            // 
            // recarrega
            // 
            recarrega.Location = new Point(890, 21);
            recarrega.Name = "recarrega";
            recarrega.Size = new Size(75, 23);
            recarrega.TabIndex = 12;
            recarrega.Text = "Recarregar";
            recarrega.UseVisualStyleBackColor = true;
            recarrega.Click += recarrega_Click;
            // 
            // GetResenha
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1096, 645);
            Controls.Add(recarrega);
            Controls.Add(Voltar);
            Controls.Add(Deletar);
            Controls.Add(Atualizar);
            Controls.Add(Criar);
            Controls.Add(listaReserva);
            Name = "GetResenha";
            Text = "GetResenha";
            Load += GetResenha_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView listaReserva;
        private Button Criar;
        private Button Atualizar;
        private Button Deletar;
        private Button Voltar;
        private Button recarrega;
    }
}