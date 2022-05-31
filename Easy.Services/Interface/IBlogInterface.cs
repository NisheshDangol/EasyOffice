using Easy.Connection;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IBlogInterface
    {
        Task<BlogCategory> BlogCategory(int Primary);
        Task<CategoryWiseBlog> CategoryWiseBlog(string CategoryID, int Count, int IsVideoFeat, int Via);
        Task<CategoryWiseBlog> TagWiseBlog(string CategoryID, int Count, int IsVideoFeat, int Via);
        Task<LatestBlog> LatestBlog(int Count, int IsVideoFeat);
        Task<BlogTag> BlogTag(string BlogID, int Via);
        Task<BlogInfo> BlogInfo(string BlogID, int Via);
        Task<CommonResponse> CreateBlogCategory(CreateBlogCat blogCat);
        Task<CommonResponse> UpdateBlogCategory(CreateBlogCat blogCat);
        Task<CommonResponse> UpdateBlogCategoryStatus(CreateBlogCat blogCat);
        Task<BlogCategory> BlogCategoryList(CreateBlogCat blogCat);
        Task<CommonResponse> CreateBlogTag(BlogTagAdmin blogTag);
        Task<CommonResponse> UpdateBlogTag(BlogTagAdmin blogTag);
        Task<BlogTag> BlogTagList(BlogTagAdmin blogTag);
        Task<CommonResponse> CreatePostTag(PostTagAdmin postTag);
        Task<CommonResponse> UpdateBlogPostTag(PostTagAdmin postTag);
        Task<CommonResponse> UpdatePostTagStatus(PostTagAdmin postTag);
        Task<PostTag> PostTagList(PostTagAdmin postTag);
        Task<CommonResponse> CreatePost(BlogPost blogPost);
        Task<CommonResponse> UpdatePost(BlogPost blogPost);
        Task<BlogInfo> BlogInfo(BlogPost blogPost);
        Task<BlogList> BlogList(BlogPost blogPost);
        Task<CommonResponse> UpdatePostStatus(BlogPost blogPost);
    }
}
