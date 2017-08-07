using ObjectMatcher;
using Xunit;

namespace ObjectMatcherTester
{
    public class ObjectMatcherFixture
    {
        [Fact]
        public void Testing_if_two_null_values_are_equal()
        {
            Matcher matcher = new Matcher();
            Assert.False(matcher.AreEqual(null, null));
        }
    }
}
