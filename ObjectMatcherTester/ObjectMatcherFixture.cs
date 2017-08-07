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

        [Fact]
        public void Testing_if_int_value_types_are_equal()
        {
            IMatcher matcher = new Matcher();
            Assert.True(matcher.AreEqual(5, 5));
            Assert.False(matcher.AreEqual(5, 6));
        }

        enum Number
        {
            One,
            Two
        };

        [Fact]
        public void Testing_if_enum_value_types_are_equal()
        {
            IMatcher matcher = new Matcher();
            Assert.True(matcher.AreEqual(Number.One, Number.One));
            Assert.True(matcher.AreEqual(Number.Two, Number.Two));
            Assert.False(matcher.AreEqual(Number.One, Number.Two));
        }

        struct EmptyStructure1 { }
        struct EmptyStructure2 { }
        [Fact]
        public void Testing_if_two_empty_structures_are_equal()
        {
            IMatcher matcher = new Matcher();
            Assert.True(matcher.AreEqual(new EmptyStructure1(), new EmptyStructure1()));
            Assert.True(matcher.AreEqual(new EmptyStructure2(), new EmptyStructure2()));
            Assert.False(matcher.AreEqual(new EmptyStructure1(), new EmptyStructure2()));
        }
    }
}
