using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace html_test2
{
    public partial class frmSource : Form
    {
        public frmSource()
        {
            InitializeComponent();
        }

        public void setText(string text)
        {
            this.textBox1.Text = text;
        }
    }
}