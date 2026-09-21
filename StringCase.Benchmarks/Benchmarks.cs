using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;

namespace StringCase.Benchmarks;

public class Benchmarks
{
    [Benchmark]
    public string AdaCase()
    {
        return StringCase.AdaCase("foo_bar100%BAZQux");
    }

    [Benchmark]
    public string AdaCaseWithSep()
    {
        var opts = new Options(separators: "_");
        return StringCase.AdaCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string AdaCaseWithKeep()
    {
        var opts = new Options(keep: "_");
        return StringCase.AdaCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string AdaCaseWithNumsAsWord()
    {
        var opts = new Options(separateBeforeNonAlphabets: true);
        return StringCase.AdaCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string AdaCaseWithOptions()
    {
        var opts = new Options(true, true, "", "%");
        return StringCase.AdaCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string CamelCase()
    {
        return StringCase.CamelCase("foo_bar100%BAZQux");
    }

    [Benchmark]
    public string CamelCaseWithSep()
    {
        var opts = new Options(separators: "_");
        return StringCase.CamelCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string CamelCaseWithKeep()
    {
        var opts = new Options(keep: "_");
        return StringCase.CamelCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string CamelCaseWithNumsAsWord()
    {
        var opts = new Options(separateBeforeNonAlphabets: true);
        return StringCase.CamelCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string CamelCaseWithOptions()
    {
        var opts = new Options(true, true, "", "%");
        return StringCase.CamelCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string CobolCase()
    {
        return StringCase.CobolCase("foo_bar100%BAZQux");
    }

    [Benchmark]
    public string CobolCaseWithSep()
    {
        var opts = new Options(separators: "_");
        return StringCase.CobolCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string CobolCaseWithKeep()
    {
        var opts = new Options(keep: "_");
        return StringCase.CobolCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string CobolCaseWithNumsAsWord()
    {
        var opts = new Options(separateBeforeNonAlphabets: true);
        return StringCase.CobolCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string CobolCaseWithOptions()
    {
        var opts = new Options(true, true, "", "%");
        return StringCase.CobolCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string KebabCase()
    {
        return StringCase.KebabCase("foo_bar100%BAZQux");
    }

    [Benchmark]
    public string KebabCaseWithSep()
    {
        var opts = new Options(separators: "_");
        return StringCase.KebabCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string KebabCaseWithKeep()
    {
        var opts = new Options(keep: "_");
        return StringCase.KebabCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string KebabCaseWithNumsAsWord()
    {
        var opts = new Options(separateBeforeNonAlphabets: true);
        return StringCase.KebabCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string KebabCaseWithOptions()
    {
        var opts = new Options(true, true, "", "%");
        return StringCase.KebabCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string MacroCase()
    {
        return StringCase.MacroCase("foo_bar100%BAZQux");
    }

    [Benchmark]
    public string MacroCaseWithSep()
    {
        var opts = new Options(separators: "_");
        return StringCase.MacroCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string MacroCaseWithKeep()
    {
        var opts = new Options(keep: "_");
        return StringCase.MacroCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string MacroCaseWithNumsAsWord()
    {
        var opts = new Options(separateBeforeNonAlphabets: true);
        return StringCase.MacroCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string MacroCaseWithOptions()
    {
        var opts = new Options(true, true, "", "%");
        return StringCase.MacroCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string PascalCase()
    {
        return StringCase.PascalCase("foo_bar100%BAZQux");
    }

    [Benchmark]
    public string PascalCaseWithSep()
    {
        var opts = new Options(separators: "_");
        return StringCase.PascalCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string PascalCaseWithKeep()
    {
        var opts = new Options(keep: "_");
        return StringCase.PascalCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string PascalCaseWithNumsAsWord()
    {
        var opts = new Options(separateBeforeNonAlphabets: true);
        return StringCase.PascalCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string PascalCaseWithOptions()
    {
        var opts = new Options(true, true, "", "%");
        return StringCase.PascalCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string SnakeCase()
    {
        return StringCase.SnakeCase("foo_bar100%BAZQux");
    }

    [Benchmark]
    public string SnakeCaseWithSep()
    {
        var opts = new Options(separators: "_");
        return StringCase.SnakeCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string SnakeCaseWithKeep()
    {
        var opts = new Options(keep: "_");
        return StringCase.SnakeCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string SnakeCaseWithNumsAsWord()
    {
        var opts = new Options(separateBeforeNonAlphabets: true);
        return StringCase.SnakeCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string SnakeCaseWithOptions()
    {
        var opts = new Options(true, true, "", "%");
        return StringCase.SnakeCaseWithOptions("foo_bar100%BAZQux", opts);
    }
}

public class TitleCase
{
    [Benchmark]
    public string NoOptions()
    {
        return StringCase.TitleCase("foo_bar100%BAZQux");
    }

    [Benchmark]
    public string TitleCaseWithSep()
    {
        var opts = new Options(separators: "_");
        return StringCase.TitleCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string TitleCaseWithKeep()
    {
        var opts = new Options(keep: "_");
        return StringCase.TitleCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string TitleCaseWithNumsAsWord()
    {
        var opts = new Options(separateBeforeNonAlphabets: true);
        return StringCase.TitleCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string TitleCaseWithOptions()
    {
        var opts = new Options(true, true, "", "%");
        return StringCase.TitleCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string TrainCase()
    {
        return StringCase.TrainCase("foo_bar100%BAZQux");
    }

    [Benchmark]
    public string TrainCaseWithSep()
    {
        var opts = new Options(separators: "_");
        return StringCase.TrainCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string TrainCaseWithKeep()
    {
        var opts = new Options(keep: "_");
        return StringCase.TrainCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string TrainCaseWithNumsAsWord()
    {
        var opts = new Options(separateBeforeNonAlphabets: true);
        return StringCase.TrainCaseWithOptions("foo_bar100%BAZQux", opts);
    }

    [Benchmark]
    public string TrainCaseWithOptions()
    {
        var opts = new Options(true, true, "", "%");
        return StringCase.TrainCaseWithOptions("foo_bar100%BAZQux", opts);
    }
}
