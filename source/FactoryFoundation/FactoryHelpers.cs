// <copyright file="FactoryHelpers.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;

namespace FactoryFoundation
{
    /// <summary>
    /// A set of helpers for factories.
    /// </summary>
    public static class FactoryHelpers
    {
        /// <summary>
        /// Attempts to create a <typeparamref name="TEntity"/> via a <see cref="Func{TResult}"/>.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="creationFunc">A <see cref="Func{TResult}"/> that will yield a <typeparamref name="TEntity"/>.</param>
        /// <returns>A <see cref="ValidationEnvelope{TEntity}"/> result.</returns>
        public static ValidationEnvelope<TEntity> TryCreateValidate<TEntity>(Func<TEntity> creationFunc)
        {
            TEntity entity;

            try
            {
                entity = creationFunc.Invoke();
            }
            catch (Exception exception)
            {
                return ValidationEnvelope<TEntity>.Failure(exception);
            }

            return ValidationEnvelope<TEntity>.Success(entity);
        }
    }
}
