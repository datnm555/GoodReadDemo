using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodRead.Domain.Entities;
using GoodRead.Domain.Repositories.Interfaces;
using Moq;

namespace GoodRead.Services.Test.Mocks
{
    public class RepositoryMocks
    {
        //public static Mock<IGenericRepository<User>> GetCategoryRepository()
        //{

        //var categories = new List<Category>
        //{
        //    new Category
        //    {
        //        CategoryId = concertGuid,
        //        Name = "Concerts"
        //    },
        //    new Category
        //    {
        //        CategoryId = musicalGuid,
        //        Name = "Musicals"
        //    },
        //    new Category
        //    {
        //        CategoryId = conferenceGuid,
        //        Name = "Conferences"
        //    },
        //    new Category
        //    {
        //        CategoryId = playGuid,
        //        Name = "Plays"
        //    }
        //};

        //var mockCategoryRepository = new Mock<IAsyncRepository<Category>>();
        //mockCategoryRepository.Setup(repo => repo.ListAllAsync()).ReturnsAsync(categories);

        //mockCategoryRepository.Setup(repo => repo.AddAsync(It.IsAny<Category>())).ReturnsAsync(
        //    (Category category) =>
        //    {
        //        categories.Add(category);
        //        return category;
        //    });

        //return mockCategoryRepository;
        //}
    }
}
