// <copyright file="ServiceProviderExtensionsTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Reflection;
using FactoryFoundation.Tests.TestEntities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void AddFactoryFoundation_NoAssemblies_ThrowsExceptions()
        {
            var collection = new ServiceCollection();

            Assert.ThrowsException<ArgumentNullException>(() => collection.AddFactoryFoundation());
        }

        /// <summary>
        /// Assembly with no factory types throws exception.
        /// </summary>
        [TestMethod]
        public void AddFactoryFoundation_NoFactoryTypes_ThrowsException()
        {
            var assembly = Assembly.Load("FactoryFoundation");

            var collection = new ServiceCollection();

            Assert.ThrowsException<NullReferenceException>(() => collection.AddFactoryFoundation(assembly));
        }

        /// <summary>
        /// Valid types are registered correctly.
        /// </summary>
        [TestMethod]
        public void AddFactoryFoundation_ValidTypes_RegistersCorrectly()
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
        public void MixedFactories_CanBeResolved()
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
