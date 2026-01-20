// <copyright file="Widget.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace FactoryFoundation.Samples.Widgets
{
    /// <summary>
    /// Sample widget.
    /// </summary>
    public class Widget
    {
        /// <summary>
        /// Gets the widget name.
        /// </summary>
        public string Name { get; } = "Mr. Sprocket Co";

        /// <summary>
        /// Gets the widget identifier.
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// Gets the widget cost.
        /// </summary>
        public decimal Cost { get; } = 9.99m;
    }
}
