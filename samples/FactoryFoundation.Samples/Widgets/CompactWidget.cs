// <copyright file="CompactWidget.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.ComponentModel.DataAnnotations;

namespace FactoryFoundation.Samples.Widgets
{
    /// <summary>
    /// Compacted widget response.
    /// </summary>
    public class CompactWidget
    {
        /// <summary>
        /// Gets the widget summary.
        /// </summary>
        [Required]
        public string Summary { get; init; } = string.Empty;
    }
}
