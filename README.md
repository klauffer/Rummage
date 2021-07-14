Rummage
=======

[![BuildDeploy](https://github.com/klauffer/Rummage/actions/workflows/BuildDeploy.yml/badge.svg)](https://github.com/klauffer/Rummage/actions/workflows/BuildDeploy.yml)


A Collection of Search Algorithms in .NET


### Installing Rummage

You should install [Rummage with NuGet](https://www.nuget.org/packages/Rummage):

    Install-Package Rummage
    
Or via the .NET Core command line interface:

    dotnet add package Rummage

Either commands, from Package Manager Console or .NET Core CLI, will download and install MediatR and all required dependencies.


Performance
=======
 
``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.1083 (21H1/May2021Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=5.0.103
  [Host]     : .NET Core 3.1.12 (CoreCLR 4.700.21.6504, CoreFX 4.700.21.6905), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 3.1.12 (CoreCLR 4.700.21.6504, CoreFX 4.700.21.6905), X64 RyuJIT


```
|                   Method |     Mean |   Error |  StdDev |
|------------------------- |---------:|--------:|--------:|
|            HammingSearch | 342.2 ms | 6.00 ms | 5.61 ms |
|        LevenshteinSearch | 274.5 ms | 3.43 ms | 3.04 ms |
| DamerauLevenshteinSearch | 292.9 ms | 5.77 ms | 6.64 ms |
