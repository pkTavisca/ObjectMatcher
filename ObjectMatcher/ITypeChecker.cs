using System;

namespace ObjectMatcher
{
    public interface ITypeChecker
    {
        bool AreEqual(Object o1, Object o2);
    }
}