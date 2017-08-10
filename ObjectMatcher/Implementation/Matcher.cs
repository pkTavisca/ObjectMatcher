using System;
using System.Collections;

namespace ObjectMatcher
{
    public class Matcher : IMatcher
    {
        public bool AreEqual(Object x, Object y)
        {
            if (x == null || y == null) return false;
            if (x.Equals(y)) return true;

            if (IsValueType(x) && IsValueType(y))
            {
                IMatcher valueTypeMatcher = new ValueTypeMatcher();
                return valueTypeMatcher.AreEqual(x, y);
            }
            if (IsValueType(x) == false && IsValueType(y) == false)
            {
                IMatcher refTypeMatcher = new ReferenceTypeMatcher();
                return refTypeMatcher.AreEqual(x, y);
            }

            return false;
        }

        private bool IsValueType(Object obj)
        {
            return obj is ValueType;
        }
    }
}
