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
            IMatcher matcher = new Matcher();
            Assert.False(matcher.AreEqual(null, null));
        }

        [Fact]
        public void Testing_if_same_object_is_equal()
        {
            IMatcher matcher = new Matcher();
            Object o1 = new Object();
            Assert.True(matcher.AreEqual(o1, o1));
        }
    }
}
