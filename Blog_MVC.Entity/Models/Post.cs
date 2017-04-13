using System;
using System.Collections.Generic;

namespace Blog_MVC.Entity.Models
{
    public class Post : Base
    {
        public int PostID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PostDate { get; set; }

        public string PictureUrl { get; set; }

        public int AdminID { get; set; }

        public int CategoryID { get; set; }

        public List<Tag> Tags { get; set; }

        //mapping
        public Admin Admin { get; set; }
        public Category Category { get; set; }

    }
}
