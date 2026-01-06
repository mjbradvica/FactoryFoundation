// <copyright file="MixedFactory.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace FactoryFoundation.Tests.TestEntities
{
    /// <summary>
    /// Factory with mixed interfaces.
    /// </summary>
    public class MixedFactory :
        IEmptyInterface,
        ICanTranslate<IEnumerable<int>, IEnumerable<int>>
    {
        /// <inheritdoc/>
        public IEnumerable<int> TranslateTo(IEnumerable<int> initial)
        {
            return initial;
        }
    }
}
