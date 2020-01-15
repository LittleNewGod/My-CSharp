using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CoreForSpider
{
    class Program
    {
        static void Main(string[] args)
        {
            var resutl = ParseCnBlogs();
            foreach(var re in resutl)
            {
                Console.WriteLine(re.Author + "---" + re.Comment + "--" + re.Title + "--" + re.View);
            }
            //FromWeb();
            //FromFile();
            //FromString();
            Console.WriteLine("Hello World!");
        }

        /// <summary>
        /// 从文件读取
        /// </summary>
        public static void FromFile()
        {
            var path = @"..\..\..\test.html";
            var doc = new HtmlDocument();
            
            doc.Load(path);
            var node = doc.DocumentNode.SelectSingleNode("//body");
            Console.WriteLine(node.OuterHtml);
        }
        /// <summary>
        /// 从字符串读取
        /// </summary>
        public static void FromString()
        {
            var html = @"<!DOCTYPE html>
                        <html>
                        <body>
                        <h1>This is <b>bold</b> heading</h1>
                        <p>This is <u>underlined</u> paragraph</p>
                        <h2>This is <i>italic</i> heading</h2>
                        </body>
                        </html> ";
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(html);
            var htmlBody = htmlDoc.DocumentNode.SelectSingleNode("//body");
            Console.WriteLine(htmlBody.OuterHtml);
        }

        /// <summary>
        /// 从网络地址加载
        /// </summary>
        public static void FromWeb()
        {
            var html = @"https://www.cnblogs.com/";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);
            var node = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='post_list']");
            Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);
        }


        /// <summary>
        /// 解析
        /// </summary>
        /// <returns></returns>
        public static List<Article> ParseCnBlogs()
        {
            var url = "https://www.cnblogs.com";
            HtmlWeb web = new HtmlWeb();
            //1.支持从web或本地path加载html
            var htmlDoc = web.Load(url);
            var post_listnode = htmlDoc.DocumentNode.SelectSingleNode("//div[@id='post_list']");
            //Console.WriteLine("Node Name: " + post_listnode.Name + "\n" + post_listnode.OuterHtml);
            var postitemsNodes = post_listnode.SelectNodes("div[@class='post_item']");
            var articles = new List<Article>();
            var digitRegex = @"[^0-9]+";
            foreach (var item in postitemsNodes)
            {
                var article = new Article();
                var diggnumnode = item.SelectSingleNode("*//span[@class='diggnum']");
                //body
                var post_item_bodynode = item.SelectSingleNode("div[@class='post_item_body']");
                var titlenode = post_item_bodynode.SelectSingleNode("*//a[@class='titlelnk']");
                var summarynode = post_item_bodynode.SelectSingleNode("p[@class='post_item_summary']");
                //foot
                var footnode = post_item_bodynode.SelectSingleNode("div[@class='post_item_foot']");
                var authornode = footnode.ChildNodes[1];
                var commentnode = footnode.SelectSingleNode("span[@class='article_comment']");
                var viewnode = footnode.SelectSingleNode("span[@class='article_view']");
                article.Diggit = int.Parse(diggnumnode.InnerText);
                article.Title = titlenode.InnerText;
                article.Url = titlenode.Attributes["href"].Value;
                article.Summary = titlenode.InnerHtml;
                article.Author = authornode.InnerText;
                article.AuthorUrl = authornode.Attributes["href"].Value;
                article.Comment = int.Parse(Regex.Replace(commentnode.ChildNodes[0].InnerText, digitRegex, ""));
                article.View = int.Parse(Regex.Replace(viewnode.ChildNodes[0].InnerText, digitRegex, ""));
                articles.Add(article);
            }
            return articles;
        }
    }
}
