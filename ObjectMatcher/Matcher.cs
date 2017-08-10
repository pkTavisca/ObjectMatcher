using System;
using System.Collections.Generic;

namespace ObjectMatcher
{
    public class Matcher : IMatcher
    {
        public bool AreEqual(Object o1, Object o2)
        {
            if (o1 == null || o2 == null) return false;
            if (o1.Equals(o2)) return true;

            if (IsValueType(o1) && IsValueType(o2))
            {
                ValueTypeMatcher valueTypeMatcher = new ValueTypeMatcher();
                valueTypeMatcher.AreEqual(o1, o2);
            }
            if (IsValueType(o1) == false && IsValueType(o2) == false)
            {
                ReferenceTypeMatcher refTypeMatcher = new ReferenceTypeMatcher();
                return refTypeMatcher.AreEqual(o1, o2);
            }

            return false;
        }

        private bool IsValueType(Object obj)
        {
            return obj is ValueType;
        }
    }
}
