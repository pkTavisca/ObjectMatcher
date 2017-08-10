using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ObjectMatcher
{
    public class ListMatcher : IMatcher
    {
        public bool AreEqual(object x, object y)
        {
            var fields = GetFieldsOf(x);

            int sizeOfX = GetSizeOf(x);
            int sizeOfY = GetSizeOf(y);
            if (sizeOfX != sizeOfY) return false;

            IMatcher matcher = new Matcher();

            for (int i = 0; i < ((IList)x).Count; i++)
            {
                var elementOfX = ((IList)x)[i];
                for (int j = 0; j < ((IList)y).Count; j++)
                {
                    var elementOfY = ((IList)y)[j];
                    if (matcher.AreEqual(elementOfX, elementOfY))
                    {
                        ((IList)x).RemoveAt(i--);
                        ((IList)y).RemoveAt(j--);
                        break;
                    }
                }
            }
            if (((IList)x).Count > 0) return false;
            return true;
        }

        private int GetSizeOf(object x)
        {
            var fields = GetFieldsOf(x);
            return (int)fields[1].GetValue(x);
        }

        private FieldInfo[] GetFieldsOf(object obj)
        {
            return obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        }
    }
}
