using System;

namespace ObjectMatcher
{
    public class ValueTypeMatcher : IMatcher
    {
        public bool AreEqual(object o1, object o2)
        {
            return o1 == o2;
        }
    }
}