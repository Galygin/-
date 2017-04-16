namespace ib_lab
{
    partial class Form1
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
            this.input_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.key = new System.Windows.Forms.TextBox();
            this.method = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.encrypted_text = new System.Windows.Forms.TextBox();
            this.encrypt = new System.Windows.Forms.Button();
            this.decrypt = new System.Windows.Forms.Button();
            this.load_ab_from_file = new System.Windows.Forms.Button();
            this.load_text_from_file = new System.Windows.Forms.Button();
            this.keylabel = new System.Windows.Forms.Label();
            this.ab = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // input_text
            // 
            this.input_text.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.input_text.Location = new System.Drawing.Point(12, 35);
            this.input_text.Multiline = true;
            this.input_text.Name = "input_text";
            this.input_text.Size = new System.Drawing.Size(425, 308);
            this.input_text.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Исходный текст:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(732, 390);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Исходный алфавит:";
            // 
            // key
            // 
            this.key.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.key.Location = new System.Drawing.Point(12, 416);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(300, 20);
            this.key.TabIndex = 3;
            // 
            // method
            // 
            this.method.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.method.FormattingEnabled = true;
            this.method.Items.AddRange(new object[] {
            "Простая подстановка",
            "Блочная перестановка",
            "Усложненная блочная перестановка",
            "Шифр Цезаря",
            "XOR"});
            this.method.Location = new System.Drawing.Point(12, 462);
            this.method.Name = "method";
            this.method.Size = new System.Drawing.Size(300, 22);
            this.method.TabIndex = 4;
            this.method.SelectedIndexChanged += new System.EventHandler(this.method_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 439);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Метод шифрования:";
            // 
            // encrypted_text
            // 
            this.encrypted_text.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.encrypted_text.Location = new System.Drawing.Point(443, 35);
            this.encrypted_text.Multiline = true;
            this.encrypted_text.Name = "encrypted_text";
            this.encrypted_text.Size = new System.Drawing.Size(439, 308);
            this.encrypted_text.TabIndex = 6;
            this.encrypted_text.TextChanged += new System.EventHandler(this.encrypted_text_TextChanged);
            // 
            // encrypt
            // 
            this.encrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.encrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.encrypt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.encrypt.Location = new System.Drawing.Point(888, 35);
            this.encrypt.Name = "encrypt";
            this.encrypt.Size = new System.Drawing.Size(147, 100);
            this.encrypt.TabIndex = 7;
            this.encrypt.Text = "Зашифровать";
            this.encrypt.UseVisualStyleBackColor = false;
            this.encrypt.Click += new System.EventHandler(this.encrypt_Click);
            // 
            // decrypt
            // 
            this.decrypt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.decrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decrypt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.decrypt.Location = new System.Drawing.Point(888, 141);
            this.decrypt.Name = "decrypt";
            this.decrypt.Size = new System.Drawing.Size(147, 100);
            this.decrypt.TabIndex = 8;
            this.decrypt.Text = "Расшифровать";
            this.decrypt.UseVisualStyleBackColor = false;
            this.decrypt.Click += new System.EventHandler(this.button2_Click);
            // 
            // load_ab_from_file
            // 
            this.load_ab_from_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.load_ab_from_file.Location = new System.Drawing.Point(984, 390);
            this.load_ab_from_file.Name = "load_ab_from_file";
            this.load_ab_from_file.Size = new System.Drawing.Size(51, 17);
            this.load_ab_from_file.TabIndex = 9;
            this.load_ab_from_file.Text = "Файл...";
            this.load_ab_from_file.UseVisualStyleBackColor = true;
            this.load_ab_from_file.Click += new System.EventHandler(this.load_ab_from_file_Click);
            // 
            // load_text_from_file
            // 
            this.load_text_from_file.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.load_text_from_file.Location = new System.Drawing.Point(261, 12);
            this.load_text_from_file.Name = "load_text_from_file";
            this.load_text_from_file.Size = new System.Drawing.Size(51, 17);
            this.load_text_from_file.TabIndex = 10;
            this.load_text_from_file.Text = "Файл...";
            this.load_text_from_file.UseVisualStyleBackColor = true;
            this.load_text_from_file.Click += new System.EventHandler(this.load_text_from_file_Click);
            // 
            // keylabel
            // 
            this.keylabel.AutoSize = true;
            this.keylabel.Location = new System.Drawing.Point(9, 390);
            this.keylabel.Name = "keylabel";
            this.keylabel.Size = new System.Drawing.Size(36, 13);
            this.keylabel.TabIndex = 11;
            this.keylabel.Text = "Ключ:";
            // 
            // ab
            // 
            this.ab.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ab.Location = new System.Drawing.Point(735, 416);
            this.ab.Name = "ab";
            this.ab.Size = new System.Drawing.Size(300, 20);
            this.ab.TabIndex = 12;
            this.ab.Text = "abcdefghijklmnopqrstuvwxyz";
            this.ab.TextChanged += new System.EventHandler(this.ab_TextChanged);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(261, 386);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(51, 17);
            this.button3.TabIndex = 13;
            this.button3.Text = "Файл...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.load_key_from_file_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1047, 490);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ab);
            this.Controls.Add(this.keylabel);
            this.Controls.Add(this.load_text_from_file);
            this.Controls.Add(this.load_ab_from_file);
            this.Controls.Add(this.decrypt);
            this.Controls.Add(this.encrypt);
            this.Controls.Add(this.encrypted_text);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.method);
            this.Controls.Add(this.key);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.input_text);
            this.Name = "Form1";
            this.Text = "Игра в шпиона";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private  System.Windows.Forms.TextBox input_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox key;
        private System.Windows.Forms.ComboBox method;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox encrypted_text;
        private System.Windows.Forms.Button encrypt;
        private System.Windows.Forms.Button decrypt;
        private System.Windows.Forms.Button load_ab_from_file;
        private System.Windows.Forms.Button load_text_from_file;
        private System.Windows.Forms.Label keylabel;
        private System.Windows.Forms.TextBox ab;
        private System.Windows.Forms.Button button3;
    }
}

