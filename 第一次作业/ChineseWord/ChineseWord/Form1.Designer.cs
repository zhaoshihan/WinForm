namespace ChineseWord
{
    partial class ChineseWord
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonGetPinYin = new System.Windows.Forms.Button();
            this.buttonTtoS = new System.Windows.Forms.Button();
            this.buttonStoT = new System.Windows.Forms.Button();
            this.buttonTTS = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入汉字";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(56, 65);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(153, 21);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(56, 145);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(153, 100);
            this.textBox2.TabIndex = 2;
            // 
            // buttonGetPinYin
            // 
            this.buttonGetPinYin.Location = new System.Drawing.Point(287, 47);
            this.buttonGetPinYin.Name = "buttonGetPinYin";
            this.buttonGetPinYin.Size = new System.Drawing.Size(75, 23);
            this.buttonGetPinYin.TabIndex = 3;
            this.buttonGetPinYin.Text = "获取拼音";
            this.buttonGetPinYin.UseVisualStyleBackColor = true;
            this.buttonGetPinYin.Click += new System.EventHandler(this.buttonGetPinYin_Click);
            // 
            // buttonTtoS
            // 
            this.buttonTtoS.Location = new System.Drawing.Point(287, 117);
            this.buttonTtoS.Name = "buttonTtoS";
            this.buttonTtoS.Size = new System.Drawing.Size(75, 23);
            this.buttonTtoS.TabIndex = 4;
            this.buttonTtoS.Text = "繁转简";
            this.buttonTtoS.UseVisualStyleBackColor = true;
            this.buttonTtoS.Click += new System.EventHandler(this.buttonTtoS_Click);
            // 
            // buttonStoT
            // 
            this.buttonStoT.Location = new System.Drawing.Point(287, 155);
            this.buttonStoT.Name = "buttonStoT";
            this.buttonStoT.Size = new System.Drawing.Size(75, 23);
            this.buttonStoT.TabIndex = 5;
            this.buttonStoT.Text = "简转繁";
            this.buttonStoT.UseVisualStyleBackColor = true;
            this.buttonStoT.Click += new System.EventHandler(this.buttonStoT_Click);
            // 
            // buttonTTS
            // 
            this.buttonTTS.Location = new System.Drawing.Point(287, 222);
            this.buttonTTS.Name = "buttonTTS";
            this.buttonTTS.Size = new System.Drawing.Size(75, 23);
            this.buttonTTS.TabIndex = 6;
            this.buttonTTS.Text = "文本发音";
            this.buttonTTS.UseVisualStyleBackColor = true;
            this.buttonTTS.Click += new System.EventHandler(this.buttonTTS_Click);
            // 
            // ChineseWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 303);
            this.Controls.Add(this.buttonTTS);
            this.Controls.Add(this.buttonStoT);
            this.Controls.Add(this.buttonTtoS);
            this.Controls.Add(this.buttonGetPinYin);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "ChineseWord";
            this.Text = "汉字";
            this.Load += new System.EventHandler(this.ChineseChar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonGetPinYin;
        private System.Windows.Forms.Button buttonTtoS;
        private System.Windows.Forms.Button buttonStoT;
        private System.Windows.Forms.Button buttonTTS;
    }
}

