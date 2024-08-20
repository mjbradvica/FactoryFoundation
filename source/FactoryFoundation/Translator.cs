// <copyright file="Translator.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
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
        public TResult Translate<TInitial, TResult>(TInitial initial)
            where TInitial : class
            where TResult : class
        {
            var translator = _serviceProvider.GetService<ICanTranslate<TInitial, TResult>>();

            if (translator != null)
            {
                return translator.TranslateTo(initial);
            }

            throw new NullReferenceException($"The translator for {typeof(TInitial)} to {typeof(TResult)} could not be found. Did you define one?");
        }
    }
}
