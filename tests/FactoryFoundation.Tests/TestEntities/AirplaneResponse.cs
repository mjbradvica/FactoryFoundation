// <copyright file="AirplaneResponse.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace FactoryFoundation.Tests.TestEntities
{
    /// <summary>
    /// Test response object.
    /// </summary>
    internal class AirplaneResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirplaneResponse"/> class.
        /// </summary>
        /// <param name="id">The airplane identifier.</param>
        public AirplaneResponse(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public string Id { get; }
    }
}
