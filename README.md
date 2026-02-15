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
    - [Factory Helpers](#factory-helpers)
  - [Detailed Usage](#detailed-usage)
    - [Accepting Dependencies](#accepting-dependencies)
    - [Returning Multiple Types](#returning-multiple-types)
  - [FAQ](#faq)

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

## Quick Start

### Defining Factories

Defining a factory is straight forward, have a class inherit from the "ICanTranslate" interface of type T and K, where "T" is your initial value and "K" is the value you are mapping to.

```csharp
public class AirplaneFactory :
    ICanTranslate<Airplane, AirplaneResponse>
{
    public AirplaneResponse TranslateTo(Airplane first)
    {
        // implementation.
    }
}
```

### Using the Translator interface

When you require a factory, inject an "ITranslator" interface into whatever service or handler required.

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

> You may also pass the "ICanTranslate" interface if you just need one specific translation.

### Multiple Types

FactoryFoundation currently supports mapping from one, two, or three types down to a single result.

```csharp
public class MyFactory : 
    ICanTranslate<int, string, string>,
    ICanTranslate<int, double, string, string>
{
    public string TranslateTo(int first, string second)
    {
        return $"{first} & {second}";
    }

    public string TranslateTo(int first, double second, string third)
    {
        return $"{first}, {second}, {third}";
    }
}
```

The number of types is determined by how many types you pass into each interface.

```csharp
var firstResult = _translator.Translate<int, string, string>(1, "hello");

var secondResult = _translator.Translate<int, double, string, string>(4, 3.33, "hi");
```

### Factory Helpers

FactoryFoundation comes with a small helper to make object creation easier.

```csharp
var envelope = FactoryHelpers.TryCreateValidate(() => new Widget());
```

The function will attempt to create the object specified, if an exception is thrown, the proper envelope response will be returned.

## Detailed Usage

### Accepting Dependencies

FactoryFoundation is 100% dependency injection compliant. You may pass dependencies to your factory if required.

```csharp
public class MyFactory
    : ICanTranslate<string, string>
{
    private readonly TimeProvider _timeProvider;

    public MyFactory(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public string TranslateTo(string first)
    {
        return $"{first} at: {_timeProvider.GetUtcNow()}";
    }
}
```

### Returning Multiple Types

If you need to return multiple types, the best way to do so is via a Tuple or create a custom type.

```csharp
public class MyFactory : 
    ICanTranslate<int, string, Tuple<int, string>>
    ICanTranslate<int, string, MyCustomType>
{
    public Tuple<int, string> TranslateTo(int first, string second)
    {
        return new Tuple<int, string>(first, second);
    }

    public MyCustomType TranslateTo(int first, string second)
    {
        return new MyCustomType(first, second);
    }
}
```

## FAQ

### Do I Need FactoryFoundation?

The best reasons to use FactoryFoundation is:

1) You prefer having a consistent way of creating objects
2) You need a single interface for object mapping

### Does FactoryFoundation do any auto mapping?

The library was designed specifically NOT to perform anything automatically. However, there are several advantages to this, FactoryFoundation is far easier to debug versus other automatic libraries. The mapping process can also be significantly faster than other libraries because the process is so simple.

### How long does FactoryFoundation take to learn?

Anyone can learn FactoryFoundation in 3 minutes. There are only two interfaces to use, and a single line configuration.
