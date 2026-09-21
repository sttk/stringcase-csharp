## 0.1.0

```
BenchmarkDotNet v0.15.8, macOS Tahoe 26.7 (25G229) [Darwin 25.6.0]
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 10.0.401
  [Host]     : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v3
  DefaultJob : .NET 10.0.12 (10.0.12, 10.0.1226.42308), X64 RyuJIT x86-64-v3
```
| Method                   | Mean     | Error   | StdDev   | Median   |
|------------------------- |---------:|--------:|---------:|---------:|
| AdaCase                  | 288.1 ns | 1.74 ns |  1.46 ns | 287.8 ns |
| AdaCaseWithSep           | 336.5 ns | 1.82 ns |  1.70 ns | 336.3 ns |
| AdaCaseWithKeep          | 344.0 ns | 1.84 ns |  1.54 ns | 344.1 ns |
| AdaCaseWithNumsAsWord    | 308.8 ns | 1.32 ns |  1.24 ns | 308.7 ns |
| AdaCaseWithOptions       | 368.3 ns | 7.27 ns | 14.51 ns | 364.7 ns |
| CamelCase                | 224.5 ns | 4.49 ns |  4.99 ns | 222.8 ns |
| CamelCaseWithSep         | 302.7 ns | 5.95 ns |  7.73 ns | 301.1 ns |
| CamelCaseWithKeep        | 282.3 ns | 5.42 ns |  5.56 ns | 281.7 ns |
| CamelCaseWithNumsAsWord  | 227.8 ns | 4.13 ns |  3.45 ns | 227.6 ns |
| CamelCaseWithOptions     | 281.1 ns | 4.04 ns |  3.37 ns | 280.7 ns |
| CobolCase                | 276.9 ns | 4.63 ns |  4.75 ns | 278.3 ns |
| CobolCaseWithSep         | 342.6 ns | 6.68 ns | 11.52 ns | 339.4 ns |
| CobolCaseWithKeep        | 335.3 ns | 2.32 ns |  1.94 ns | 335.3 ns |
| CobolCaseWithNumsAsWord  | 317.9 ns | 6.21 ns |  8.50 ns | 319.5 ns |
| CobolCaseWithOptions     | 365.7 ns | 7.25 ns | 15.30 ns | 362.5 ns |
| KebabCase                | 286.8 ns | 5.51 ns | 10.22 ns | 285.6 ns |
| KebabCaseWithSep         | 335.8 ns | 5.83 ns |  5.45 ns | 337.0 ns |
| KebabCaseWithKeep        | 339.1 ns | 6.74 ns |  6.62 ns | 339.9 ns |
| KebabCaseWithNumsAsWord  | 302.1 ns | 6.09 ns |  9.48 ns | 301.9 ns |
| KebabCaseWithOptions     | 353.5 ns | 4.85 ns |  4.30 ns | 355.2 ns |
| MacroCase                | 287.3 ns | 3.12 ns |  2.60 ns | 286.2 ns |
| MacroCaseWithSep         | 335.4 ns | 6.71 ns |  6.59 ns | 337.1 ns |
| MacroCaseWithKeep        | 346.9 ns | 6.92 ns |  8.50 ns | 347.3 ns |
| MacroCaseWithNumsAsWord  | 318.9 ns | 6.20 ns |  8.27 ns | 321.4 ns |
| MacroCaseWithOptions     | 351.7 ns | 6.17 ns |  6.06 ns | 354.7 ns |
| PascalCase               | 232.6 ns | 4.45 ns |  3.72 ns | 234.2 ns |
| PascalCaseWithSep        | 294.3 ns | 5.90 ns |  9.52 ns | 293.7 ns |
| PascalCaseWithKeep       | 286.6 ns | 5.76 ns | 10.08 ns | 284.3 ns |
| PascalCaseWithNumsAsWord | 230.0 ns | 4.63 ns |  7.87 ns | 228.2 ns |
| PascalCaseWithOptions    | 288.0 ns | 5.54 ns |  9.99 ns | 286.9 ns |
| SnakeCase                | 290.2 ns | 4.98 ns |  5.54 ns | 289.7 ns |
| SnakeCaseWithSep         | 333.5 ns | 6.33 ns |  5.92 ns | 330.7 ns |
| SnakeCaseWithKeep        | 341.4 ns | 6.67 ns |  5.91 ns | 340.8 ns |
| SnakeCaseWithNumsAsWord  | 303.3 ns | 6.07 ns |  9.62 ns | 298.7 ns |
| SnakeCaseWithOptions     | 354.7 ns | 7.15 ns | 11.13 ns | 352.9 ns |
