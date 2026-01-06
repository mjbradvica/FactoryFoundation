// <copyright file="TranslatorTests.cs" company="Simplex Software LLC">
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
    /// Tests for the <see cref="Translator"/> class.
    /// </summary>
    [TestClass]
    public class TranslatorTests
    {
        private readonly ITranslator _translator;

        /// <summary>
        /// Initializes a new instance of the <see cref="TranslatorTests"/> class.
        /// </summary>
        public TranslatorTests()
        {
            var collection = new ServiceCollection();
            collection.AddFactoryFoundation(Assembly.GetExecutingAssembly());
            _translator = collection.BuildServiceProvider().GetRequiredService<ITranslator>();
        }

        /// <summary>
        /// Ensures translations are correct.
        /// </summary>
        [TestMethod]
        public void Translations_Are_Correct()
        {
            var airplane = new Airplane();

            var result = _translator.Translate<Airplane, AirplaneResponse>(airplane);

            Assert.IsNotNull(result);
            Assert.AreEqual(airplane.Id.ToString(), result.Id);
        }

        /// <summary>
        /// Non-registered translators throw exception.
        /// </summary>
        [TestMethod]
        public void Translations_NoRegistrations_ThrowsException()
        {
            Assert.ThrowsException<NullReferenceException>(() => _translator.Translate<IEnumerable<string>, IEnumerable<string>>(new List<string>()));
        }
    }
}
