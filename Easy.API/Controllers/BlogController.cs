using Easy.Connection;
using Easy.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Models;

using System.Threading.Tasks;

namespace TravelSolution.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BlogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet, Route("~/api/blog-category")]
        public async Task<IActionResult> BlogCategory(int Primary)
        {
            var data = await _unitOfWork.blogservice.BlogCategory(Primary);
            return Ok(data);
        }

        [HttpGet, Route("~/api/blogs")]
        public async Task<IActionResult> Blog(string CategoryID, string TagID, int Count, int IsVideoFeat, int Via, string Flag)
        {
            if (Flag.Equals("c", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.CategoryWiseBlog(CategoryID, Count, IsVideoFeat, Via);
                return Ok(data);
            }
            else if (Flag.Equals("t", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.TagWiseBlog(TagID, Count, IsVideoFeat, Via);
                return Ok(data);
            }
            else
            {
                return Ok(new CommonResponse()
                {
                    StatusCode = 400,
                    Message = "Invalid Flag"
                });

            }
        }

        [HttpGet, Route("~/api/latest-blog")]
        public async Task<IActionResult> LatestBlog(int Count, int IsVideoFeat)
        {
            var data = await _unitOfWork.blogservice.LatestBlog(Count, IsVideoFeat);
            return Ok(data);
        }

        [HttpGet, Route("~/api/blog-tag")]
        public async Task<IActionResult> BlogTag(string BlogID, int Via)
        {
            var data = await _unitOfWork.blogservice.BlogTag(BlogID, Via);
            return Ok(data);
        }

        [HttpGet, Route("~/api/blog-info")]
        public async Task<IActionResult> BlogInfo(string BlogID, int Via)
        {
            var data = await _unitOfWork.blogservice.BlogInfo(BlogID, Via);
            return Ok(data);
        }

        [HttpPost, Route("~/api/admin/blog-category")]
        public async Task<IActionResult> CreateBlogCategory(CreateBlogCat category)
        {
            if (category.Flag.Equals("i", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.CreateBlogCategory(category);
                return Ok(data);
            }
            else if (category.Flag.Equals("u", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.UpdateBlogCategory(category);
                return Ok(data);
            }
            else if (category.Flag.Equals("us", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.UpdateBlogCategoryStatus(category);
                return Ok(data);
            }
            else if (category.Flag.Equals("s", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.BlogCategoryList(category);
                return Ok(data);
            }
            else
            {
                return Ok(new CommonResponse()
                {
                    StatusCode = 400,
                    Message = "Invalid Flag"
                });

            }
        }

        [HttpPost, Route("~/api/admin/blog-tags")]
        public async Task<IActionResult> CreateBlogTag(BlogTagAdmin blogTag)
        {
            if (blogTag.Flag.Equals("i", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.CreateBlogTag(blogTag);
                return Ok(data);
            }
            else if (blogTag.Flag.Equals("u", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.UpdateBlogTag(blogTag);
                return Ok(data);
            }
            else if (blogTag.Flag.Equals("us", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.UpdateBlogTagStatus(blogTag);
                return Ok(data);
            }
            else if (blogTag.Flag.Equals("s", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.BlogTagList(blogTag);
                return Ok(data);
            }
            else
            {
                return Ok(new CommonResponse()
                {
                    StatusCode = 400,
                    Message = "Invalid Flag",
                });

            }
        }

        [HttpPost, Route("~/api/admin/posts-tags")]
        public async Task<IActionResult> BlogPostTags(PostTagAdmin blogTag)
        {
            if (blogTag.Flag.Equals("i", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.CreatePostTag(blogTag);
                return Ok(data);
            }
            else if (blogTag.Flag.Equals("u", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.UpdateBlogPostTag(blogTag);
                return Ok(data);
            }
            else if (blogTag.Flag.Equals("us", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.UpdatePostTagStatus(blogTag);
                return Ok(data);
            }
            else if (blogTag.Flag.Equals("s", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.PostTagList(blogTag);
                return Ok(data);
            }
            else
            {
                return Ok(new CommonResponse()
                {
                    StatusCode = 400,
                    Message = "Invalid Flag"
                });

            }
        }


        [HttpPost, Route("~/api/admin/blog-posts")]
        public async Task<IActionResult> BlogPost(BlogPost blogPost)
        {
            if (blogPost.Flag.Equals("i", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.CreatePost(blogPost);
                return Ok(data);
            }
            else if (blogPost.Flag.Equals("u", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.UpdatePost(blogPost);
                return Ok(data);
            }
            else if (blogPost.Flag.Equals("si", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.BlogInfo(blogPost);
                return Ok(data);
            }
            else if (blogPost.Flag.Equals("s", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.BlogList(blogPost);
                return Ok(data);
            }
            else if (blogPost.Flag.Equals("us", System.StringComparison.OrdinalIgnoreCase))
            {
                var data = await _unitOfWork.blogservice.UpdatePostStatus(blogPost);
                return Ok(data);
            }
            else
            {
                return Ok(new CommonResponse()
                {
                    StatusCode=400,
                    Message="Invalid Flag"
                });
            }
        }
    }
}
