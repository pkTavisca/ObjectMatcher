using System;
using System.Reflection;

namespace ObjectMatcher
{
    public class ValueTypeMatcher : IMatcher
    {
        public bool AreEqual(object x, object y)
        {
            if (IsStruct(x) && IsStruct(y))
            {
                IMatcher refMatcher = new ReferenceTypeMatcher();
                return refMatcher.AreEqual(x, y);
            }
            return x == y;
        }

        public bool IsStruct(Object obj)
        {
            var typeInfo = obj.GetType().GetTypeInfo();
            return typeInfo.IsValueType && !typeInfo.IsPrimitive && !typeInfo.IsEnum;
        }
    }
}