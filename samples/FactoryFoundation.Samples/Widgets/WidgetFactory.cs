// <copyright file="WidgetFactory.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace FactoryFoundation.Samples.Widgets
{
    /// <summary>
    /// Defines a factory for <see cref="Widget"/> objects.
    /// </summary>
    public class WidgetFactory :
        ICanTranslate<Widget, WidgetResponse>,
        ICanTranslate<Widget, CompactWidget>
    {
        /// <inheritdoc/>
        WidgetResponse ICanTranslate<Widget, WidgetResponse>.TranslateTo(Widget initial)
        {
            return new WidgetResponse
            {
                Id = initial.Id,
                Name = initial.Name,
                Cost = initial.Cost,
            };
        }

        /// <inheritdoc/>
        CompactWidget ICanTranslate<Widget, CompactWidget>.TranslateTo(Widget initial)
        {
            return new CompactWidget
            {
                Summary = $"Widget is: {initial.Id} - {initial.Name} and costs: {initial.Cost}.",
            };
        }
    }
}
