using System;
using Flyweight.Tests.Data;
using NUnit.Framework;
using StructureMap;

namespace Flyweight.Tests.Fixtures
{
    [TestFixture]
    public class LazyLoadFixture
    {
        [SetUp]
        public void FixtureSetUp()
        {
            ObjectFactory.Initialize(expression =>
                {
                    expression.For(typeof (Lazy<>)).Use(typeof (Lazy<>)).CtorDependency<bool>("isThreadSafe").Is(true);
                    expression.Scan(assemblyScanner =>
                        {
                            assemblyScanner.TheCallingAssembly();
                            assemblyScanner.WithDefaultConventions();
                        });
                });
            InstanceCounter.Reset();
        }
    }
}