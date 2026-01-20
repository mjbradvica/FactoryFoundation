// <copyright file="ValidationEnvelopeTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

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
        public void SuccessReturnsCorrectProperties()
        {
            const string result = "result";

            var envelope = new ValidationEnvelope<string>(result);

            Assert.AreEqual(result, envelope.Entity);
            Assert.IsFalse(envelope.IsInvalid);
            Assert.IsNull(envelope.Exception);
        }

        /// <summary>
        /// Ensures the failure method returns the correct properties.
        /// </summary>
        [TestMethod]
        public void FailureReturnsCorrectProperties()
        {
            var exception = new ArgumentNullException();

            var envelope = new ValidationEnvelope<string>(exception);

            Assert.AreEqual(exception, envelope.Exception);
            Assert.IsTrue(envelope.IsInvalid);
            Assert.IsNull(envelope.Entity);
        }
    }
}
