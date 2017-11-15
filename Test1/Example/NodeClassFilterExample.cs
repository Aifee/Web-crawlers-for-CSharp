/*
 *************************************************************
 * Copyright (c) 2017 - 2019 liuaf
 * Create time：2017/11/8 14:35:32
 * Created by：liuaf
 * Contact information：329737941@qq.com
 **************************************************************
 */

using System;
using System.Text;
using Winista.Text.HtmlParser;
using Winista.Text.HtmlParser.Http;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;
using Winista.Text.HtmlParser.Visitors;
using Winista.Text.HtmlParser.Lex;

namespace Test1.Example
{
    public class NodeClassFilterExample
    {
        public void Start()
        {
            String url = "https://www.baidu.com/";

            HtmlPage page = PageUtils.LoadPage(url, Encoding.UTF8);
            if (page != null)
            {
                //获取页面中的<a href='xxx' [属性]>格式的链接
                NodeList nodelist = page.Body;
                //过滤页面中的链接标签
                NodeFilter filter = new NodeClassFilter(typeof(LinkTag));
                nodelist = nodelist.ExtractAllNodesThatMatch(filter, true);
                int count = nodelist.Size();
                for (int i = 0; i < count; i++)
                {
                    LinkTag node = (LinkTag)nodelist.ElementAt(i);
                    Console.WriteLine("LinkTag link :" + node.Link);
                }


                //或取页面中的<img src='xxx' [属性='属性值']>格式的链接
                nodelist = page.Body;
                //过滤页面中的链接标签
                filter = new NodeClassFilter(typeof(ImageTag));
                nodelist = nodelist.ExtractAllNodesThatMatch(filter, true);
                count = nodelist.Size();
                for (int i = 0; i < count; i++)
                {
                    ImageTag node = (ImageTag)nodelist.ElementAt(i);
                    Console.WriteLine("ImageTag url :" + node.ImageURL);
                }


                //或取页面<title>xxxx</title>标题
                nodelist = page.Body;
                //过滤页面中的链接标签
                filter = new NodeClassFilter(typeof(TitleTag));
                nodelist = nodelist.ExtractAllNodesThatMatch(filter, true);
                count = nodelist.Size();
                for (int i = 0; i < count; i++)
                {
                    TitleTag node = (TitleTag)nodelist.ElementAt(i);

                    Console.WriteLine("TitleTag text :" + node.StringText);
                }


                //获取页面<div [属性='属性值']> xxx</div>
                nodelist = page.Body;
                //过滤页面中的链接标签
                filter = new NodeClassFilter(typeof(Div));
                nodelist = nodelist.ExtractAllNodesThatMatch(filter, true);
                count = nodelist.Size();
                for (int i = 0; i < count; i++)
                {
                    Div node = (Div)nodelist.ElementAt(i);
                    Console.WriteLine("DivTag href :" + node.ChildCount);
                    
                }
            }
            
        }

        /// <summary>
        /// 过滤页面中的标签信息
        /// </summary>
        /// <param name="url"> 要解析的url页面 </param>
        /// <param name="encoding"> 使用的字符编码 </param>
        /// <param name="tagType"> 要或取得页面标签,如要获取页面中的超链接 值为LinkTag.class,要获取页面中图片链接,值为ImageTag.class 要传入的标签类为org.htmlparser.tags下的</param>
        public void nodeFilterTagClass(HtmlPage page, Type tagType)
        {
            NodeList nodelist = page.Body;
            //过滤页面中的链接标签
            NodeFilter filter = new NodeClassFilter(tagType);
            nodelist = nodelist.ExtractAllNodesThatMatch(filter, true);
            int count = nodelist.Size();
            for (int i = 0; i < count; i++)
            {
                INode node = (INode)nodelist.ElementAt(i);
                Console.WriteLine("link is :" + node.ToHtml());
            }
        }
    }
}