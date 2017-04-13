using System;
using System.Collections.Generic;

namespace Blog_MVC.Entity.Models.ViewModel
{
    public class ViewPost
    {
        public int PostID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PostDate { get; set; }

        public string PictureUrl { get; set; }

        public int AdminID { get; set; }

        public string UserName { get; set; }

        public string NameSurname { get; set; }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public List<Tag> Tags { get; set; }


    }
}
