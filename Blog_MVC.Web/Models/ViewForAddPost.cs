namespace Blog_MVC.Web.Models
{
    public class ViewForAddPost
    {
        public int PostID { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public string PictureUrl { get; set; }

        public string CategoryName { get; set; }

        public string Tags { get; set; }
    }
}