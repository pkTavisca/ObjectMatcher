using System;

namespace ObjectMatcher
{
    public class ArrayMatcher : IMatcher
    {
        public bool AreEqual(object x, object y)
        {
            if (GetLength(x) != GetLength(y)) return false;
            IMatcher matcher = new Matcher();
            for (int i = 0; i < GetLength(x); i++)
            {
                if (matcher.AreEqual(((Array)x).GetValue(i), ((Array)y).GetValue(i)) == false)
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