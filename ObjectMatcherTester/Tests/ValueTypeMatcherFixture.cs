using Xunit;
using ObjectMatcher;

namespace ObjectMatcherTester
{
    public class ValueTypeMatcherFixture
    {
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

        struct ValueTypeOnlyStructure1
        {
            public ValueTypeOnlyStructure1(int a)
            {
                this.a = a;
            }
            int a;
        }
        struct ValueTypeOnlyStructure2
        {
            public ValueTypeOnlyStructure2(int a)
            {
                this.a = a;
            }
            int a;
        }

        [Fact]
        public void Testing_if_two_value_type_only_structures_with_same_values_are_equal()
        {
            IMatcher matcher = new Matcher();
            Assert.True(matcher.AreEqual(new ValueTypeOnlyStructure1(5), new ValueTypeOnlyStructure1(5)));
            Assert.False(matcher.AreEqual(new ValueTypeOnlyStructure1(5), new ValueTypeOnlyStructure2(5)));
        }

        [Fact]
        public void Testing_if_two_value_type_only_structures_with_different_values()
        {
            IMatcher matcher = new Matcher();
            Assert.False(matcher.AreEqual(new ValueTypeOnlyStructure1(5), new ValueTypeOnlyStructure1(6)));
            Assert.False(matcher.AreEqual(new ValueTypeOnlyStructure1(5), new ValueTypeOnlyStructure2(6)));
        }

        struct RefTypeOnlyStructure1
        {
            public RefTypeOnlyStructure1(object a)
            {
                this.a = a;
            }
            object a;
        }
        struct RefTypeOnlyStructure2
        {
            public RefTypeOnlyStructure2(object a)
            {
                this.a = a;
            }
            object a;
        }

        [Fact]
        public void Testing_if_two_ref_type_structures_with_same_object_are_equal()
        {
            object a = new object();
            RefTypeOnlyStructure1 ref1 = new RefTypeOnlyStructure1(a);
            RefTypeOnlyStructure2 ref2 = new RefTypeOnlyStructure2(a);
            IMatcher matcher = new Matcher();
            Assert.False(matcher.AreEqual(ref1, ref2));
        }

        [Fact]
        public void Testing_if_same_ref_type_structures_are_equal()
        {
            RefTypeOnlyStructure1 ref1 = new RefTypeOnlyStructure1(new object());
            IMatcher matcher = new Matcher();
            Assert.True(matcher.AreEqual(ref1, ref1));
        }
    }
}
