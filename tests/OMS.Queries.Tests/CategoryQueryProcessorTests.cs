using FluentAssertions;
using Moq;
using OMS.API.Models.Dtos.CategoryDto;
using OMS.Data.Access.DAL;
using OMS.Data.Model.Entities;
using OMS.Queries.Interfaces;
using OMS.Queries.QueryProcessors;

namespace OMS.Queries.Tests
{
    public class CategoryQueryProcessorTests
    {
        private Mock<IUnitOfWork> _unitOfWork;
        private List<Category> _categoryList;
        private ICategoryQueryProcessor _queryProcessor;
        //private Random _random;
        private Category _category;
        private CancellationToken _token;

        public CategoryQueryProcessorTests()
        {
            _unitOfWork = new Mock<IUnitOfWork>();

            _categoryList = new List<Category>();
            _unitOfWork.Setup(x => x.Query<Category>()).Returns(() => _categoryList.AsQueryable());
            _category = new Category { CategoryId = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" };

            _queryProcessor = new CategoryQueryProcessor(_unitOfWork.Object);

            #region OLD
            ////_categoryList = new();
            ////var mock = this._categoryList.AsQueryable().BuildMock();

            //////

            ////this._random = new Random();
            ////this._unitOfWork = new Mock<IUnitOfWork>();

            ////this._categoryList = new List<Category>();
            ////this._unitOfWork.Setup(x => x.Query<Category>())
            ////    .Returns(() => _categoryList.AsQueryable());
            ////this._queryProcessor = new CategoryQueryProcessor(_unitOfWork.Object);

            ////this._token = new CancellationToken();

            //_unitOfWork = new Mock<IUnitOfWork>();

            //_categoryList = new List<Category>();
            //_unitOfWork.Setup(x => x.Query<Category>()).Returns(() => _categoryList.AsQueryable());
            //_category = new Category() { CategoryId = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" };

            //_queryProcessor = new CategoryQueryProcessor(_unitOfWork.Object);
            #endregion
        }

        [Fact]
        public void GetByIdTest()
        {
            var category = new Category { CategoryId = _category.CategoryId };
            _categoryList.Add(category);

            var result = _queryProcessor.Get(category.CategoryId);

            result.Should().Be(category);

            #region OLD

            ////var category = new Category { CategoryId = _category.CategoryId };
            ////_categoryList.Add(category);

            ////var result = _queryProcessor.GetById(category.CategoryId, _token);
            ////result.Should().Be(category);
            ////this._categoryList.Add(new Category() { CategoryId = 1, CategoryName = "Beverages" });
            //////this._categoryList.Add(new Category() { CategoryId = 2, CategoryName = "Condiments" });

            //////var id = _categoryList[0].CategoryId;
            ////var tcs = new CancellationTokenSource(1000);

            ////var result = await this._queryProcessor.GetById(1, tcs.Token);
            ////var t = 2;
            //////result.CategoryId.Should().Be(1);

            //////////Act
            ////////var f = await this._queryProcessor.GetById(1, this._token);

            //////////Accert
            ////////Assert.NotNull(f);
            //////////Assert.Equal(new Category 
            //////////{
            //////////    CategoryId = 1,
            //////////    CategoryName = "Beverages"
            //////////});




            //////var expectedResult = new Category
            //////{
            //////    CategoryId = 1,
            //////    CategoryName = "Beverages",
            //////    Description = "Soft drinks, coffees, teas, beers, and ales",
            //////    Products = new List<Product>()
            //////};
            //////this._categoryList.Add(expectedResult);

            //////var result = this._queryProcessor.GetById(1, this._token);

            //////Assert.NotNull(result);
            ////////result.Should().Be(expectedResult);
            #endregion
        }

        [Fact]
        public async Task CreateCategory()
        {
            var entity = new CategoryDtoCreate
            {
                CategoryName = _category.CategoryName,
                Description = _category.Description,
            };

            var result = await _queryProcessor.Create(entity, _token);

            result.CategoryName.Should().Be(entity.CategoryName);
            result.Description.Should().Be(entity.Description);
            _unitOfWork.Verify(x => x.Add(result, _token));
        }

        [Fact]
        public async Task UpdateCategory()
        {
            var category = new Category { CategoryId = _category.CategoryId };
            _categoryList.Add(category);

            var entity = new CategoryDtoUpdate
            {
                CategoryName = _category.CategoryName,
                Description = _category.Description,
            };

            var result = await _queryProcessor.Update(category.CategoryId, entity, _token);

            result.Should().Be(category);
            result.Description.Should().Be(entity.Description);

        }

        ////[Fact]
        //public async Task DeleteCategory()
        //{
        //    var category = new Category() { CategoryId = 11 };// _category.CategoryId };
        //    _categoryList.Add(category);

        //    await _queryProcessor.Delete(category.CategoryId, _token);

        //    category.Should()
        //    //_category.Should().c(0);

        //    //_unitOfWork.Verify(x => x.CommitAsync(_token));


        //    //
        //    //var checkCategory = _queryProcessor.Get(category.CategoryId);
        //    //checkCategory.Should().BeNull();
        //    //

        //    //var authorList = await repository.GetAuthorsAsync();
        //    //Assert.Equal(2, authorList.Count);
        //}

        //[Fact]
        //public async Task<Category> GetByIdTest()
        //{
        //    _categoryList.Add(new Category { CategoryId == 1})
        //}

        //[Fact]
        //public async Task<Category> GetByIdTest()
        //{
        //    var randomCategoryId = new Category
        //    {
        //        CategoryId = _random.Next()
        //    };
        //    _categoryList.Add(randomCategoryId);

        //    var result = _queryProcessor.GetById(randomCategoryId.CategoryId, _token);
        //    result.Should().Be(randomCategoryId);
        //    //_unitOfWork.Setup(x=> x.Query())
        //    //    .Returns(1);
        //    return randomCategoryId;
        //}


        //// todo: переименовать метод в соответствии с конфенцией
        //[Fact]
        //public async Task<Category> CreateTest()//(CancellationToken token)
        //{
        //    var category = await _queryProcessor
        //        .Create(new CategoryDtoCreate()
        //        {

        //        }, CancellationToken.None);

        //    category.Should().Contain(category);
        //    await _unitOfWork.Verify(x => x.CommitAsync());
        //}
    }
}