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
            IList listX = x as IList;
            IList listY = y as IList;

            if (listX.Count != listY.Count) return false;

            IMatcher matcher = new Matcher();

            for (int i = 0; i < listX.Count; i++)
            {
                var elementOfX = listX[i];
                for (int j = 0; j < listY.Count; j++)
                {
                    var elementOfY = listY[j];
                    if (matcher.AreEqual(elementOfX, elementOfY))
                    {
                        listX.RemoveAt(i--);
                        listY.RemoveAt(j--);
                        break;
                    }
                }
            }
            if (listX.Count > 0) return false;
            return true;
        }
    }
}
