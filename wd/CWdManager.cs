using System;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using wdc;

namespace HttpGet
{
    public struct data_conf_t // web data conf
    {
        public string id;

        public object owner;

        public string url;
        public string encoding;

        public Hashtable areas; // data_area_t
        public int cols;

        public string source;

        public data_conf_t(string _id)
        {
            id = _id;
            owner = null; url = ""; encoding = ""; areas = new Hashtable(); cols = 0; source = "";
        }

        public void copy(data_conf_t conf)
        {
            id = conf.id;
            owner = conf.owner;
            url = conf.url;
            encoding = conf.encoding;
            areas = (Hashtable)conf.areas.Clone();
            cols = conf.cols;
            source = conf.source;
        }
    }

    class CWdManager
    {
        public Hashtable data_confs;
        public data_conf_t conf;

        // Declare the delegate (if using non-generic pattern).
        public delegate void SourceEventHandler(object sender, string result);
        // Declare the event.
        public event SourceEventHandler OnSourceEvent;

        public CWdManager()
        {
            data_confs = new Hashtable();
        }

        public void load_game()
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml("./wdc.sites");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return;
            }

            XmlNodeList list = doc.DocumentElement.GetElementsByTagName("title");


            foreach (XmlNode node in list)
            {
                //ret += node.ChildNodes[1].InnerText;
                //Console.WriteLine(node.ChildNodes[1].InnerText); //mac
                //Console.WriteLine(node.ChildNodes[2].InnerText); //type
                //Console.WriteLine(node.ChildNodes[9].InnerText); //ip
            }
        }

        private XmlNode add_node(XmlDocument xmldoc, XmlNode xmlParent, string node)
        {
            XmlNode xmlnode;
            xmlnode = xmldoc.CreateElement(node);
            xmlParent.AppendChild(xmlnode);

            return xmlnode;
        }
        private void add_node(XmlDocument xmldoc, XmlNode xmlParent, string elem, string value)
        {
            XmlElement xmlelem;
            XmlText xmltext;
            xmlelem = xmldoc.CreateElement(elem);
            xmltext = xmldoc.CreateTextNode(value);
            xmlelem.AppendChild(xmltext);
            xmlParent.AppendChild(xmlelem);
        }

        public void save_game()
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode xmlroot;
            XmlNode xmlsites;
            XmlNode xmlsite;
            XmlNode xmlarea;

            xmlroot = xmldoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            xmldoc.AppendChild(xmlroot);

            xmlroot = xmldoc.CreateElement("root"); xmldoc.AppendChild(xmlroot);
            xmlsites = xmldoc.CreateElement("sites"); xmlroot.AppendChild(xmlsites);

            // <root>/<sites>/<site>
            foreach (DictionaryEntry item in data_confs)
            {
                data_conf_t conf = (data_conf_t)item.Value;

                xmlsite = add_node(xmldoc, xmlsites, "site");
                add_node(xmldoc, xmlsite, "id", conf.id);
                add_node(xmldoc, xmlsite, "url", conf.url);
                add_node(xmldoc, xmlsite, "encoding", conf.encoding);
                add_node(xmldoc, xmlsite, "cols", conf.cols.ToString());

                foreach (DictionaryEntry area_item in conf.areas)
                {
                    data_area_t area = (data_area_t)area_item.Value;

                    xmlarea = add_node(xmldoc, xmlsite, "area");
                    add_node(xmldoc, xmlarea, "id", area.id);
                    add_node(xmldoc, xmlarea, "from", area.from);
                    add_node(xmldoc, xmlarea, "to", area.to);
                    add_node(xmldoc, xmlarea, "regex", area.regex);

                }

            }

            xmldoc.Save("./wdc.sites");
        }


        public void go()
        {
            conf.source = this.getContent(conf.url, conf.encoding);
            OnSourceEvent(conf.owner, conf.source);
        }
        //[STAThread]  
        public void getLinks(string url, out string[] links)
        {
            int index = 0;
            System.Net.WebClient client = new WebClient();
            byte[] page = client.DownloadData(url);
            string content = System.Text.Encoding.UTF8.GetString(page);
            string regex = "href=[\\\"\\\'](http:\\/\\/|\\.\\/|\\/)?\\w+(\\.\\w+)*(\\/\\w+(\\.\\w+)?)*(\\/|\\?\\w*=\\w*(&\\w*=\\w*)*)?[\\\"\\\']";
            Regex re = new Regex(regex);
            MatchCollection matches = re.Matches(content);

            links = new string[matches.Count];
            System.Collections.IEnumerator enu = matches.GetEnumerator();
            while (enu.MoveNext() && enu.Current != null)
            {
                Match match = (Match)(enu.Current);
                links[index++] = match.Value;
                Console.Write(match.Value + "\r\n");
            }
        }

        public string getContent(string Url, string encode)
        {
            string strResult = "";
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                //声明一个HttpWebRequest请求  
                request.Timeout = 30000;
                //设置连接超时时间  
                request.Headers.Set("Pragma", "no-cache");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.GetEncoding(encode);
                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                strResult = streamReader.ReadToEnd();
                streamReader.Close();
            }
            catch
            {

            }
            return strResult;
        }

        public string getData(string url, data_conf_t conf, out string[] items)
        {
            string result = "";
            string ret = "";
            string htmlsource = getContent(url, conf.encoding);
            int from = 0;
            int to = 0;
            items = null;

            foreach (DictionaryEntry item in conf.areas)
            {
                data_area_t area = (data_area_t)item.Value;
                from = htmlsource.IndexOf(area.from,StringComparison.OrdinalIgnoreCase);
                to = htmlsource.IndexOf(area.to, from >= 0 ? from : 0, StringComparison.OrdinalIgnoreCase);

                if (from < 0 || (to < 0 && from < 0) || (to != -1 && to <= from))
                {
                    Console.WriteLine(area.id + "不符合规则");
                    items = null;
                    continue;
                }
                if (to < 0)
                {
                    to = htmlsource.Length;
                }

                from += area.from.Length;

                string content = htmlsource.Substring(from, to - from);

                CHtmlTag tag = new CHtmlTag();
                int startindex = 0; int len = 0;
                //tag.getSourceByTag(content, "script", ref startindex, out len);
                //content = tag.getSourceWithoutScript(content);
                //TODO:parse html
                ret = content.Replace("\t", "");
                ret = ret.Replace("\r", "");
                ret = ret.Replace("\n", "");
                
                result += area.id;
                result += ":\r\n";
                if (area.mode == AREA_MODE.ITERATOR)
                {
                    result += tag.getIterInfo(ret, area);
                } 
                else 
                {
                    result += tag.getInfo(ret, area);
                }
                result += "\r\n\r\n";

                items = ret.Split(new char[1] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
            }

            return result;
        }

        public string getXmlText(string url)
        {
            string ret = "";
            System.Net.WebClient client = new WebClient();
            byte[] page = client.DownloadData(url);
            string content = System.Text.Encoding.UTF8.GetString(page);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content);

            XmlNodeList list = doc.DocumentElement.GetElementsByTagName("title");


            foreach (XmlNode node in list)
            {
                ret += node.ChildNodes[1].InnerText;
                Console.WriteLine(node.ChildNodes[1].InnerText); //mac
                Console.WriteLine(node.ChildNodes[2].InnerText); //type
                Console.WriteLine(node.ChildNodes[9].InnerText); //ip
            }

            //XmlNode node = doc.SelectSingleNode("response/TAG[tagid=105461601172]");//根据xpath,这里我把你数字后面的空格去掉了 
            //string mac = node.ChildNodes[1].InnerText;//根据排列规律（tag下面的第二个节点）
            //string type = node.ChildNodes[2].InnerText;
            //string ip = node.ChildNodes[9].InnerText;
            return ret;
        }



        public Bitmap GenerateScreenshot(string url)
        {
            // This method gets a screenshot of the webpage
            // rendered at its full size (height and width)
            return GenerateScreenshot(url, -1, -1);
        }

        public Bitmap GenerateScreenshot(string url, int width, int height)
        {

            // Load the webpage into a WebBrowser control
            WebBrowser wb = new WebBrowser();
            wb.ScrollBarsEnabled = false;
            wb.ScriptErrorsSuppressed = true;
            wb.Navigate(url);
            while (wb.ReadyState != WebBrowserReadyState.Complete) { Application.DoEvents(); }


            // Set the size of the WebBrowser control
            wb.Width = width;
            wb.Height = height;

            if (width == -1)
            {
                // Take Screenshot of the web pages full width
                wb.Width = wb.Document.Body.ScrollRectangle.Width;
            }

            if (height == -1)
            {
                // Take Screenshot of the web pages full height
                wb.Height = wb.Document.Body.ScrollRectangle.Height;
            }

            // Get a Bitmap representation of the webpage as it's rendered in the WebBrowser control
            Bitmap bitmap = new Bitmap(wb.Width, wb.Height);
            wb.DrawToBitmap(bitmap, new Rectangle(0, 0, wb.Width, wb.Height));
            wb.Dispose();

            return bitmap;

        }
    }
}
