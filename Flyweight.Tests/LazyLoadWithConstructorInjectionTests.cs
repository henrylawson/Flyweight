using Flyweight.Tests.Data;
using Flyweight.Tests.Fixtures;
using NUnit.Framework;
using StructureMap;

namespace Flyweight.Tests
{
    [TestFixture]
    public class LazyLoadWithConstructorInjectionTests : LazyLoadFixture
    {
        [Test]
        public void SystemWithConstructorInjection_ShouldNotCreateInstance_WhenInstantiated()
        {
            ObjectFactory.GetInstance<ISystemWithConstructorInjection>();

            Assert.That(InstanceCounter.Count, Is.EqualTo(0));
        }

        [Test]
        public void SystemWithConstructorInjection_ShouldCreateASingleInstance_WhenUsedOnce()
        {
            var system = ObjectFactory.GetInstance<ISystemWithConstructorInjection>();

            system.UseInjectedField();

            Assert.That(InstanceCounter.Count, Is.EqualTo(1));
        }

        [Test]
        public void SystemWithConstructorInjection_ShouldCreateASingleInstance_WhenUsedMultipleTimes()
        {
            var system = ObjectFactory.GetInstance<ISystemWithConstructorInjection>();

            system.UseInjectedField();
            system.UseInjectedField();

            Assert.That(InstanceCounter.Count, Is.EqualTo(1));
        }
    }
}
