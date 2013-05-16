using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using Winista.Text.HtmlParser;
//using Winista.Text.HtmlParser.Lex;
//using Winista.Text.HtmlParser.Util;
//using Winista.Text.HtmlParser.Tags;
//using Winista.Text.HtmlParser.Filters;


namespace HTMLParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //AddUrl();
        }

        //private void btnParser_Click(object sender, EventArgs e)
        //{
        //    #region 获得网页的html
        //    try
        //    {

        //        txtHtmlWhole.Text = "";
        //        string url = CBUrl.SelectedItem.ToString().Trim();
        //        System.Net.WebClient aWebClient = new System.Net.WebClient();
        //        aWebClient.Encoding = System.Text.Encoding.Default;
        //        string html = aWebClient.DownloadString(url);
        //        txtHtmlWhole.Text = html;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    #endregion

        //    #region 分析网页html节点
        //    Lexer lexer = new Lexer(this.txtHtmlWhole.Text);
        //    Parser parser = new Parser(lexer);
        //    NodeList htmlNodes = parser.Parse(null);
        //    this.treeView1.Nodes.Clear();
        //    this.treeView1.Nodes.Add("root");
        //    TreeNode treeRoot = this.treeView1.Nodes[0];
        //    for (int i = 0; i < htmlNodes.Count; i++)
        //    {
        //        this.RecursionHtmlNode(treeRoot, htmlNodes[i], false);
        //    }

        //    #endregion

        //}

        //private void RecursionHtmlNode(TreeNode treeNode, INode htmlNode, bool siblingRequired)
        //{
        //    if (htmlNode == null || treeNode == null) return;

        //    TreeNode current = treeNode;
        //    TreeNode content;
        //    //current node  
        //    if (htmlNode is ITag)
        //    {
        //        ITag tag = (htmlNode as ITag);
        //        if (!tag.IsEndTag())
        //        {
        //            string nodeString = tag.TagName;
        //            if (tag.Attributes != null && tag.Attributes.Count > 0)
        //            {
        //                if (tag.Attributes["ID"] != null)
        //                {
        //                    nodeString = nodeString + " { id=\"" + tag.Attributes["ID"].ToString() + "\" }";
        //                }
        //                if (tag.Attributes["HREF"] != null)
        //                {
        //                    nodeString = nodeString + " { href=\"" + tag.Attributes["HREF"].ToString() + "\" }";
        //                }
        //            }

        //            current = new TreeNode(nodeString);
        //            treeNode.Nodes.Add(current);
        //        }
        //    }

        //    //获取节点间的内容  
        //    if (htmlNode.Children != null && htmlNode.Children.Count > 0)
        //    {
        //        this.RecursionHtmlNode(current, htmlNode.FirstChild, true);
        //        content = new TreeNode(htmlNode.FirstChild.GetText());
        //        treeNode.Nodes.Add(content);
        //    }

        //    //the sibling nodes  
        //    if (siblingRequired)
        //    {
        //        INode sibling = htmlNode.NextSibling;
        //        while (sibling != null)
        //        {
        //            this.RecursionHtmlNode(treeNode, sibling, false);
        //            sibling = sibling.NextSibling;
        //        }
        //    }
        //}
        //private void AddUrl()
        //{
        //    CBUrl.Items.Add("http://www.hao123.com");
        //    CBUrl.Items.Add("http://www.sina.com");
        //    CBUrl.Items.Add("http://www.heuet.edu.cn");
        //}



    }
}