using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;
using TatBlog.Data.Seeders;
using TatBlog.Services.Blogs;
using TatBlog.WinApp;

namespace TatBlog.WinApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            var context = new BlogDbContext();

            IBlogRepository blogRepo = new BlogRepository(context);

            var pagingParams = new PagingParams
            {
                PageNumber = 1,
                PageSize = 5,
                SortColumn = "Name",
                SortOrder = "DESC"
            };
                
            var tagList = await blogRepo.GetPagedTagsAsync(pagingParams);

            Console.WriteLine("{0,-5}{1,-50}{2,10}",
                "ID", "Name", "Count");

            foreach (var item in tagList)
            {
                Console.WriteLine("{0,-5}{1,-50}{2,10}",
                    item.Id, item.Name, item.PostCount);
            }
            
        }
    }
}