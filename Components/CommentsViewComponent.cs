using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ScholarHat.Models;


namespace ScholarHat.Components
{
    public class CommentsViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke(int id)
        {
            List<CommentViewModel>? lstComments = new List<CommentViewModel>();

            string url = "https://jsonplaceholder.typicode.com/posts/" + id + "/comments";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                lstComments = JsonConvert.DeserializeObject<List<CommentViewModel>>(response.Content.ReadAsStringAsync().Result);
            }

            return View("~/Views/Components/_Comments.cshtml", lstComments);
        }
    }
}