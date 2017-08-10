using System;
using System.Reflection;

namespace ObjectMatcher
{
    internal class ReferenceTypeMatcher : IMatcher
    {
        public bool AreEqual(object o1, object o2)
        {
            if (o1.GetType().Equals(o2.GetType()) == false) return false;

            var fieldsObj1 = GetPropertiesOf(o1);
            var fieldsObj2 = GetPropertiesOf(o2);

            IMatcher matcher = new Matcher();
            for (int i = 0; i < fieldsObj1.Length; i++)
            {
                if (matcher.AreEqual(fieldsObj1[i].GetValue(o1), fieldsObj2[i].GetValue(o2)) == false)
                    return false;
            }

            return true;
        }

        private static FieldInfo[] GetPropertiesOf(object obj)
        {
            return obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        }
    }
}