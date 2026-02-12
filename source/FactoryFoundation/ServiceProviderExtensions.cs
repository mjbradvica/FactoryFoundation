// <copyright file="ServiceProviderExtensions.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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

            RegisterTypes(services, assemblies, typeof(ICanTranslate<,>));
            RegisterTypes(services, assemblies, typeof(ICanTranslate<,,>));
            RegisterTypes(services, assemblies, typeof(ICanTranslate<,,,>));

            return services;
        }

        private static void RegisterTypes(IServiceCollection services, IEnumerable<Assembly> assemblies, Type type)
        {
            var factoryTypes = assemblies
                .SelectMany(assembly => assembly.GetTypes()
                    .Where(assemblyType => !assemblyType.IsInterface && !assemblyType.IsAbstract)
                    .Where(assemblyType => assemblyType.GetInterfaces().Any(interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == type)))
                .ToList();

            foreach (var factory in factoryTypes)
            {
                factory
                    .GetInterfaces()
                    .Where(interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == type)
                    .ToList()
                    .ForEach(interfaceType => services.AddTransient(interfaceType, factory));
            }
        }
    }
}
