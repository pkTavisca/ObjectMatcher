using ObjectMatcher;
using ObjectMatcherTester.Objects;
using Xunit;

namespace ObjectMatcherTester
{
    public class ReferenceTypeFixture
    {
        [Fact]
        public void Testing_if_two_objects_with_only_value_type_fields_are_equal()
        {
            ObjectWithValueTypeProps o1 = new ObjectWithValueTypeProps(5, 2);
            ObjectWithValueTypeProps o2 = new ObjectWithValueTypeProps(5, 2);
            IMatcher matcher = new Matcher();
            Assert.True(matcher.AreEqual(o1, o2));
        }

        [Fact]
        public void Testing_if_two_objects_with_only_value_type_fields_with_diff_values_are_equal()
        {
            ObjectWithValueTypeProps o1 = new ObjectWithValueTypeProps(5, 2);
            ObjectWithValueTypeProps o2 = new ObjectWithValueTypeProps(5, 3);
            IMatcher matcher = new Matcher();
            Assert.False(matcher.AreEqual(o1, o2));
        }

        [Fact]
        public void Testing_if_two_objects_with_ref_type_fields_with_same_values_are_equal()
        {
            ObjectWithObjectProp o1 = new ObjectWithObjectProp(new ObjectWithValueTypeProps(1, 1));
            ObjectWithObjectProp o2 = new ObjectWithObjectProp(new ObjectWithValueTypeProps(1, 1));
            IMatcher matcher = new Matcher();
            Assert.True(matcher.AreEqual(o1, o2));
        }

        [Fact]
        public void Testing_if_two_objects_with_ref_type_fields_with_diff_values_are_equal()
        {
            ObjectWithObjectProp o1 = new ObjectWithObjectProp(new ObjectWithValueTypeProps(1, 1));
            ObjectWithObjectProp o2 = new ObjectWithObjectProp(new ObjectWithValueTypeProps(2, 1));
            IMatcher matcher = new Matcher();
            Assert.False(matcher.AreEqual(o1, o2));
        }
    }
}
