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
    }
}
