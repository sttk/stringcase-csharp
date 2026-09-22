namespace StringCase.Tests;

public class StringCase_Options
{
    [Fact]
    public void Constructor()
    {
        var opts = new Options(true, false, "_%", "-#$");
        Assert.Equal(opts.SeparateBeforeNonAlphabets, true);
        Assert.Equal(opts.SeparateAfterNonAlphabets, false);
        Assert.Equal(opts.Separators, "_%");
        Assert.Equal(opts.Keep, "-#$");
    }

    public class NamedArguments
    {
        [Fact]
        public void OnlySeparateBeforeNonAlphabets()
        {
            var opts = new Options(separateBeforeNonAlphabets: true);
            Assert.Equal(opts.SeparateBeforeNonAlphabets, true);
            Assert.Equal(opts.SeparateAfterNonAlphabets, false);
            Assert.Null(opts.Separators);
            Assert.Null(opts.Keep);
        }

        [Fact]
        public void OnlySeparateAfterNonAlphabets()
        {
            var opts = new Options(separateAfterNonAlphabets: true);
            Assert.Equal(opts.SeparateBeforeNonAlphabets, false);
            Assert.Equal(opts.SeparateAfterNonAlphabets, true);
            Assert.Null(opts.Separators);
            Assert.Null(opts.Keep);
        }

        [Fact]
        public void OnlySeparators()
        {
            var opts = new Options(separators: "-_");
            Assert.Equal(opts.SeparateBeforeNonAlphabets, false);
            Assert.Equal(opts.SeparateAfterNonAlphabets, false);
            Assert.Equal(opts.Separators, "-_");
            Assert.Null(opts.Keep);
        }

        [Fact]
        public void OnlyKeep()
        {
            var opts = new Options(keep: "-_");
            Assert.Equal(opts.SeparateBeforeNonAlphabets, false);
            Assert.Equal(opts.SeparateAfterNonAlphabets, false);
            Assert.Null(opts.Separators);
            Assert.Equal(opts.Keep, "-_");
        }

        [Fact]
        public void SeparatorsAndKeep()
        {
            var opts = new Options(keep: "-_", separators: "#@");
            Assert.Equal(opts.SeparateBeforeNonAlphabets, false);
            Assert.Equal(opts.SeparateAfterNonAlphabets, false);
            Assert.Equal(opts.Separators, "#@");
            Assert.Equal(opts.Keep, "-_");
        }
    }
}
