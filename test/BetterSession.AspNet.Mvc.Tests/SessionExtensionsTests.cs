using Microsoft.AspNet.Http.Features;
using Xunit;

namespace BetterSession.AspNet.Mvc.Tests
{
    public class SessionExtensionsTests
    {
        [Fact]
        public void Set_TisString_SavesWithoutError()
        {
            ISession session = new FakeSession();
            session.Set<string>("t", "TEST");
            Assert.True(true);
        }

        [Fact]
        public void Set_TisInt_SavesWithoutError()
        {
            ISession session = new FakeSession();
            session.Set("t", 1);
            Assert.True(true);
        }

        [Fact]
        public void Set_TisComplex_SavesWithoutError()
        {
            ISession session = new FakeSession();
            var model = new TestModel();
            session.Set("t", model);
            Assert.True(true);
        }

        [Fact]
        public void Set_TisString_Persists()
        {
            var fake = new FakeSession();
            ISession session = fake as ISession;
            session.Set("t", "TEXT");
            Assert.True(fake.cache.ContainsKey("t"));
        }

        [Fact]
        public void Set_TisInt_Persists()
        {
            var fake = new FakeSession();
            ISession session = fake as ISession;
            session.Set("t", 1);
            Assert.True(fake.cache.ContainsKey("t"));
        }

        [Fact]
        public void Set_TisComplex_Persists()
        {
            var fake = new FakeSession();
            ISession session = fake as ISession;
            var model = new TestModel();
            session.Set("t", model);
            Assert.True(fake.cache.ContainsKey("t"));
        }

        [Fact]
        public void Get_TisString_Persists()
        {
            var fake = new FakeSession();
            ISession session = fake as ISession;
            session.Set("t", "TEXT");
            Assert.Equal("TEXT", session.Get<string>("t"));
        }

        [Fact]
        public void Get_TisInt_Persists()
        {
            var fake = new FakeSession();
            ISession session = fake as ISession;
            session.Set("t", 1);
            Assert.Equal(1, session.Get<int>("t"));
        }

        [Fact]
        public void Get_TisComplex_Persists()
        {
            var fake = new FakeSession();
            ISession session = fake as ISession;
            var model = new TestModel()
            {
                Nr = 1,
                Name = "D"
            };
            session.Set("t", model);
            var value = session.Get<TestModel>("t");
            Assert.NotNull(value);
            Assert.Equal(1, value.Nr);
            Assert.Equal("D", value.Name);
        }
    }    
}
