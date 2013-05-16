using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HttpGet;
using System.Threading;
using wdc;

namespace html_test2
{
    public partial class Form2 : Form
    {
        CWdManager work1;
        protected data_conf_t data_conf;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            //ListViewItem item;
            string url = comboBox1.Text;
            string[] links;

            CWdManager test1 = new CWdManager();
            test1.getLinks(url, out links);

            txtResult.Text = "";
            while (i < links.Length)
            {
                txtResult.Text += i.ToString();
                txtResult.Text += "\t";
                for (int j = 1; j < 2; j++)
                {
                    txtResult.Text += links[i++];
                    txtResult.Text += "\t";
                    if (i >= links.Length)
                    {
                        break;
                    }
                }
                txtResult.Text += "\r\n";
            }

            
            /*
            listView1.Items.Clear();
            listView1.Columns.Clear();

            for (i = 0; i < 2; i++) {
                ColumnHeader head = new ColumnHeader();
                head.Width = -1;
                head.Text = i.ToString();
                listView1.Columns.Add(head);
            }

            while (i < links.Length) {
                item = new ListViewItem();
                item.Text = i.ToString();
                for (int j = 1; j < 2; j++) {
                    item.SubItems.Add(links[i++]);
                    if (i >= links.Length) {
                        break;
                    }
                }
                listView1.Items.Add(item);
            }

            for (i = 0; i < 2; i++) {
                listView1.Columns[i].Width = -1;
            }
             * */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //CWdManager work1 = new CWdManager();
            //work1.conf.url = this.data_conf.url;
            //work1.conf.from = this.data_conf.from;
            //work1.conf.to = this.data_conf.to;
            //work1.conf.cols = this.data_conf.cols;
            //work1.conf.encoding = this.data_conf.encoding;
            //work1.conf.owner = this;

            //frmSource source = new frmSource();
            //source.Show();
            //source.setText(work1.getContent(work1.conf.url, work1.conf.encoding));
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string url = comboBox1.Text;
            CWdManager test1 = new CWdManager();
            frmSource source = new frmSource();
            source.Show();
            
            try {
                source.setText(test1.getXmlText(url));
            } catch (Exception) {
                MessageBox.Show("指定的页面不符合XML语法规范");
                source.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim().Length == 0)
            {
                return;
            }
            if (!work1.data_confs.ContainsKey(comboBox1.Text))
            {
                return;
            }
            this.data_conf = (data_conf_t)work1.data_confs[comboBox1.Text];

            string url = data_conf.url;
            CWdManager test1 = new CWdManager();

            Bitmap thumbnail;// = test1.GenerateScreenshot(url, 1024, 768);
            // Generate thumbnail of a webpage at the webpage's full size (height and width)
            thumbnail = test1.GenerateScreenshot(url);

            // Display Thumbnail in PictureBox control
            pictureBox1.Image = thumbnail;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string[] items;
            string ret = "";
            CWdManager work1 = new CWdManager();
            work1.conf.copy(this.data_conf);

            ret = work1.getData(work1.conf.url, work1.conf, out items);
            txtResult.Text = ret;

            toolStripStatusLabel1.Text = "就绪.";
        }

        private void btnGO_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "工作中...";

            if (comboBox1.Text.Trim().Length == 0 || !work1.data_confs.ContainsKey(comboBox1.Text))
            {
                return;
            }
            this.data_conf = (data_conf_t)work1.data_confs[comboBox1.Text];

            if (comboBox1.Text.CompareTo("pyw") == 0) {
                this.Text = "数据收集器样本0.01 by pyw 2011";
                return;
            }

            //button4_Click(sender, e);
            button5_Click(sender, e);

