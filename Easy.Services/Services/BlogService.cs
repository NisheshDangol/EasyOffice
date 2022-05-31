using Dapper;
using Easy.Connection;
using Easy.Connection.Dapper;
using Model.Models;

using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class BlogService: IBlogInterface
    {
        public async Task<BlogCategory> BlogCategory(int Primary)
        {
            var res = new BlogCategory();
            if (Primary == 0)
            {
                res.BlogCat = null;
                res.StatusCode = 400;
                res.Message = "Primary is Empty";
            }
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "blogcategory");
                parameters.Add("@primary", Primary);
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if(data.Count()!=0 && data.FirstOrDefault().Message == null)
                {
                    res.StatusCode = 200;
                    res.Message = "Success";
                    res.BlogCat = data.ToList();
                }
                else if (data.Count()==1 && data.FirstOrDefault().Message != null)
                {
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;
                    res.BlogCat = null;
                }
                else
                {
                    res.StatusCode = 400;
                    res.Message = "No Data";
                    res.BlogCat= null;
                }
            }
            return res;
        }

        public async Task<CategoryWiseBlog> CategoryWiseBlog(string CategoryID, int Count, int IsVideoFeat, int Via)
        {
            var res = new CategoryWiseBlog();
            res.StatusCode = 400;
            res.CatWiseBlog = null;
            if (string.IsNullOrEmpty(CategoryID)) res.Message = "CategoryID is Empty";
            else if (Count == 0) res.Message = "Count is Empty";
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "catwiseblog");
                parameters.Add("@categoryid", CategoryID);
                parameters.Add("@count", Count);
                parameters.Add("@isvideofeat", IsVideoFeat);
                parameters.Add("@via", Via);
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    res.StatusCode = 200;
                    res.Message = "Success";
                    res.CatWiseBlog = data.ToList();
                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;
                    res.CatWiseBlog = null;
                }
                else
                {
                    res.StatusCode = 400;
                    res.Message = "No Data";
                    res.CatWiseBlog = null;
                }
            }
            return res;
        }

        public async Task<CategoryWiseBlog> TagWiseBlog(string CategoryID, int Count, int IsVideoFeat, int Via)
        {
            var res = new CategoryWiseBlog();
            res.StatusCode = 400;
            res.CatWiseBlog = null;
            if (string.IsNullOrEmpty(CategoryID)) res.Message = "TagID is Empty";
            else if (Count == 0) res.Message = "Count is Empty";
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "tagwiseblog");
                parameters.Add("@tagid", CategoryID);
                parameters.Add("@count", Count);
                parameters.Add("@isvideofeat", IsVideoFeat);
                parameters.Add("@via", Via);
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    res.StatusCode = 200;
                    res.Message = "Success";
                    res.CatWiseBlog = data.ToList();
                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;
                    res.CatWiseBlog = null;
                }
                else
                {
                    res.StatusCode = 400;
                    res.Message = "No Data";
                    res.CatWiseBlog = null;
                }
            }
            return res;
        }

        public async Task<LatestBlog> LatestBlog(int Count, int IsVideoFeat)
        {
            var res = new LatestBlog();
            res.StatusCode = 400;
            res.LatestBlogs = null;
            if (Count==0) res.Message = "Count is Empty";
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "latestblog");
                parameters.Add("@isvideofeat", IsVideoFeat);
                parameters.Add("@count", Count);
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    res.StatusCode = 200;
                    res.Message = "Success";
                    res.LatestBlogs = data.ToList();
                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;
                    res.LatestBlogs = null;
                }
                else
                {
                    res.StatusCode = 400;
                    res.Message = "No Data";
                    res.LatestBlogs = null;
                }
            }
            return res;
        }

        public async Task<BlogTag> BlogTag(string BlogID, int Via)
        {
            var res = new BlogTag();
            res.StatusCode = 400;
            if (string.IsNullOrEmpty(BlogID)) res.Message = "BlogID is Empty";
            else if (Via == 0) res.Message = "Via is Empty";
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "blogtag");
                parameters.Add("@blogid", BlogID);
                parameters.Add("@via", Via);
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    res.StatusCode = 200;
                    res.Message = "Success";
                    res.BlogsTag = data.ToList();
                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;
                    res.BlogsTag = null;
                }
                else
                {
                    res.StatusCode = 400;
                    res.Message = "No Data";
                    res.BlogsTag = null;
                }
            }
            return res;
        }

        public async Task<BlogInfo> BlogInfo(string BlogID, int Via)
        {
            var res = new BlogInfo();
            res.StatusCode = 400;
            if (string.IsNullOrEmpty(BlogID)) res.Message = "BlogID is Empty";
            else if (Via == 0) res.Message = "Via is Empty";
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "bloginfo");
                parameters.Add("@blogid", BlogID);
                parameters.Add("@via", Via);
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    res.StatusCode = 200;
                    res.Message = "Success";
                    res.BlogsInfo = data.ToList();
                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;
                    res.BlogsInfo = null;
                }
                else
                {
                    res.StatusCode = 400;
                    res.Message = "No Data";
                    res.BlogsInfo = null;
                }
            }
            return res;
        }

        public async Task<CommonResponse> CreateBlogCategory(CreateBlogCat blogCat)
        {
            var res = new CommonResponse();
            res.StatusCode = 400;
            if (blogCat.UserID == 0) res.Message = "UserID is Empty";
            else if (string.IsNullOrEmpty(blogCat.Category)) res.Message = "Category is Empty";
            else if (string.IsNullOrEmpty(blogCat.Slug)) res.Message = "Slug is Empty";
            else if (string.IsNullOrEmpty(blogCat.Icon)) res.Message = "Icon is Empty";            
            
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "createblogcat");
                parameters.Add("@userid", blogCat.UserID);
                parameters.Add("@category", blogCat.Category);
                parameters.Add("@slug", blogCat.Slug);
                var img = Convert.FromBase64String(blogCat.Icon);
                var imgname = DateTime.Now.Ticks+".jpg";
                Image image = Image.FromStream(new MemoryStream(img));
                image.Save("Images/Blog/" + imgname, ImageFormat.Jpeg);
                parameters.Add("@icon", imgname);
                parameters.Add("@isprimary", blogCat.IsPrimary);
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
                res.StatusCode = data.FirstOrDefault().StatusCode;
                res.Message = data.FirstOrDefault().Message;
            }
            return res;
        }

        public async Task<CommonResponse> UpdateBlogCategory(CreateBlogCat blogCat)
        {
            var res = new CommonResponse();
            res.StatusCode = 400;
            if (blogCat.UserID == 0) res.Message = "UserID is Empty";
            else if (blogCat.CategoryID == 0) res.Message = "CategoryID is Empty";
            else if (string.IsNullOrEmpty(blogCat.Category)) res.Message = "Category is Empty";
            else if (string.IsNullOrEmpty(blogCat.Slug)) res.Message = "Slug is Empty";
            else if (string.IsNullOrEmpty(blogCat.Icon)) res.Message = "Icon is Empty";

            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "updateblogcat");
                parameters.Add("@userid", blogCat.UserID);
                parameters.Add("@categoryid", blogCat.CategoryID);
                parameters.Add("@category", blogCat.Category);
                parameters.Add("@slug", blogCat.Slug);
                var img = Convert.FromBase64String(blogCat.Icon);
                var imgname = DateTime.Now.Ticks + ".jpg";
                Image image = Image.FromStream(new MemoryStream(img));
                image.Save("Images/Blog/" + imgname, ImageFormat.Jpeg);
                parameters.Add("@icon", imgname);
                parameters.Add("@isprimary", blogCat.IsPrimary);
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
                res.StatusCode = data.FirstOrDefault().StatusCode;
                res.Message = data.FirstOrDefault().Message;
            }
            return res;
        }

        public async Task<CommonResponse> UpdateBlogCategoryStatus(CreateBlogCat blogCat)
        {
            var res = new CommonResponse();
            res.StatusCode = 400;
            if (blogCat.UserID == 0) res.Message = "UserID is Empty";
            else if (blogCat.CategoryID == 0) res.Message = "CategoryID is Empty";
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "updateblogcatstatus");
                parameters.Add("@userid", blogCat.UserID);
                parameters.Add("@categoryid", blogCat.CategoryID);
                parameters.Add("@status", blogCat.Status);                
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
                res.StatusCode = data.FirstOrDefault().StatusCode;
                res.Message = data.FirstOrDefault().Message;
            }
            return res;
        }

        public async Task<BlogCategory> BlogCategoryList(CreateBlogCat blogCat)
        {
            var res = new BlogCategory();
            res.BlogCat = null;
            res.StatusCode = 400;
            if (blogCat.UserID == 0) res.Message = "UserID is Empty";
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "blogcatlist");
                parameters.Add("@userid", blogCat.UserID);
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    res.StatusCode = 200;
                    res.Message = "Success";
                    res.BlogCat = data.ToList();
                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;
                    res.BlogCat = null;
                }
                else
                {
                    res.StatusCode = 400;
                    res.Message = "No Data";
                    res.BlogCat = null;
                }     
            }
            return res;
        }

        public async Task<CommonResponse> CreateBlogTag(BlogTagAdmin blogTag)
        {
            var res = new CommonResponse();
            res.StatusCode = 400;
            if (blogTag.UserID == 0) res.Message = "UserID is Empty";
            else if (string.IsNullOrEmpty(blogTag.Tags)) res.Message = "Tags is Empty";
            else if (string.IsNullOrEmpty(blogTag.Slug)) res.Message = "Slug is Empty";
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "createblogtag");
                parameters.Add("@userid", blogTag.UserID);
                parameters.Add("@tag", blogTag.Tags);
                parameters.Add("@slug", blogTag.Slug);                
                parameters.Add("@istrending", blogTag.IsTrending);
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
                res.StatusCode = data.FirstOrDefault().StatusCode;
                res.Message = data.FirstOrDefault().Message;
            }
            return res;
        }

        public async Task<CommonResponse> UpdateBlogTag(BlogTagAdmin blogTag)
        {
            var res = new CommonResponse();
            res.StatusCode = 400;
            if (blogTag.UserID == 0) res.Message = "UserID is Empty";
            else if (blogTag.TagsID == 0) res.Message = "TagsID is Empty";
            else if (string.IsNullOrEmpty(blogTag.Tags)) res.Message = "Tags is Empty";
            else if (string.IsNullOrEmpty(blogTag.Slug)) res.Message = "Slug is Empty";
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "updateblogtag");
                parameters.Add("@userid", blogTag.UserID);
                parameters.Add("@tagid", blogTag.TagsID);
                parameters.Add("@tag", blogTag.Tags);
                parameters.Add("@slug", blogTag.Slug);                
                parameters.Add("@istrending", blogTag.IsTrending);
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
                res.StatusCode = data.FirstOrDefault().StatusCode;
                res.Message = data.FirstOrDefault().Message;
            }
            return res;
        }


        public async Task<CommonResponse> UpdateBlogTagStatus(BlogTagAdmin blogTag)
        {
            var res = new CommonResponse();
            res.StatusCode = 400;
            if (blogTag.UserID == 0) res.Message = "UserID is Empty";
            else if (blogTag.TagsID == 0) res.Message = "TagsID is Empty";
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "updateblogtagstatus");
                parameters.Add("@userid", blogTag.UserID);
                parameters.Add("@tagid", blogTag.TagsID);
                parameters.Add("@status", blogTag.Status);
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
                res.StatusCode = data.FirstOrDefault().StatusCode;
                res.Message = data.FirstOrDefault().Message;
            }
            return res;
        }

        public async Task<BlogTag> BlogTagList(BlogTagAdmin blogTag)
        {
            var res = new BlogTag();
            res.BlogsTag = null;
            res.StatusCode = 400;
            if (blogTag.UserID == 0) res.Message = "UserID is Empty";
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "blogcatlist");
                parameters.Add("@userid", blogTag.UserID);
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    res.StatusCode = 200;
                    res.Message = "Success";
                    res.BlogsTag = data.ToList();
                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;
                    res.BlogsTag = null;
                }
                else
                {
                    res.StatusCode = 400;
                    res.Message = "No Data";
                    res.BlogsTag = null;
                }
            }
            return res;
        }

        public async Task<CommonResponse> CreatePostTag(PostTagAdmin postTag)
        {
            var res = new CommonResponse();
            res.StatusCode = 400;
            if (postTag.UserID == 0) res.Message = "UserID is Empty";
            else if (postTag.PostID==0) res.Message = "PostID is Empty";
            else if (postTag.TagsID == 0) res.Message = "TagsID is Empty";            
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "createposttag");
                parameters.Add("@userid", postTag.UserID);
                parameters.Add("@postid", postTag.PostID);
                parameters.Add("@tagid", postTag.TagsID);                
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
                res.StatusCode = data.FirstOrDefault().StatusCode;
                res.Message = data.FirstOrDefault().Message;
            }
            return res;
        }

        public async Task<CommonResponse> UpdateBlogPostTag(PostTagAdmin postTag)
        {
            var res = new CommonResponse();
            res.StatusCode = 400;
            if (postTag.UserID == 0) res.Message = "UserID is Empty";
            else if (postTag.TagsID == 0) res.Message = "TagsID is Empty";
            else if (postTag.PostTagsID == 0) res.Message = "PostTagID is Empty";
            else if (postTag.PostID==0) res.Message = "PostID is Empty";
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "updateblogposttag");
                parameters.Add("@userid", postTag.UserID);
                parameters.Add("@tagid", postTag.TagsID);
                parameters.Add("@postid", postTag.PostID);
                parameters.Add("@posttagid", postTag.PostTagsID);
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
                res.StatusCode = data.FirstOrDefault().StatusCode;
                res.Message = data.FirstOrDefault().Message;
            }
            return res;
        }

        public async Task<CommonResponse> UpdatePostTagStatus(PostTagAdmin postTag)
        {
            var res = new CommonResponse();
            res.StatusCode = 400;
            if (postTag.UserID == 0) res.Message = "UserID is Empty";
            else if (postTag.PostTagsID == 0) res.Message = "PostTagsID is Empty";
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "updateposttagstatus");
                parameters.Add("@userid", postTag.UserID);
                parameters.Add("@posttagid", postTag.PostTagsID);
                parameters.Add("@status", postTag.Status);
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
                res.StatusCode = data.FirstOrDefault().StatusCode;
                res.Message = data.FirstOrDefault().Message;
            }
            return res;
        }

        public async Task<PostTag> PostTagList(PostTagAdmin postTag)
        {
            var res = new PostTag();
            res.PostTags = null;
            res.StatusCode = 400;
            if (postTag.UserID == 0) res.Message = "UserID is Empty";
            else if (postTag.PostID == 0) res.Message = "PostID is Empty";
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "posttaglist");
                parameters.Add("@userid", postTag.UserID);
                parameters.Add("@postid", postTag.PostID);
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    res.StatusCode = 200;
                    res.Message = "Success";
                    res.PostTags = data.ToList();
                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;
                    res.PostTags = null;
                }
                else
                {
                    res.StatusCode = 400;
                    res.Message = "No Data";
                    res.PostTags = null;
                }
            }
            return res;
        }


        public async Task<CommonResponse> CreatePost(BlogPost blogPost)
        {
            var res = new CommonResponse();
            res.StatusCode = 400;
            if (blogPost.UserID == 0) res.Message = "UserID is Empty";
            else if (blogPost.CategoryID == 0) res.Message = "CategoryID is Empty";
            else if (string.IsNullOrEmpty(blogPost.Title)) res.Message = "Title is Empty";
            else if (string.IsNullOrEmpty(blogPost.Slug)) res.Message = "Slug is Empty";
            else if (string.IsNullOrEmpty(blogPost.Post)) res.Message = "Post is Empty";
            else if (string.IsNullOrEmpty(blogPost.FeateImg)) res.Message = "FeatImg is Empty";
            else if (string.IsNullOrEmpty(blogPost.Excerpt)) res.Message = "Excerpt is Empty";
            
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "createpost");
                parameters.Add("@userid", blogPost.UserID);
                parameters.Add("@categoryid", blogPost.CategoryID);
                parameters.Add("@title", blogPost.Title);
                parameters.Add("@slug", blogPost.Slug);
                parameters.Add("@post", blogPost.Post);
                var imgname = DateTime.Now.Ticks+".jpg";
                var img = Convert.FromBase64String(blogPost.FeateImg);
                Image image = Image.FromStream(new MemoryStream(img));
                image.Save("Images/Blog/"+imgname,ImageFormat.Jpeg);
                parameters.Add("@featimg", imgname);
                parameters.Add("@excerpt", blogPost.Excerpt);
                parameters.Add("@meta", blogPost.Meta);
                parameters.Add("@isvideofeat", blogPost.IsVideoFeat);
                parameters.Add("@ispublished", blogPost.IsPublished);
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
                res.StatusCode = data.FirstOrDefault().StatusCode;
                res.Message = data.FirstOrDefault().Message;

            }
            return res;
        }

        public async Task<CommonResponse> UpdatePost(BlogPost blogPost)
        {
            var res = new CommonResponse();
            res.StatusCode = 400;
            if (blogPost.UserID == 0) res.Message = "UserID is Empty";
            else if (blogPost.CategoryID == 0) res.Message = "CategoryID is Empty";
            else if (string.IsNullOrEmpty(blogPost.BlogsID)) res.Message = "BlogsID is Empty";
            else if (string.IsNullOrEmpty(blogPost.Title)) res.Message = "Title is Empty";
            else if (string.IsNullOrEmpty(blogPost.Slug)) res.Message = "Slug is Empty";
            else if (string.IsNullOrEmpty(blogPost.Post)) res.Message = "Post is Empty";
            else if (string.IsNullOrEmpty(blogPost.FeateImg)) res.Message = "FeatImg is Empty";
            else if (string.IsNullOrEmpty(blogPost.Excerpt)) res.Message = "Excerpt is Empty";

            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "updatepost");
                parameters.Add("@userid", blogPost.UserID);
                parameters.Add("@blogid", blogPost.BlogsID);
                parameters.Add("@categoryid", blogPost.CategoryID);
                parameters.Add("@title", blogPost.Title);
                parameters.Add("@slug", blogPost.Slug);
                parameters.Add("@post", blogPost.Post);
                var imgname = DateTime.Now.Ticks + ".jpg";
                var img = Convert.FromBase64String(blogPost.FeateImg);
                Image image = Image.FromStream(new MemoryStream(img));
                image.Save("Images/Blog/" + imgname, ImageFormat.Jpeg);
                parameters.Add("@featimg", imgname);
                parameters.Add("@excerpt", blogPost.Excerpt);
                parameters.Add("@meta", blogPost.Meta);
                parameters.Add("@isvideofeat", blogPost.IsVideoFeat);
                parameters.Add("@ispublished", blogPost.IsPublished);
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
                res.StatusCode = data.FirstOrDefault().StatusCode;
                res.Message = data.FirstOrDefault().Message;

            }
            return res;
        }

        public async Task<BlogInfo> BlogInfo(BlogPost blogPost)
        {
            var res = new BlogInfo();
            res.StatusCode = 400;
            if (blogPost.UserID == 0) res.Message = "UserID is Empty";
            else if (string.IsNullOrEmpty(blogPost.BlogsID)) res.Message = "BlogsID is Empty";
            else if (blogPost.Via == 0) res.Message = "Via is Empty";
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "bloginfoadmin");
                parameters.Add("@userid", blogPost.UserID);
                parameters.Add("@blogid", blogPost.BlogsID);
                parameters.Add("@via", blogPost.Via);
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    res.StatusCode = 200;
                    res.Message = "Success";
                    res.BlogsInfo = data.ToList();
                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;
                    res.BlogsInfo = null;
                }
                else
                {
                    res.StatusCode = 400;
                    res.Message = "No Data";
                    res.BlogsInfo = null;
                }
            }
            return res;
        }

        public async Task<BlogList> BlogList(BlogPost blogPost)
        {
            var res = new BlogList();
            res.StatusCode = 400;
            if (blogPost.UserID == 0) res.Message = "UserID is Empty";
            
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "bloglist");
                parameters.Add("@userid", blogPost.UserID);
                
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    res.StatusCode = 200;
                    res.Message = "Success";
                    res.BlogsList = data.ToList();
                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;
                    res.BlogsList = null;
                }
                else
                {
                    res.StatusCode = 400;
                    res.Message = "No Data";
                    res.BlogsList = null;
                }
            }
            return res;
        }

        public async Task<CommonResponse> UpdatePostStatus(BlogPost blogPost)
        {
            var res = new CommonResponse();
            res.StatusCode = 400;
            if (blogPost.UserID == 0) res.Message = "UserID is empty";
            else if (string.IsNullOrEmpty(blogPost.BlogsID)) res.Message = "BlogID is empty";
            //else if (blogPost.Status == 0) res.Message = "Status is Empty";
            else
            {
                var sql = "sp_blog";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "updatepoststatus");
                parameters.Add("@userid", blogPost.UserID);
                parameters.Add("@blogid", blogPost.BlogsID);
                parameters.Add("@status", blogPost.Status);
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
                res.StatusCode = data.FirstOrDefault().StatusCode;
                res.Message = data.FirstOrDefault().Message;
            }
            return res;
        }
        
    }
}
