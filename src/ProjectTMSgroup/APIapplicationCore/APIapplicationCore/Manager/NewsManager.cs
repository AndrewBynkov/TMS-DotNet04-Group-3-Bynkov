using APIapplicationCore.InterfacesNews;
using System;
using System.Threading.Tasks;

namespace APIapplicationCore.Manager
{
    /// <summary>
    /// Getting an article by keyword
    /// </summary>
    public class NewsManager
    {
        private readonly IRequestServiceNews _requestServiceNews;
        public NewsManager()
        {
            _requestServiceNews = new ServicesNews.RequestServiсeNews();
        }
        public async Task ArticleAsync(string keyword)
        {
            var article = await _requestServiceNews.GetListAtricleSearchAsync(keyword);

            var result = article.response.docs;
            if (result != null)
            {
                foreach (var item in result)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Аbstract: {item._abstract}; Link: {item.web_url}");
                    Console.ResetColor();
                    Console.WriteLine("Link: "+item.web_url+"\n");
                }
            }
            else
            {
                Console.WriteLine("Try again...");
            }
        }
    }
}
