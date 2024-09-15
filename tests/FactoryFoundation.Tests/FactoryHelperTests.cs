// <copyright file="FactoryHelperTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void TryCreateValidate_OnSuccess_ReturnsEntity()
        {
            const string result = "result";

            var envelope = FactoryHelpers.TryCreateValidate(() => result);

            Assert.AreEqual(result, envelope.Entity);
        }

        /// <summary>
        /// Exceptions are correctly handled in method.
        /// </summary>
        [TestMethod]
        public void TryCreateValidate_OnException_CatchesCorrectly()
        {
            var envelope = FactoryHelpers.TryCreateValidate<string>(() => throw new NullReferenceException());

            Assert.IsInstanceOfType<NullReferenceException>(envelope.Exception);
        }
    }
}
