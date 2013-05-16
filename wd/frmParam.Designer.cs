namespace html_test2
{
    partial class frmParam
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtCol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboEncoding = new System.Windows.Forms.ComboBox();
            this.checkBoxDelete = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReg = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.chklArea = new System.Windows.Forms.CheckedListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboIterTag = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCol
            // 
            this.txtCol.Location = new System.Drawing.Point(98, 252);
            this.txtCol.Name = "txtCol";
            this.txtCol.Size = new System.Drawing.Size(31, 21);
            this.txtCol.TabIndex = 10;
            this.txtCol.Text = "6";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 255);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "分析结果分为        列";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(73, 16);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(259, 21);
            this.txtFrom.TabIndex = 5;
            this.txtFrom.Leave += new System.EventHandler(this.txtFrom_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "开始标志";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 16;
            this.label3.Text = "结束标志";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(73, 43);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(259, 21);
            this.txtTo.TabIndex = 6;
            this.txtTo.Leave += new System.EventHandler(this.txtTo_Leave);
            this.txtTo.TextChanged += new System.EventHandler(this.txtTo_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(234, 287);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "好";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "网址";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "http://ishare.iask.sina.com.cn/random/",
            "http://ishare.iask.sina.com.cn/topuser/tophot.php?classid=1822",
            "http://www.isccc.gov.cn/zsgg/08/398933.shtml"});
            this.comboBox1.Location = new System.Drawing.Point(50, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(494, 20);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "http://ishare.iask.sina.com.cn/topuser/tophot.php?classid=1822";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 21;
            this.label5.Text = "编码";
            // 
            // cboEncoding
            // 
            this.cboEncoding.FormattingEnabled = true;
            this.cboEncoding.Items.AddRange(new object[] {
            "GB2312",
            "UTF-8"});
            this.cboEncoding.Location = new System.Drawing.Point(50, 32);
            this.cboEncoding.Name = "cboEncoding";
            this.cboEncoding.Size = new System.Drawing.Size(100, 20);
            this.cboEncoding.TabIndex = 1;
            this.cboEncoding.Text = "GB2312";
            // 
            // checkBoxDelete
            // 
            this.checkBoxDelete.AutoSize = true;
            this.checkBoxDelete.Location = new System.Drawing.Point(17, 291);
            this.checkBoxDelete.Name = "checkBoxDelete";
            this.checkBoxDelete.Size = new System.Drawing.Size(84, 16);
            this.checkBoxDelete.TabIndex = 11;
            this.checkBoxDelete.Text = "删除此站点";
            this.checkBoxDelete.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(14, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "提取";
            // 
            // txtReg
            // 
            this.txtReg.Location = new System.Drawing.Point(73, 104);
            this.txtReg.Name = "txtReg";
            this.txtReg.Size = new System.Drawing.Size(259, 21);
            this.txtReg.TabIndex = 8;
            this.txtReg.Leave += new System.EventHandler(this.txtReg_Leave);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtFrom);
            this.groupBox1.Controls.Add(this.txtTo);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboIterTag);
            this.groupBox1.Controls.Add(this.cboMode);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtReg);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(234, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 183);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "区域1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.chklArea);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Location = new System.Drawing.Point(17, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(215, 183);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "要采集的数据是";
            // 
            // btnRemove
            // 
            this.btnRemove.AutoSize = true;
            this.btnRemove.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRemove.Location = new System.Drawing.Point(33, 16);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(21, 22);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "-";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // chklArea
            // 
            this.chklArea.FormattingEnabled = true;
            this.chklArea.Location = new System.Drawing.Point(6, 40);
            this.chklArea.Name = "chklArea";
            this.chklArea.Size = new System.Drawing.Size(203, 132);
            this.chklArea.TabIndex = 4;
            this.chklArea.ThreeDCheckBoxes = true;
            this.chklArea.SelectedIndexChanged += new System.EventHandler(this.chklArea_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAdd.Location = new System.Drawing.Point(6, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(21, 22);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "+";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(14, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 16;
            this.label7.Text = "模式";
            // 
            // cboMode
            // 
            this.cboMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Items.AddRange(new object[] {
            "表达式",
            "纯文本",
            "迭代"});
            this.cboMode.Location = new System.Drawing.Point(73, 70);
            this.cboMode.Name = "cboMode";
            this.cboMode.Size = new System.Drawing.Size(100, 20);
            this.cboMode.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(14, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "迭代标签";
            // 
            // cboIterTag
            // 
            this.cboIterTag.FormattingEnabled = true;
            this.cboIterTag.Items.AddRange(new object[] {
            "tr",
            "td",
            "table",
            "div"});
            this.cboIterTag.Location = new System.Drawing.Point(73, 133);
            this.cboIterTag.Name = "cboIterTag";
            this.cboIterTag.Size = new System.Drawing.Size(259, 20);
            this.cboIterTag.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(424, 295);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(167, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "¤ 红色的内容本版本不能修改";
            // 
            // frmParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 322);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxDelete);
            this.Controls.Add(this.cboEncoding);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtCol);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmParam";
            this.Text = "参数设置";
            this.Load += new System.EventHandler(this.frmParam_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboEncoding;
        private System.Windows.Forms.CheckBox checkBoxDelete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtReg;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.CheckedListBox chklArea;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboMode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboIterTag;
        private System.Windows.Forms.Label label9;
    }
}