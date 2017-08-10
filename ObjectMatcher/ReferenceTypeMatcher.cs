using System;
using System.Collections.Generic;
using System.Reflection;

namespace ObjectMatcher
{
    internal class ReferenceTypeMatcher : IMatcher
    {
        public bool AreEqual(object x, object y)
        {
            if (x.GetType().Equals(y.GetType()) == false) return false;

            if (IsArray(x))
            {
                IMatcher arrayMatcher = new ArrayMatcher();
                return arrayMatcher.AreEqual(x, y);
            }

            var fieldsObj = GetFieldsOf(x);

            if (IsList(x))
            {
                IMatcher listMatcher = new ListMatcher();
                return listMatcher.AreEqual(x, y);
            }

            InjectEqualityFunctionIfDictionary(x, y);

            IMatcher matcher = new Matcher();
            for (int i = 0; i < fieldsObj.Length; i++)
            {
                if (fieldsObj[i].GetValue(x) == null && fieldsObj[i].GetValue(y) == null)
                    continue;
                if (matcher.AreEqual(fieldsObj[i].GetValue(x), fieldsObj[i].GetValue(y)) == false)
                    return false;
            }

            return true;
        }

        private void InjectEqualityFunctionIfDictionary(params object[] objects)
        {
            foreach (var obj in objects)
            {
                if (IsDictionary(obj))
                {
                    var fields = GetFieldsOf(obj);
                }
            }
        }

        private bool IsDictionary(object obj)
        {
            return obj.GetType().FullName.Contains("System.Collections.Generic.Dictionary");
        }

        private bool IsList(object obj)
        {
            return obj.GetType().FullName.Contains("System.Collections.Generic.List");
        }

        private bool IsArray(object obj)
        {
            return obj is Array;
        }

        private FieldInfo[] GetFieldsOf(object obj)
        {
            return obj.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        }
    }
}