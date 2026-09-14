namespace WindowsFormsAppp.Posts.SubCarros
{
    partial class PostModelo
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
            comboMarca = new ComboBox();
            label1 = new Label();
            ModeloNome = new TextBox();
            label2 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // comboMarca
            // 
            comboMarca.FormattingEnabled = true;
            comboMarca.Location = new Point(56, 126);
            comboMarca.Name = "comboMarca";
            comboMarca.Size = new Size(121, 23);
            comboMarca.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(65, 96);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 2;
            label1.Text = "Selecione a Marca";
            // 
            // ModeloNome
            // 
            ModeloNome.Location = new Point(65, 226);
            ModeloNome.Name = "ModeloNome";
            ModeloNome.Size = new Size(100, 23);
            ModeloNome.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 193);
            label2.Name = "label2";
            label2.Size = new Size(143, 15);
            label2.TabIndex = 4;
            label2.Text = "Digite o nome do Modelo";
            // 
            // button1
            // 
            button1.Location = new Point(79, 270);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Enviar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PostModelo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(235, 329);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(ModeloNome);
            Controls.Add(label1);
            Controls.Add(comboMarca);
            Name = "PostModelo";
            Text = "PostModelo";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboMarca;
        private Label label1;
        private TextBox ModeloNome;
        private Label label2;
        private Button button1;
    }
}