using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowStopper
{
    public partial class Form1 : Form
    {
        private int hour;
        private int minute;
        private int second;
        private Settings settings;
        private string saveFileName;
        private bool needToSave;
        

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 1000; // 10 Hz
            this.settings = new Settings();
            this.reset();
            this.loadButtons();
        }

        public void reset()
        {
            this.hour = 0;
            this.minute = 0;
            this.second = 0;
            this.saveFileName = "";
            this.needToSave = false;
        }

        public string getTime()
        {
            string fmt = "{0:00}:{1:00}:{2:00}";
            string rtn = String.Format(fmt, this.hour, this.minute, this.second);
            return rtn;
        }

        public void DisplayTime()
        {
            string dt = this.getTime();
            this.displayLbl.Text = dt;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            this.second++;
            if (this.second >= 60)
            {
                this.second = 0;
                this.minute++;
            }
            if(this.minute >= 60)
            {
                this.minute = 0;
                this.hour++;
            }
            this.DisplayTime();
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            string ts = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.saveFileName = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            this.startLbl.Text = ts;
            Settings.ButtonSpec bs = new Settings.ButtonSpec("Start", "START", "Started at " + ts);
            this.addRow(bs);
            timer1.Start();
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            string ts = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.stopLbl.Text = ts;
            Settings.ButtonSpec bs = new Settings.ButtonSpec("Stop", "STOP", "Stopped at " + ts);
            this.addRow(bs);
            timer1.Stop();
        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            this.reset();
            this.DisplayTime();
            this.startLbl.Text = "";
            this.stopLbl.Text = "";
            dataGridView1.Rows.Clear();
        }

        private bool okToExit()
        {
            bool rtn = true;
            if (this.needToSave == true)
            {
                AreYouSure ays = new AreYouSure();
                DialogResult result = ays.ShowDialog();
                switch (result)
                {
                    case DialogResult.Yes:
                        // save first ...
                        saveBtn_Click(null,null);
                        break;
                    case DialogResult.No:
                        break;
                    case DialogResult.Cancel:
                        rtn = false;
                        break;
                }
            }
            return rtn;
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            if (this.okToExit())
            {
                this.Close();
                Application.Exit();
            }
        }

        private void clearButtons()
        {
            List<Control> listControls = new List<Control>();

            foreach (Control control in this.buttonFlp.Controls)
            {
                listControls.Add(control);
            }

            foreach (Control control in listControls)
            {
                this.buttonFlp.Controls.Remove(control);
                control.Dispose();
            }
        }
        private Color getColorFromString(string s)
        {
            Color rtn = Color.Black;
            int ir, ig, ib;
            ir = ig = ib = 0;
            string[] sa = s.Split(','); // r,g,b
            if(sa.Length == 3)
            {
                ir = int.Parse(sa[0]);
                ig = int.Parse(sa[1]);
                ib = int.Parse(sa[2]);
             }
             rtn = System.Drawing.Color.FromArgb(ir, ig, ib);

            return rtn;
        }
        private void loadButtons()
        {
            this.clearButtons();
            this.settings = new Settings();
            foreach (KeyValuePair<string, Settings.ButtonSpec> entry in this.settings.buttons)
            {
                string l = entry.Value.buttonLabel;
                string t = entry.Value.buttonType;
                string m = entry.Value.buttonMessage;
                Button btn = new Button();
                btn.AutoSize = true;
                btn.Text = l;
                Settings.ColorSet cs = this.settings.getColorSet(t);
                btn.ForeColor = this.getColorFromString(cs.fgColor);
                btn.BackColor = this.getColorFromString(cs.bgColor);
                btn.Click += new EventHandler(button_Click);
                buttonFlp.Controls.Add(btn);
            }
        }

        private void addRow(Settings.ButtonSpec bs)
        {
            int r;
            
            Settings.ColorSet cs = this.settings.getColorSet(bs.buttonType);
            Color fg = this.getColorFromString(cs.fgColor);
            Color bg = this.getColorFromString(cs.bgColor);
            List<string> ls = new List<string>();
            ls.Add(this.getTime());
            ls.Add(bs.buttonType);
            ls.Add(bs.buttonMessage);
            r = dataGridView1.Rows.Add(ls.ToArray());
            DataGridViewRow row = dataGridView1.Rows[r];
            for (int i = 0; i < row.Cells.Count; i++)
            {
                row.Cells[i].Style.ForeColor = fg;
                row.Cells[i].Style.BackColor = bg;
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string label = btn.Text;
            Settings.ButtonSpec bs = this.settings.getButtonSpec(label);
            this.addRow(bs);
            this.needToSave = true;
        }

        private int hms_to_seconds(string hms)
        {
            // hh:mm:ss
            int rtn = 0;
            int hours   = int.Parse(hms.Substring(0, 2));
            int minutes = int.Parse(hms.Substring(3, 2));
            int seconds = int.Parse(hms.Substring(6, 2));
            rtn = seconds + (60 * minutes) + (3600 * hours);

            return rtn;
        }

        private string seconds_to_hms(int s)
        {
            int hours = s / 3600;
            s = s - (hours * 3600);
            int minutes = s / 60;
            s = s - (minutes * 60);
            int seconds = s;
          
            string fmt = "{0:00}:{1:00}:{2:00}";
            string rtn = String.Format(fmt, hours, minutes, seconds);
            return rtn;

        }

        private List<string> gridToList()
        {
            List<string> ls = new List<string>();
            foreach (DataGridViewRow obj in dataGridView1.Rows)
            {
                if (!obj.IsNewRow)
                {
                    string ts = obj.Cells[0].Value.ToString();
                    string bty = obj.Cells[1].Value.ToString();
                    string msg = obj.Cells[2].Value.ToString();
                    string s = ts + "\t" + bty + "\t" + msg;

                    ls.Add(s);
                }
            }
            return ls;
        }

        private Dictionary<string,int> gridToDurations()
        {
            Dictionary<string, int> durations = new Dictionary<string, int>();

            string prevMsg = "";
            int prevHMS = 0;

            foreach (DataGridViewRow obj in dataGridView1.Rows)
            {
                if (!obj.IsNewRow)
                {
                    string ts = obj.Cells[0].Value.ToString();
                    string bty = obj.Cells[1].Value.ToString();
                    string msg = obj.Cells[2].Value.ToString();

                    // see if this is a trackble event
                    Settings.ColorSet cs = this.settings.getColorSet(bty);
                    if ((cs.tracked == "1") || (bty == "STOP"))
                    {
                        int hms = this.hms_to_seconds(ts);
                        if ((prevMsg != "") && (prevMsg != msg))
                        {
                            int dur = hms - prevHMS;
                            if (!durations.ContainsKey(prevMsg))
                            {
                                durations.Add(prevMsg, 0);
                            }
                            durations[prevMsg] += dur;
                            prevHMS = hms;
                            prevMsg = msg;
                        }
                        else if (prevMsg == "")
                        {
                            prevHMS = hms;
                            prevMsg = msg;
                        }
                    }
                }
            }

            return durations;
        }

        private void old_saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File|*.txt";
            sfd.Title = "Save the data";
            sfd.FileName = this.saveFileName + ".txt";
            DialogResult res = sfd.ShowDialog();
            if(res == DialogResult.OK)
            {
                List<string> ls = new List<string>();
                string prevMsg = "";
                int prevHMS = 0;
                Dictionary<string, int> durations = new Dictionary<string, int>();

                foreach (DataGridViewRow obj in dataGridView1.Rows)
                {
                    if(!obj.IsNewRow)
                    {
                        
                        
                        string ts  = obj.Cells[0].Value.ToString();
                        string bty = obj.Cells[1].Value.ToString();
                        string msg = obj.Cells[2].Value.ToString();
                        string s = ts + "\t" + bty + "\t" + msg;

                        ls.Add(s);
                        // see if this is a trackble event
                        Settings.ColorSet cs = this.settings.getColorSet(bty);
                        if ((cs.tracked == "1") || (bty == "STOP"))
                        {
                            int hms = this.hms_to_seconds(ts);
                            if ((prevMsg != "") && (prevMsg != msg))
                            {
                                int dur = hms - prevHMS;
                                if (!durations.ContainsKey(prevMsg))
                                {
                                    durations.Add(prevMsg, 0);
                                }
                                durations[prevMsg] += dur;
                                prevHMS = hms;
                                prevMsg = msg;
                            }
                            else if (prevMsg == "")
                            {
                                prevHMS = hms;
                                prevMsg = msg;
                            }
                        }
                        
                    }
                }
                ls.Add("");
                ls.Add("Durations");
                ls.Add("");
                foreach (KeyValuePair<string, int> entry in durations)
                {
                    ls.Add(entry.Key + "\t" + this.seconds_to_hms(entry.Value));
                }
                File.WriteAllLines(sfd.FileName, ls.ToArray());
            }
            this.needToSave = false;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text File|*.txt";
            sfd.Title = "Save the data";
            sfd.FileName = this.saveFileName + ".txt";
            DialogResult res = sfd.ShowDialog();
            if (res == DialogResult.OK)
            {
                List<string> ls = this.gridToList();

                Dictionary<string, int> durations = this.gridToDurations();

                ls.Add("");
                ls.Add("Durations");
                ls.Add("");
                foreach (KeyValuePair<string, int> entry in durations)
                {
                    ls.Add(entry.Key + "\t" + this.seconds_to_hms(entry.Value));
                }
                File.WriteAllLines(sfd.FileName, ls.ToArray());
            }
            this.needToSave = false;
        }

        private void colorsBtn_Click(object sender, EventArgs e)
        {
            //ColorList cl = new ColorList();
            //DialogResult result = cl.ShowDialog();
            ColorPickerForm cpf = new ColorPickerForm();
            DialogResult result = cpf.ShowDialog();
            this.loadButtons();
        }

        private void entriesBtn_Click(object sender, EventArgs e)
        {
            EntryForm ef = new EntryForm();
            DialogResult result = ef.ShowDialog();
            this.loadButtons();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !this.okToExit();
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> durations = this.gridToDurations();
            ExportForm ef = new ExportForm();
            ef.Durations = durations;
            DialogResult result = ef.ShowDialog();
        }
    }
}
