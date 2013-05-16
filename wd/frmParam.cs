using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttpGet;
using System.Collections;
using wdc;

namespace html_test2
{
    public partial class frmParam : Form
    {
        public data_conf_t data_conf;
        public bool delete;
        public frmParam()
        {
            InitializeComponent();
        }

        private void frmParam_Load(object sender, EventArgs e)
        {
            comboBox1.Text = data_conf.url;
            comboBox1.Items.Add(data_conf.url);
            txtCol.Text = data_conf.cols.ToString();
            cboEncoding.Text = data_conf.encoding;

            foreach (DictionaryEntry item in data_conf.areas)
            {
                data_area_t area = (data_area_t)item.Value;
                chklArea.Items.Add(area.id, area.enable);
            }

            //txtFrom.Text = data_conf.from;
            //txtTo.Text = data_conf.to;
            //txtReg.Text = data_conf.regex;
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //this.data_conf.from = System.Text.Encoding.UTF8.GetString(
            //    System.Text.Encoding.UTF8.GetBytes(txtFrom.Text));

            //this.data_conf.to = System.Text.Encoding.UTF8.GetString(
            //    System.Text.Encoding.UTF8.GetBytes(txtTo.Text));

            //data_conf.regex = txtReg.Text;

            this.data_conf.url = comboBox1.Text;
            this.data_conf.encoding = cboEncoding.Text;
            this.data_conf.cols = Int32.Parse(txtCol.Text);
            this.delete = checkBoxDelete.Checked;

            this.Close();
        }

        private void chklArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            string key;
            data_area_t area;
            if (chklArea.SelectedItems.Count < 1)
            {
                return;
            }

            key = (string)chklArea.SelectedItems[0];
            area = (data_area_t)this.data_conf.areas[key];

            txtFrom.Text = area.from;
            txtTo.Text = area.to;
            txtReg.Text = area.regex;
            cboIterTag.Text = area.iter_tag;
            switch (area.mode)
            {
                case AREA_MODE.ITERATOR:
                    cboMode.SelectedIndex = 2;
                    break;
                case AREA_MODE.REGEX:
                    cboMode.SelectedIndex = 0;
                    break;
                case AREA_MODE.TEXT:
                    cboMode.SelectedIndex = 1;
                    break;
                default:
                    break;
            }

            groupBox1.Enabled = true;
            groupBox1.Text = area.id;

        }

        private void txtFrom_Leave(object sender, EventArgs e)
        {
            if (chklArea.SelectedItems.Count < 1)
            {
                return;
            }

            string key;
            data_area_t area;
            key = (string)chklArea.SelectedItems[0];
            area = (data_area_t)this.data_conf.areas[key];

            area.from = txtFrom.Text;
            this.data_conf.areas[key] = area;
        }

        private void txtTo_Leave(object sender, EventArgs e)
        {
            if (chklArea.SelectedItems.Count < 1)
            {
                return;
            }

            string key;
            data_area_t area;
            key = (string)chklArea.SelectedItems[0];
            area = (data_area_t)this.data_conf.areas[key];

            area.to = txtTo.Text;
            this.data_conf.areas[key] = area;
        }

        private void txtReg_Leave(object sender, EventArgs e)
        {
            if (chklArea.SelectedItems.Count < 1)
            {
                return;
            }

            string key;
            data_area_t area;
            key = (string)chklArea.SelectedItems[0];
            area = (data_area_t)this.data_conf.areas[key];

            area.regex = txtReg.Text;
            this.data_conf.areas[key] = area;
        }

        private void txtTo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int index = 0;
            string key = "";
            if (data_conf.areas == null)
            {
                data_conf.areas = new Hashtable();
            }
            
            data_area_t area = new data_area_t();
            area.enable = true;
            area.from = "";
            area.to = "";
            area.regex = "";
            area.mode = AREA_MODE.REGEX;
            area.info_path = "";
            index = data_conf.areas.Count;
            do
            {
                index++;
                key = "区域" + index.ToString();
            }while(data_conf.areas.ContainsKey(key));

            area.id = key;
            data_conf.areas.Add(area.id, area);
            chklArea.Items.Add(area.id, area.enable);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (chklArea.SelectedItems.Count < 1)
            {
                return;
            }

            string key;
            key = (string)chklArea.SelectedItems[0];

            data_conf.areas.Remove(key);
            chklArea.Items.Remove(key);
        }
    }
}