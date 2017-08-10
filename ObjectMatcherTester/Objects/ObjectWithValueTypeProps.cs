namespace ObjectMatcherTester.Objects
{
    public class ObjectWithValueTypeProps
    {
        public int Property { get; set; }
        private int _a;

        public ObjectWithValueTypeProps(int Property, int a)
        {
            this.Property = Property;
            _a = a;
        }
    }
}
