using System;
using Flyweight.Tests.Data;
using Flyweight.Tests.Fixtures;
using NUnit.Framework;

namespace Flyweight.Tests
{
    [TestFixture]
    public class LazyLoadTests : LazyLoadFixture
    {
        [Test]
        public void IsCreated_ShouldEqualFalse_WhenJustInstantiated()
        {
            var lazy = new Lazy<InstanceCounter>(() => new InstanceCounter());

            Assert.That(lazy.IsValueCreated, Is.EqualTo(false));
        }

        [Test]
        public void IsCreated_ShouldEqualTrue_WhenInstanceHasBeenCalled()
        {
            var lazy = new Lazy<InstanceCounter>(() => new InstanceCounter());

            var instanceCounter = lazy.Value;

            Assert.That(lazy.IsValueCreated, Is.EqualTo(true));
        }

        [Test]
        public void Instance_ShouldReturnTheInstance_WhenItIsCalled()
        {
            var counter = new InstanceCounter();
            var lazy = new Lazy<InstanceCounter>(() => counter);

            var instanceCounter = lazy.Value;

            Assert.That(instanceCounter, Is.SameAs(counter));
        }

        [Test]
        public void Instance_ShouldNotInstantiateInstance_WhenNotCalled()
        {
            var lazy = new Lazy<InstanceCounter>(() => new InstanceCounter());

            Assert.That(InstanceCounter.Count, Is.EqualTo(0));
        }

        [Test]
        public void Instance_ShouldInstantiateASingleInstance_WhenCalledOnce()
        {
            var lazy = new Lazy<InstanceCounter>(() => new InstanceCounter());

            var instanceCounter = lazy.Value;

            Assert.That(InstanceCounter.Count, Is.EqualTo(1));
        }

        [Test]
        public void Instance_ShouldOnlyInstantiateASingleInstance_WhenCalledMultipleTimes()
        {
            var lazy = new Lazy<InstanceCounter>(() => new InstanceCounter());

            var instanceCounter = lazy.Value;
            var instanceCounter1 = lazy.Value;
            var instanceCounter2 = lazy.Value;

            Assert.That(InstanceCounter.Count, Is.EqualTo(1));
        }
    }
}
