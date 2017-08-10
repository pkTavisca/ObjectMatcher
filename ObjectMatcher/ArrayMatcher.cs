using System;

namespace ObjectMatcher
{
    public class ArrayMatcher : IMatcher
    {
        public bool AreEqual(object o1, object o2)
        {
            if (GetLength(o1) != GetLength(o2)) return false;
            IMatcher matcher = new Matcher();
            for (int i = 0; i < GetLength(o1); i++)
            {
                if (matcher.AreEqual(((Array)o1).GetValue(i), ((Array)o2).GetValue(i)) == false)
                    return false;
            }
            return true;
        }

        private int GetLength(object obj)
        {
            return (obj as Array).Length;
        }
    }
}