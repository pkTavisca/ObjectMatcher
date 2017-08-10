using System;
using System.Collections.Generic;
using System.Reflection;

namespace ObjectMatcher
{
    internal class ReferenceTypeMatcher : IMatcher
    {
        public bool AreEqual(object o1, object o2)
        {
            if (o1.GetType().Equals(o2.GetType()) == false) return false;

            if (IsArray(o1))
            {
                IMatcher arrayMatcher = new ArrayMatcher();
                return arrayMatcher.AreEqual(o1, o2);
            }

            var fieldsObj = GetFieldsOf(o1);

            SortArrayIfList(o1, o2);
            InjectEqualityFunctionIfDictionary(o1, o2);

            IMatcher matcher = new Matcher();
            for (int i = 0; i < fieldsObj.Length; i++)
            {
                if (fieldsObj[i].GetValue(o1) == null && fieldsObj[i].GetValue(o2) == null)
                    continue;
                if (matcher.AreEqual(fieldsObj[i].GetValue(o1), fieldsObj[i].GetValue(o2)) == false)
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

        private void SortArrayIfList(params object[] objects)
        {
            foreach (var obj in objects)
            {
                if (IsList(obj) == true)
                {
                    var fields = GetFieldsOf(obj);
                    Array.Sort(fields[0].GetValue(obj) as Array,new Matcher());
                }
            }
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