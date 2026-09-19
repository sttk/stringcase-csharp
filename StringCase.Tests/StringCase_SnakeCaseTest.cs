namespace StringCase.Tests;

public class StringCase_SnakeCaseTest
{

    public
    class SnakeCase
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var result = StringCase.SnakeCase("abcDefGHIjk");
            Assert.Equal(result, "abc_def_gh_ijk");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var result = StringCase.SnakeCase("AbcDefGHIjk");
            Assert.Equal(result, "abc_def_gh_ijk");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var result = StringCase.SnakeCase("abc_def_ghi");
            Assert.Equal(result, "abc_def_ghi");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var result = StringCase.SnakeCase("abc-def-ghi");
            Assert.Equal(result, "abc_def_ghi");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var result = StringCase.SnakeCase("Abc-Def-Ghi");
            Assert.Equal(result, "abc_def_ghi");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var result = StringCase.SnakeCase("ABC_DEF_GHI");
            Assert.Equal(result, "abc_def_ghi");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var result = StringCase.SnakeCase("ABC-DEF-GHI");
            Assert.Equal(result, "abc_def_ghi");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var result = StringCase.SnakeCase("abc123-456defG89HIJklMN12");
            Assert.Equal(result, "abc123_456_def_g89_hi_jkl_mn12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var result = StringCase.SnakeCase(":.abc~!@def#$ghi%&jk(lm)no/?");
            Assert.Equal(result, "abc_def_ghi_jk_lm_no");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var result = StringCase.SnakeCase("123abc456def");
            Assert.Equal(result, "123_abc456_def");

            result = StringCase.SnakeCase("123ABC456DEF");
            Assert.Equal(result, "123_abc456_def");

            result = StringCase.SnakeCase("123Abc456Def");
            Assert.Equal(result, "123_abc456_def");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var result = StringCase.SnakeCase("");
            Assert.Equal(result, "");
        }
    }

    public
    class SnakeCaseWithOptions
    {
        public
        class NonAlphabetsAsHeadOfWord
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "", "");
                var result = StringCase.SnakeCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc_123_456def_g_89hi_jkl_mn_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.SnakeCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "abc_def_ghi_jk_lm_no");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc_456def");

                result = StringCase.SnakeCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc_456def");

                result = StringCase.SnakeCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_abc_456_def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public
        class NonAlphabetsAsTailOfWord
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "", "");
                var result = StringCase.SnakeCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123_456_def_g89_hi_jkl_mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.SnakeCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "abc_def_ghi_jk_lm_no");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_abc456_def");

                result = StringCase.SnakeCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_abc456_def");

                result = StringCase.SnakeCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_abc456_def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public
        class NonAlphabetsAsWord
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "", "");
                var result = StringCase.SnakeCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc_123_456_def_g_89_hi_jkl_mn_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.SnakeCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "abc_def_ghi_jk_lm_no");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_abc_456_def");

                result = StringCase.SnakeCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_abc_456_def");

                result = StringCase.SnakeCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_abc_456_def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.SnakeCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public
        class NonAlphabetsPartAsWord
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "", "");
                var result = StringCase.SnakeCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123_456def_g89hi_jkl_mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.SnakeCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "abc_def_ghi_jk_lm_no");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.SnakeCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.SnakeCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_abc456_def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public
        class NonAlphabetsAsHeadOfWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, false, "-_", null);
                var result = StringCase.SnakeCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "-_", "");
                var result = StringCase.SnakeCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, "_", null);
                var result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, false, "-", null);
                result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc__def__ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, false, "_", null);
                result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc_-def_-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, false, "_", null);
                result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc_-_def_-_ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, "_", null);
                var result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, false, "-", null);
                result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc__def__ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, false, "_", null);
                result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc_-def_-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc_123_456def_g_89hi_jkl_mn_12");

                opts = new Options(true, false, "_", null);
                result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc_123-456def_g_89hi_jkl_mn_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, ":@$&()/", null);
                var result = StringCase.SnakeCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc_~!_def_#_ghi_%_jk_lm_no_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.SnakeCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc_456def");

                result = StringCase.SnakeCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc_456def");

                result = StringCase.SnakeCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_abc_456_def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.SnakeCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(true, false, "-b2", null);
                var result = StringCase.SnakeCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "abc_123def");
            }
        }

        public
        class NonAlphabetsAsTailOfWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, true, "-_", null);
                var result = StringCase.SnakeCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "-_", "");
                var result = StringCase.SnakeCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, "_", null);
                var result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, true, "-", null);
                result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc__def__ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, true, "_", null);
                result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-_def-_ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, true, "_", null);
                result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-_def-_ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, "_", null);
                var result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, true, "-", null);
                result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc__def__ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, true, "_", null);
                result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-_def-_ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123_456_def_g89_hi_jkl_mn12");

                opts = new Options(false, true, "_", null);
                result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456_def_g89_hi_jkl_mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, ":@$&()/", null);
                var result = StringCase.SnakeCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "._abc~!_def#_ghi%_jk_lm_no_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.SnakeCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_abc456_def");

                result = StringCase.SnakeCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_abc456_def");

                result = StringCase.SnakeCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_abc456_def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, "-_", null);
                var result = StringCase.SnakeCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(false, true, "-b2", null);
                var result = StringCase.SnakeCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "abc123_def");
            }
        }

        public
        class NonAlphabetsAsWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.SnakeCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "-_", "");
                var result = StringCase.SnakeCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, "_", null);
                var result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, true, "-", null);
                result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc___def___ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, true, "_", null);
                result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc_-_def_-_ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, true, "_", null);
                result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc_-_def_-_ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, "_", null);
                var result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, true, "-", null);
                result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc___def___ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, true, "_", null);
                result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc_-_def_-_ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc_123_456_def_g_89_hi_jkl_mn_12");

                opts = new Options(true, true, "_", null);
                result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc_123-456_def_g_89_hi_jkl_mn_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, ":@$&()/", null);
                var result = StringCase.SnakeCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "._abc_~!_def_#_ghi_%_jk_lm_no_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.SnakeCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_abc_456_def");

                result = StringCase.SnakeCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_abc_456_def");

                result = StringCase.SnakeCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_abc_456_def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.SnakeCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(true, true, "-b2", null);
                var result = StringCase.SnakeCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "abc_123_def");
            }
        }

        public
        class NonAlphabetsAsPartOfWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.SnakeCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "-_", "");
                var result = StringCase.SnakeCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, "_", null);
                var result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, false, "-", null);
                result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, false, "_", null);
                result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, false, "_", null);
                result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-_def-_ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, "_", null);
                var result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, false, "-", null);
                result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, false, "_", null);
                result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123_456def_g89hi_jkl_mn12");

                opts = new Options(false, false, "_", null);
                result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456def_g89hi_jkl_mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, ":@$&()/", null);
                var result = StringCase.SnakeCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc~!_def#_ghi%_jk_lm_no_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.SnakeCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.SnakeCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.SnakeCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_abc456_def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.SnakeCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(false, false, "-b2", null);
                var result = StringCase.SnakeCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "abc123def");
            }
        }

        public
        class NonAlphabetsAsHeadOfWordAndWithKeptCharacters
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, false, null, "-_");
                var result = StringCase.SnakeCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "", "-_");
                var result = StringCase.SnakeCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, false, null, "_");
                result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc__def__ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, false, null, "-");
                result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc_-def_-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, false, null, "-");
                result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc_-_def_-_ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, false, null, "_");
                result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc__def__ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, false, null, "-");
                result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc_-def_-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc_123_456def_g_89hi_jkl_mn_12");

                opts = new Options(true, false, null, "-");
                result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc_123-456def_g_89hi_jkl_mn_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, null, ".~!#%?");
                var result = StringCase.SnakeCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc_~!_def_#_ghi_%_jk_lm_no_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.SnakeCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc_456def");

                result = StringCase.SnakeCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc_456def");

                result = StringCase.SnakeCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_abc_456_def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, "-_");
                var result = StringCase.SnakeCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public
        class NonAlphabetsAsTailOfWordAndWithKeptCharacters
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, true, null, "-_");
                var result = StringCase.SnakeCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "", "-_");
                var result = StringCase.SnakeCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, null, "-");
                var result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, true, null, "_");
                result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc__def__ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, true, null, "-");
                result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-_def-_ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, true, null, "-");
                result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-_def-_ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, null, "-");
                var result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, true, null, "_");
                result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc__def__ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, true, null, "-");
                result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-_def-_ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123_456_def_g89_hi_jkl_mn12");

                opts = new Options(false, true, null, "-");
                result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456_def_g89_hi_jkl_mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, null, ".~!#%?");
                var result = StringCase.SnakeCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "._abc~!_def#_ghi%_jk_lm_no_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.SnakeCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_abc456_def");

                result = StringCase.SnakeCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_abc456_def");

                result = StringCase.SnakeCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_abc456_def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, null, "-_");
                var result = StringCase.SnakeCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public
        class NonAlphabetsAsWordAndWithKeptCharacters
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, true, null, "-_");
                var result = StringCase.SnakeCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "", "-_");
                var result = StringCase.SnakeCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, null, "-");
                var result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, true, null, "_");
                result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc___def___ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, true, null, "-");
                result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc_-_def_-_ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, true, null, "-");
                result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc_-_def_-_ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, null, "-");
                var result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, true, null, "_");
                result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc___def___ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(true, true, null, "-");
                result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc_-_def_-_ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc_123_456_def_g_89_hi_jkl_mn_12");

                opts = new Options(true, true, null, "-");
                result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc_123-456_def_g_89_hi_jkl_mn_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, null, ".~!#%?");
                var result = StringCase.SnakeCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "._abc_~!_def_#_ghi_%_jk_lm_no_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, null, "-_");
                var result = StringCase.SnakeCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_abc_456_def");

                result = StringCase.SnakeCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_abc_456_def");

                result = StringCase.SnakeCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_abc_456_def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, null, "-_");
                var result = StringCase.SnakeCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public
        class NonAlphabetsAsPartOfWordAndWithKeptCharacters
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, false, null, "-_");
                var result = StringCase.SnakeCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "", "-_");
                var result = StringCase.SnakeCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abc_def_gh_ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, null, "-");
                var result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, false, null, "_");
                result = StringCase.SnakeCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, false, null, "-");
                result = StringCase.SnakeCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, false, null, "-");
                result = StringCase.SnakeCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-_def-_ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, null, "-");
                var result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, false, null, "_");
                result = StringCase.SnakeCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc_def_ghi");

                opts = new Options(false, false, null, "-");
                result = StringCase.SnakeCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123_456def_g89hi_jkl_mn12");

                opts = new Options(false, false, null, "-");
                result = StringCase.SnakeCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456def_g89hi_jkl_mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, null, ".~!#%?");
                var result = StringCase.SnakeCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc~!_def#_ghi%_jk_lm_no_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, null, "-_");
                var result = StringCase.SnakeCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.SnakeCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.SnakeCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_abc456_def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, null, "-_");
                var result = StringCase.SnakeCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }
    }
}
