// <copyright file="TestFactory.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace FactoryFoundation.Tests.TestEntities
{
    /// <summary>
    /// Test factory.
    /// </summary>
    internal class TestFactory :
        ICanTranslate<Airplane, AirplaneResponse>
    {
        /// <inheritdoc/>
        public AirplaneResponse TranslateTo(Airplane initial)
        {
            return new AirplaneResponse(initial.Id.ToString());
        }
    }
}
