using ObjectMatcher;
using ObjectMatcherTester.Objects;
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

        [Fact]
        public void Check_if_ref_type_same_lists_are_equal()
        {
            List<ObjectWithValueTypeProps> o1 = new List<ObjectWithValueTypeProps>() { new ObjectWithValueTypeProps(1, 1) };
            List<ObjectWithValueTypeProps> o2 = new List<ObjectWithValueTypeProps>() { new ObjectWithValueTypeProps(1, 1) };
            IMatcher matcher = new Matcher();
            Assert.True(matcher.AreEqual(o1, o2));
        }

        [Fact]
        public void Check_if_ref_type_different_lists_are_equal()
        {
            List<ObjectWithValueTypeProps> o1 = new List<ObjectWithValueTypeProps>() { new ObjectWithValueTypeProps(1, 1) };
            List<ObjectWithValueTypeProps> o2 = new List<ObjectWithValueTypeProps>() { new ObjectWithValueTypeProps(1, 2) };
            IMatcher matcher = new Matcher();
            Assert.False(matcher.AreEqual(o1, o2));
        }
    }
}
