namespace WindowsFormsAppp
{
    partial class Cliente
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
            button1 = new Button();
            button2 = new Button();
            button4 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(479, 241);
            label1.Name = "label1";
            label1.Size = new Size(119, 45);
            label1.TabIndex = 1;
            label1.Text = "Cliente";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Location = new Point(489, 157);
            button1.Name = "button1";
            button1.Size = new Size(106, 37);
            button1.TabIndex = 2;
            button1.Text = "Criar";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(489, 343);
            button2.Name = "button2";
            button2.Size = new Size(106, 37);
            button2.TabIndex = 4;
            button2.Text = "Ver";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Location = new Point(705, 249);
            button4.Name = "button4";
            button4.Size = new Size(106, 37);
            button4.TabIndex = 6;
            button4.Text = "Atualizar";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(317, 249);
            button3.Name = "button3";
            button3.Size = new Size(106, 37);
            button3.TabIndex = 7;
            button3.Text = "Remover";
            button3.UseVisualStyleBackColor = true;
            // 
            // Cliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1075, 585);
            Controls.Add(button3);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Cliente";
            Text = "Cliente";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button4;
        private Button button3;
    }
}