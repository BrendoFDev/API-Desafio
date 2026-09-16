namespace WindowsFormsAppp.Puts.PutSubCarros
{
    partial class PutMarca
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
            button1 = new Button();
            txtNome = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 66);
            label2.Name = "label2";
            label2.Size = new Size(223, 15);
            label2.TabIndex = 7;
            label2.Text = "Digite o ID da Marca que deseja atualizar:";
            // 
            // txtId
            // 
            txtId.Location = new Point(85, 100);
            txtId.Name = "txtId";
            txtId.PlaceholderText = "Id";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 8;
            // 
            // button1
            // 
            button1.Location = new Point(99, 204);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 9;
            button1.Text = "Atualizar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(85, 150);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Nome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(77, 132);
            label1.Name = "label1";
            label1.Size = new Size(115, 15);
            label1.TabIndex = 11;
            label1.Text = "Digite o novo nome:";
            // 
            // PutMarca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 379);
            Controls.Add(label1);
            Controls.Add(txtNome);
            Controls.Add(button1);
            Controls.Add(txtId);
            Controls.Add(label2);
            Name = "PutMarca";
            Text = "PutMarca";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox txtId;
        private Button button1;
        private TextBox txtNome;
        private Label label1;
    }
}