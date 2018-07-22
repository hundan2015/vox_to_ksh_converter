using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vox_to_ksh_converter
{
    public partial class Form1 : Form
    {
        List<string> Obj_Data = new List<string>();
        List<string> handle_split = new List<string>();
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
        public Form1()
        {
            InitializeComponent();


        }
        public bool load_vox(String FilePath)
        {
            int line = 0;
            string buffer;
            string[] handle;
            System.IO.StreamReader ksh_file = new System.IO.StreamReader(FilePath);
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
            autotap_data.Clear();
            tilt_data.Clear();
            peak_effect_data.Clear();
            fx_effect_data.Clear();
            laser_fx_value_data.Clear();

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
            }
            handle = beat_data[0].Split('\t');
            if (handle[0] == "001,01,00")
            {
                beat_bunmo = Convert.ToInt32(handle[1]);
                beat_bunja = Convert.ToInt32(handle[2]);
            }
            else
            {
                error = "beat parse error";
                return false;
            }
            handle = bpm_data[0].Split('\t');
            if (handle[0] == "001,01,00")
            {
                bpm = Convert.ToDouble(handle[1]);
            }
            else
            {
                error = "bpm parse error";
                return false;
            }
            string[] data_line = new string[10];
            string data_line_result = "";
            int longnote_length_a = 0;
            int longnote_length_b = 0;
            int longnote_length_c = 0;
            int longnote_length_d = 0;
            Obj_Data.Add("t="+Convert.ToString(bpm));
            Obj_Data.Add("beat=" + Convert.ToString(beat_bunja)+"/"+ Convert.ToString(beat_bunmo));
            for (int bar = 1; bar <= end_pos; bar++)
            {
                Obj_Data.Add("--");
                for (int beat = 1; beat <= beat_bunmo; beat++)
                {
                    for (int tick = 0; tick < 48; tick++)
                    {                      
                        string current_pos = String.Format("{0:D3}", bar) + "," + String.Format("{0:D2}", beat) + "," + String.Format("{0:D2}", tick);
                        for(int a=0; a < Track3_data.Count(); a++)
                        {
                            handle = Track3_data[a].Split('\t');
                            if(handle[0] == current_pos)
                            {
                                if (longnote_length_a == 0 && Convert.ToInt16(handle[1]) == 0)
                                {
                                    data_line[0] = "1";
                                }
                                else if(Convert.ToInt16(handle[1]) > 0)
                                {
                                    data_line[0] = "2";
                                    longnote_length_a = Convert.ToInt16(handle[1]);
                                }
                                break;
                            }
                            else if(longnote_length_a > 0)
                            {
                                data_line[0] = "2";
                                longnote_length_a--;
                                break;
                            }
                            else
                            {
                                data_line[0] = "0";
                                break;
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
                                    longnote_length_b = Convert.ToInt16(handle[1]);
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
                                break;
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
                                    longnote_length_c = Convert.ToInt16(handle[1]);
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
                                break;
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
                                    longnote_length_d = Convert.ToInt16(handle[1]);
                                }
                                break;
                            }
                            else if (longnote_length_d > 0)
                            {
                                data_line[3] = "2";
                                longnote_length_d--;
                                break;
                            }
                            else
                            {
                                data_line[3] = "0";
                                break;
                            }
                            
                        }
                        data_line[4] = "|";
                        data_line[5] = "0";
                        data_line[6] = "0";
                        data_line[7] = "|";
                        data_line[8] = "-";
                        data_line[9] = "-";
                        for (int p = 0; p<10; p++)
                        {
                            data_line_result += data_line[p];
                        }
                        Obj_Data.Add(data_line_result);
                        data_line_result = null;
                        
                    }
                }
            }
            Obj_Data.Add("--");
            return true;
        }
                      
        private void save_ksh()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                // System.IO.File.WriteAllText(Application.StartupPath)
                string FilePath = folderBrowserDialog1.SelectedPath + "\\result.ksh";
                using (StreamWriter File = new StreamWriter(FilePath))
                {
                    for(int i = 0; i < Obj_Data.Count(); i++)
                    {
                        File.WriteLine(Obj_Data[i]);
                    }
                }
            }
        }
            

        string laser_convert(int input)
        {
            double a = (double)input / 2.54;
            int result = Convert.ToInt32(Math.Round(Math.Round(a * 100) / 100));
            return Convert.ToString(Ksh_Laser[result]);
        }
        string fx_define_convert(string input)
        {
            string input_converted = input.Replace("\t", "");
            string[] vox_fx_info = input_converted.Split(',');
            string[] fx_type_name = { "Retrigger", "Gate", "Flanger", "TapeStop ", "SideChain", "Wobble", "BitCrusher", "Echo", " PitchShift", "SwitchAudio" };
            string type = "";
            string type_name = "";
            string updateTrigger = "";
            string updatePeriod = "";
            string volume = "";
            string waveLength = "";
            string bit = "";
            string mix = "";
            string speed = "";
            string result = "";
            if (vox_fx_info[0] == "1" || vox_fx_info[0] == "8")
            {
                type = fx_type_name[0];
                bit = Convert.ToString((4 / Convert.ToDouble(vox_fx_info[3])) * Convert.ToDouble(vox_fx_info[1]));
                updatePeriod = "1/"+Convert.ToString(4 / Convert.ToDouble(vox_fx_info[3]));
                waveLength ="1/"+ bit;
                mix = "0%>"+Convert.ToString(Convert.ToInt32(Convert.ToDouble(vox_fx_info[2]))) + "%";
                if(vox_fx_info[0] == "8")
                    result = "RE" + bit + " type=" + type + ";updatePeriod=0" + ";waveLength=" + waveLength + ";mix=" + mix + "updateTrigger=off> on";
                else
                    result = "RE" + bit + " type=" + type + ";updatePeriod=" + updatePeriod + ";waveLength=" + waveLength + ";mix=" + mix;
            }
            else if(vox_fx_info[0] == "2")
            {
                type = fx_type_name[1];
                bit = Convert.ToString((2 / Convert.ToDouble(vox_fx_info[3])) * Convert.ToDouble(vox_fx_info[2]));
                waveLength = "1/" + bit;
                mix = "0%>" + Convert.ToString(Convert.ToInt32(Convert.ToDouble(vox_fx_info[1]))) + "%";
                result = "GA" + bit + " type=" + type + ";waveLength=" + waveLength;
            }            
            else if(vox_fx_info[0] == "3")
            {

            }
            else if(vox_fx_info[0] == "4")
            {
                double speed_1;
                type = fx_type_name[3];
                mix = "0%>" + Convert.ToString(Convert.ToInt32(Convert.ToDouble(vox_fx_info[1]))) + "%";
                speed_1 = (Convert.ToDouble(vox_fx_info[3]) * 10 )/ 6.75;
                if (speed_1 > 50)
                    speed = "50";
                else
                    speed = Convert.ToString(speed_1) + "%";
                result = "Tstop" + speed + " type=" + type + ";speed=" + speed + ";mix=" + mix;
            }
            return result;
        }

        private void chartloadbtn_Click(object sender, EventArgs e)
        {
            label1.Text = fx_define_convert(textBox1.Text);
            openFileDialog1.ShowDialog();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            save_ksh();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            load_vox(openFileDialog1.FileName);
        }
    }
}
