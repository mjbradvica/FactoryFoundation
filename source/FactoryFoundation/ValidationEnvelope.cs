// <copyright file="ValidationEnvelope.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;

namespace FactoryFoundation
{
    /// <summary>
    /// An envelope for returning either a valid or invalid entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class ValidationEnvelope<TEntity>
    {
        private ValidationEnvelope(bool isInvalid, TEntity entity, Exception exception)
        {
            IsInvalid = isInvalid;
            Entity = entity;
            Exception = exception;
        }

        /// <summary>
        /// Gets a value indicating whether the operation was a failure.
        /// </summary>
        public bool IsInvalid { get; }

        /// <summary>
        /// Gets the entity from the operation.
        /// </summary>
        public TEntity Entity { get; }

        /// <summary>
        /// Gets the validation exception.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Returns a successful operation result.
        /// </summary>
        /// <param name="entity">The newly created entity.</param>
        /// <returns>A <see cref="ValidationEnvelope{TEntity}"/> with a success result.</returns>
        public static ValidationEnvelope<TEntity> Success(TEntity entity)
        {
            return new ValidationEnvelope<TEntity>(false, entity, new Exception());
        }

        /// <summary>
        /// Returns a failed operation result.
        /// </summary>
        /// <param name="exception">The exception thrown during the process.</param>
        /// <returns>A <see cref="ValidationEnvelope{TEntity}"/> with a failed result.</returns>
        public static ValidationEnvelope<TEntity> Failure(Exception exception)
        {
            return new ValidationEnvelope<TEntity>(true, default!, exception);
        }
    }
}
