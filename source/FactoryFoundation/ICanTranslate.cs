// <copyright file="ICanTranslate.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace FactoryFoundation
{
    /// <summary>
    /// Defines a method that will translate one class to another.
    /// </summary>
    /// <typeparam name="TInitial">The type of the initial object.</typeparam>
    /// <typeparam name="TResult">The type of the resulting object.</typeparam>
    public interface ICanTranslate<in TInitial, out TResult>
        where TInitial : class
        where TResult : class
    {
        /// <summary>
        /// Defines a method for translating from a <typeparamref name="TInitial"/> to <typeparamref name="TResult"/>.
        /// </summary>
        /// <param name="initial">The initial object to translate.</param>
        /// <returns>The resulting translated object.</returns>
        TResult TranslateTo(TInitial initial);
    }
}
