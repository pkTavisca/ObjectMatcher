using ObjectMatcher;
using System.Collections.Generic;
using Xunit;

namespace ObjectMatcherTester
{
    public class ListFixture
    {
        [Fact]
        public void Check_if_objects_with_equal_list_are_equal()
        {
            List<int> o1 = new List<int>() { 1, 2, 3, 4 };
            List<int> o2 = new List<int>() { 1, 2, 3, 4 };
            IMatcher matcher = new Matcher();
            Assert.True(matcher.AreEqual(o1, o2));
        }

        [Fact]
        public void Check_if_objects_with_equal_unordered_list_are_equal()
        {
            List<int> o1 = new List<int>() { 1, 2, 3, 4 };
            List<int> o2 = new List<int>() { 1, 2, 4, 3 };
            IMatcher matcher = new Matcher();
            Assert.True(matcher.AreEqual(o1, o2));
        }

        [Fact]
        public void Check_if_objects_with_different_list_are_equal()
        {
            List<int> o1 = new List<int>() { 1, 2, 3 };
            List<int> o2 = new List<int>() { 1, 2, 3, 4 };
            IMatcher matcher = new Matcher();
            Assert.False(matcher.AreEqual(o1, o2));
        }
    }
}
