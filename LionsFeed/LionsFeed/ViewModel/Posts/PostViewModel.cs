using LionsFeed.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LionsFeed.ViewModel.Posts
{
    public class PostViewModel
    {
        [MinLength(1, ErrorMessage = "Please enter a valid message.")]
        public string PostText { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public IEnumerable<Post> Posts { get; set; }


    }
}
