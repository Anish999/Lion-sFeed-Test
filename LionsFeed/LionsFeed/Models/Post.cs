using System;
using System.ComponentModel.DataAnnotations;

namespace LionsFeed.Models
{
    public class Post
    {
        public int ID { get; set; }

        public string PostText { get; set; }

        public DateTime CreatedDate { get; set; }

        public ApplicationUser Artist { get; set; }

        [Required]
        public int ArtistId { get; set; }

        public int LikeCount { get; set; }
    }
}

