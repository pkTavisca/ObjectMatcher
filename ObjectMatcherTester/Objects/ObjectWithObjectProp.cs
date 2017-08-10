using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectMatcherTester.Objects
{
    public class ObjectWithObjectProp
    {
        ObjectWithValueTypeProps ValueObject { get; set; }

        public ObjectWithObjectProp(ObjectWithValueTypeProps ValueObject)
        {
            this.ValueObject = ValueObject;
        }
    }
}
