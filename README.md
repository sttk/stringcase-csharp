# [StringCase][repo-url] [![NuGet Repository][nuget-img]][nuget-url] [![GitHub.io][io-img]][io-url] [![CI Status][ci-img]][ci-url] [![MIT license][mit-img]][mit-url]

This library provides some static methods of `StringCase` static class that convert string cases
between Ada_Case, camelCase, COBOL-CASE, kebab-case, MACRO_CASE, PascalCase, snake_case,
Title Case, and Train-Case.
In addition, the static methods of `StringCase` static class: `Capitalize`, `Lowerize`, and
`Upperize` are provided to convert string cases with a custom joiner character.

Essentially, these static methods only target ASCII uppercase and lowercase letters for
capitalization.
All characters other than ASCII uppercase and lowercase letters and ASCII numbers are removed as
word separators.

If you want to use some symbols as separators, specify those symbols in the `Separators` field of
an `Options` instance and use the `〜CaseWithOptions` static methods for the desired case.
If you want to retain certain symbols and use everything else as separators, specify those symbols
in `Keep` field of an `Options` instance and use the `〜CaseWithOptions` static methods for the
desired case.

Additionally, you can specify whether to place word boundaries before and/or after non-alphabetic
characters with conversion options.
This can be set using the `SeparateBeforeNonAlphabets` and `SeparateAfterNonAlphabets` fields in
the `Options` instance.

The `〜Case` static methods that do not take `Options` as an argument only place word boundaries
after non-alphabetic characters.
In other words, they behave as if
`SeparateBeforeNonAlphabets = false` and `SeparateAfterNonAlphabets = true`.

## Install

This package can be installed from [NuGet][nuget-url].

In your project file, write this package as a dependency.

```xml
<PackageReference Include="StringCase" Version="0.1.0" />
```

You can also install this package with `dotnet` command, as follows.

```bash
dotnet package add StringCase --version 0.1.0
```

## Usage

The static methods of `StringCase` static class in this package can be executed as follows:

```c#
use StringCase;

string input = "fooBar123Baz";
string snake = StringCase.SnakeCase(input);
Console.WriteLine(snake);  // => "foo_bar123_baz"
```

If you want the conversion to behave differently, use `〜CaseWithOptions`.

```c#
use StringCase;

string opts = new Options(true, true, null, null);
string input = "fooBar123Baz";
string snake = StringCase.SnakeCaseWithOptions(input, opts);
Console.WriteLine(snake);  // => "foo_bar_123_baz"
```

You can also use the static method `Capitalize`, `Lowerize`, and `Upperize` to convert strings into capitalized, lowercased, or uppercased words joined by a custom joiner character:

```c#
use StringCase;

string opts = new Options(true, true, null, null);
string input = "fooBar123Baz";
string output = StringCase.Capitalize(input, '.', opts);
Console.WriteLine(snake);  // => "Foo.Bar.123.Baz"
```

## Native build

This library supports native build.

### Actually test results

```
% ./build.sh native-test
Restore complete (0.7s)
    Determining projects to restore...
    All projects are up-to-date for restore.
  StringCase net10.0 succeeded (0.1s) → StringCase/bin/Release/net10.0/StringCase.dll
  StringCase.NativeTests net10.0 osx-x64 succeeded (1.9s) → StringCase.NativeTests/bin/Release/net10.0/osx-x64/publish/

Build succeeded in 3.6s
xUnit.net v3 In-Process Runner v4.0.1+8ed8aa354c [native/osx-x64] (.NET 10.0.12)
  Discovering: StringCase.NativeTests
  Discovered:  StringCase.NativeTests
  Starting:    StringCase.NativeTests
  Finished:    StringCase.NativeTests (ID = '7c9d899a8a0c67345e61bfa2d0a3e64e2ec5aecd11fee42f72a87286073b8916')
=== TEST EXECUTION SUMMARY ===
   StringCase.NativeTests  Total: 1737, Errors: 0, Failed: 0, Skipped: 0, Not Run: 0, Time: 0.041s
```

## License

Copyright (C) 2026 Takayuki Sato

This program is free software under MIT License.<br>
See the file LICENSE in this distribution for more details.


[repo-url]: https://github.com/sttk/stringcase-csharp
[nuget-img]: https://img.shields.io/badge/NuGet-0.1.0-6600ff.svg
[nuget-url]: https://nuget.org/packages/StringCase
[ci-img]: https://github.com/sttk/stringcase-csharp/actions/workflows/csharp.yml/badge.svg?branch=main
[ci-url]: https://github.com/sttk/stringcase-csharp/actions?query=branch%3Amain
[io-img]: https://img.shields.io/badge/github.io-docfx-4c69fd.svg
[io-url]: https://sttk.github.io/stringcase-csharp/api/StringCase.html
[mit-img]: https://img.shields.io/badge/license-MIT-green.svg
[mit-url]: https://opensource.org/licenses/MIT
