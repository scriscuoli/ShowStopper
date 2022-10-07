using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace ShowStopper
{
    public partial class ExportForm : Form
    {
        private Dictionary<string, int> durations;
        private Settings settings;

        public Dictionary<string, int> Durations
        {
            get { return durations;  }
            set {
                durations = value;
                foreach (KeyValuePair<string, int> entry in durations)
                {
                    this.summaryTb.AppendText(entry.Key.ToString() + Environment.NewLine);
                }
            }

        }
        public ExportForm()
        {
            this.settings = new Settings();
            InitializeComponent();
            foreach(string c in this.settings.Credits)
            {
                this.creditsTb.AppendText(c + Environment.NewLine);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private string generateSummaryHtml()
        {
            string rtn;
            string nl = Environment.NewLine;

            rtn = "<h2>Summary</h2>" + nl;
            string[] slines = Regex.Split(this.summaryTb.Text, nl);
            rtn += "<ul>" + nl;

            foreach(string s in slines)
            {
                rtn += "<li>" + nl;
                rtn += "<h4>" + s + "</h4>" + nl;
                rtn += "</li>" + nl;
            }

            rtn += "</ul>" + nl;

            return rtn;
        }

        private string generateLinksHtml()
        {
            string rtn;
            string nl = Environment.NewLine;

            rtn = "<h2>Links</h2>" + nl;
            string[] slines = Regex.Split(this.linksTb.Text, nl);
            rtn += "<ul>" + nl;

            foreach (string s in slines)
            {
                rtn += "<li>" + nl;
                string[] la = s.Split('|');
                string lbl = la[0];
                string url = la[la.Length - 1];
                string hs = lbl + " - " + "<a href=\"" + url + "\"" + " target=\"_blank \"" + ">" + url + "</a>";
                rtn += "<h4>" + hs + "</h4>" + nl;
                rtn += "</li>" + nl;
            }


            rtn += "</ul>" + nl;
            return rtn;
        }

        private string generateHtml()
        {
            string rtn;

            rtn = this.generateSummaryHtml();
            rtn += this.generateLinksHtml();
            rtn += this.creditsTb.Text;

            return rtn;
        }


        private void htmlBtn_Click(object sender, EventArgs e)
        {
            this.outputTb.Text = this.generateHtml();
        }

        private void xmlBtn_Click(object sender, EventArgs e)
        {
            string hs = generateHtml();
            this.outputTb.Text = hs.Replace("&", "&amp;").Replace("\"", "&quot;").Replace(">", "&gt;").Replace("<", "&lt;");
        }
    }
}