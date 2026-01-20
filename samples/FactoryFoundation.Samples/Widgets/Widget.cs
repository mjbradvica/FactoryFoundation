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
        public string Name { get; init; } = "Mr. Sprocket Co";

        /// <summary>
        /// Gets the widget identifier.
        /// </summary>
        public Guid Id { get; init; } = Guid.NewGuid();

        /// <summary>
        /// Gets the widget cost.
        /// </summary>
        public decimal Cost { get; init; } = 9.99m;

        /// <summary>
        /// Creates an empty widget.
        /// </summary>
        /// <returns>An empty <see cref="Widget"/>.</returns>
        public static Widget Empty()
        {
            return new Widget
            {
                Id = Guid.Empty,
                Name = string.Empty,
                Cost = 0.00m,
            };
        }
    }
}
