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

Examples in the [wiki](https://github.com/klauffer/Rummage/wiki).

Performance
=======
 
``` ini

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.1110 (21H1/May2021Update)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=5.0.103
  [Host]     : .NET Core 3.1.12 (CoreCLR 4.700.21.6504, CoreFX 4.700.21.6905), X64 RyuJIT  [AttachedDebugger]
  DefaultJob : .NET Core 3.1.12 (CoreCLR 4.700.21.6504, CoreFX 4.700.21.6905), X64 RyuJIT


```
|                   Method |     Mean |   Error |  StdDev |
|------------------------- |---------:|--------:|--------:|
|            HammingSearch | 260.9 ms | 5.05 ms | 5.19 ms |
|        LevenshteinSearch | 238.3 ms | 4.02 ms | 4.93 ms |
| DamerauLevenshteinSearch | 242.1 ms | 3.13 ms | 2.93 ms |
|               JaroSearch | 252.3 ms | 4.62 ms | 4.10 ms |
