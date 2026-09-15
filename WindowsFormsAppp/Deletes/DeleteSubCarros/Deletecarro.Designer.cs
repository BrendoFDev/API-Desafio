namespace WindowsFormsAppp.Deletes.DeleteSubCarros
{
    partial class Deletecarro
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
            txtId = new TextBox();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Location = new Point(77, 109);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(73, 80);
            label2.Name = "label2";
            label2.Size = new Size(111, 15);
            label2.TabIndex = 9;
            label2.Text = "Digite o ID do Carro";
            // 
            // button1
            // 
            button1.Location = new Point(88, 138);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "Enviar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Deletecarro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 226);
            Controls.Add(button1);
            Controls.Add(txtId);
            Controls.Add(label2);
            Name = "Deletecarro";
            Text = "Deletecarro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtId;
        private Label label2;
        private Button button1;
    }
}