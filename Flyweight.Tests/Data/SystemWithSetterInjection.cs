using System;
using StructureMap.Attributes;

namespace Flyweight.Tests.Data
{
    public class SystemWithSetterInjection : ISystemWithSetterInjection
    {
        private Lazy<IInstanceCounter> testClass;

        [SetterProperty]
        public Lazy<IInstanceCounter> TestClass { set { testClass = value; }}

        public IInstanceCounter UseInjectedField()
        {
            return testClass.Value;
        }
    }
}