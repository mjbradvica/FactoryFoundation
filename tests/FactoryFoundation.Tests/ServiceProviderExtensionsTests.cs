// <copyright file="ServiceProviderExtensionsTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using FactoryFoundation.Tests.TestEntities;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FactoryFoundation.Tests
{
    /// <summary>
    /// Tests for the <see cref="ServiceProviderExtensions"/> class.
    /// </summary>
    [TestClass]
    public class ServiceProviderExtensionsTests
    {
        /// <summary>
        /// Exception is throw with no assemblies.
        /// </summary>
        [TestMethod]
        public void AddFactoryFoundationNoAssembliesThrowsExceptions()
        {
            var collection = new ServiceCollection();

            Assert.ThrowsExactly<ArgumentNullException>(() => collection.AddFactoryFoundation());
        }

        /// <summary>
        /// Assembly with no factory types throws exception.
        /// </summary>
        [TestMethod]
        public void AddFactoryFoundationNoFactoryTypesThrowsException()
        {
            var assembly = Assembly.Load("FactoryFoundation");

            var collection = new ServiceCollection();

            Assert.ThrowsExactly<ArgumentNullException>(() => collection.AddFactoryFoundation(assembly));
        }

        /// <summary>
        /// Valid types are registered correctly.
        /// </summary>
        [TestMethod]
        public void AddFactoryFoundationValidTypesRegistersCorrectly()
        {
            var collection = new ServiceCollection();

            collection.AddFactoryFoundation(Assembly.GetExecutingAssembly());

            var provider = collection.BuildServiceProvider();

            var translator = provider.GetService<ICanTranslate<Airplane, AirplaneResponse>>();

            Assert.IsNotNull(translator);
        }

        /// <summary>
        /// Mixed factories can be resolved.
        /// </summary>
        [TestMethod]
        public void MixedFactoriesCanBeResolved()
        {
            var collection = new ServiceCollection();

            collection.AddFactoryFoundation(Assembly.GetExecutingAssembly());

            var provider = collection.BuildServiceProvider();

            var translator = provider.GetRequiredService<ITranslator>();

            var response = translator.Translate<IEnumerable<int>, IEnumerable<int>>(new List<int>());

            Assert.IsNotNull(response);
        }
    }
}
