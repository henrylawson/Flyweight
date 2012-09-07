using System;

namespace Flyweight.Tests.Data
{
    public class SystemWithConstructorInjection : ISystemWithConstructorInjection
    {
        private readonly Lazy<IInstanceCounter> testClass;

        public SystemWithConstructorInjection(Lazy<IInstanceCounter> testClass)
        {
            this.testClass = testClass;
        }

        public IInstanceCounter UseInjectedField()
        {
            return testClass.Value;
        }
    }
}