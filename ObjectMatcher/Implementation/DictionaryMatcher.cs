using System;
using System.Collections;

namespace ObjectMatcher
{
    public class DictionaryMatcher : IMatcher
    {
        public bool AreEqual(object x, object y)
        {
            IDictionary dictX = (IDictionary)x;
            IDictionary dictY = (IDictionary)y;

            if (dictX.Count != dictY.Count) return false;

            IMatcher matcher = new Matcher();

            var matchedY = new bool[dictY.Count];

            foreach (var xKey in dictX.Keys)
            {
                var xValue = dictX[xKey];
                var found = false;
                int j = 0;
                foreach (var yKey in dictY.Keys)
                {
                    var yValue = dictY[yKey];
                    if (matchedY[j])
                    {
                        j++;
                        continue;
                    }
                    if (matcher.AreEqual(xKey, yKey))
                        if (matcher.AreEqual(xValue, yValue))
                        {
                            matchedY[j] = true;
                            found = true;
                            break;
                        }
                    j++;
                }
                if (found == false) return false;
            }

            return true;
        }
    }
}
