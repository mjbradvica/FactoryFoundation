// <copyright file="FinalResponse.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace FactoryFoundation.Tests.TestEntities
{
    /// <summary>
    /// Test response object.
    /// </summary>
    internal sealed class FinalResponse
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public Guid Id { get; init; }

        /// <summary>
        /// Gets the age.
        /// </summary>
        public int Age { get; init; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; init; } = string.Empty;
    }
}
