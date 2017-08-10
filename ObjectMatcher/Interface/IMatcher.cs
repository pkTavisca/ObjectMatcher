using System;

namespace ObjectMatcher
{
    public interface IMatcher
    {
        bool AreEqual(Object x, Object y);
    }
}