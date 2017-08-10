using ObjectMatcher;
using ObjectMatcherTester.Objects;
using System.Collections.Generic;
using Xunit;

namespace ObjectMatcherTester
{
    public class DictionaryFixture
    {
        [Fact]
        public void Checking_if_same_dictionaries_are_equal()
        {
            Dictionary<int, int> dict1 = GenerateDictionary();
            Dictionary<int, int> dict2 = GenerateDictionary();
            IMatcher matcher = new Matcher();
            Assert.True(matcher.AreEqual(dict1, dict2));
        }

        [Fact]
        public void Checking_if_different_dictionaries_are_equal()
        {
            Dictionary<int, int> dict1 = GenerateDictionary();
            Dictionary<int, int> dict2 = GenerateDictionary();
            dict2[3] = 3;
            IMatcher matcher = new Matcher();
            Assert.False(matcher.AreEqual(dict1, dict2));
        }

        [Fact]
        public void Checking_if_diff_dictionaries_with_diff_values_are_equal()
        {
            Dictionary<int, int> dict1 = GenerateDictionary();
            Dictionary<int, int> dict2 = GenerateDictionary();
            dict2[2] = 3;
            IMatcher matcher = new Matcher();
            Assert.False(matcher.AreEqual(dict1, dict2));
        }

        [Fact]
        public void Checking_if_same_dictionaries_with_ref_types_values_are_equal()
        {
            Dictionary<int, ObjectWithObjectProp> dict1 = new Dictionary<int, ObjectWithObjectProp>()
            {
                { 1, new ObjectWithObjectProp(new ObjectWithValueTypeProps(1,1)) },
                { 2, new ObjectWithObjectProp(new ObjectWithValueTypeProps(1,1)) }
            };
            var dict2 = new Dictionary<int, ObjectWithObjectProp>(dict1);
            IMatcher matcher = new Matcher();
            Assert.True(matcher.AreEqual(dict1, dict2));
        }

        [Fact]
        public void Checking_if_same_dictionaries_with_ref_types_keys_are_equal()
        {
            Dictionary<ObjectWithObjectProp, int> dict1 = new Dictionary<ObjectWithObjectProp, int>()
            {
                { new ObjectWithObjectProp(new ObjectWithValueTypeProps(1,1)),1 },
                { new ObjectWithObjectProp(new ObjectWithValueTypeProps(1,1)),2 }
            };

            Dictionary<ObjectWithObjectProp, int> dict2 = new Dictionary<ObjectWithObjectProp, int>()
            {
                { new ObjectWithObjectProp(new ObjectWithValueTypeProps(1,1)),1 },
                { new ObjectWithObjectProp(new ObjectWithValueTypeProps(1,1)),2 }
            };
            IMatcher matcher = new Matcher();
            Assert.True(matcher.AreEqual(dict1, dict2));
        }

        [Fact]
        public void Checking_if_diff_dictionaries_with_ref_types_keys_are_equal()
        {
            Dictionary<ObjectWithObjectProp, int> dict1 = new Dictionary<ObjectWithObjectProp, int>()
            {
                { new ObjectWithObjectProp(new ObjectWithValueTypeProps(1,1)),1 },
                { new ObjectWithObjectProp(new ObjectWithValueTypeProps(1,1)),2 }
            };

            Dictionary<ObjectWithObjectProp, int> dict2 = new Dictionary<ObjectWithObjectProp, int>()
            {
                { new ObjectWithObjectProp(new ObjectWithValueTypeProps(1,1)),1 },
                { new ObjectWithObjectProp(new ObjectWithValueTypeProps(1,2)),2 }
            };

            IMatcher matcher = new Matcher();
            Assert.False(matcher.AreEqual(dict1, dict2));
        }


        private Dictionary<int, int> GenerateDictionary()
        {
            return new Dictionary<int, int>()
            {
                { 1,1 },
                { 2,2 }
            };
        }

    }
}
