// <copyright file="Program.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using FactoryFoundation.Samples.Widgets;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace FactoryFoundation.Samples
{
    /// <summary>
    /// Sample entry class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Sample entry point.
        /// </summary>
        public static void Main()
        {
            var services = new ServiceCollection();

            services.AddFactoryFoundation(Assembly.GetExecutingAssembly());

            var provider = services.BuildServiceProvider();

            var translator = provider.GetRequiredService<ITranslator>();

            var widget = new Widget();

            var response = translator.Translate<Widget, WidgetResponse>(widget);

            Console.WriteLine($"{response.Id} - {response.Name} - {response.Cost}");

            var compact = translator.Translate<Widget, CompactWidget>(widget);

            Console.WriteLine(compact.Summary);
        }
    }
}
