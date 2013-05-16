using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace wdc
{
    /*
     关于Html标签的类
     * by 0xff 2011-12-10[hoker.ffb@gmail.com]
     */

    public enum AREA_MODE
    {
        REGEX,
        TEXT,
        ITERATOR
    }
    public struct data_area_t
    {
        public string id;
        public string text;
        public bool enable;
        public AREA_MODE mode;

        // 开始
        public string from; // 从数据的什么地方开始
        public string to;  // 到数据的什么地方结束
        public string info_path; // temp
        public string regex; // 匹配什么样子的数据
        // 接着做...
        public string iter_tag; // 迭代解析什么标签中的数据

        public data_area_t(string _id)
        {
            id = _id;
            text = ""; enable = true; mode = AREA_MODE.REGEX; from = ""; to = ""; info_path = ""; regex = ""; iter_tag = "";
        }
    }

    class CHtmlTag
    {
        // 取得HTML或者XML源代码片段中的纯文本信息(过滤掉所有的标签)
        public string getText(string content)
        {
            string ret;
            Regex regex = new Regex(@"<[^>]+>|</[^>]+>");
            ret = regex.Replace(content, "");

            return ret;
        }

        public string getIterInfo(string content, data_area_t area)
        {
            string ret = "";
            string buf = "";
            int index = 0;
            int len = 0;
            int i = 0;

            do
            {
                buf = getSourceByTag(content, area.iter_tag,ref index, out len);
                if (len > 0) 
                {
                    i++;
                    ret += i.ToString() + "\r\n";
                    ret += getText(buf);
                    ret += "\r\n";
                }
            }while(index < content.Length);

            //Console.WriteLine(ret);
            return ret;
        }

        public string getInfo(string content, data_area_t area)
        {
            int i = 0;
            string[] buf=new string[16];
            string regbuf;
            string ret = "";
            MatchCollection mc;
            Regex regex;
            string path = area.info_path;
            string regex_str = area.regex;

            // parse path
            buf = path.Split(new char[1] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            for (i = 0; i < buf.Length; i++)
            {
                regbuf = string.Format("(?<=<({0}).*>).*(?=<\\/\\1>)", buf[i]);

                regex = new Regex(regbuf, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                Match m = regex.Match(content);
                content = m.Value;
            }

            // parse regex
            regex = new Regex(regex_str, RegexOptions.IgnoreCase | RegexOptions.Multiline);
            mc = regex.Matches(content);

            foreach (System.Text.RegularExpressions.Match item in mc)
            {
                //Console.WriteLine(item.Value);
                // parse text
                if (AREA_MODE.TEXT == area.mode)
                {
                    ret += getText(item.Value);
                }
                else
                {
                    ret += item.Value;
                }
                
                ret += "\r\n";
            }

            return ret;
        }

        // 取得HTML或者XML源代码片段中的可以闭合的部分
        public string getCompleteSource(string content)
        {
            return "";
        }

        // 取得HTML或者XML源代码片段中不包含javascript的部分
        public string getSourceWithoutScript(string content)
        {
            int start = 0;
            int end;
            string ret;

            do
            {
                start = content.IndexOf("<script");
                end = content.IndexOf("</script>");
                if (start < 0) {
                    break;
                }
                if (end < 0)
                {
                    end = content.Length;
                }
                if (start > end)
                {
                    Console.WriteLine("error");
                    break;
                }

                Console.WriteLine("remove:" + content.Substring(start, end - start + 7 + 2));
                content = content.Remove(start, end - start + 7 + 2);
            } while(start > 0);

            ret = content;
            return ret;
        }

        /*
         * 获取指定的标签的代码块
         example:
         * <li>
         *  <li>
         *      <span>text</span>
         *  </li>
         * </li>
         * htmlsource="<html><p>te<p></p>xt</p></html>", tag="p"
         * return "<p>te<p></p>xt</p>", start=7, len=11
         */
        public string getSourceByTag(string htmlsource, string tag, ref int startindex, out int len)
        {
            int start = 0;
            int end = 0;
            int test = 0;
            int tempstart = 0;
            string ret = htmlsource;

            len = 0;
            do
            {
                start = htmlsource.IndexOf("<" + tag, startindex, StringComparison.OrdinalIgnoreCase);
                end = htmlsource.IndexOf("</" + tag + ">", startindex, StringComparison.OrdinalIgnoreCase);
                
                //Console.WriteLine("getsource({0}):{1}-{2}:{3}", tag, start, end, htmlsource.Substring(start, 30));
                if (start < 0)
                {
                    startindex = htmlsource.Length;
                    len = 0;
                    break;
                }
                if (end < 0)
                {
                    end = htmlsource.Length;
                    len = 0;
                }
                if (start > end)
                {
                    startindex = htmlsource.Length;
                    len = 0;
                    Console.WriteLine("error");
                    break;
                }

                // 处理嵌套
                tempstart = start + tag.Length + 2;
                do
                {
                    test = htmlsource.IndexOf("<" + tag, tempstart, StringComparison.OrdinalIgnoreCase);
                    if (test >= 0 && test < end)
                    {
                        tempstart = test + tag.Length + 1;
                        end = htmlsource.IndexOf("</" + tag + ">", end + tag.Length + 3, StringComparison.OrdinalIgnoreCase);
                        if (end < 0)
                        {
                            end = htmlsource.Length;
                            break;
                        }
                        continue;
                    }
                    //Console.WriteLine("嵌套处理not found:{0}", htmlsource.Substring(tempstart, 1200));
                    break;
                }
                while (true);

                len = end - start + tag.Length + 1 + 2;
                //Console.WriteLine("block[{0}]:{1}", len, htmlsource.Substring(start, len));
                startindex = end + tag.Length + 3; // len("</>") = 3
                ret = htmlsource.Substring(start, len);

                break;
            } while (start > 0);

            return ret;
        }
    }
}
