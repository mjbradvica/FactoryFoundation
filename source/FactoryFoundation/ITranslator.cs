// <copyright file="ITranslator.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace FactoryFoundation
{
    /// <summary>
    /// Composed interface for the translation of all defined objects.
    /// </summary>
    public interface ITranslator
    {
        /// <summary>
        /// Translates an object from the initial to the resulting class.
        /// </summary>
        /// <typeparam name="TInitial">The type of the initial object.</typeparam>
        /// <typeparam name="TResult">The type of the result object.</typeparam>
        /// <param name="initial">The object to map to the result.</param>
        /// <returns>An instance of the resulting class.</returns>
        TResult Translate<TInitial, TResult>(TInitial initial)
            where TInitial : class
            where TResult : class;
    }
}
