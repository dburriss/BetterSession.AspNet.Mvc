using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Xunit;
using BetterSession.AspNetCore.Mvc;

namespace BetterSession.AspNetCore.Tests
{
    public class TempDataExtensionsTests
    {
        [Fact]
        public void Set_TisString_SavesWithoutError()
        {
            ITempDataDictionary session = new FakeTempData();
            session.Set<string>("t", "TEST");
            Assert.True(true);
        }

        [Fact]
        public void Set_TisInt_SavesWithoutError()
        {
            ITempDataDictionary session = new FakeTempData();
            session.Set("t", 1);
            Assert.True(true);
        }

        [Fact]
        public void Set_TisComplex_SavesWithoutError()
        {
            ITempDataDictionary session = new FakeTempData();
            var model = new TestModel();
            session.Set("t", model);
            Assert.True(true);
        }

        [Fact]
        public void Set_TisString_Persists()
        {
            var fake = new FakeTempData();
            ITempDataDictionary tempData = fake as ITempDataDictionary;
            tempData.Set("t", "TEXT");
            Assert.True(fake.cache.ContainsKey("t"));
        }

        [Fact]
        public void Set_TisInt_Persists()
        {
            var fake = new FakeTempData();
            ITempDataDictionary tempData = fake as ITempDataDictionary;
            tempData.Set("t", 1);
            Assert.True(fake.cache.ContainsKey("t"));
        }

        [Fact]
        public void Set_TisComplex_Persists()
        {
            var fake = new FakeTempData();
            ITempDataDictionary tempData = fake as ITempDataDictionary;
            var model = new TestModel();
            tempData.Set("t", model);
            Assert.True(fake.cache.ContainsKey("t"));
        }

        [Fact]
        public void Get_TisString_Persists()
        {
            var fake = new FakeTempData();
            ITempDataDictionary tempData = fake as ITempDataDictionary;
            tempData.Set("t", "TEXT");
            var result = tempData.Get<string>("t");
            Assert.Equal("TEXT", result);
        }

        [Fact]
        public void Get_TisInt_Persists()
        {
            var fake = new FakeTempData();
            ITempDataDictionary tempData = fake as ITempDataDictionary;
            tempData.Set("t", 1);
            Assert.Equal(1, tempData.Get<int>("t"));
        }

        [Fact]
        public void Get_TisComplex_Persists()
        {
            var fake = new FakeTempData();
            ITempDataDictionary tempData = fake as ITempDataDictionary;
            var model = new TestModel()
            {
                Nr = 1,
                Name = "D"
            };
            tempData.Set("t", model);
            var value = tempData.Get<TestModel>("t");
            Assert.NotNull(value);
            Assert.Equal(1, value.Nr);
            Assert.Equal("D", value.Name);
        }
    }    
}
