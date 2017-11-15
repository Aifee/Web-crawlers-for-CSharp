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

namespace Test1.Example
{
    public class TagNameFilterExample
    {
        /// <summary>
        /// 根据标签名过滤页面中的标签信息
        /// </summary>
        public void Start()
        {
            String url = "https://www.baidu.com/";

            HtmlPage page = PageUtils.LoadPage(url, Encoding.UTF8);
            if (page != null)
            {
                //获取页面中的<a href='xxx' [属性]>格式的链接
                NodeList nodelist = page.Body;
                //过滤页面中的链接标签
                NodeFilter filter = new TagNameFilter("a");
                nodelist = nodelist.ExtractAllNodesThatMatch(filter, true);
                int count = nodelist.Size();
                for (int i = 0; i < count; i++)
                {
                    ATag node = (ATag)nodelist.ElementAt(i);
                    Console.WriteLine("ATag link :" + node.Link);
                }


                filter = new TagNameFilter("img");
                nodelist = nodelist.ExtractAllNodesThatMatch(filter, true);
                count = nodelist.Size();
                for (int i = 0; i < count; i++)
                {
                    ImageTag node = (ImageTag)nodelist.ElementAt(i);
                    Console.WriteLine("ImageTag ImageURL :" + node.ImageURL);
                }
            }
        }
    }
}
