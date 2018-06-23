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
    public partial class EntryForm : Form
    {
        private Settings settings;
        private bool needToSave;

        public EntryForm()
        {
            InitializeComponent();
            this.settings = new Settings();
            List<string> btl = this.settings.getButtonTypes();
            foreach(string bty in btl)
            {
                this.comboBox1.Items.Add(bty);
            }
            this.load_from_settings();
            this.needToSave = false;
        }

        private void SetNeedToSave(bool b)
        {
            this.needToSave = b;
            this.Text = (b) ? "Entry Form*" : "Entry Form";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add
           this.add_entry(textBox1.Text,comboBox1.Text,textBox2.Text);
            
        }

        private void load_from_settings()
        {
            foreach (KeyValuePair<string, Settings.ButtonSpec> entry in this.settings.buttons)
            {
                this.add_entry(entry.Value.buttonLabel,entry.Value.buttonType,entry.Value.buttonMessage);
            }
            this.SetNeedToSave(false);
        }

        private void add_entry(string lbl, string bt, string msg)
        {
            DataGridViewRow row;
            List<string> ls = new List<string>();
            ls.Add(lbl);
            ls.Add(bt);
            ls.Add(msg);
            dataGridView1.Rows.Add(ls.ToArray());
            this.SetNeedToSave(true);
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            // delete
            int curRow = dataGridView1.CurrentRow.Index;
            dataGridView1.Rows.RemoveAt(curRow);
            this.SetNeedToSave(true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // save
            this.settings.clearButtons();
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string lbl = row.Cells[0].Value.ToString();
                    string typ = row.Cells[1].Value.ToString();
                    string msg = row.Cells[2].Value.ToString();
                    this.settings.addButton(new Settings.ButtonSpec(lbl, typ, msg));
                }
            }
            this.settings.save();
            this.SetNeedToSave(false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // close
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool okToMove(DataGridView dgv)
        {
            bool rtn = true;

            if (dgv.SelectedCells.Count == 0) // nothing selected
            {
                rtn = false;
            }
            else
            {
                int rowInd = -1;
                foreach (DataGridViewCell cell in dgv.SelectedCells)
                {
                    if (rowInd == -1)
                    {
                        rowInd = cell.RowIndex;
                    }
                    if (cell.RowIndex != rowInd)
                    {
                        rtn = false;
                    }
                }
            }

            return rtn;
        }
        private List<int> getSelectedColumns(DataGridView dgv)
        {
            List<int> rtn = new List<int>();
            if (this.okToMove(dgv))
            {
                foreach (DataGridViewCell cell in dgv.SelectedCells)
                {
                    rtn.Add(cell.ColumnIndex);
                }
            }
            return rtn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // up
            try
            {   
                int totalRows = dataGridView1.Rows.Count;
                if (this.okToMove(dataGridView1))
                {
                    int rowIndex = dataGridView1.SelectedCells[0].OwningRow.Index;
                    if(rowIndex > 0)
                    {
                        List<int> cols = this.getSelectedColumns(dataGridView1);
                        DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                        dataGridView1.Rows.Remove(selectedRow);
                        dataGridView1.Rows.Insert(rowIndex - 1, selectedRow);
                        dataGridView1.ClearSelection();
                        foreach(int col in cols)
                        {
                            dataGridView1.Rows[rowIndex - 1].Cells[col].Selected = true;
                        }
                    }
                }
            }
            catch { }
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            // down
            try
            {
                int totalRows = dataGridView1.Rows.Count;
                if (this.okToMove(dataGridView1))
                {
                    int rowIndex = dataGridView1.SelectedCells[0].OwningRow.Index;
                    if (rowIndex < (totalRows-2))
                    {
                        List<int> cols = this.getSelectedColumns(dataGridView1);
                        DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
                        dataGridView1.Rows.Remove(selectedRow);
                        dataGridView1.Rows.Insert(rowIndex + 1, selectedRow);
                        dataGridView1.ClearSelection();
                        foreach (int col in cols)
                        {
                            dataGridView1.Rows[rowIndex + 1].Cells[col].Selected = true;
                        }
                    }
                }
            }
            catch { }
        }
    }
}
