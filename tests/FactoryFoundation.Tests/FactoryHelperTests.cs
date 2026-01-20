// <copyright file="FactoryHelperTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace FactoryFoundation.Tests
{
    /// <summary>
    /// Tests for the <see cref="FactoryHelpers"/> class.
    /// </summary>
    [TestClass]
    public class FactoryHelperTests
    {
        /// <summary>
        /// Successful creation returns the newly created entity.
        /// </summary>
        [TestMethod]
        public void TryCreateValidateOnSuccessReturnsEntity()
        {
            const string result = "result";

            var envelope = FactoryHelpers.TryCreateValidate(() => result);

            Assert.AreEqual(result, envelope.Entity);
        }

        /// <summary>
        /// Exceptions are correctly handled in method.
        /// </summary>
        [TestMethod]
        public void TryCreateValidateOnExceptionCatchesCorrectly()
        {
            var envelope = FactoryHelpers.TryCreateValidate<string>(() => throw new ArgumentNullException());

            Assert.IsInstanceOfType<ArgumentNullException>(envelope.Exception);
        }
    }
}
