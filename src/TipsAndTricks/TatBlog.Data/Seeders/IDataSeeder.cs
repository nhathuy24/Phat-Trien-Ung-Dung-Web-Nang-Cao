using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TatBlog.Core.Entities;
using TatBlog.Data.Contexts;

namespace TatBlog.Data.Seeders
{
    public class DataSeeder : IDataSeeder
    {
        private readonly BlogDbContext _dbContext;

        public DataSeeder(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Initialize()
        {
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Posts.Any()) return;

            var authors = AddAuthors();
            var categories = AddCategories();
            var tags = AddTags();
            var posts = AddPosts(authors, categories, tags);
        }

        private IList<Author> AddAuthors()
        {
            var authors = new List<Author>()
            {
                new()
                {
                    FullName = "Jason Mouth",
                    UrlSlug = "jason-mouth",
                    Email = "json@gmail.com",
                    JoinedDate = new DateTime(2020, 4, 21)
                },
                new()
                {
                    FullName = "Jessica Wonder",
                    UrlSlug = "jessica-wonder",
                    Email = "jessica665@motip.com",
                    JoinedDate = new DateTime(2020, 4, 19)
                },
                 new()
                {
                    FullName = "Pham Hoang Nhat Huy",
                    UrlSlug = "pham-hoang-nhat-huy",
                    Email = "nhuey@motip.com",
                    JoinedDate = new DateTime(2019, 2, 24)
                },
                 new()
                 {
                    FullName = "Pham Hoang Minh Anh",
                    UrlSlug = "pham-hoang-minh-anh",
                    Email = "minhanh@motip.com",
                    JoinedDate = new DateTime(2019, 9, 4)
                },
            };

            _dbContext.Authors.AddRange(authors);
            _dbContext.SaveChanges();

            return authors;
        }

        private IList<Category> AddCategories()
        {
            var categories = new List<Category>()
            {
                new(){Name = ".NET Core", Description = ".NET Core", UrlSlug = "dotnet-core", ShowOnMenu = true},
                new(){Name = "Architecture", Description = "Architecture", UrlSlug = "architecture", ShowOnMenu = true},
                new(){Name = "Messaging", Description = "Messaging", UrlSlug = "messaging", ShowOnMenu = true},
                new(){Name = "OOP", Description = "OOP", UrlSlug = "oop", ShowOnMenu = true},
                new(){Name = "Design Pattern", Description = "Design Pattern", UrlSlug = "design-pattern", ShowOnMenu = true},

            };

            _dbContext.Categories.AddRange(categories);
            _dbContext.SaveChanges();

            return categories;
        }

        private IList<Tag> AddTags()
        {
            var tags = new List<Tag>()
            {
                new(){Name = "Google", Description = "Google applications", UrlSlug = "google"},
                new(){Name = "ASP .NET MVC", Description = "ASP .NET MVC", UrlSlug = "asp-dotnet-mvc"},
                new(){Name = "Razor Page", Description = "Razor Page", UrlSlug = "razor-page"},
                new(){Name = "Blazor", Description = "Blazor", UrlSlug = "blazor"},
                new(){Name = "Deep Learning", Description = "Deep Learning", UrlSlug = "deep-learning"},

                new(){Name = "Nha Trang", Description = "Nha Trang", UrlSlug = "nha-trang"},
                new(){Name = "Ha Noi", Description = "Ha Noi", UrlSlug = "ha-noi"},
                new(){Name = "Da Lat", Description = "Da Lat", UrlSlug = "da-lat"},
                new(){Name = "Sai gon", Description = "Sai gon", UrlSlug = "sai-gon"},
                new(){Name = "Gogi", Description = "Gogi", UrlSlug = "go-gi"},
            };

            _dbContext.Tags.AddRange(tags);
            _dbContext.SaveChanges();

            return tags;
        }

        private IList<Post> AddPosts(
            IList<Author> authors,
            IList<Category> categories,
            IList<Tag> tags
            )
        {
            var posts = new List<Post>()
            {
                new()
                {
                    Title = "ASP .NET Core Diagnosric Scenarios",
                    ShortDescription = "David and friends has a great repository filled with examples of \"broken patterns\" in ASP.NET Core applications.",
                    Description = "Here's a list of ASP.NET Core Guidance. This one is fascinating." +
                    " ASP.NET Core doesn't buffer responses which allows it to be VERY scalable. " +
                    "Massively so. As such you do need to be aware that things need to happen in a" +
                    " certain order - Headers come before Body, etc so you want to avoid adding headers " +
                    "after the HttpResponse has started.",
                    Meta = "David and friends has a great repository filled with examples of \"broken patterns\" in ASP.NET Core applications.",
                    UrlSlug = "asp-dotnet-core-diagnosric-scenarios",
                    Published = true,
                    PostedDate = new DateTime(2021, 9, 30, 10, 20, 0),
                    ModifiedDate = null,
                    ViewCount = 10,
                    Author = authors[0],
                    Category = categories[0],
                    Tags = new List<Tag>()
                    {
                        tags[0]
                    }
                },

                new()
                {
                    Title = "Festival Hoa Da Lat 2022",
                    ShortDescription = "Festival Hoa",
                    Description = "New world",
                    Meta = "Festival Hoa",
                    UrlSlug = "festival-hoa-da-lat-2022",
                    Published = true,
                    PostedDate = new DateTime(2022, 10, 3, 11, 0, 0),
                    ModifiedDate = null,
                    ViewCount = 200,
                    Author = authors[1],
                    Category = categories[1],
                    Tags = new List<Tag>()
                    {
                        tags[1]
                    }
                },

                new()
                {
                    Title = "Golden Gate ",
                    ShortDescription = "Gogi",
                    Description = "Doan truoc san sang, " +
                    "Sot sang phuc vu, Den du ve day, " +
                    "Lam chu cuoc choi, An tuong bat ngo, " +
                    "Tu te tu tam",
                    Meta = "Gogi",
                    UrlSlug = "golden-gate",
                    Published = true,
                    PostedDate = new DateTime(2020, 4, 11, 2, 24, 0),
                    ModifiedDate = null,
                    ViewCount = 1000,
                    Author = authors[2],
                    Category = categories[2],
                    Tags = new List<Tag>()
                    {
                        tags[2]
                    }
                },
                new()
                {
                    Title = "Hello",
                    ShortDescription = "What your name",
                    Description = "Pham Hoang Nhat Huy",
                    Meta = "What your name",
                    UrlSlug = "what-your-name",
                    Published = true,
                    PostedDate = new DateTime(2023, 8, 2, 7, 16, 0),
                    ModifiedDate = null,
                    ViewCount = 300,
                    Author = authors[3],
                    Category = categories[3],
                    Tags = new List<Tag>()
                    {
                        tags[3]
                    }
                },
                new()
                {
                    Title = "Giao Vien",
                    ShortDescription = "Day Van",
                    Description = "Ngu van 9",
                    Meta = "Day Van",
                    UrlSlug = "day-van",
                    Published = true,
                    PostedDate = new DateTime(2019, 3, 9, 4, 19, 0),
                    ModifiedDate = null,
                    ViewCount = 500,
                    Author = authors[2],
                    Category = categories[4],
                    Tags = new List<Tag>()
                    {
                        tags[4]
                    }
                },


            };

            _dbContext.Posts.AddRange(posts);
            _dbContext.SaveChanges();

            return posts;
        }
    }
}