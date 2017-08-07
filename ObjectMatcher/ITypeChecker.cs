using System;

namespace ObjectMatcher
{
    public interface IMatcher
    {
        bool AreEqual(Object o1, Object o2);
    }
}