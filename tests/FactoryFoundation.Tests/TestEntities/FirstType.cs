// <copyright file="FirstType.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace FactoryFoundation.Tests.TestEntities
{
    /// <summary>
    /// Test object for translation.
    /// </summary>
    internal sealed class FirstType
    {
        /// <summary>
        /// Gets the airplane identifier.
        /// </summary>
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
