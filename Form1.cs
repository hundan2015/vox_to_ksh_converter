﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using _2dxlib;

namespace vox_to_ksh_converter
{
    public partial class Form1 : Form
    {
        int dxfilecount;
        string savedir = "";
        string ver_last = "1.20";
        string date_last = "2018-08-17";
        string supportvoxver = "6~10";
        string time_last = "13:21";
        bool loadok = false;
        string last_filter_name = "";
        string sound_filepath = "";
        string ksh_filepath = "";
        string last_filtertype = "";
        List <string> Obj_Data = new List<string>();
        List<string> handle_split = new List<string>();
        List<string> format_ver = new List<string>();
        List<string> Track1_data = new List<string>();
        List<string> Track2_data = new List<string>();
        List<string> Track3_data = new List<string>();
        List<string> Track4_data = new List<string>();
        List<string> Track5_data = new List<string>();
        List<string> Track6_data = new List<string>();
        List<string> Track7_data = new List<string>();
        List<string> Track8_data = new List<string>();
        List<string> Spcont_data = new List<string>();
        List<string> bpm_data = new List<string>();
        List<string> beat_data = new List<string>();
        List<string> autotap_data = new List<string>();
        List<string> tilt_data = new List<string>();
        List<string> peak_effect_data = new List<string>();
        List<string> fx_effect_data = new List<string>();
        List<string> laser_fx_value_data = new List<string>();
        double cam_sens_top = 150.0;
        double cam_sens_btm = -150.0;
        List<string> fx_define_data = new List<string>();
        List<string> filter_define_data = new List<string>();
        int vox_version;
        int end_pos;
        //int beat, bar, tick;
        int beat_bunja, beat_bunmo;
        double bpm;
        string error;
        char[] Ksh_Laser = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o' };
        //string Ksh_Laser = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmno";
        List<List<string>> Data = new List<List<string>>();
        List<string> Raw_vox_data = new List<string>();
        public Form1(string[] args)
        {
            
            //Application.Run(new Form2()); 
            if (args.Length > 0)
            {
                /* string argument = "";
                 for (int i = 0; i < args.Length; i++)
                 {
                     argument += args[i];
                     argument += " ";
                 }*/
                try
                {
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(args[0]);
                    //MessageBox.Show("Language changed into " + Convert.ToString(Thread.CurrentThread.CurrentUICulture));
                }
                catch (System.Globalization.CultureNotFoundException)
                {
                    MessageBox.Show("\"" + args[0] + "\"" + " is not a valid language code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
            InitializeComponent();
            time.Text = time_last;
            date.Text = date_last;
            voxver.Text = supportvoxver;
            version.Text = ver_last;

        }
        
                      
        private void save_ksh()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // System.IO.File.WriteAllText(Application.StartupPath)
                string FilePath = "";
                
                if (outputfilename_text.Text == "")
                {
                    FilePath = folderBrowserDialog1.SelectedPath + "\\result.ksh";
                }
                else
                {
                    FilePath = folderBrowserDialog1.SelectedPath + "\\" + outputfilename_text.Text;
                }
                savedir = folderBrowserDialog1.SelectedPath + "\\" + Path.GetFileNameWithoutExtension(FilePath).Substring(0, Path.GetFileNameWithoutExtension(FilePath).Length - 3);
                DirectoryInfo di = new DirectoryInfo(savedir);
                if (di.Exists != true)
                    di.Create();
                
                using (StreamWriter File = new StreamWriter(savedir + "\\" + Path.GetFileName(FilePath)))
                {
                    for(int i = 0; i < Obj_Data.Count(); i++)
                    {
                        File.WriteLine(Obj_Data[i]);
                    }
                    for(int i=0; i<fx_define_data.Count(); i++)
                    {
                        File.WriteLine(fx_define_data[i]);
                    }
                    for(int i=0; i<filter_define_data.Count(); i++)
                    {
                        File.WriteLine(filter_define_data[i]);
                    }
                }
                if (soundpath.Text != "")
                {
                    dxlib.dxextract(soundpath.Text, savedir);
                }
            }
        }
        
        string filter_param_add(string input)
        {
            string result="";            
            string[] handle = input.Split(' ');
            string[] eff_info = handle[0].Split(',');
            int effnum = Convert.ToInt32(eff_info[0]);
            string[] param = laser_fx_value_data[effnum + 2].Split(',');
            for(int i=0; i< param.Count(); i++)
            {
                param[i] = param[i].Replace("\t","");
            }

            if (param[1] == "0")
            {
                return input;
            }
            else
            {
                
            }
            return result;
        }

        string laser_convert(int input)
        {
            double a = input / 2.54;
            int result = Convert.ToInt32(Math.Round(Math.Round(a * 100) / 100));
            return Convert.ToString(Ksh_Laser[result]);
        }
        string fx_define_convert(string input)
        {
            string input_converted = input.Replace("\t", "");
            string[] vox_fx_info = input_converted.Split(',');
            string[] fx_type_name = { "Retrigger", "Gate", "Flanger", "TapeStop", "SideChain", "Wobble", "BitCrusher", "Echo", "PitchShift", "SwitchAudio" };
            string type = "";
            string type_name = "";
            string updateTrigger = "";
            string updatePeriod = "";
            string volume = "";
            string waveLength = "";
            string delay = "";
            string depth = "";
            string bit = "";
            string mix = "";
            string speed = "";
            string result = "";
            string rate = "";
            string feedbackvol = "";
            string lowfreq = "";
            string highfreq = "";
            string Q = "";
            string pitch = "";
            string reduction = "";
            if (vox_fx_info[0] == "1" || vox_fx_info[0] == "8")
            {
                type = fx_type_name[0];
                if(Convert.ToDouble(vox_fx_info[3], CultureInfo.InvariantCulture) < 0)
                {
                    bit =  Convert.ToString(Convert.ToInt32(vox_fx_info[1])*16);
                    updatePeriod = "1/18";
                }
                else
                {
                    bit = Convert.ToString((4 / Convert.ToDouble(vox_fx_info[3],CultureInfo.InvariantCulture)) * Convert.ToDouble(vox_fx_info[1], CultureInfo.InvariantCulture));
                    updatePeriod = "1/" + Convert.ToString(4 / Convert.ToDouble(vox_fx_info[3], CultureInfo.InvariantCulture));
                }                              
                waveLength ="1/"+ bit;
                rate = Convert.ToString(Convert.ToInt32(Convert.ToDouble(vox_fx_info[5], CultureInfo.InvariantCulture) * 100))+"%";
                mix = "0%>"+Convert.ToString(Convert.ToInt32(Convert.ToDouble(vox_fx_info[2], CultureInfo.InvariantCulture))) + "%";
                feedbackvol = Convert.ToString( Convert.ToInt32(Convert.ToDouble(vox_fx_info[4], CultureInfo.InvariantCulture) *100));
                if(feedbackvol != "100")
                {
                    if (vox_fx_info[0] == "8")
                        result = "Echo," + bit+","+feedbackvol + " type=Echo;updatePeriod=0" + ";waveLength=" + waveLength + ";mix=" + mix  + ";updateTrigger=off>on" + ";feedbackLevel="+feedbackvol+"%";
                    else
                        result = "Echo," + bit +","+feedbackvol+ " type=Echo;updatePeriod=" + updatePeriod + ";waveLength=" + waveLength +  ";mix=" + mix + ";updateTrigger=off" + ";feedbackLevel=" + feedbackvol + "%";
                }
                else if(Convert.ToDouble(vox_fx_info[3], CultureInfo.InvariantCulture) < 0)
                {
                    result = "RE," + bit + " type=" + type + ";updatePeriod=" + updatePeriod + ";waveLength=" + waveLength + ";rate=" + rate + ";mix=" + mix;
                }
                else
                {
                    if (vox_fx_info[0] == "8")
                    result = "RE," + bit + " type=" + type + ";updatePeriod=0" + ";waveLength=" + waveLength + ";mix=" + mix +";rate=" + rate + ";updateTrigger=off>on";
                    else
                    result = "RE," + bit + " type=" + type + ";updatePeriod=" + updatePeriod + ";waveLength=" + waveLength + ";rate="+rate + ";mix=" + mix;
                }
               
            }
            else if(vox_fx_info[0] == "2")
            {
                type = fx_type_name[1];
                bit = Convert.ToString((2 / Convert.ToDouble(vox_fx_info[3], CultureInfo.InvariantCulture)) * Convert.ToDouble(vox_fx_info[2], CultureInfo.InvariantCulture));
                waveLength = "1/" + bit;
                mix = "0%>" + Convert.ToString(Convert.ToInt32(Convert.ToDouble(vox_fx_info[1], CultureInfo.InvariantCulture))) + "%";
                result = "GA," + bit + " type=" + type + ";waveLength=" + waveLength;
            }            
            else if(vox_fx_info[0] == "3")
            {
                type = fx_type_name[2];
                delay = Convert.ToString(Convert.ToInt32(Convert.ToDouble(vox_fx_info[2], CultureInfo.InvariantCulture) * 100))+"samples";
                depth = Convert.ToString(Convert.ToInt32(Convert.ToDouble(vox_fx_info[3], CultureInfo.InvariantCulture) * 100)) + "samples";
                volume = Convert.ToString(Convert.ToInt32(Convert.ToDouble(vox_fx_info[1], CultureInfo.InvariantCulture)))+"%";
                result = "Flan" + " type=" + type + ";delay=" + delay + ";depth=" + depth + ";volume=" + volume;
            }
            else if(vox_fx_info[0] == "4")
            {
                double speed_1;
                type = fx_type_name[3];
                mix = "0%>" + Convert.ToString(Convert.ToInt32(Convert.ToDouble(vox_fx_info[1], CultureInfo.InvariantCulture))) + "%";
                speed_1 = (Convert.ToDouble(vox_fx_info[3], CultureInfo.InvariantCulture) * (Convert.ToDouble(vox_fx_info[2], CultureInfo.InvariantCulture) * 9.8125));
                if (speed_1 > 50)
                    speed = "50";
                else
                    speed = Convert.ToString(Convert.ToInt16(speed_1));
                result = "Tstop," + speed + " type=" + type + ";speed=" + speed +"%"+ ";mix=" + mix;
            }
            else if(vox_fx_info[0] == "5")
            {
                type = fx_type_name[4];
                bit = Convert.ToString(Convert.ToInt16(Convert.ToDouble(vox_fx_info[2], CultureInfo.InvariantCulture) * 2));
                waveLength = "1/" + bit;
                result = "Sich," + bit + " type=" + type + ";period=" + waveLength;
            }
            else if (vox_fx_info[0] == "6")
            {
                type = fx_type_name[5];
                lowfreq = Convert.ToString(Convert.ToInt32(Convert.ToDouble(vox_fx_info[4], CultureInfo.InvariantCulture)));
                highfreq = Convert.ToString(Convert.ToInt32(Convert.ToDouble(vox_fx_info[5], CultureInfo.InvariantCulture)));
                Q = Convert.ToString(Convert.ToDouble(vox_fx_info[7], CultureInfo.InvariantCulture));
                waveLength = "1/"+ Convert.ToString(Convert.ToInt16(Convert.ToDouble(vox_fx_info[6], CultureInfo.InvariantCulture)) * 4);
                bit = Convert.ToString(Convert.ToInt16(Convert.ToDouble(vox_fx_info[6], CultureInfo.InvariantCulture)) * 4);
                mix = "0%>" + Convert.ToString(Convert.ToInt32(Convert.ToDouble(vox_fx_info[3], CultureInfo.InvariantCulture))) + "%";
                result = "Wob," + bit + " type=" + type + ";loFreq=" + lowfreq + "Hz;hiFreq=" + highfreq + "Hz;Q=" + Q + ";waveLength=" + waveLength;
            }
            else if (vox_fx_info[0] == "7")
            {
                type = fx_type_name[6];
                reduction = vox_fx_info[2];
                mix = "0%>" + Convert.ToString(Convert.ToInt32(Convert.ToDouble(vox_fx_info[1], CultureInfo.InvariantCulture))) + "%";
                result = "Bitc," + reduction + " type=" + type + ";reduction=" + reduction + "samples" + ";mix=" + mix;
            }
            else if (vox_fx_info[0] == "9")
            {
                type = fx_type_name[8];
                pitch = Convert.ToString(Convert.ToInt16(Convert.ToDouble(vox_fx_info[2], CultureInfo.InvariantCulture)));
                mix = "0%>" + Convert.ToString(Convert.ToInt32(Convert.ToDouble(vox_fx_info[1], CultureInfo.InvariantCulture))) + "%";
                result = "Pitc," + pitch + " type=" + type + ";pitch=" + pitch + ";mix=" + mix;
            }
            else if (vox_fx_info[0] == "11")
            {
                type = fx_type_name[5];
                lowfreq = Convert.ToString(Convert.ToInt32(Convert.ToDouble(vox_fx_info[3], CultureInfo.InvariantCulture)));
                highfreq = Convert.ToString(Convert.ToInt32(Convert.ToDouble(vox_fx_info[3], CultureInfo.InvariantCulture)));
                Q = "1.4";
                result = "LPF" + " type=" + type + ";loFreq=" + lowfreq + "Hz;hiFreq=" + highfreq + "Hz;Q=" + Q;
            }
            else
            {
                result = null;
            }
            return result;
        }

        private void chartloadbtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Sound Voltex chart files|*.vox|All files (*.*)|*.*";
            openFileDialog1.Title = "Select a chart file.";
            openFileDialog1.ShowDialog();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            save_ksh();
        }

