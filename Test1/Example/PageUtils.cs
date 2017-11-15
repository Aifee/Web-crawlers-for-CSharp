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
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Visitors;
using Winista.Text.HtmlParser.Util;

namespace Test1.Example
{
    public class PageUtils
    {
        public static HtmlPage LoadPage(string url, Encoding coding)
        {
            System.Net.WebClient web = new System.Net.WebClient();
            web.Encoding = coding;
            string html = web.DownloadString(url.Trim());

            Parser parser = Parser.CreateParser(html, null);
            HtmlPage page = new HtmlPage(parser);
            try
            {
                parser.VisitAllNodesWith(page);
            }
            catch (ParserException ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
            return page;
        }
    }
}
