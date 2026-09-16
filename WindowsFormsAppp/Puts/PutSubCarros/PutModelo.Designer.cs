namespace WindowsFormsAppp.Puts.PutSubCarros
{
    partial class PutModelo
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
            txtNome = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 61);
            label2.Name = "label2";
            label2.Size = new Size(232, 15);
            label2.TabIndex = 8;
            label2.Text = "Digite o ID do Modelo que deseja atualizar:";
            // 
            // txtId
            // 
            txtId.Location = new Point(81, 91);
            txtId.Name = "txtId";
            txtId.PlaceholderText = "Id";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 136);
            label1.Name = "label1";
            label1.Size = new Size(174, 15);
            label1.TabIndex = 10;
            label1.Text = "Digite o novo nome que deseja:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(81, 163);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Nome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(96, 206);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 12;
            button1.Text = "Atualizar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PutModelo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 379);
            Controls.Add(button1);
            Controls.Add(txtNome);
            Controls.Add(label1);
            Controls.Add(txtId);
            Controls.Add(label2);
            Name = "PutModelo";
            Text = "PutModelo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox txtId;
        private Label label1;
        private TextBox txtNome;
        private Button button1;
    }
}