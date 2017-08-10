using System;
using System.Reflection;

namespace ObjectMatcher
{
    public class ValueTypeMatcher : IMatcher
    {
        public bool AreEqual(object o1, object o2)
        {
            if (IsStruct(o1) && IsStruct(o2))
            {
                IMatcher refMatcher = new ReferenceTypeMatcher();
                return refMatcher.AreEqual(o1, o2);
            }
            return o1 == o2;
        }

        public bool IsStruct(Object obj)
        {
            var typeInfo = obj.GetType().GetTypeInfo();
            return typeInfo.IsValueType && !typeInfo.IsPrimitive && !typeInfo.IsEnum;
        }
    }
}