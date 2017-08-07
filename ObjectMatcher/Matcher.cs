using System;
using System.Collections.Generic;

namespace ObjectMatcher
{
    public class Matcher : ITypeChecker
    {
        private readonly Dictionary<Type, ITypeChecker> _typeToCheckerMap = new Dictionary<Type, ITypeChecker>()
        {

        };

        public bool AreEqual(Object o1, Object o2)
        {
            if (o1 == null || o2 == null) return false;
            if (o1.Equals(o2)) return true;
            
            return false;
        }
    }
}
