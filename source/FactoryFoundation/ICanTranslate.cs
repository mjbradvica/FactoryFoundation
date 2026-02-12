// <copyright file="ICanTranslate.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace FactoryFoundation
{
    /// <summary>
    /// Translate one type to another.
    /// </summary>
    /// <typeparam name="TFirst">The first type.</typeparam>
    /// <typeparam name="TFinal">TThe type of the final result.</typeparam>
    public interface ICanTranslate<in TFirst, out TFinal>
    {
        /// <summary>
        /// Defines a method for translating from one type to another.
        /// </summary>
        /// <param name="first">The first object to translate.</param>
        /// <returns>The resulting translated object.</returns>
        TFinal TranslateTo(TFirst first);
    }

    /// <summary>
    /// Translates two types down to a single result.
    /// </summary>
    /// <typeparam name="TFirst">The first type.</typeparam>
    /// <typeparam name="TSecond">The second type.</typeparam>
    /// <typeparam name="TFinal">The type of the final result.</typeparam>
    public interface ICanTranslate<in TFirst, in TSecond, out TFinal>
    {
        /// <summary>
        /// Defines a method for translating two types down to one.
        /// </summary>
        /// <param name="first">The first type.</param>
        /// <param name="second">The second type.</param>
        /// <returns>The type of the final result.</returns>
        TFinal TranslateTo(TFirst first, TSecond second);
    }

    /// <summary>
    /// Translates three types down to a single result.
    /// </summary>
    /// <typeparam name="TFirst">The first type.</typeparam>
    /// <typeparam name="TSecond">The second type.</typeparam>
    /// <typeparam name="TThird">The third type.</typeparam>
    /// <typeparam name="TFinal">THe type of the final result.</typeparam>
    public interface ICanTranslate<in TFirst, in TSecond, in TThird, out TFinal>
    {
        /// <summary>
        /// Defines a method for translating three types down to one.
        /// </summary>
        /// <param name="first">The first type.</param>
        /// <param name="second">The second type.</param>
        /// <param name="third">The third type.</param>
        /// <returns>The type of the final result.</returns>
        TFinal TranslateTo(TFirst first, TSecond second, TThird third);
    }
}
