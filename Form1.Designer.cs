namespace vox_to_ksh_converter
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.chartloadbtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.save_btn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.filepathtextbox = new System.Windows.Forms.TextBox();
            this.convert_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.title_text = new System.Windows.Forms.TextBox();
            this.artist_text = new System.Windows.Forms.TextBox();
            this.effecter_text = new System.Windows.Forms.TextBox();
            this.ilust_text = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.difficulty_text = new System.Windows.Forms.ComboBox();
            this.level_text = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.musicpath_text = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.soundloadbtn = new System.Windows.Forms.Button();
            this.soundpath = new System.Windows.Forms.TextBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // chartloadbtn
            // 
            this.chartloadbtn.Location = new System.Drawing.Point(42, 34);
            this.chartloadbtn.Name = "chartloadbtn";
            this.chartloadbtn.Size = new System.Drawing.Size(75, 23);
            this.chartloadbtn.TabIndex = 0;
            this.chartloadbtn.Text = "Load";
            this.chartloadbtn.UseVisualStyleBackColor = true;
            this.chartloadbtn.Click += new System.EventHandler(this.chartloadbtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // save_btn
            // 
            this.save_btn.Enabled = false;
            this.save_btn.Location = new System.Drawing.Point(538, 362);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(75, 23);
            this.save_btn.TabIndex = 3;
            this.save_btn.Text = "save";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // filepathtextbox
            // 
            this.filepathtextbox.Enabled = false;
            this.filepathtextbox.Location = new System.Drawing.Point(123, 35);
            this.filepathtextbox.Name = "filepathtextbox";
            this.filepathtextbox.Size = new System.Drawing.Size(458, 21);
            this.filepathtextbox.TabIndex = 4;
            // 
            // convert_btn
            // 
            this.convert_btn.Cursor = System.Windows.Forms.Cursors.Default;
            this.convert_btn.Enabled = false;
            this.convert_btn.Location = new System.Drawing.Point(455, 362);
            this.convert_btn.Name = "convert_btn";
            this.convert_btn.Size = new System.Drawing.Size(75, 23);
            this.convert_btn.TabIndex = 5;
            this.convert_btn.Text = "Convert";
            this.convert_btn.UseVisualStyleBackColor = true;
            this.convert_btn.Click += new System.EventHandler(this.convert_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Song title:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Artist:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 201);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Effecter:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "Illustrater:";
            // 
            // title_text
            // 
            this.title_text.Enabled = false;
            this.title_text.Location = new System.Drawing.Point(108, 117);
            this.title_text.Name = "title_text";
            this.title_text.Size = new System.Drawing.Size(217, 21);
            this.title_text.TabIndex = 10;
            // 
            // artist_text
            // 
            this.artist_text.Enabled = false;
            this.artist_text.Location = new System.Drawing.Point(108, 155);
            this.artist_text.Name = "artist_text";
            this.artist_text.Size = new System.Drawing.Size(217, 21);
            this.artist_text.TabIndex = 10;
            // 
            // effecter_text
            // 
            this.effecter_text.Enabled = false;
            this.effecter_text.Location = new System.Drawing.Point(108, 197);
            this.effecter_text.Name = "effecter_text";
            this.effecter_text.Size = new System.Drawing.Size(217, 21);
            this.effecter_text.TabIndex = 10;
            // 
            // ilust_text
            // 
            this.ilust_text.Enabled = false;
            this.ilust_text.Location = new System.Drawing.Point(108, 233);
            this.ilust_text.Name = "ilust_text";
            this.ilust_text.Size = new System.Drawing.Size(217, 21);
            this.ilust_text.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(353, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "Difficulty:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(355, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "Level:";
            // 
            // difficulty_text
            // 
            this.difficulty_text.Enabled = false;
            this.difficulty_text.FormattingEnabled = true;
            this.difficulty_text.Items.AddRange(new object[] {
            "light",
            "challenge",
            "extended",
            "infinete"});
            this.difficulty_text.Location = new System.Drawing.Point(428, 117);
            this.difficulty_text.Name = "difficulty_text";
            this.difficulty_text.Size = new System.Drawing.Size(121, 20);
            this.difficulty_text.TabIndex = 13;
            // 
            // level_text
            // 
            this.level_text.Enabled = false;
            this.level_text.FormattingEnabled = true;
            this.level_text.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.level_text.Location = new System.Drawing.Point(428, 155);
            this.level_text.Name = "level_text";
            this.level_text.Size = new System.Drawing.Size(121, 20);
            this.level_text.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(62, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 12);
            this.label7.TabIndex = 15;
            this.label7.Text = "Music:";
            // 
            // musicpath_text
            // 
            this.musicpath_text.Enabled = false;
            this.musicpath_text.Location = new System.Drawing.Point(108, 270);
            this.musicpath_text.Name = "musicpath_text";
            this.musicpath_text.Size = new System.Drawing.Size(217, 21);
            this.musicpath_text.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(40, 324);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(249, 48);
            this.label8.TabIndex = 16;
            this.label8.Text = "Ver 1.0 (2018-07-25)\r\nSupport vox ver 6~10\r\nLast compiled at 2018-07-25 14:58 (GM" +
    "T+9)\r\nMade by runner38.OOC\r\n";
            // 
            // soundloadbtn
            // 
            this.soundloadbtn.Location = new System.Drawing.Point(42, 66);
            this.soundloadbtn.Name = "soundloadbtn";
            this.soundloadbtn.Size = new System.Drawing.Size(75, 23);
            this.soundloadbtn.TabIndex = 17;
            this.soundloadbtn.Text = "2dx load";
            this.soundloadbtn.UseVisualStyleBackColor = true;
            this.soundloadbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // soundpath
            // 
            this.soundpath.Enabled = false;
            this.soundpath.Location = new System.Drawing.Point(123, 67);
            this.soundpath.Name = "soundpath";
            this.soundpath.Size = new System.Drawing.Size(458, 21);
            this.soundpath.TabIndex = 18;
            this.soundpath.TextChanged += new System.EventHandler(this.soundpath_TextChanged);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 418);
            this.Controls.Add(this.soundpath);
            this.Controls.Add(this.soundloadbtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.level_text);
            this.Controls.Add(this.difficulty_text);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.musicpath_text);
            this.Controls.Add(this.ilust_text);
            this.Controls.Add(this.effecter_text);
            this.Controls.Add(this.artist_text);
            this.Controls.Add(this.title_text);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.convert_btn);
            this.Controls.Add(this.filepathtextbox);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.chartloadbtn);
            this.Name = "Form1";
            this.Text = "SDVX chart to K-shoot mania chart converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chartloadbtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox filepathtextbox;
        private System.Windows.Forms.Button convert_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox title_text;
        private System.Windows.Forms.TextBox artist_text;
        private System.Windows.Forms.TextBox effecter_text;
        private System.Windows.Forms.TextBox ilust_text;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox difficulty_text;
        private System.Windows.Forms.ComboBox level_text;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox musicpath_text;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button soundloadbtn;
        private System.Windows.Forms.TextBox soundpath;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

