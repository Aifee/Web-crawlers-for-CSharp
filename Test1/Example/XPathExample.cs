/*
 *************************************************************
 * Copyright (c) 2017 - 2019 liuaf
 * Create time：2017/11/8 14:35:32
 * Created by：liuaf
 * Contact information：329737941@qq.com
 **************************************************************
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Http;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;
using Winista.Text.HtmlParser.Visitors;
using Winista.Text.HtmlParser.Lex;
using HtmlAgilityPack;
using System.IO;
using System.Xml;

namespace Test1.Example
{
    public class XPathExample
    {
        public void Start()
        {
            String url = "http://tools.2345.com/frame/black/list/1";
            HtmlPage page = PageUtils.LoadPage(url, Encoding.GetEncoding("gb2312"));
            if (page != null)
            {
                NodeList nodelist = page.Body;
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.OptionOutputAsXml = true;
                htmlDoc.LoadHtml(nodelist.ToHtml());

                StringBuilder sbXml = new StringBuilder();
                StringWriter sw = new StringWriter(sbXml);
                htmlDoc.Save(sw);

                Console.WriteLine(sbXml.ToString());
                XmlDocument doc = new XmlDocument();

                doc.Save("C:/Users/user/Desktop/test/1.xml");
            }
            

            //XPathDocument doc = new XPathDocument("http://tools.2345.com/frame/black/list/1");
            //XPathNavigator xPathNav = doc.CreateNavigator();
            ////使用xPath取rss中最新的10条随笔
            //XPathNodeIterator nodeIterator = xPathNav.Select("/body/div/div/div/div/div/div/ul/li");
            //while (nodeIterator.MoveNext())
            //{
            //    XPathNavigator itemNav = nodeIterator.Current;
            //    string title = itemNav.SelectSingleNode("title").Value;
            //    string url = itemNav.SelectSingleNode("link").Value;
            //    Console.WriteLine("{0} = {1}", title, url);
            //}
        }
    }
}
