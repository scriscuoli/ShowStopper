using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowStopper
{
    public partial class ColorPickerForm : Form
    {
        private Settings settings;

        public ColorPickerForm()
        {
            InitializeComponent();
            settings = new Settings();
            loadFromSettings();
        }

        private void loadFromSettings()
        {
            listView1.Items.Clear();
            foreach (KeyValuePair<string, Settings.ColorSet> entry in this.settings.colors)
            {
                string k = entry.Key;
                Settings.ColorSet cs = entry.Value;
                if(cs.tracked == "1")
                {
                    k = k + "*";
                }
                ListViewItem lvi = new ListViewItem();
                lvi.Text = k;
                lvi.ForeColor = this.getColorFromString(cs.fgColor);
                lvi.BackColor = this.getColorFromString(cs.bgColor);
                listView1.Items.Add(lvi);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // close
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private Color getColorFromString(string s)
        {
            Color rtn = Color.Black;
            int ir, ig, ib;
            ir = ig = ib = 0;
            string[] sa = s.Split(','); // r,g,b
            if (sa.Length == 3)
            {
                ir = int.Parse(sa[0]);
                ig = int.Parse(sa[1]);
                ib = int.Parse(sa[2]);
            }
            rtn = System.Drawing.Color.FromArgb(ir, ig, ib);

            return rtn;
        }

        private string getStringFromColor(Color c)
        {
            string rtn = c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString();
            return rtn;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // add
            ListViewItem lvi = new ListViewItem();
            lvi.Text = textBox1.Text;
            lvi.ForeColor = button5.BackColor;
            lvi.BackColor = button6.BackColor;
            listView1.Items.Add(lvi);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // delete
            //listView1.se
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                textBox1.Text = item.Text;
                listView1.Items.Remove(item);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // fg
            ColorDialog cd = new ColorDialog();
            DialogResult result = cd.ShowDialog();
            if(result == DialogResult.OK)
            {
                button5.BackColor = cd.Color;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // bg
            ColorDialog cd = new ColorDialog();
            DialogResult result = cd.ShowDialog();
            if (result == DialogResult.OK)
            {
                button6.BackColor = cd.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // save
            this.settings.clearColors();
            foreach(ListViewItem lvi in listView1.Items)
            {
                string lbl = lvi.Text;
                string tracked = "0";
                if(lbl.Substring(lbl.Length-1,1) == "*")
                {
                    tracked = "1";
                    lbl = lbl.Substring(0, lbl.Length - 1);
                }
                string fgs = this.getStringFromColor(lvi.ForeColor);
                string bgs = this.getStringFromColor(lvi.BackColor);
                Settings.ColorSet cs = new Settings.ColorSet(lbl, fgs, bgs,tracked);
                this.settings.addColor(cs);
            }
            this.settings.save();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ListViewItem lvi = listView1.SelectedItems[0];
                button5.BackColor = lvi.ForeColor;
                button6.BackColor = lvi.BackColor;
            }
        }
    }
}
