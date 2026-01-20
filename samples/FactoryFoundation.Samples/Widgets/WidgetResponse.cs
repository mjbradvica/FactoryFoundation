// <copyright file="WidgetResponse.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace FactoryFoundation.Samples.Widgets
{
    /// <summary>
    /// Samples widget response.
    /// </summary>
    public class WidgetResponse
    {
        /// <summary>
        /// Gets the widget name.
        /// </summary>
        [Required]
        public string Name { get; init; } = string.Empty;

        /// <summary>
        /// Gets the widget identifier.
        /// </summary>
        [Required]
        public Guid Id { get; init; }

        /// <summary>
        /// Gets the widget cost.
        /// </summary>
        [Required]
        public decimal Cost { get; init; }
    }
}
