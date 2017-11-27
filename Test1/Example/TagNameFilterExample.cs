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
            String url = "http://tools.2345.com/frame/black/list/1";

            HtmlPage page = PageUtils.LoadPage(url, Encoding.GetEncoding("gb2312"));
        //    if (page != null)
        //    {
        //        //获取页面中的<a href='xxx' [属性]>格式的链接
        //        NodeList nodelist = page.Body;
        //        //过滤页面中的链接标签
        //        NodeFilter filter = new TagNameFilter("li");
        //        nodelist = nodelist.ExtractAllNodesThatMatch(filter, true);
        //        int count = nodelist.Size();
        //        for (int i = 0; i < count; i++)
        //        {
        //            Bullet nullet = (Bullet)nodelist.ElementAt(i);

        //            for (int j = 0; j < nullet.ChildCount; j++)
        //            {
        //                ATag div = (ATag)nullet.ChildAt(j);
        //                Console.WriteLine(div.StringText);
        //            }

        //            Console.WriteLine("nullet xml :" + nullet.ToHtml());
        //        }


        //        filter = new TagNameFilter("img");
        //        nodelist = nodelist.ExtractAllNodesThatMatch(filter, true);
        //        count = nodelist.Size();
        //        for (int i = 0; i < count; i++)
        //        {
        //            ImageTag node = (ImageTag)nodelist.ElementAt(i);
        //            Console.WriteLine("ImageTag ImageURL :" + node.ImageURL);
        //        }

        //        filter = new TagNameFilter("Tag");
        //        nodelist = nodelist.ExtractAllNodesThatMatch(filter, true);
        //        count = nodelist.Size();
        //        for (int i = 0; i < count; i++)
        //        {
        //            INode node = (INode)nodelist.ElementAt(i);
        //            Console.WriteLine("INode html :" + node.ToHtml());
        //        }
        //    }
            if (page != null)
            {
                NodeList nodelist = page.Body;
                for (int i = 0; i < nodelist.Count; i++)
                {
                    RecursionHtmlNode(nodelist[i], false);
                }  
            }



        }
        private void RecursionHtmlNode(INode htmlNode, bool siblingRequired)
        {
            if (htmlNode == null)
                return;

            if (htmlNode is ITag)
            {
                ITag tag = (htmlNode as ITag);
                if (!tag.IsEndTag())
                {
                    string nodeString = tag.TagName;
                    if (tag.Attributes != null && tag.Attributes.Count > 0)
                    {
                        if (tag.Attributes["ID"] != null)
                        {
                            nodeString = nodeString + " { id=\"" + tag.Attributes["ID"].ToString() + "\" }";
                            Console.WriteLine("nodeString:" + nodeString);
                        }
                        if (tag.Attributes["HREF"] != null)
                        {
                            nodeString = nodeString + " { href=\"" + tag.Attributes["HREF"].ToString() + "\" }";
                            Console.WriteLine("nodeString:" + nodeString);
                        }
                    }
                }
            }
            if (htmlNode.Children != null && htmlNode.Children.Count > 0)
            {
                RecursionHtmlNode(htmlNode.FirstChild, true);
            }

            //the sibling nodes  
            if (siblingRequired)
            {
                INode sibling = htmlNode.NextSibling;
                while (sibling != null)
                {
                    this.RecursionHtmlNode(sibling, false);
                    sibling = sibling.NextSibling;
                    Console.WriteLine("sibling:" + sibling);
                }
            }  
        }
    }
}
