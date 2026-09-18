#!/usr/bin/env bash

#
# Make a development environement of a C# project.
#

## Make a new solution
dotnet new solution --name StringCase

## Make a project of a library
dotnet new classlib --name StringCase --output StringCase
dotnet solution StringCase.slnx add StringCase/StringCase.csproj

## Make a project for unit tests
dotnet new xunit --name StringCase.Tests --output StringCase.Tests
dotnet solution StringCase.slnx add StringCase.Tests/StringCase.Tests.csproj
dotnet add StringCase.Tests/StringCase.Tests.csproj reference StringCase/StringCase.csproj

## Make a project for native build
dotnet new console --name StringCase.NativeTests --framework net10.0
dotnet solution StringCase.slnx add StringCase.NativeTests/StringCase.NativeTests.csproj
dotnet add StringCase.NativeTests/StringCase.NativeTests.csproj reference StringCase/StringCase.csproj
awk '/<\/PropertyGroup>/{print "    <PublishAot>true</PublishAot>"}1' StringCase.NativeTests/StringCase.NativeTests.csproj > .tmp
mv .tmp StringCase.NativeTests/StringCase.NativeTests.csproj

## Make a project for benchmark
dotnet new install BenchmarkDotNet.Templates
dotnet new benchmark --name StringCase.Benchmarks --output StringCase.Benchmarks --framework net10.0
dotnet solution StringCase.slnx add StringCase.Benchmarks/StringCase.Benchmarks.csproj
dotnet add StringCase.Benchmarks/StringCase.Benchmarks.csproj reference StringCase/StringCase.csproj

## NOTE: macOS-specific issue:
##
## The following errors:
##
##   ld: library 'ssl' not found
##   ld: library 'brotlienc' not found
##
## are caused by the following `clang` linker options:
##
##   -lssl, -lbrotlienc, -lbrotlidec, -lbrotlicommon
##
## To resolve this issue, set the Homebrew prefix in the `LIBRARY_PATH` environment variable.
##
##    export LIBRARY_PATH="$(brew --prefix)/lib:$LIBRARY_PATH"
##
