using System;

namespace ObjectMatcher
{
    internal class ReferenceTypeMatcher : IMatcher
    {
        public bool AreEqual(object o1, object o2)
        {
            if (o1.GetType().Equals(o2.GetType()) == false) return false;
            return true;
        }
    }
}