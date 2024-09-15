// <copyright file="ValidationEnvelopeTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NullReferenceException = System.NullReferenceException;

namespace FactoryFoundation.Tests
{
    /// <summary>
    /// Tests for the <see cref="ValidationEnvelope{TEntity}"/> class.
    /// </summary>
    [TestClass]
    public class ValidationEnvelopeTests
    {
        /// <summary>
        /// Ensures the success method returns the correct properties.
        /// </summary>
        [TestMethod]
        public void Success_ReturnsCorrectProperties()
        {
            const string result = "result";

            var envelope = ValidationEnvelope<string>.Success(result);

            Assert.AreEqual(result, envelope.Entity);
            Assert.IsFalse(envelope.IsInvalid);
            Assert.IsInstanceOfType<Exception>(envelope.Exception);
        }

        /// <summary>
        /// Ensures the failure method returns the correct properties.
        /// </summary>
        [TestMethod]
        public void Failure_ReturnsCorrectProperties()
        {
            var exception = new NullReferenceException();

            var envelope = ValidationEnvelope<string>.Failure(exception);

            Assert.AreEqual(exception, envelope.Exception);
            Assert.IsTrue(envelope.IsInvalid);
            Assert.IsNull(envelope.Entity);
        }
    }
}
