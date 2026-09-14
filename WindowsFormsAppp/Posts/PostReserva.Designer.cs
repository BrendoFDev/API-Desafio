namespace WindowsFormsAppp.Posts
{
    partial class PostReserva
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
            label2 = new Label();
            button1 = new Button();
            cId = new TextBox();
            crId = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 78);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 2;
            label1.Text = "Selecione o Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(62, 182);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 3;
            label2.Text = "Selecione o Carro";
            // 
            // button1
            // 
            button1.Location = new Point(86, 251);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Enviar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // cId
            // 
            cId.Location = new Point(65, 96);
            cId.Name = "cId";
            cId.Size = new Size(100, 23);
            cId.TabIndex = 5;
            // 
            // crId
            // 
            crId.Location = new Point(65, 200);
            crId.Name = "crId";
            crId.Size = new Size(100, 23);
            crId.TabIndex = 6;
            // 
            // PostReserva
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(233, 336);
            Controls.Add(crId);
            Controls.Add(cId);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "PostReserva";
            Text = "PostReserva";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox comboBox2;
        private Label label1;
        private Label label2;
        private Button button1;
        private TextBox cId;
        private TextBox crId;
    }
}