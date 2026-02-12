// <copyright file="TestFactory.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace FactoryFoundation.Tests.TestEntities
{
    /// <summary>
    /// Test factory.
    /// </summary>
    internal sealed class TestFactory :
        ICanTranslate<FirstType, FinalResponse>,
        ICanTranslate<FirstType, SecondType, FinalResponse>,
        ICanTranslate<FirstType, SecondType, ThirdType, FinalResponse>
    {
        /// <inheritdoc/>
        public FinalResponse TranslateTo(FirstType first)
        {
            return new FinalResponse
            {
                Id = first.Id,
            };
        }

        /// <inheritdoc/>
        public FinalResponse TranslateTo(FirstType first, SecondType second)
        {
            return new FinalResponse
            {
                Id = first.Id,
                Age = second.Age,
            };
        }

        /// <inheritdoc/>
        public FinalResponse TranslateTo(FirstType first, SecondType second, ThirdType third)
        {
            return new FinalResponse
            {
                Id = first.Id,
                Age = second.Age,
                Name = third.Name,
            };
        }
    }
}
