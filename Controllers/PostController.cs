using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ScholarHat.Models;
using System;

namespace ScholarHat.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            PostViewModel? _blogPost = new PostViewModel();
            //get a random post id to display
            Random _randomPostNo = new Random();  
            // Any random integer   
            int _blogPostNo = _randomPostNo.Next(1,100);
            string _postUrl = "https://jsonplaceholder.typicode.com/posts/" + _blogPostNo;
            HttpClient _client = new HttpClient();
            HttpResponseMessage response = _client.GetAsync(_postUrl).Result;
            if (response.IsSuccessStatusCode)
            {
                _blogPost = JsonConvert.DeserializeObject<PostViewModel>(response.Content.ReadAsStringAsync().Result);
            }
            return View(_blogPost);
        }
    }
}
