// <copyright file="TranslatorTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using FactoryFoundation.Tests.TestEntities;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
        public void OneTranslationIsCorrect()
        {
            var first = new FirstType();

            var result = _translator.Translate<FirstType, FinalResponse>(first);

            Assert.IsNotNull(result);
            Assert.AreEqual(first.Id, result.Id);
        }

        /// <summary>
        /// Non-registered translators throw exception.
        /// </summary>
        [TestMethod]
        public void OneTranslationNoRegistrationsThrowsException()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() => _translator.Translate<string, string>(string.Empty));
        }

        /// <summary>
        /// Translation is correct.
        /// </summary>
        [TestMethod]
        public void TwoTranslationsAreCorrect()
        {
            var first = new FirstType();
            var second = new SecondType();

            var result = _translator.Translate<FirstType, SecondType, FinalResponse>(first, second);

            Assert.IsNotNull(result);
            Assert.AreEqual(first.Id, result.Id);
            Assert.AreEqual(second.Age, result.Age);
        }

        /// <summary>
        /// Non-registered translators throw exception.
        /// </summary>
        [TestMethod]
        public void TwoTranslationNoRegistrationsThrowsException()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() => _translator.Translate<string, string, string>(string.Empty, string.Empty));
        }

        /// <summary>
        /// Three translation is correct.
        /// </summary>
        [TestMethod]
        public void ThreeTranslationsAreCorrect()
        {
            var first = new FirstType();
            var second = new SecondType();
            var third = new ThirdType();

            var result = _translator.Translate<FirstType, SecondType, ThirdType, FinalResponse>(first, second, third);

            Assert.IsNotNull(result);
            Assert.AreEqual(first.Id, result.Id);
            Assert.AreEqual(second.Age, result.Age);
            Assert.AreEqual(third.Name, result.Name);
        }

        /// <summary>
        /// Non-registered translators throw exception.
        /// </summary>
        [TestMethod]
        public void ThreeTranslationNoRegistrationsThrowsException()
        {
            Assert.ThrowsExactly<ArgumentNullException>(() => _translator.Translate<string, string, string, string>(string.Empty, string.Empty, string.Empty));
        }
    }
}
