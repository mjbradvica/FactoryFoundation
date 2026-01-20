# FactoryFoundation

A micro-library for factories in dotnet.

![web-logo](https://i.imgur.com/j7J9CGF.png)

![build-status](https://github.com/mjbradvica/FactoryFoundation/workflows/main/badge.svg) ![downloads](https://img.shields.io/nuget/dt/FactoryFoundation) ![nuget](https://img.shields.io/nuget/v/FactoryFoundation) ![activity](https://img.shields.io/github/last-commit/mjbradvica/FactoryFoundation/master)

## Overview

FactoryFoundation gives you:

- :factory: Fully typed factories with zero reflection.
- :spiral_notepad: Consistency via common interfaces.
- :package: Auto-registration with the DI container.
- :bug: Easy debugging via normal step-through ability.

## Table of Contents

- [FactoryFoundation](#factoryfoundation)
  - [Overview](#overview)
  - [Table of Contents](#table-of-contents)
  - [Samples](#samples)
  - [Advantages vs Disadvantages of FactoryFoundation](#advantages-vs-disadvantages-of-factoryfoundation)
  - [Dependencies](#dependencies)
  - [Installation](#installation)
  - [Setup](#setup)
  - [Quick Start](#quick-start)
    - [Defining Factories](#defining-factories)
    - [Using the Translator interface](#using-the-translator-interface)

## Samples

If you would like code samples for FactoryFoundation, they can be found [here in the documentation](https://github.com/mjbradvica/FactoryFoundation/tree/master/samples/FactoryFoundation.Samples).

## Advantages vs Disadvantages of FactoryFoundation

FactoryFoundation is a micro-library. The intention is to help you remove some, but not all, of the ceremony and boilerplate around factories and the mapping of objects from an entity to data transfer object.

Advantages:

- Common interface and function naming
- Method generation via your IDE
- Auto DI registration and resolving
- Easy debugging

Disadvantages:

- No automatic mapping

## Dependencies

FactoryFoundation has one dependency on the [Microsoft.Extensions.DependencyInjection.Abstractions](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection.Abstractions/) package to allow for easy integration with the DI container.

## Installation

The easiest way to get started is to: [Install with NuGet](https://www.nuget.org/).

In your application layer:

```bash
Install-Package FactoryFoundation
```

## Setup

FactoryFoundation has a method that will automatically register all of your factories with the DI container.

> You may also pass a params of assemblies if required.

```csharp
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddFactoryFoundation(Assembly.GetExecutingAssembly());

        // Continue setup below
    }
}
```

### Quick Start

### Defining Factories

Defining a factory is straight forward, have a class inherit from the "ICanTranslate" interface and pass the generic types you are translating from and to.

```csharp
public class AirplaneFactory :
    ICanTranslate<Airplane, AirplaneResponse>
{
    public AirplaneResponse TranslateTo(Airplane initial)
    {
        // implementation.
    }
}
```

### Using the Translator interface

When you required a factory, just inject an "ITranslator" interface into whatever service or handler required.

```csharp
public class MyService
{
    private readonly ITranslator _translator;

    public MyService(ITranslator translator)
    {
        _translator = translator;
    }
}
```

Call the "Translate" method and pass the initial and final type that you wish to translate between.

```csharp
public class MyService
{
    private readonly ITranslator _translator;

    public MyService(ITranslator translator)
    {
        _translator = translator;
    }

    public MyResponse DoSomething()
    {
        // get data

        return _translator.Translate<MyEntity, MyResponse>(entity);
    }
}
```