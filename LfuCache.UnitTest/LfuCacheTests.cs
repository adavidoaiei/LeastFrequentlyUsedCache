using NUnit.Framework;

namespace LfuCache.UnitTest
{
    [TestFixture]
    public class LfuCacheTests
    {
        private LfuCache<string, string> _lfuCache;

        [SetUp]
        public void BeforeEach()
        {
            _lfuCache = new LfuCache<string, string>(3);
        }

        [Test]
        public void AddRetrieveToLfuCache()
        {
            // Arrange
            _lfuCache.Add("1", "one");
            _lfuCache.Add("2", "two");
            _lfuCache.Add("3", "three");

            // Act
            var one = _lfuCache.Get("1");
            var two = _lfuCache.Get("2");
            var three = _lfuCache.Get("3");

            // Assert
            Assert.AreEqual("one", one);
            Assert.AreEqual("two", two);
            Assert.AreEqual("three", three);
        }

        [Test]
        public void AddRetrieveToLfuCacheSizeOne()
        {
            _lfuCache = new LfuCache<string, string>(1);

            // Arrange
            _lfuCache.Add("1", "one");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Add("2", "two");
            _lfuCache.Get("2");
            _lfuCache.Get("2");
            _lfuCache.Get("2");

            // Act
            var one = _lfuCache.Get("1");
            var two = _lfuCache.Get("2");

            // Assert
            Assert.IsNull(one);
            Assert.AreEqual("two", two);
        }

        [Test]
        public void AddRetrieveToLfuCacheWithEvicts()
        {
            // Arrange
            _lfuCache.Add("1", "one");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Add("2", "two");
            _lfuCache.Get("2");
            _lfuCache.Get("2");
            _lfuCache.Get("2");
            _lfuCache.Add("3", "three");
            _lfuCache.Get("3");
            _lfuCache.Get("3");
            _lfuCache.Get("3");
            _lfuCache.Get("3");
            _lfuCache.Add("4", "four");

            // Act
            var one = _lfuCache.Get("1");
            var two = _lfuCache.Get("2");
            var three = _lfuCache.Get("3");
            var four = _lfuCache.Get("4");

            // Assert
            Assert.AreEqual("one", one);
            Assert.IsNull(two);
            Assert.AreEqual("three", three);
            Assert.AreEqual("four", four);
        }

#if DEBUG
        [Test]
        public void AddRetrieveToLfuCacheWithEvictsTestingUsingEvents()
        {
            _lfuCache.EvictEvent += delegate(string value)
            {
                Assert.AreEqual("two", value);
            };

            _lfuCache.Add("1", "one");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Get("1");
            _lfuCache.Add("2", "two");
            _lfuCache.Get("2");
            _lfuCache.Get("2");
            _lfuCache.Get("2");
            _lfuCache.Add("3", "three");
            _lfuCache.Get("3");
            _lfuCache.Get("3");
            _lfuCache.Get("3");
            _lfuCache.Get("3");
            _lfuCache.Add("4", "four");
        }
#endif
    }
}
