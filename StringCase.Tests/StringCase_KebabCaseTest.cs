namespace StringCase.Tests;

public class StringCase_KebabCaseTest
{
    public class KebabCase
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var result = StringCase.KebabCase("abcDefGHIjk");
            Assert.Equal(result, "abc-def-gh-ijk");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var result = StringCase.KebabCase("AbcDefGHIjk");
            Assert.Equal(result, "abc-def-gh-ijk");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var result = StringCase.KebabCase("abc_def_ghi");
            Assert.Equal(result, "abc-def-ghi");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var result = StringCase.KebabCase("abc-def-ghi");
            Assert.Equal(result, "abc-def-ghi");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var result = StringCase.KebabCase("Abc-Def-Ghi");
            Assert.Equal(result, "abc-def-ghi");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var result = StringCase.KebabCase("ABC_DEF_GHI");
            Assert.Equal(result, "abc-def-ghi");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var result = StringCase.KebabCase("ABC-DEF-GHI");
            Assert.Equal(result, "abc-def-ghi");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var result = StringCase.KebabCase("abc123-456defG89HIJklMN12");
            Assert.Equal(result, "abc123-456-def-g89-hi-jkl-mn12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var result = StringCase.KebabCase(":.abc~!@def#$ghi%&jk(lm)no/?");
            Assert.Equal(result, "abc-def-ghi-jk-lm-no");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var result = StringCase.KebabCase("123abc456def");
            Assert.Equal(result, "123-abc456-def");

            result = StringCase.KebabCase("123ABC456DEF");
            Assert.Equal(result, "123-abc456-def");

            result = StringCase.KebabCase("123Abc456Def");
            Assert.Equal(result, "123-abc456-def");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var result = StringCase.KebabCase("");
            Assert.Equal(result, "");
        }
    }

    public class KebabCaseWithOptions
    {
        public class NonAlphabetsAsHeadOfWord
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.KebabCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "", "");
                var result = StringCase.KebabCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc-123-456def-g-89hi-jkl-mn-12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.KebabCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "abc-def-ghi-jk-lm-no");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.KebabCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc-456def");

                result = StringCase.KebabCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc-456def");

                result = StringCase.KebabCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123-abc-456-def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.KebabCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public class NonAlphabetsAsTailOfWord
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.KebabCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "", "");
                var result = StringCase.KebabCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456-def-g89-hi-jkl-mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.KebabCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "abc-def-ghi-jk-lm-no");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.KebabCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123-abc456-def");

                result = StringCase.KebabCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123-abc456-def");

                result = StringCase.KebabCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123-abc456-def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.KebabCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public class NonAlphabetsAsWord
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.KebabCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "", "");
                var result = StringCase.KebabCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc-123-456-def-g-89-hi-jkl-mn-12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.KebabCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "abc-def-ghi-jk-lm-no");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.KebabCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123-abc-456-def");

                result = StringCase.KebabCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123-abc-456-def");

                result = StringCase.KebabCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123-abc-456-def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.KebabCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public class NonAlphabetsPartAsWord
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.KebabCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "", "");
                var result = StringCase.KebabCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456def-g89hi-jkl-mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.KebabCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "abc-def-ghi-jk-lm-no");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.KebabCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.KebabCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.KebabCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123-abc456-def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.KebabCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public class NonAlphabetsAsHeadOfWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, false, "-_", null);
                var result = StringCase.KebabCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "-_", "");
                var result = StringCase.KebabCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, "_", null);
                var result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, false, "-", null);
                result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc-_def-_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, false, "_", null);
                result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc--def--ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, false, "_", null);
                result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc---def---ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, "_", null);
                var result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, false, "-", null);
                result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc-_def-_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, false, "_", null);
                result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc--def--ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc-123-456def-g-89hi-jkl-mn-12");

                opts = new Options(true, false, "_", null);
                result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc-123-456def-g-89hi-jkl-mn-12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, ":@$&()/", null);
                var result = StringCase.KebabCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc-~!-def-#-ghi-%-jk-lm-no-?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.KebabCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc-456def");

                result = StringCase.KebabCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc-456def");

                result = StringCase.KebabCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123-abc-456-def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.KebabCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(true, false, "-b2", null);
                var result = StringCase.KebabCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "abc-123def");
            }
        }

        public class NonAlphabetsAsTailOfWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, true, "-_", null);
                var result = StringCase.KebabCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "-_", "");
                var result = StringCase.KebabCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, "_", null);
                var result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, true, "-", null);
                result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_-def_-ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, true, "_", null);
                result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc--def--ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, true, "_", null);
                result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc--def--ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, "_", null);
                var result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, true, "-", null);
                result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_-def_-ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, true, "_", null);
                result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc--def--ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456-def-g89-hi-jkl-mn12");

                opts = new Options(false, true, "_", null);
                result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456-def-g89-hi-jkl-mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, ":@$&()/", null);
                var result = StringCase.KebabCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".-abc~!-def#-ghi%-jk-lm-no-?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.KebabCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123-abc456-def");

                result = StringCase.KebabCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123-abc456-def");

                result = StringCase.KebabCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123-abc456-def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, "-_", null);
                var result = StringCase.KebabCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(false, true, "-b2", null);
                var result = StringCase.KebabCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "abc123-def");
            }
        }

        public class NonAlphabetsAsWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.KebabCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "-_", "");
                var result = StringCase.KebabCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, "_", null);
                var result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, true, "-", null);
                result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc-_-def-_-ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, true, "_", null);
                result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc---def---ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, true, "_", null);
                result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc---def---ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, "_", null);
                var result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, true, "-", null);
                result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc-_-def-_-ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, true, "_", null);
                result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc---def---ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc-123-456-def-g-89-hi-jkl-mn-12");

                opts = new Options(true, true, "_", null);
                result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc-123-456-def-g-89-hi-jkl-mn-12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, ":@$&()/", null);
                var result = StringCase.KebabCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".-abc-~!-def-#-ghi-%-jk-lm-no-?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.KebabCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123-abc-456-def");

                result = StringCase.KebabCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123-abc-456-def");

                result = StringCase.KebabCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123-abc-456-def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.KebabCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(true, true, "-b2", null);
                var result = StringCase.KebabCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "abc-123-def");
            }
        }

        public class NonAlphabetsAsPartOfWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.KebabCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "-_", "");
                var result = StringCase.KebabCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, "_", null);
                var result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, false, "-", null);
                result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, false, "_", null);
                result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, false, "_", null);
                result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc--def--ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, "_", null);
                var result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, false, "-", null);
                result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, false, "_", null);
                result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456def-g89hi-jkl-mn12");

                opts = new Options(false, false, "_", null);
                result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456def-g89hi-jkl-mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, ":@$&()/", null);
                var result = StringCase.KebabCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc~!-def#-ghi%-jk-lm-no-?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.KebabCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.KebabCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.KebabCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123-abc456-def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.KebabCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(false, false, "-b2", null);
                var result = StringCase.KebabCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "abc123def");
            }
        }

        public class NonAlphabetsAsHeadOfWordAndWithKeptCharacters
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, false, null, "-_");
                var result = StringCase.KebabCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "", "-_");
                var result = StringCase.KebabCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, false, null, "_");
                result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc-_def-_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, false, null, "-");
                result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc--def--ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, false, null, "-");
                result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc---def---ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, false, null, "_");
                result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc-_def-_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, false, null, "-");
                result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc--def--ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc-123-456def-g-89hi-jkl-mn-12");

                opts = new Options(true, false, null, "-");
                result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc-123-456def-g-89hi-jkl-mn-12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, null, ".~!#%?");
                var result = StringCase.KebabCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc-~!-def-#-ghi-%-jk-lm-no-?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.KebabCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc-456def");

                result = StringCase.KebabCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc-456def");

                result = StringCase.KebabCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123-abc-456-def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, "-_");
                var result = StringCase.KebabCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public class NonAlphabetsAsTailOfWordAndWithKeptCharacters
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, true, null, "-_");
                var result = StringCase.KebabCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "", "-_");
                var result = StringCase.KebabCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, null, "-");
                var result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, true, null, "_");
                result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_-def_-ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, true, null, "-");
                result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc--def--ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, true, null, "-");
                result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc--def--ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, null, "-");
                var result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, true, null, "_");
                result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_-def_-ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, true, null, "-");
                result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc--def--ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456-def-g89-hi-jkl-mn12");

                opts = new Options(false, true, null, "-");
                result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456-def-g89-hi-jkl-mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, null, ".~!#%?");
                var result = StringCase.KebabCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".-abc~!-def#-ghi%-jk-lm-no-?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.KebabCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123-abc456-def");

                result = StringCase.KebabCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123-abc456-def");

                result = StringCase.KebabCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123-abc456-def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, null, "-_");
                var result = StringCase.KebabCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public class NonAlphabetsAsWordAndWithKeptCharacters
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, true, null, "-_");
                var result = StringCase.KebabCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "", "-_");
                var result = StringCase.KebabCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, null, "-");
                var result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, true, null, "_");
                result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc-_-def-_-ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, true, null, "-");
                result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc---def---ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, true, null, "-");
                result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc---def---ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, null, "-");
                var result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, true, null, "_");
                result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc-_-def-_-ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(true, true, null, "-");
                result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc---def---ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc-123-456-def-g-89-hi-jkl-mn-12");

                opts = new Options(true, true, null, "-");
                result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc-123-456-def-g-89-hi-jkl-mn-12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, null, ".~!#%?");
                var result = StringCase.KebabCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".-abc-~!-def-#-ghi-%-jk-lm-no-?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, null, "-_");
                var result = StringCase.KebabCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123-abc-456-def");

                result = StringCase.KebabCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123-abc-456-def");

                result = StringCase.KebabCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123-abc-456-def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, null, "-_");
                var result = StringCase.KebabCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public class NonAlphabetsAsPartOfWordAndWithKeptCharacters
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, false, null, "-_");
                var result = StringCase.KebabCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "", "-_");
                var result = StringCase.KebabCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc-def-gh-ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, null, "-");
                var result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, false, null, "_");
                result = StringCase.KebabCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, false, null, "-");
                result = StringCase.KebabCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, false, null, "-");
                result = StringCase.KebabCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc--def--ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, null, "-");
                var result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, false, null, "_");
                result = StringCase.KebabCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");

                opts = new Options(false, false, null, "-");
                result = StringCase.KebabCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456def-g89hi-jkl-mn12");

                opts = new Options(false, false, null, "-");
                result = StringCase.KebabCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456def-g89hi-jkl-mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, null, ".~!#%?");
                var result = StringCase.KebabCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc~!-def#-ghi%-jk-lm-no-?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, null, "-_");
                var result = StringCase.KebabCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.KebabCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.KebabCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123-abc456-def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, null, "-_");
                var result = StringCase.KebabCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }
    }
}