        private void convert_btn_Click(object sender, EventArgs e)
        {


            title_text.Enabled = false;
            artist_text.Enabled = false;
            musicpath_text.Enabled = false;
            ilust_text.Enabled = false;
            effecter_text.Enabled = false;
            difficulty_text.Enabled = false;
            level_text.Enabled = false;
            backgroundWorker1.RunWorkerAsync(ksh_filepath);
            

        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            
            soundpath.Text = openFileDialog2.FileName;
            sound_filepath = openFileDialog2.FileName;
            _2dxload(sound_filepath);
            
            //MessageBox.Show(Convert.ToString(dxlib.vaild2dx(sound_filepath)[0]));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Bemani sound files|*.2dx|All files (*.*)|*.*";
            openFileDialog2.Title = "Select a 2dx file.";
            openFileDialog2.ShowDialog();
        }

        private void soundpath_TextChanged(object sender, EventArgs e)
        {
            //openFileDialog2.InitialDirectory = soundpath.Text;
            sound_filepath = soundpath.Text;
            if (soundpath.Text != "")
            {
                if(_2dxload(sound_filepath) == false)
                {
                    soundpath.Text = "";
                }
                
            }
            
            
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            convert_btn.Enabled = false;
            chartloadbtn.Enabled = false;
            string kfpath = (string)e.Argument;
            //MessageBox.Show(kfpath); 
            //loadok = load_vox(kfpath);
            Func<string,bool> load_vox = null;
            load_vox = (FilePath) =>
            {
                {                  
                    bool lasermute = false;
                    bool anotherfx = false;
                    int line = 0;
                    string buffer;
                    string[] handle;
                    System.IO.StreamReader ksh_file = new System.IO.StreamReader(FilePath, System.Text.Encoding.UTF8);
                    Raw_vox_data.Clear();
                    Data.Clear();
                    Obj_Data.Clear();
                    Track1_data.Clear();
                    Track2_data.Clear();
                    Track3_data.Clear();
                    Track4_data.Clear();
                    Track5_data.Clear();
                    Track6_data.Clear();
                    Track7_data.Clear();
                    Track8_data.Clear();
                    handle_split.Clear();
                    Spcont_data.Clear();
                    bpm_data.Clear();
                    beat_data.Clear();
                    fx_define_data.Clear();
                    filter_define_data.Clear();
                    autotap_data.Clear();
                    tilt_data.Clear();
                    peak_effect_data.Clear();
                    fx_effect_data.Clear();
                    format_ver.Clear();
                    laser_fx_value_data.Clear();
                    Obj_Data.Add("title=" + title_text.Text);
                    Obj_Data.Add("artist=" + artist_text.Text);
                    Obj_Data.Add("effect=" + effecter_text.Text);
                    Obj_Data.Add("illustrator=" + ilust_text.Text);
                    Obj_Data.Add("difficulty=" + difficulty_text.Text);
                    Obj_Data.Add("level=" + level_text.Text);
                    Obj_Data.Add("chokkakuautovol=0");
                    Obj_Data.Add("chokkakuvol=50");
                    Obj_Data.Add("pfiltergain=50");
                    Obj_Data.Add("bg=desert\r\nlayer=arrow");
                    Obj_Data.Add("jacket=.jpg");
                    Obj_Data.Add("m=" + musicpath_text.Text);
                    Obj_Data.Add("mvol=100");
                    while ((buffer = ksh_file.ReadLine()) != null)
                    {
                        line++;
                        Raw_vox_data.Add(buffer);
                    }

                    for (int i = 0; i < line; i++)
                    {
                        if (Raw_vox_data[i] == "#BEAT INFO")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                j++;
                                if (Raw_vox_data[j] != "#END") beat_data.Add(Raw_vox_data[j]);
                            }

                        }
                        if (Raw_vox_data[i] == "#BPM INFO")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                j++;
                                if (Raw_vox_data[j] != "#END") bpm_data.Add(Raw_vox_data[j]);
                            }

                        }
                        if (Raw_vox_data[i] == "#TILT MODE INFO")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                j++;
                                if (Raw_vox_data[j] != "#END") tilt_data.Add(Raw_vox_data[j]);
                            }

                        }
                        if (Raw_vox_data[i] == "#END POSITION")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                string[] tempbuffer;
                                j++;
                                tempbuffer = Raw_vox_data[j].Split(',');
                                if (Raw_vox_data[j] != "#END") end_pos = Convert.ToInt32(tempbuffer[0]);
                            }

                        }
                        if (Raw_vox_data[i] == "#TAB EFFECT INFO")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                j++;
                                if (Raw_vox_data[j] != "#END") peak_effect_data.Add(Raw_vox_data[j]);
                            }

                        }
                        if (Raw_vox_data[i] == "#FXBUTTON EFFECT INFO")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                j++;
                                if (Raw_vox_data[j] != "#END") fx_effect_data.Add(Raw_vox_data[j]);
                            }

                        }
                        if (Raw_vox_data[i] == "#TAB PARAM ASSIGN INFO")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                j++;
                                if (Raw_vox_data[j] != "#END") laser_fx_value_data.Add(Raw_vox_data[j]);
                            }

                        }
                        if (Raw_vox_data[i] == "#TRACK1")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                j++;
                                if (Raw_vox_data[j] != "#END") Track1_data.Add(Raw_vox_data[j]);
                            }

                        }
                        if (Raw_vox_data[i] == "#TRACK2")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                j++;
                                if (Raw_vox_data[j] != "#END") Track2_data.Add(Raw_vox_data[j]);
                            }

                        }
                        if (Raw_vox_data[i] == "#TRACK3")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                j++;
                                if (Raw_vox_data[j] != "#END") Track3_data.Add(Raw_vox_data[j]);
                            }

                        }
                        if (Raw_vox_data[i] == "#TRACK4")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                j++;
                                if (Raw_vox_data[j] != "#END") Track4_data.Add(Raw_vox_data[j]);
                            }

                        }
                        if (Raw_vox_data[i] == "#TRACK5")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                j++;
                                if (Raw_vox_data[j] != "#END") Track5_data.Add(Raw_vox_data[j]);
                            }

                        }
                        if (Raw_vox_data[i] == "#TRACK6")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                j++;
                                if (Raw_vox_data[j] != "#END") Track6_data.Add(Raw_vox_data[j]);
                            }

                        }
                        if (Raw_vox_data[i] == "#TRACK7")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                j++;
                                if (Raw_vox_data[j] != "#END") Track7_data.Add(Raw_vox_data[j]);
                            }

                        }
                        if (Raw_vox_data[i] == "#TRACK8")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                j++;
                                if (Raw_vox_data[j] != "#END") Track8_data.Add(Raw_vox_data[j]);
                            }

                        }
                        if (Raw_vox_data[i] == "#SPCONTROLER")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                j++;
                                if (Raw_vox_data[j] != "#END") Spcont_data.Add(Raw_vox_data[j]);
                            }

                        }
                        if (Raw_vox_data[i] == "#TRACK AUTO TAB")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                j++;
                                if (Raw_vox_data[j] != "#END") autotap_data.Add(Raw_vox_data[j]);
                            }

                        }
                        if (Raw_vox_data[i] == "#FORMAT VERSION")
                        {
                            int j = i;
                            while (Raw_vox_data[j] != "#END")
                            {
                                j++;
                                if (Raw_vox_data[j] != "#END") format_ver.Add(Raw_vox_data[j]);
                            }
                        }
                    }
                    ksh_file.Close();
                    try
                    {
                        handle = beat_data[0].Split('\t');
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        error = "No beat information found.";
                        return false;
                    }
                    vox_version = Convert.ToInt16(format_ver[0]);
                    if (vox_version < 6)
                    {
                        error = "This converter supports vox ver 6 to 10 only.";
                        return false;
                    }
                    if (handle[0] == "001,01,00")
                    {
                        beat_bunmo = Convert.ToInt32(handle[2]);
                        beat_bunja = Convert.ToInt32(handle[1]);
                    }
                    else
                    {
                        error = "beat parse error";
                        return false;
                    }
                    handle = bpm_data[0].Split('\t');
                    if (handle[0] == "001,01,00")
                    {
                        bpm = Convert.ToDouble(handle[1], CultureInfo.InvariantCulture);
                        Obj_Data.Add("t=" + bpm);
                    }
                    else
                    {
                        error = "bpm parse error";
                        return false;
                    }
                    Obj_Data.Add("filtertype=peak");
                    string[] data_line = new string[11];
                    // data_line = null;
                    string data_line_result = null;
                    int longnote_length_a = 0;
                    int longnote_length_b = 0;
                    int longnote_length_c = 0;
                    int longnote_length_d = 0;
                    int longnote_length_fx_l = 0;
                    int longnote_length_fx_r = 0;
                    double last_cam_btm_value = 0.0;
                    double last_cam_top_value = 0.0;
                    int cam_btm_length = 0;
                    int cam_top_length = 0;
                    int current_beat = 0;
                    int zero_tilt_langth = 0;
                    string last_laser_L_pos = "";
                    string last_laser_L_x = "";
                    string last_laser_R_x = "";
                    int last_laser_L_value = 0;
                    int last_laser_L_length = 0;
                    int last_laser_R_length = 0;
                    bool laser_L_slam = false;
                    bool laser_R_slam = false;
                    string last_laser_R_pos = "";
                    int last_laser_R_value = 0;
                    bool laser_L = false;
                    bool laser_R = false;
                    bool laser_filter = false;
                    bool cam_top = false;
                    bool cam_btm = false;
                    bool tilt_side = false;
                    bool stop = true;
                    bool autotab_enabled = false;
                    int autotap_length = 0;
                    int stop_length = 0;
                    string last_laser_filter = null;
                    string last_laser_filter_r = null;
                    string last_laser_filter_l = null;
                    string[,] fx_param_data = new string[12, 1];
                    string laser_filter_data = null;
                    List<string> other_func_data = new List<string>();
                    //Obj_Data.Add("t="+Convert.ToString(bpm));
                    // Obj_Data.Add("beat=" + Convert.ToString(beat_bunja)+"/"+ Convert.ToString(beat_bunmo));
                    Obj_Data.Add("ver=160");
                    other_func_data.Clear();
                    {
                        fx_param_data[0, 0] = fx_effect_data[0];
                        fx_param_data[1, 0] = fx_effect_data[3];
                        fx_param_data[2, 0] = fx_effect_data[6];
                        fx_param_data[3, 0] = fx_effect_data[9];
                        fx_param_data[4, 0] = fx_effect_data[12];
                        fx_param_data[5, 0] = fx_effect_data[15];
                        fx_param_data[6, 0] = fx_effect_data[18];
                        fx_param_data[7, 0] = fx_effect_data[21];
                        fx_param_data[8, 0] = fx_effect_data[24];
                        fx_param_data[9, 0] = fx_effect_data[27];
                        fx_param_data[10, 0] = fx_effect_data[30];
                        fx_param_data[11, 0] = fx_effect_data[33];
                        for (int i = 0; i < 12; i++)
                        {
                            if (fx_define_convert(fx_param_data[i, 0]) != null)
                            {
                                fx_define_data.Add( "#define_fx " + (i + 2) + "," + fx_define_convert(fx_param_data[i, 0]));
                                filter_define_data.Add( "#define_filter " + (i + 2) + "," + fx_define_convert(fx_param_data[i, 0]));
                            }
                            else
                            {
                                fx_define_data.Add(null);
                                filter_define_data.Add(null);
                            }

                        }

                    }
                    progressBar1.Maximum = end_pos;
                    
                    for (int bar = 1; bar <= end_pos; bar++)
                    {
                        label10.Text = bar + "/" + end_pos;
                        progressBar1.Value = bar;
                        Obj_Data.Add("--");
                        //string current_pos_bar = String.Format("{0:D3}", bar) + ",01,00";
                        //other_func_data.Add("//" + current_pos_bar);
                        for (int beat = 1; beat <= beat_bunja; beat++)
                        {
                            for (int tick = 0; tick < (192 / beat_bunmo); tick = tick + 1)
                            {
                                
                                string current_pos = String.Format("{0:D3}", bar) + "," + String.Format("{0:D2}", beat) + "," + String.Format("{0:D2}", tick);
                                
                                for (; ; )
                                {

                                    for (int a = 0; a < bpm_data.Count(); a++)
                                    {
                                        handle = bpm_data[a].Split('\t');
                                        if (handle[0] == current_pos && handle[2].Contains("-") == false)
                                        {
                                            other_func_data.Add("t=" + Convert.ToString(handle[1]));
                                        }
                                        else if (handle[0] == current_pos && handle[2].Contains("-") == true)
                                        {
                                            string[] handle_a = bpm_data[a + 1].Split('\t');
                                            stop = true;
                                            string[] pos = handle[0].Split(',');
                                            int[] pos_b = new int[3];
                                            int[] pos_f = new int[3];
                                            double pos_b_value = 0;
                                            double pos_f_value = 0;
                                            for (int i = 0; i < 3; i++)
                                            {
                                                pos_b[i] = Convert.ToInt32(pos[i]);
                                            }
                                            pos = handle_a[0].Split(',');
                                            for (int i = 0; i < 3; i++)
                                            {
                                                pos_f[i] = Convert.ToInt32(pos[i]);
                                            }
                                            pos_b_value = (pos_b[0] * (192 * (beat_bunja / beat_bunmo))) + (pos_b[1] * (192 / beat_bunja)) + (pos_b[2]);
                                            pos_f_value = (pos_f[0] * (192 * (beat_bunja / beat_bunmo))) + (pos_f[1] * (192 / beat_bunja)) + (pos_f[2]);
                                            stop_length = Convert.ToInt32(pos_f_value) - Convert.ToInt32(pos_b_value);
                                            Obj_Data.Add("stop=" + stop_length);

                                        }
                                    }
                                    for (int a = 0; a < beat_data.Count(); a++)
                                    {
                                        handle = beat_data[a].Split('\t');
                                        if (handle[0] == current_pos)
                                        {
                                            beat_bunmo = Convert.ToInt32(handle[2]);
                                            beat_bunja = Convert.ToInt32(handle[1]);
                                            other_func_data.Add("beat=" + Convert.ToString(beat_bunja) + "/" + Convert.ToString(beat_bunmo));
                                        }
                                    }
                                    break;
                                }
                                for (int a = 0; a < Track3_data.Count(); a++)
                                {

                                    handle = Track3_data[a].Split('\t');
                                    if (handle[0] == current_pos)
                                    {
                                        if (longnote_length_a == 0 && Convert.ToInt16(handle[1]) == 0)
                                        {
                                            data_line[0] = "1";
                                        }
                                        else if (Convert.ToInt16(handle[1]) > 0)
                                        {
                                            data_line[0] = "2";
                                            longnote_length_a = Convert.ToInt16(handle[1]) - 1;
                                        }
                                        break;
                                    }
                                    else if (longnote_length_a > 0)
                                    {
                                        data_line[0] = "2";
                                        longnote_length_a--;
                                        break;
                                    }
                                    else
                                    {
                                        data_line[0] = "0";
                                        // break;
                                    }

                                }
                                for (int a = 0; a < Track4_data.Count(); a++)
                                {
                                    handle = Track4_data[a].Split('\t');
                                    if (handle[0] == current_pos)
                                    {
                                        if (longnote_length_b == 0 && Convert.ToInt16(handle[1]) == 0)
                                        {
                                            data_line[1] = "1";
                                        }
                                        else if (Convert.ToInt16(handle[1]) > 0)
                                        {
                                            data_line[1] = "2";
                                            longnote_length_b = Convert.ToInt16(handle[1]) - 1;
                                        }
                                        break;
                                    }
                                    else if (longnote_length_b > 0)
                                    {
                                        data_line[1] = "2";
                                        longnote_length_b--;
                                        break;
                                    }
                                    else
                                    {
                                        data_line[1] = "0";
                                        // break;
                                    }

                                }
                                for (int a = 0; a < Track5_data.Count(); a++)
                                {
                                    handle = Track5_data[a].Split('\t');
                                    if (handle[0] == current_pos)
                                    {
                                        if (longnote_length_c == 0 && Convert.ToInt16(handle[1]) == 0)
                                        {
                                            data_line[2] = "1";
                                        }
                                        else if (Convert.ToInt16(handle[1]) > 0)
                                        {
                                            data_line[2] = "2";
                                            longnote_length_c = Convert.ToInt16(handle[1]) - 1;
                                        }
                                        break;
                                    }
                                    else if (longnote_length_c > 0)
                                    {
                                        data_line[2] = "2";
                                        longnote_length_c--;
                                        break;
                                    }
                                    else
                                    {
                                        data_line[2] = "0";
                                        // break;
                                    }

                                }
                                for (int a = 0; a < Track6_data.Count(); a++)
                                {
                                    handle = Track6_data[a].Split('\t');
                                    if (handle[0] == current_pos)
                                    {
                                        if (longnote_length_d == 0 && Convert.ToInt16(handle[1]) == 0)
                                        {
                                            data_line[3] = "1";
                                        }
                                        else if (Convert.ToInt16(handle[1]) > 0)
                                        {
                                            data_line[3] = "2";
                                            longnote_length_d = Convert.ToInt16(handle[1]) - 1;
                                        }
                                        break;
                                    }
                                    else if (longnote_length_d > 0)
                                    {
                                        longnote_length_d--;
                                        data_line[3] = "2";

                                        break;
                                    }
                                    else
                                    {
                                        data_line[3] = "0";
                                        // break;
                                    }
                                }
                                for (int a = 0; a < Track2_data.Count(); a++)
                                {
                                    handle = Track2_data[a].Split('\t');
                                    if (handle[0] == current_pos)
                                    {
                                        if (longnote_length_fx_l == 0 && Convert.ToInt16(handle[1]) == 0)
                                        {
                                            data_line[5] = "2";
                                            if (Convert.ToInt16(handle[2]) != 0 && vox_version >= 10)
                                            {
                                                Obj_Data.Add("fx-l_se=" + handle[2]);
                                            }
                                        }
                                        else if (Convert.ToInt16(handle[1]) > 0)
                                        {

                                            data_line[5] = "1";
                                            longnote_length_fx_l = Convert.ToInt16(handle[1]) - 1;
                                            if (handle[2] != "0")
                                            {
                                                if (Convert.ToInt16(handle[2]) == 254)
                                                {
                                                    anotherfx = true;
                                                    Obj_Data.Add("fx-l=fx");
                                                    //Obj_Data.Add("//This(FX_L) effect is another sound file.");
                                                }
                                                else if (fx_define_data[Convert.ToInt16(handle[2]) - 2] != null)
                                                {
                                                    string[] fx = fx_define_data[Convert.ToInt16(handle[2]) - 2].Split(' ');
                                                    string[] fx_param = fx[1].Split(',');
                                                    if (fx_param.Length > 2)
                                                    {
                                                        Obj_Data.Add("fx-l=" + fx[1] + ";" + fx_param[2]);
                                                    }
                                                    else
                                                    {
                                                        Obj_Data.Add("fx-l=" + fx[1]);
                                                    }
                                                }
                                                else
                                                {
                                                    Obj_Data.Add("//This(FX_L) effect is not supported.");
                                                }
                                            }

                                        }
                                        break;
                                    }
                                    else if (longnote_length_fx_l > 0)
                                    {
                                        longnote_length_fx_l--;
                                        data_line[5] = "1";

                                        break;
                                    }
                                    else
                                    {
                                        data_line[5] = "0";
                                    }
                                }
                                for (int a = 0; a < Track7_data.Count(); a++)
                                {
                                    handle = Track7_data[a].Split('\t');
                                    if (handle[0] == current_pos)
                                    {
                                        if (longnote_length_fx_r == 0 && Convert.ToInt16(handle[1]) == 0)
                                        {
                                            data_line[6] = "2";
                                            if (Convert.ToInt16(handle[2]) != 0 && vox_version >= 10)
                                            {
                                                Obj_Data.Add("fx-r_se=" + handle[2]);
                                            }
                                        }
                                        else if (Convert.ToInt16(handle[1]) > 0)
                                        {
                                            data_line[6] = "1";
                                            longnote_length_fx_r = Convert.ToInt16(handle[1]) - 1;
                                            if (handle[2] != "0")
                                            {
                                                if (Convert.ToInt16(handle[2]) == 254)
                                                {
                                                    anotherfx = true;
                                                    Obj_Data.Add("fx-r=fx");
                                                    //Obj_Data.Add("//This(FX_R) effect is another sound file.");
                                                }
                                                else if (fx_define_data[Convert.ToInt16(handle[2]) - 2] != null)
                                                {
                                                    string[] fx = fx_define_data[Convert.ToInt16(handle[2]) - 2].Split(' ');
                                                    string[] fx_param = fx[1].Split(',');
                                                    if (fx_param.Length > 2)
                                                    {
                                                        Obj_Data.Add("fx-r=" + fx[1] + ";" + fx_param[2]);
                                                    }
                                                    else
                                                    {
                                                        Obj_Data.Add("fx-r=" + fx[1]);
                                                    }
                                                }
                                                else
                                                {
                                                    Obj_Data.Add("//This(FX_R) effect is not supported.");
                                                }
                                            }
                                        }
                                        break;
                                    }
                                    else if (longnote_length_fx_r > 0)
                                    {
                                        longnote_length_fx_r--;
                                        data_line[6] = "1";

                                        break;
                                    }
                                    else
                                    {
                                        data_line[6] = "0";
                                    }
                                }

                                //Laser_L
                                for (int a = 0; a < Track1_data.Count(); a++)
                                {
                                    handle = Track1_data[a].Split('\t');

                                    if (laser_L_slam == true)
                                    {
                                        last_laser_L_length--;
                                        if (last_laser_L_length == 0)
                                        {
                                            data_line[8] = laser_convert(Convert.ToInt16(last_laser_L_x));
                                            laser_L_slam = false;
                                        }
                                        else if (last_laser_L_length > 0)
                                        {
                                            data_line[8] = ":";
                                        }
                                        break;
                                    }
                                    else if (handle[0] == current_pos)
                                    {
                                        last_laser_L_value = a;
                                        if (handle[2] == "1")
                                        {
                                            data_line[8] = laser_convert(Convert.ToInt16(handle[1]));
                                            laser_L = true;
                                        }
                                        else if (handle[2] == "0")
                                        {
                                            data_line[8] = laser_convert(Convert.ToInt16(handle[1]));
                                        }
                                        else if (handle[2] == "2")
                                        {
                                            data_line[8] = laser_convert(Convert.ToInt16(handle[1]));
                                            laser_L = false;
                                        }
                                        if (handle[5] == "2")
                                        {
                                            other_func_data.Add("laserrange_l=2x");
                                        }

                                        if (handle[4] != null)
                                        {
                                            if (handle[4] == "2")
                                            {
                                                if (last_laser_filter_l != handle[4])
                                                {
                                                    laser_filter_data = "filtertype=lpf1";
                                                    last_laser_filter_l = handle[4];
                                                    last_laser_filter = handle[4];
                                                }

                                            }
                                            else if (handle[4] == "4")
                                            {
                                                if (last_laser_filter_l != handle[4])
                                                {
                                                    laser_filter_data = "filtertype=hpf1";
                                                    last_laser_filter = handle[4];
                                                    last_laser_filter_l = handle[4];
                                                }
                                            }
                                            else if (handle[4] == "5")
                                            {
                                                if (last_laser_filter_l != handle[4])
                                                {
                                                    laser_filter_data = "filtertype=bitc";
                                                    last_laser_filter = handle[4];
                                                    last_laser_filter_l = handle[4];
                                                }

                                            }
                                            else if (handle[4] == "0")
                                            {
                                                if (last_laser_filter_l != handle[4])
                                                {
                                                    laser_filter_data = "filtertype=peak";
                                                    last_laser_filter = handle[4];
                                                    last_laser_filter_l = handle[4];
                                                }

                                            }

                                            else if (handle[4] == "6")
                                            {
                                                last_laser_filter_l = "6";
                                            }
                                        }
                                        if (a < Track1_data.Count() - 1)
                                        {
                                            string[] handle_1 = Track1_data[a + 1].Split('\t');

                                            if (handle_1[0] == current_pos)
                                            {
                                                laser_L_slam = true;
                                                last_laser_L_length = 6;
                                                last_laser_L_x = handle_1[1];
                                                if (handle[3] == "1")
                                                {
                                                    if (Convert.ToInt16(handle[1]) > Convert.ToInt16(handle_1[1]))
                                                    {
                                                        data_line[10] = "@(192";
                                                    }
                                                    else
                                                    {
                                                        data_line[10] = "@)192";
                                                    }
                                                }
                                                else if (handle[3] == "2")
                                                {
                                                    if (Convert.ToInt16(handle[1]) > Convert.ToInt16(handle_1[1]))
                                                    {
                                                        data_line[10] = "@(48";
                                                    }
                                                    else
                                                    {
                                                        data_line[10] = "@)48";
                                                    }
                                                }
                                                else if (handle[3] == "3")
                                                {
                                                    if (Convert.ToInt16(handle[1]) > Convert.ToInt16(handle_1[1]))
                                                    {
                                                        data_line[10] = "@(96";
                                                    }
                                                    else
                                                    {
                                                        data_line[10] = "@)96";
                                                    }
                                                }
                                                else if (handle[3] == "4")
                                                {
                                                    if (Convert.ToInt16(handle[1]) > Convert.ToInt16(handle_1[1]))
                                                    {
                                                        data_line[10] = "@(384";
                                                    }
                                                    else
                                                    {
                                                        data_line[10] = "@)384";
                                                    }
                                                }
                                                else if (handle[3] == "5")
                                                {
                                                    if (Convert.ToInt16(handle[1]) > Convert.ToInt16(handle_1[1]))
                                                    {
                                                        data_line[10] = "@<96";
                                                    }
                                                    else
                                                    {
                                                        data_line[10] = "@>96";
                                                    }
                                                }
                                                else if (handle[3] == "0")
                                                {
                                                    data_line[10] = "";
                                                }
                                                if (handle_1[2] == "2")
                                                {
                                                    laser_L = false;
                                                }
                                                if (handle_1[4] != null)
                                                {
                                                    if (handle_1[4] == "2")
                                                    {
                                                        if (last_laser_filter_l != handle_1[4])
                                                        {
                                                            laser_filter_data = "filtertype=lpf1";
                                                            last_laser_filter_l = handle_1[4];
                                                            last_laser_filter = handle_1[4];
                                                        }

                                                    }
                                                    else if (handle_1[4] == "4")
                                                    {
                                                        if (last_laser_filter_l != handle_1[4])
                                                        {
                                                            laser_filter_data = "filtertype=hpf1";
                                                            last_laser_filter = handle_1[4];
                                                            last_laser_filter_l = handle_1[4];
                                                        }
                                                    }
                                                    else if (handle_1[4] == "5")
                                                    {
                                                        if (last_laser_filter_l != handle_1[4])
                                                        {
                                                            laser_filter_data = "filtertype=bitc";
                                                            last_laser_filter = handle_1[4];
                                                            last_laser_filter_l = handle_1[4];
                                                        }

                                                    }
                                                    else if (handle_1[4] == "0")
                                                    {
                                                        if (last_laser_filter_l != handle_1[4])
                                                        {
                                                            laser_filter_data = "filtertype=peak";
                                                            last_laser_filter = handle_1[4];
                                                            last_laser_filter_l = handle_1[4];
                                                        }

                                                    }

                                                    else if (handle_1[4] == "6")
                                                    {
                                                        last_laser_filter_l = "6";
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                    else if (laser_L == true)
                                    {
                                        // last_laser_L_value = a;
                                        data_line[8] = ":";
                                        // break;
                                    }
                                    else
                                    {
                                        data_line[8] = "-";
                                    }

                                }
                                //laser_R
                                for (int a = 0; a < Track8_data.Count(); a++)
                                {
                                    handle = Track8_data[a].Split('\t');
                                    last_laser_filter = handle[4];
                                    if (laser_R_slam == true)
                                    {
                                        last_laser_R_length--;
                                        if (last_laser_R_length == 0)
                                        {
                                            data_line[9] = laser_convert(Convert.ToInt16(last_laser_R_x));
                                            laser_R_slam = false;
                                        }
                                        else if (last_laser_R_length > 0)
                                        {
                                            data_line[9] = ":";
                                        }
                                        break;
                                    }
                                    else if (handle[0] == current_pos)
                                    {
                                        last_laser_R_value = a;
                                        if (handle[2] == "1")
                                        {
                                            data_line[9] = laser_convert(Convert.ToInt16(handle[1]));
                                            laser_R = true;
                                        }
                                        else if (handle[2] == "0")
                                        {
                                            data_line[9] = laser_convert(Convert.ToInt16(handle[1]));
                                        }
                                        else if (handle[2] == "2")
                                        {
                                            data_line[9] = laser_convert(Convert.ToInt16(handle[1]));
                                            laser_R = false;
                                        }
                                        if (handle[5] == "2")
                                        {
                                            other_func_data.Add("laserrange_r=2x");
                                        }

                                        if (handle[4] != null)
                                        {
                                            if (handle[4] == "2")
                                            {
                                                if (last_laser_filter_r != handle[4])
                                                {
                                                    laser_filter_data = "filtertype=lpf1";
                                                    last_laser_filter = handle[4];
                                                    last_laser_filter_r = handle[4];
                                                }

                                            }
                                            else if (handle[4] == "4")
                                            {
                                                if (last_laser_filter_r != handle[4])
                                                {
                                                    laser_filter_data = "filtertype=hpf1";
                                                    last_laser_filter = handle[4];
                                                    last_laser_filter_r = handle[4];
                                                }
                                            }
                                            else if (handle[4] == "5")
                                            {
                                                if (last_laser_filter_r != handle[4])
                                                {
                                                    laser_filter_data = "filtertype=bitc";
                                                    last_laser_filter = handle[4];
                                                    last_laser_filter_r = handle[4];
                                                }

                                            }
                                            else if (handle[4] == "0")
                                            {
                                                if (last_laser_filter_r != handle[4])
                                                {
                                                    laser_filter_data = "filtertype=peak";
                                                    last_laser_filter = handle[4];
                                                    last_laser_filter_r = handle[4];
                                                }

                                            }

                                            else if (handle[4] == "6")
                                            {
                                                last_laser_filter_r = "6";
                                            }


                                        }
                                        if (a < Track8_data.Count() - 1)
                                        {
                                            string[] handle_1 = Track8_data[a + 1].Split('\t');
                                            last_laser_filter = handle_1[4];
                                            if (handle_1[0] == current_pos)
                                            {
                                                if (handle[3] == "1")
                                                {
                                                    if (Convert.ToInt16(handle[1]) > Convert.ToInt16(handle_1[1]))
                                                    {
                                                        data_line[10] = "@(192";
                                                    }
                                                    else
                                                    {
                                                        data_line[10] = "@)192";
                                                    }

                                                }
                                                else if (handle[3] == "2")
                                                {
                                                    if (Convert.ToInt16(handle[1]) > Convert.ToInt16(handle_1[1]))
                                                    {
                                                        data_line[10] = "@(48";
                                                    }
                                                    else
                                                    {
                                                        data_line[10] = "@)48";
                                                    }
                                                }
                                                else if (handle[3] == "3")
                                                {
                                                    if (Convert.ToInt16(handle[1]) > Convert.ToInt16(handle_1[1]))
                                                    {
                                                        data_line[10] = "@(96";
                                                    }
                                                    else
                                                    {
                                                        data_line[10] = "@)96";
                                                    }
                                                }
                                                else if (handle[3] == "4")
                                                {
                                                    if (Convert.ToInt16(handle[1]) > Convert.ToInt16(handle_1[1]))
                                                    {
                                                        data_line[10] = "@(384";
                                                    }
                                                    else
                                                    {
                                                        data_line[10] = "@)384";
                                                    }
                                                }
                                                else if (handle[3] == "5")
                                                {
                                                    if (Convert.ToInt16(handle[1]) > Convert.ToInt16(handle_1[1]))
                                                    {
                                                        data_line[10] = "@<96";
                                                    }
                                                    else
                                                    {
                                                        data_line[10] = "@>96";
                                                    }
                                                }
                                                else if (handle[3] == "0")
                                                {
                                                    data_line[10] = "";
                                                }
                                                laser_R_slam = true;
                                                last_laser_R_length = 6;
                                                last_laser_R_x = handle_1[1];
                                                if (handle_1[2] == "2")
                                                {
                                                    laser_R = false;
                                                }
                                                if (handle_1[4] != null)
                                                {
                                                    if (handle_1[4] == "2")
                                                    {
                                                        if (last_laser_filter_l != handle_1[4])
                                                        {
                                                            laser_filter_data = "filtertype=lpf1";
                                                            last_laser_filter_l = handle_1[4];
                                                            last_laser_filter = handle_1[4];
                                                        }

                                                    }
                                                    else if (handle_1[4] == "4")
                                                    {
                                                        if (last_laser_filter_l != handle_1[4])
                                                        {
                                                            laser_filter_data = "filtertype=hpf1";
                                                            last_laser_filter = handle_1[4];
                                                            last_laser_filter_l = handle_1[4];
                                                        }
                                                    }
                                                    else if (handle_1[4] == "5")
                                                    {
                                                        if (last_laser_filter_l != handle_1[4])
                                                        {
                                                            laser_filter_data = "filtertype=bitc";
                                                            last_laser_filter = handle_1[4];
                                                            last_laser_filter_l = handle_1[4];
                                                        }

                                                    }
                                                    else if (handle_1[4] == "0")
                                                    {
                                                        if (last_laser_filter_l != handle_1[4])
                                                        {
                                                            laser_filter_data = "filtertype=peak";
                                                            last_laser_filter = handle_1[4];
                                                            last_laser_filter_l = handle_1[4];
                                                        }

                                                    }

                                                    else if (handle_1[4] == "6")
                                                    {
                                                        last_laser_filter_r = "6";
                                                    }
                                                }
                                            }
                                        }
                                        break;
                                    }
                                    else if (laser_R == true)
                                    {
                                        // last_laser_R_value = a;
                                        data_line[9] = ":";
                                        // break;
                                    }
                                    else
                                    {
                                        data_line[9] = "-";
                                    }

                                }
                                for (int a = 0; a < autotap_data.Count(); a++)
                                {
                                    handle = autotap_data[a].Split('\t');
                                    if (handle[0] == current_pos)
                                    {
                                        if (Convert.ToInt16(handle[2]) == 254)
                                        {
                                            anotherfx = true;
                                            Obj_Data.Add("filtertype=fx");
                                            lasermute = true;
                                            //Obj_Data.Add("//This FX effect is another sound file.");
                                        }
                                        else if (filter_define_data[Convert.ToInt16(handle[2]) - 2] != null)
                                        {
                                            string[] filter_fx = filter_define_data[Convert.ToInt16(handle[2]) - 2].Split(' ');
                                            string[] fx_param = filter_fx[2].Split(';');
                                            last_filtertype = fx_param[0].Replace("type=", "");
                                            autotab_enabled = true;
                                            autotap_length = Convert.ToInt32(handle[1]);
                                            if (last_laser_filter_l == "6" || last_laser_filter_r == "6")
                                            {
                                                Obj_Data.Add("filtertype=" + filter_fx[1]);
                                                lasermute = true;
                                            }
                                            else
                                            {
                                                if (last_filtertype == "SideChain")
                                                {
                                                    Obj_Data.Add("filter:" + filter_fx[1] + ":ratio=5");
                                                }
                                                else if (last_filtertype == "TapeStop")
                                                {
                                                    Obj_Data.Add("filtertype=" + filter_fx[1]);
                                                }
                                                else
                                                {
                                                    Obj_Data.Add("filter:" + filter_fx[1] + ":mix=100%");
                                                }

                                            }
                                            last_filter_name = filter_fx[1];
                                        }
                                        else
                                        {
                                            Obj_Data.Add("//This fx effect is not supported.");
                                        }
                                        break;
                                    }
                                    else if (autotap_length > 0)
                                    {
                                        autotap_length--;
                                        if (autotap_length == 0)
                                        {

                                            autotab_enabled = false;
                                            if (lasermute == true)
                                            {

                                                if (last_laser_filter == "0")
                                                {
                                                    Obj_Data.Add("filtertype=peak");
                                                }
                                                else if (last_laser_filter == "2")
                                                {
                                                    Obj_Data.Add("filtertype=lpf1");
                                                }
                                                else if (last_laser_filter == "4")
                                                {
                                                    Obj_Data.Add("filtertype=hpf1");
                                                }
                                                else if (last_laser_filter == "5")
                                                {
                                                    Obj_Data.Add("filtertype=bitc");
                                                }
                                                lasermute = false;
                                            }
                                            else
                                            {
                                                if (last_filtertype == "SideChain")
                                                {
                                                    Obj_Data.Add("filter:" + last_filter_name + ":ratio=1>5");
                                                }
                                                else if (last_filtertype == "TapeStop")
                                                {
                                                    Obj_Data.Add("filtertype=" + last_filter_name);
                                                }
                                                else
                                                {
                                                    Obj_Data.Add("filter:" + last_filter_name + ":mix=0%>100");
                                                }

                                            }

                                        }
                                        break;
                                    }
                                }
                                for (int a = 0; a < Spcont_data.Count(); a++)
                                {
                                    handle = Spcont_data[a].Split('\t');
                                    if (handle[0] == current_pos && handle[1] == "CAM_RotX")
                                    {
                                        cam_top = true;
                                        if (handle[4] == "")
                                        {
                                            other_func_data.Add("zoom_top=" + Convert.ToString(Convert.ToDouble(handle[4 + 1], CultureInfo.InvariantCulture) * cam_sens_top));
                                            last_cam_top_value = Convert.ToDouble(handle[5 + 1], CultureInfo.InvariantCulture) * cam_sens_top;
                                            cam_top_length = Convert.ToInt32(handle[3]);
                                            if (cam_top_length == 0)
                                            {
                                                cam_top = false;
                                                other_func_data.Add("zoom_top=" + Convert.ToInt32(Convert.ToDouble(handle[5 + 1], CultureInfo.InvariantCulture) * cam_sens_top));
                                            }
                                            break;
                                        }
                                        else
                                        {
                                            other_func_data.Add("zoom_top=" + Convert.ToString(Convert.ToDouble(handle[4], CultureInfo.InvariantCulture) * cam_sens_top));
                                            last_cam_top_value = Convert.ToDouble(handle[5], CultureInfo.InvariantCulture) * cam_sens_top;
                                            cam_top_length = Convert.ToInt32(handle[3]);
                                            if (cam_top_length == 0)
                                            {
                                                cam_top = false;
                                                other_func_data.Add("zoom_top=" + Convert.ToInt32(Convert.ToDouble(handle[5], CultureInfo.InvariantCulture) * cam_sens_top));
                                            }
                                            break;
                                        }
                                    }
                                    else if (cam_top_length > 0)
                                    {
                                        cam_top_length--;
                                        break;
                                    }
                                    else if (cam_top_length == 0 && cam_top == true)
                                    {
                                        other_func_data.Add("zoom_top=" + last_cam_top_value);
                                        cam_top = false;
                                        break;
                                    }
                                }
                                for (int a = 0; a < Spcont_data.Count(); a++)
                                {
                                    handle = Spcont_data[a].Split('\t');
                                    if (handle[0] == current_pos && handle[1] == "CAM_Radi")
                                    {
                                        cam_btm = true;
                                        if (handle[4] == "")
                                        {
                                            other_func_data.Add("zoom_bottom=" + Convert.ToString(Convert.ToDouble(handle[4 + 1], CultureInfo.InvariantCulture) * cam_sens_btm));
                                            last_cam_btm_value = Convert.ToDouble(handle[5 + 1], CultureInfo.InvariantCulture) * cam_sens_btm;
                                            cam_btm_length = Convert.ToInt32(handle[3]);
                                            if (cam_btm_length == 0)
                                            {
                                                cam_btm = false;
                                                other_func_data.Add("zoom_bottom=" + Convert.ToInt32(Convert.ToDouble(handle[5 + 1], CultureInfo.InvariantCulture) * cam_sens_btm));
                                            }
                                            break;
                                        }
                                        else
                                        {
                                            other_func_data.Add("zoom_bottom=" + Convert.ToString(Convert.ToDouble(handle[4], CultureInfo.InvariantCulture) * cam_sens_btm));
                                            last_cam_btm_value = Convert.ToDouble(handle[5], CultureInfo.InvariantCulture) * cam_sens_btm;
                                            cam_btm_length = Convert.ToInt32(handle[3]);
                                            if (cam_btm_length == 0)
                                            {
                                                cam_btm = false;
                                                other_func_data.Add("zoom_bottom=" + Convert.ToInt32(Convert.ToDouble(handle[5], CultureInfo.InvariantCulture) * cam_sens_btm));
                                            }
                                            break;
                                        }
                                    }
                                    else if (cam_btm_length > 0)
                                    {
                                        cam_btm_length--;
                                        break;
                                    }
                                    else if (cam_btm_length == 0 && cam_btm == true)
                                    {
                                        other_func_data.Add("zoom_bottom=" + last_cam_btm_value);
                                        cam_btm = false;
                                        break;
                                    }
                                }
                                for (int a = 0; a < Spcont_data.Count(); a++)
                                {
                                    handle = Spcont_data[a].Split('\t');
                                    if (handle[0] == current_pos && handle[1] == "Tilt")
                                    {
                                        if (handle[4] == "0.00" && handle[5] == "0.00")
                                        {
                                            zero_tilt_langth = Convert.ToInt32(handle[3]);
                                            other_func_data.Add("tilt=zero");
                                        }
                                        break;
                                    }
                                    else if (zero_tilt_langth > 0)
                                    {
                                        zero_tilt_langth--;
                                        if (zero_tilt_langth == 0)
                                        {
                                            other_func_data.Add("tilt=normal");
                                        }
                                        break;
                                    }
                                }
                                for (int a = 0; a < tilt_data.Count(); a++)
                                {
                                    handle = tilt_data[a].Split('\t');
                                    if (handle[0] == current_pos)
                                    {
                                        if (handle[1] == "0")
                                        {
                                            other_func_data.Add("tilt=normal");
                                        }
                                        else if (handle[1] == "1")
                                        {
                                            other_func_data.Add("tilt=biggest");
                                        }
                                        else if (handle[1] == "2")
                                        {
                                            other_func_data.Add("tilt=keep_biggest");
                                        }
                                        break;
                                    }
                                }
                                for (int a = 0; a < Spcont_data.Count(); a++)
                                {
                                    handle = Spcont_data[a].Split('\t');

                                    string temp = "";
                                    if (handle[0] == current_pos)
                                    {
                                        for (int i = 0; i < handle.Count(); i++)
                                        {
                                            if (handle[i] != "")
                                            {
                                                temp += handle[i] + ";";
                                            }
                                        }
                                        string[] handle_nospace = temp.Split(';');
                                        if (handle_nospace[1] == "SpecialN")
                                        {
                                            Obj_Data.Add("//" + handle_nospace[4] + " " + handle_nospace[5]);
                                        }
                                        if (handle_nospace[1] == "HudY")
                                        {
                                            Obj_Data.Add("//HudUp " + handle_nospace[4] + "->" + handle_nospace[5] + " time:" + handle_nospace[3]);
                                        }
                                        if (handle_nospace[1] == "LaneY")
                                        {
                                            Obj_Data.Add("//Lane " + handle_nospace[4] + "->" + handle_nospace[5] + " time:" + handle_nospace[3]);
                                        }
                                        break;
                                    }
                                }
                               
                                if (data_line != null)
                                {
                                    data_line[4] = "|";
                                    data_line[7] = "|";
                                    for (int p = 0; p < 11; p++)
                                    {
                                        data_line_result += data_line[p];
                                    }
                                }
                                if (laser_filter_data != null)
                                {
                                    other_func_data.Add(laser_filter_data);
                                    laser_filter_data = null;
                                }
                                if (other_func_data.Count() > 0)
                                {
                                    for (int i = 0; i < other_func_data.Count(); i++)
                                        Obj_Data.Add(other_func_data[i]);
                                    other_func_data.Clear();
                                }
                                if (data_line_result != null)
                                {
                                    Obj_Data.Add(data_line_result);
                                    data_line_result = null;
                                }
                                data_line[10] = "";
                            }

                        }
                        
                        //Task.Delay(1000);
                    }
                    if (anotherfx == true)
                    {
                        filter_define_data.Add("#define_filter fx type=SwitchAudio;fileName=1.wav");
                        fx_define_data.Add("#define_fx fx type=SwitchAudio;fileName=1.wav");
                    }
                    Obj_Data.Add("--");
                    return true;
                }
            };
            loadok = load_vox(kfpath);
            //bool load_voxs(string FilePath)         
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            convert_btn.Enabled = true;
            chartloadbtn.Enabled = true;
            //MessageBox.Show("bw end");
            if (loadok == true)
            {
                save_btn.Enabled = true;
                SystemSounds.Beep.Play();
            }
            else
            {
                MessageBox.Show(error, "Load error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string[] vox_file_name = Path.GetFileNameWithoutExtension(openFileDialog1.FileName).Split('_');
            outputfilename_text.Text = Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + ".ksh";
            //if(Directory.GetParent(Directory.GetParent(Directory.GetParent(openFileDialog1.FileName).FullName).FullName).FullName != null)
            try
            {
                openFileDialog2.InitialDirectory = Directory.GetParent(Directory.GetParent(Directory.GetParent(openFileDialog1.FileName).FullName).FullName).FullName + "\\sound";
                soundpath.Text = Directory.GetParent(Directory.GetParent(Directory.GetParent(openFileDialog1.FileName).FullName).FullName).FullName + "\\sound\\" + Path.GetFileNameWithoutExtension(openFileDialog1.FileName).Substring(0, Path.GetFileNameWithoutExtension(openFileDialog1.FileName).Length - 3) + ".2dx";
            }
            catch
            {
                openFileDialog2.InitialDirectory = Directory.GetParent(openFileDialog1.FileName).FullName;
                soundpath.Text = "";
                dx_info.Text = "2dx autoload failed.";
            }
            convert_btn.Enabled = true;
            save_btn.Enabled = false;
            ksh_filepath = openFileDialog1.FileName;
            filepathtextbox.Text = ksh_filepath;
            title_text.Enabled = true;
            artist_text.Enabled = true;
            musicpath_text.Enabled = true;
            ilust_text.Enabled = true;
            effecter_text.Enabled = true;
            difficulty_text.Enabled = true;
            level_text.Enabled = true;
            
            if (vox_file_name.Count() > 1)
            {
                title_text.Clear();
                for (int i=2; i < vox_file_name.Count() - 1; i++)
                {
                    title_text.Text += vox_file_name[i];
                    if(i != vox_file_name.Count()-2)
                        title_text.Text += "_";
                }
                artist_text.Text = vox_file_name[vox_file_name.Count() - 2];
                if (vox_file_name[vox_file_name.Count() - 1] == "1n")
                {
                    difficulty_text.SelectedIndex = 0;
                }
                else if (vox_file_name[vox_file_name.Count() - 1] == "2a")
                {
                    difficulty_text.SelectedIndex = 1;
                }
                else if (vox_file_name[vox_file_name.Count() - 1] == "3e")
                {
                    difficulty_text.SelectedIndex = 2;
                }
                else if (vox_file_name[vox_file_name.Count() - 1] == "4i" || vox_file_name[vox_file_name.Count() - 1] == "5m")
                {
                    difficulty_text.SelectedIndex = 3;
                }
                else
                {
                    difficulty_text.SelectedIndex = 0;
                }
                
            }
            

        }

        private void voxver_Click(object sender, EventArgs e)
        {

        }

        public bool _2dxload(string path)
        {
          
            object[] dxinfo = dxlib.vaild2dx(path);
            

            if (Convert.ToString(dxinfo[0]) == "true")
            {
                dx_info.Text = "2dx loaded, HeaderSize:  " + Convert.ToString(dxinfo[2]) + "byte, Included wav files: " + Convert.ToString(dxinfo[3]) + ", Name in header: " + Convert.ToString(dxinfo[1]);
               dxfilecount = Convert.ToInt32(dxinfo[3]);
                if(dxfilecount == 1)
                {
                    musicpath_text.Text = "0.wav";
                }
                else if(dxfilecount == 2)
                {
                    musicpath_text.Text = "0.wav";
                }
                else
                {
                    musicpath_text.Text = "0.wav";
                }
                return true;
            }
            else if(Convert.ToString(dxinfo[0]) == "false")
            {
                dx_info.Text = "2dx autoload failed ";
                return false;
               // MessageBox.Show(path + " is not a vaild 2dx file.","2dx load error",MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            else
            {
                dx_info.Text = "2dx autoload failed .";
                MessageBox.Show(dxinfo[0].ToString(),"2dx Load Failed");
                return false;
            }
            
        }
    }
}
