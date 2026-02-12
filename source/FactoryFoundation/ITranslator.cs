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
        /// Translates an object from the first to the resulting class.
        /// </summary>
        /// <typeparam name="TFirst">The type of the first object.</typeparam>
        /// <typeparam name="TFinal">The type of the result object.</typeparam>
        /// <param name="first">The object to map to the result.</param>
        /// <returns>An instance of the resulting class.</returns>
        TFinal Translate<TFirst, TFinal>(TFirst first);

        /// <summary>
        /// Translates two objects to the resulting class.
        /// </summary>
        /// <typeparam name="TFirst">The type of the first object.</typeparam>
        /// <typeparam name="TSecond">The type of the second object.</typeparam>
        /// <typeparam name="TFinal">The type of the result object.</typeparam>
        /// <param name="first">The first object to map from.</param>
        /// <param name="second">The second object to map from.</param>
        /// <returns>An instance of the resulting class.</returns>
        TFinal Translate<TFirst, TSecond, TFinal>(TFirst first, TSecond second);

        /// <summary>
        /// Translates three objects to the resulting class.
        /// </summary>
        /// <typeparam name="TFirst">The type of the first object.</typeparam>
        /// <typeparam name="TSecond">The type of the second object.</typeparam>
        /// <typeparam name="TThird">The type of the third object.</typeparam>
        /// <typeparam name="TFinal">The type fo the result object.</typeparam>
        /// <param name="first">The first object to map from.</param>
        /// <param name="second">The second object to map from.</param>
        /// <param name="third">The third object to map from.</param>
        /// <returns>An instance of the resulting class.</returns>
        TFinal Translate<TFirst, TSecond, TThird, TFinal>(TFirst first, TSecond second, TThird third);
    }
}
