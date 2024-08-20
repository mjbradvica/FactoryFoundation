// <copyright file="Airplane.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;

namespace FactoryFoundation.Tests.TestEntities
{
    /// <summary>
    /// Test object for translation.
    /// </summary>
    internal class Airplane
    {
        /// <summary>
        /// Gets the airplane identifier.
        /// </summary>
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
