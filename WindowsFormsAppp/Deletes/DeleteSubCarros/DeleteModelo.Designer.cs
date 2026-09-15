namespace WindowsFormsAppp.Deletes.DeleteSubCarros
{
    partial class DeleteModelo
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
            txtId.Location = new Point(85, 106);
            txtId.Name = "txtId";
            txtId.Size = new Size(100, 23);
            txtId.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(80, 87);
            label2.Name = "label2";
            label2.Size = new Size(123, 15);
            label2.TabIndex = 9;
            label2.Text = "Digite o ID do Modelo";
            // 
            // button1
            // 
            button1.Location = new Point(97, 135);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "Enviar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // DeleteModelo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(273, 226);
            Controls.Add(button1);
            Controls.Add(txtId);
            Controls.Add(label2);
            Name = "DeleteModelo";
            Text = "DeleteModelo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtId;
        private Label label2;
        private Button button1;
    }
}