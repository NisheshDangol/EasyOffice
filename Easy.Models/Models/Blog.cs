
using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class BlogCategory: CommonResponse
    {
        public List<dynamic> BlogCat { get; set; }
        public int StatusCode { get; set; }
    }

    public class CategoryWiseBlog : CommonResponse
    {
        public List<dynamic> CatWiseBlog { get; set; }
    }

    public class LatestBlog : CommonResponse
    {
        public List<dynamic> LatestBlogs { get; set; }
    }

    public class BlogTag: CommonResponse
    {
        public List<dynamic> BlogsTag { get; set; }
    }

    public class BlogInfo: CommonResponse
    {
        public List<dynamic> BlogsInfo { get; set; }
    }

    public class CreateBlogCat
    {
        public int UserID { get; set; }
        public int CategoryID { get; set; }
        public string Category { get; set; }
        public string Slug { get; set; }
        public string Icon { get; set; }
        public int IsPrimary { get; set; }
        public int Status { get; set; }
        public string Flag { get; set; }
    }

    public class BlogTagAdmin
    {
        public int UserID { get; set; }
        public int TagsID { get; set; }
        public string Tags { get; set; }
        public string Slug { get; set; }
        public int Status { get; set; }
        public int IsTrending { get; set; }
        public string Flag { get; set; }
    }

    public class PostTagAdmin
    {
        public int UserID { get; set; }
        public int PostTagsID { get; set; }
        public int PostID { get; set; }
        public int TagsID { get; set; }
        public int Status { get; set; }
        public string Flag { get; set; }
    }

    public class PostTag : CommonResponse
    {
        public List<dynamic> PostTags { get; set; }
    }

    public class BlogPost
    {
        public int UserID { get; set; }
        public string BlogsID { get; set; }
        public int CategoryID { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Post { get; set; }
        public string FeateImg { get; set; }
        public string Excerpt { get; set; }
        public string Meta { get; set; }
        public int IsVideoFeat { get; set; }
        public int IsPublished { get; set; }
        public int Via { get; set; }
        public int Status { get; set; }
        public string Flag { get; set; }
    }

    public class BlogList: CommonResponse
    {
        public List<dynamic> BlogsList { get; set; }
    }
}