            //work1.OnSourceEvent += new Class1.SourceEventHandler(work1_SourceEvent);
            //Thread workerThread = new Thread(new ThreadStart(work1.go));

           
            //workerThread.Start();

        }

        void work1_SourceEvent(object sender, string result)
        {
            Form2 form = (Form2)sender;
            if (comboBox1.InvokeRequired)
            {
                Console.WriteLine("...........");
            }
            else
            {
                comboBox1.Text = result;
            }
            
        }

		private void Form2_Load(object sender, EventArgs e) {
            //CHtmlTag debug = new CHtmlTag(); int debug1 = 0; int debug2 = 0;
            //string debugstr=debug.getSourceByTag("<li><li>test</li></li>", "li", ref debug1, out debug2);
			if (DateTime.Now.Year > 2011) {
				MessageBox.Show("该样本已经过期");
				this.Close();
			}

            data_area_t area;

            work1 = new CWdManager();
            work1.load_game();

            /*http://s.taobao.com/search?q=iphone&keyword=&commend=all&ssid=s5-e&search_type=item&atype=&tracelog=&sourceId=tb.index
http://s.taobao.com/search?q=iphone&commend=all&ssid=s5-e&filterFineness=2&s=40#J_FilterTabBar
http://s.taobao.com/search?q=iphone&commend=all&filterFineness=2&ssid=s5-e&atype=b&s=80#J_FilterTabBar
             * 
             * 
下一页 http://s.taobao.com/search?q=iphone&commend=all&atype=b&filterFineness=2&ssid=s5-e&s=120#J_FilterTabBar

s=80是页面*/

            data_conf = new data_conf_t();
            data_conf.id = "国家信息安全产品认证获证名单";
            data_conf.cols = 8;
            data_conf.url = "http://www.isccc.gov.cn/zsgg/08/398933.shtml";
            //data_conf.url = "http://127.0.0.1/list.htm";
            data_conf.encoding = "UTF-8";
            data_conf.areas = new Hashtable();
            // 区域1:title
            area = new data_area_t("标题");
            area.enable = true;
            area.from = "<head>";
            area.to = "</head>";
            area.info_path = "";
            area.regex = "(?<=<title>)[^<]*(?=</title>)";
            area.mode = AREA_MODE.REGEX;
            data_conf.areas.Add(area.id, area);
            // 区域2:名单
            area = new data_area_t("名单内容");
            //area.from = "作者：中国信息安全认证中心";
            //area.to = "获证企业展示";
            area.from = "<TABLE style=\"BORDER-RIGHT:";
            area.to = "</table>";
            area.regex = "(?<=<(tr).*>).*(?=<\\/\\1>)";
            area.mode = AREA_MODE.ITERATOR;
            area.info_path = "";
            area.iter_tag = "tr";
            data_conf.areas.Add(area.id, area);
            work1.data_confs.Add(data_conf.id, data_conf);

            data_conf = new data_conf_t("weibo.com");
            data_conf.cols = 0;
            data_conf.url = "http://weibo.com";
            data_conf.encoding = "UTF-8";
            data_conf.areas = new Hashtable();
            work1.data_confs.Add(data_conf.id, data_conf);

            data_conf = new data_conf_t("weibo_随便看看.com");
            data_conf.cols = 0;
            data_conf.url = "http://127.0.0.1/weibo_suibiankankan.htm";
            data_conf.encoding = "UTF-8";
            data_conf.areas = new Hashtable();
            // 区域1:title
            area = new data_area_t("title");
            area.enable = true;
            area.from = "<head>";
            area.to = "</head>";
            area.info_path = "";
            area.regex = "(?<=<title>)[^<]*(?=</title>)";
            area.mode = AREA_MODE.REGEX;
            data_conf.areas.Add(area.id, area);
            // 区域2
            area = new data_area_t("随便看看账号列表");
            area.enable = true;
            area.from = "<ul class=\"MIB_feed\">";
            area.to = "<div class=\"feed_bt\">";
            area.info_path = "li";
            area.regex = "(?<=<a href=\")\\S+(?=\" title=\")";
            area.mode = AREA_MODE.REGEX;
            data_conf.areas.Add(area.id, area);
            work1.data_confs.Add(data_conf.id, data_conf);

            data_conf = new data_conf_t("taobao.com(iphone)");
            data_conf.cols = 0;
            data_conf.url = "http://127.0.0.1/iphone.htm";
            data_conf.url = "http://s.taobao.com/search?q=iphone&keyword=&commend=all&ssid=s5-e&search_type=item&atype=&tracelog=&sourceId=tb.index";
            data_conf.encoding = "GB2312";
            data_conf.areas = new Hashtable();
            // 区域1:title
            area = new data_area_t("title");
            area.enable = true;
            area.from = "<head>";
            area.to = "</head>";
            area.info_path = "";
            area.regex = "(?<=<title>)[^<]*(?=</title>)";
            area.mode = AREA_MODE.REGEX;
            data_conf.areas.Add(area.id, area);
            // 区域2
            area = new data_area_t("商品列表");
            area.enable = true;
            area.from = "<!-- mall -->";
            area.to = "</form>";
            area.info_path = "";
            area.regex = ".*";
            area.iter_tag = "li";
            area.mode = AREA_MODE.ITERATOR;
            data_conf.areas.Add(area.id, area);
            work1.data_confs.Add(data_conf.id, data_conf);

            comboBox1.Items.Clear();
            foreach (DictionaryEntry item in work1.data_confs)
            {
                data_conf_t conf = (data_conf_t)item.Value;
                comboBox1.Items.Add(conf.id);
            }
            comboBox1.SelectedIndex = 0;
		}

        private void btnParam_Click(object sender, EventArgs e)
        {
            DialogResult dret;
            if (comboBox1.Text.Trim().Length == 0)
            {
                return;
            }
            frmParam param = new frmParam();
            if (!work1.data_confs.ContainsKey(comboBox1.Text))
            {
                this.data_conf = new data_conf_t();
                data_conf.areas = new Hashtable();
                this.data_conf.id = comboBox1.Text;
                this.data_conf.cols = 0;
                this.data_conf.url = "http://";
                this.data_conf.encoding = "GB2312";
                work1.data_confs.Add(data_conf.id, data_conf);
                comboBox1.Items.Add(comboBox1.Text);
            }
            this.data_conf = (data_conf_t)work1.data_confs[comboBox1.Text];
            param.data_conf = this.data_conf;
            dret = param.ShowDialog();

            if (param.delete)
            {
                work1.data_confs.Remove(comboBox1.Text);
                comboBox1.Items.Remove(comboBox1.Text);
                comboBox1.Text = "";
            }
            this.data_conf = param.data_conf;
            this.data_conf.areas = param.data_conf.areas;
            work1.data_confs[comboBox1.Text] = this.data_conf;

            if (DialogResult.OK == dret)
            {
                work1.save_game();
            }
        }



    }
}