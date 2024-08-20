// <copyright file="ServiceProviderExtensions.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace FactoryFoundation
{
    /// <summary>
    /// Allows for easy registration of factories and translators.
    /// </summary>
    public static class ServiceProviderExtensions
    {
        /// <summary>
        /// Registers all factories and translators for a series of assemblies.
        /// </summary>
        /// <param name="services">An instance of hte <see cref="IServiceCollection"/> interface.</param>
        /// <param name="assemblies">A <see cref="IEnumerable{T}"/> of <see cref="Assembly"/> to register.</param>
        /// <returns>An updated services collection.</returns>
        public static IServiceCollection AddFactoryFoundation(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddScoped<ITranslator, Translator>();

            if (assemblies.Length == 0)
            {
                throw new ArgumentNullException(nameof(assemblies), "No assemblies are available for FactoryFoundation to register. Please pass a parameter for registration.");
            }

            var factoryTypes = assemblies
                .SelectMany(assembly => assembly.GetTypes()
                    .Where(type => !type.IsInterface && !type.IsAbstract)
                    .Where(type => type.GetInterfaces().Any(interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(ICanTranslate<,>)))
                    .ToList())
                .ToList();

            if (!factoryTypes.Any())
            {
                throw new NullReferenceException("No factories were found to registration. Did you define any?");
            }

            foreach (var factory in factoryTypes)
            {
                factory
                    .GetInterfaces()
                    .Where(interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == typeof(ICanTranslate<,>))
                    .ToList()
                    .ForEach(interfaceType => services.AddSingleton(interfaceType, factory));
            }

            return services;
        }
    }
}
