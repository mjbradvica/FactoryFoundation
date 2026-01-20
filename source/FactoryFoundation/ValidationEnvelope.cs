// <copyright file="ValidationEnvelope.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace FactoryFoundation
{
    /// <summary>
    /// An envelope for returning either a valid or invalid entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class ValidationEnvelope<TEntity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationEnvelope{TEntity}"/> class.
        /// </summary>
        /// <param name="entity">An instance of the entity.</param>
        public ValidationEnvelope(TEntity entity)
        {
            IsInvalid = false;
            Entity = entity;
            Exception = null!;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationEnvelope{TEntity}"/> class.
        /// </summary>
        /// <param name="exception">The exception thrown during creation.</param>
        public ValidationEnvelope(Exception exception)
        {
            IsInvalid = true;
            Exception = exception;
            Entity = default!;
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
    }
}
