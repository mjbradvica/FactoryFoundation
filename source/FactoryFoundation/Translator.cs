// <copyright file="Translator.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;

namespace FactoryFoundation
{
    /// <inheritdoc />
    public sealed class Translator : ITranslator
    {
        private readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="Translator"/> class.
        /// </summary>
        /// <param name="serviceProvider">An instance of the <see cref="IServiceProvider"/> interface.</param>
        public Translator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        /// <inheritdoc/>
        public TFinal Translate<TFirst, TFinal>(TFirst first)
        {
            var translator = _serviceProvider.GetService<ICanTranslate<TFirst, TFinal>>();

            if (translator != null)
            {
                return translator.TranslateTo(first);
            }

            throw new ArgumentNullException(nameof(first), $"The translator for {typeof(TFirst)} to {typeof(TFinal)} could not be found. Did you define one?");
        }

        /// <inheritdoc/>
        public TFinal Translate<TFirst, TSecond, TFinal>(TFirst first, TSecond second)
        {
            var translator = _serviceProvider.GetService<ICanTranslate<TFirst, TSecond, TFinal>>();

            if (translator != null)
            {
                return translator.TranslateTo(first, second);
            }

            throw new ArgumentNullException(nameof(first), $"The translator from {typeof(TFirst)} and {typeof(TSecond)} to {typeof(TFinal)} could not be found. Did you define one?");
        }

        /// <inheritdoc/>
        public TFinal Translate<TFirst, TSecond, TThird, TFinal>(TFirst first, TSecond second, TThird third)
        {
            var translator = _serviceProvider.GetService<ICanTranslate<TFirst, TSecond, TThird, TFinal>>();

            if (translator != null)
            {
                return translator.TranslateTo(first, second, third);
            }

            throw new ArgumentNullException(nameof(first), $"The translator from {typeof(TFirst)} and {typeof(TSecond)} and {typeof(TThird)} to {typeof(TFinal)} could not be found. Did you define one?");
        }
    }
}
