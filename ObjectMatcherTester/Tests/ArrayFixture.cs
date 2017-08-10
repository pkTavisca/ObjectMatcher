using ObjectMatcher;
using Xunit;

namespace ObjectMatcherTester
{
    public class ArrayFixture
    {
        [Fact]
        public void Check_if_same_arrays_are_equal()
        {
            int[] arr1 = new int[4] { 1, 2, 3, 4 };
            int[] arr2 = new int[4] { 1, 2, 3, 4 };
            IMatcher matcher = new Matcher();
            Assert.True(matcher.AreEqual(arr1, arr2));
        }

        [Fact]
        public void Check_if_different_arrays_are_equal()
        {
            int[] arr1 = new int[4] { 1, 2, 3, 1 };
            int[] arr2 = new int[4] { 1, 2, 3, 4 };
            IMatcher matcher = new Matcher();
            Assert.False(matcher.AreEqual(arr1, arr2));
        }

        [Fact]
        public void Check_if_different_arrays_with_different_length_are_equal()
        {
            int[] arr1 = new int[3] { 1, 2, 3 };
            int[] arr2 = new int[4] { 1, 2, 3, 4 };
            IMatcher matcher = new Matcher();
            Assert.False(matcher.AreEqual(arr1, arr2));
        }
    }
}
