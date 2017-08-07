using ObjectMatcher;
using System;
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

        [Fact]
        public void Testing_if_same_object_is_equal()
        {
            Matcher matcher = new Matcher();
            Object o1 = new Object();
            Assert.True(matcher.AreEqual(o1, o1));
        }

        [Fact]
        public void Testing_if_basic_value_types_are_equal()
        {
            Matcher matcher = new Matcher();
            Assert.True(matcher.AreEqual(5, 5));
            Assert.False(matcher.AreEqual(5, 6));
        }
    }
}
