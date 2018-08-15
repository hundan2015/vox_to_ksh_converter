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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.soundloadbtn = new System.Windows.Forms.Button();
            this.soundpath = new System.Windows.Forms.TextBox();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.outputfilename_text = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.version = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.voxver = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // chartloadbtn
            // 
            resources.ApplyResources(this.chartloadbtn, "chartloadbtn");
            this.chartloadbtn.Name = "chartloadbtn";
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
            resources.ApplyResources(this.save_btn, "save_btn");
            this.save_btn.Name = "save_btn";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // filepathtextbox
            // 
            resources.ApplyResources(this.filepathtextbox, "filepathtextbox");
            this.filepathtextbox.Name = "filepathtextbox";
            // 
            // convert_btn
            // 
            this.convert_btn.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.convert_btn, "convert_btn");
            this.convert_btn.Name = "convert_btn";
            this.convert_btn.UseVisualStyleBackColor = true;
            this.convert_btn.Click += new System.EventHandler(this.convert_btn_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // title_text
            // 
            resources.ApplyResources(this.title_text, "title_text");
            this.title_text.Name = "title_text";
            // 
            // artist_text
            // 
            resources.ApplyResources(this.artist_text, "artist_text");
            this.artist_text.Name = "artist_text";
            // 
            // effecter_text
            // 
            resources.ApplyResources(this.effecter_text, "effecter_text");
            this.effecter_text.Name = "effecter_text";
            // 
            // ilust_text
            // 
            resources.ApplyResources(this.ilust_text, "ilust_text");
            this.ilust_text.Name = "ilust_text";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // difficulty_text
            // 
            resources.ApplyResources(this.difficulty_text, "difficulty_text");
            this.difficulty_text.FormattingEnabled = true;
            this.difficulty_text.Items.AddRange(new object[] {
            resources.GetString("difficulty_text.Items"),
            resources.GetString("difficulty_text.Items1"),
            resources.GetString("difficulty_text.Items2"),
            resources.GetString("difficulty_text.Items3")});
            this.difficulty_text.Name = "difficulty_text";
            // 
            // level_text
            // 
            resources.ApplyResources(this.level_text, "level_text");
            this.level_text.FormattingEnabled = true;
            this.level_text.Items.AddRange(new object[] {
            resources.GetString("level_text.Items"),
            resources.GetString("level_text.Items1"),
            resources.GetString("level_text.Items2"),
            resources.GetString("level_text.Items3"),
            resources.GetString("level_text.Items4"),
            resources.GetString("level_text.Items5"),
            resources.GetString("level_text.Items6"),
            resources.GetString("level_text.Items7"),
            resources.GetString("level_text.Items8"),
            resources.GetString("level_text.Items9"),
            resources.GetString("level_text.Items10"),
            resources.GetString("level_text.Items11"),
            resources.GetString("level_text.Items12"),
            resources.GetString("level_text.Items13"),
            resources.GetString("level_text.Items14"),
            resources.GetString("level_text.Items15"),
            resources.GetString("level_text.Items16"),
            resources.GetString("level_text.Items17"),
            resources.GetString("level_text.Items18"),
            resources.GetString("level_text.Items19")});
            this.level_text.Name = "level_text";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // musicpath_text
            // 
            resources.ApplyResources(this.musicpath_text, "musicpath_text");
            this.musicpath_text.Name = "musicpath_text";
            // 
            // soundloadbtn
            // 
            resources.ApplyResources(this.soundloadbtn, "soundloadbtn");
            this.soundloadbtn.Name = "soundloadbtn";
            this.soundloadbtn.UseVisualStyleBackColor = true;
            this.soundloadbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // soundpath
            // 
            resources.ApplyResources(this.soundpath, "soundpath");
            this.soundpath.Name = "soundpath";
            this.soundpath.TextChanged += new System.EventHandler(this.soundpath_TextChanged);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // outputfilename_text
            // 
            resources.ApplyResources(this.outputfilename_text, "outputfilename_text");
            this.outputfilename_text.Name = "outputfilename_text";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Name = "label10";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // version
            // 
            resources.ApplyResources(this.version, "version");
            this.version.Name = "version";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // date
            // 
            resources.ApplyResources(this.date, "date");
            this.date.Name = "date";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // voxver
            // 
            resources.ApplyResources(this.voxver, "voxver");
            this.voxver.Name = "voxver";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // time
            // 
            resources.ApplyResources(this.time, "time");
            this.time.Name = "time";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.progressBar1, "progressBar1");
            this.progressBar1.Name = "progressBar1";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.time);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.voxver);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.date);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.version);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.outputfilename_text);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.soundpath);
            this.Controls.Add(this.soundloadbtn);
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
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button chartloadbtn;
        private System.Windows.Forms.Button save_btn;
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
        private System.Windows.Forms.Button soundloadbtn;
        private System.Windows.Forms.TextBox soundpath;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox outputfilename_text;
        private System.Windows.Forms.Label label10;
        public System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label version;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label date;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label voxver;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

