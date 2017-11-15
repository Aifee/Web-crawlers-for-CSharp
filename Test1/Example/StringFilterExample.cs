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
using Winista.Text.HtmlParser.Http;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;
using Winista.Text.HtmlParser.Visitors;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Nodes;


namespace Test1.Example
{
    public class StringFilterExample
    {
        public void Start()
        {
            String url = "http://www.baidu.com/";

            HtmlPage page = PageUtils.LoadPage(url, Encoding.UTF8);
            if (page != null)
            {
                //获取页面中的<a href='xxx' [属性]>格式的链接
                NodeList nodelist = page.Body;
                //过滤页面中的链接标签
                NodeFilter filter = new StringFilter("www.baidu.com/img/");
                nodelist = nodelist.ExtractAllNodesThatMatch(filter, true);
                int count = nodelist.Size();
                for (int i = 0; i < count; i++)
                {
                    TextNode node = (TextNode)nodelist.ElementAt(i);
                    Console.WriteLine("ATag link :" + node.ToHtml());
                }
            }
        }
    }
}
