using Flyweight.Tests.Data;
using Flyweight.Tests.Fixtures;
using NUnit.Framework;
using StructureMap;

namespace Flyweight.Tests
{
    [TestFixture]
    public class LazyLoadWithSetterInjectionTests : LazyLoadFixture
    {
        [Test]
        public void SystemWithSetterInjection_ShouldNotCreateInstance_WhenInstantiated()
        {
            ObjectFactory.GetInstance<ISystemWithSetterInjection>();

            Assert.That(InstanceCounter.Count, Is.EqualTo(0));
        }

        [Test]
        public void SystemWithSetterInjection_ShouldCreateASingleInstance_WhenUsedOnce()
        {
            var system = ObjectFactory.GetInstance<ISystemWithSetterInjection>();

            system.UseInjectedField();

            Assert.That(InstanceCounter.Count, Is.EqualTo(1));
        }

        [Test]
        public void SystemWithSetterInjection_ShouldCreateASingleInstance_WhenUsedMultipleTimes()
        {
            var system = ObjectFactory.GetInstance<ISystemWithSetterInjection>();

            system.UseInjectedField();
            system.UseInjectedField();

            Assert.That(InstanceCounter.Count, Is.EqualTo(1));
        }
    }
}
