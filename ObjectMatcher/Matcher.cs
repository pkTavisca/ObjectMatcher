using System;
using System.Collections;

namespace ObjectMatcher
{
    public class Matcher : IMatcher, IComparer
    {
        public bool AreEqual(Object o1, Object o2)
        {
            if (o1 == null || o2 == null) return false;
            if (o1.Equals(o2)) return true;

            if (IsValueType(o1) && IsValueType(o2))
            {
                IMatcher valueTypeMatcher = new ValueTypeMatcher();
                return valueTypeMatcher.AreEqual(o1, o2);
            }
            if (IsValueType(o1) == false && IsValueType(o2) == false)
            {
                IMatcher refTypeMatcher = new ReferenceTypeMatcher();
                return refTypeMatcher.AreEqual(o1, o2);
            }

            return false;
        }

        public int Compare(object x, object y)
        {
            throw new NotImplementedException();
        }

        private bool IsValueType(Object obj)
        {
            return obj is ValueType;
        }
    }
}
