// <copyright file="CreateWidgetRequest.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace FactoryFoundation.Samples.Widgets
{
    /// <summary>
    /// Sample request.
    /// </summary>
    public class CreateWidgetRequest
    {
        /// <summary>
        /// Gets sample request name.
        /// </summary>
        public string Name { get; } = "My new Widget";

        /// <summary>
        /// Gets sample request cost.
        /// </summary>
        public decimal Cost { get; } = 19.99m;
    }
}
