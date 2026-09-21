namespace StringCase.Tests;

public class StringCase_AdaCaseTest
{

    public
    class AdaCase
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var result = StringCase.AdaCase("abcDefGHIjk");
            Assert.Equal(result, "Abc_Def_Gh_Ijk");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var result = StringCase.AdaCase("AbcDefGHIjk");
            Assert.Equal(result, "Abc_Def_Gh_Ijk");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var result = StringCase.AdaCase("abc_def_ghi");
            Assert.Equal(result, "Abc_Def_Ghi");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var result = StringCase.AdaCase("abc-def-ghi");
            Assert.Equal(result, "Abc_Def_Ghi");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var result = StringCase.AdaCase("Abc-Def-Ghi");
            Assert.Equal(result, "Abc_Def_Ghi");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var result = StringCase.AdaCase("ABC_DEF_GHI");
            Assert.Equal(result, "Abc_Def_Ghi");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var result = StringCase.AdaCase("ABC-DEF-GHI");
            Assert.Equal(result, "Abc_Def_Ghi");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var result = StringCase.AdaCase("abc123-456defG89HIJklMN12");
            Assert.Equal(result, "Abc123_456_Def_G89_Hi_Jkl_Mn12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var result = StringCase.AdaCase(":.abc~!@def#$ghi%&jk(lm)no/?");
            Assert.Equal(result, "Abc_Def_Ghi_Jk_Lm_No");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var result = StringCase.AdaCase("123abc456def");
            Assert.Equal(result, "123_Abc456_Def");

            result = StringCase.AdaCase("123ABC456DEF");
            Assert.Equal(result, "123_Abc456_Def");

            result = StringCase.AdaCase("123Abc456Def");
            Assert.Equal(result, "123_Abc456_Def");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var result = StringCase.AdaCase("");
            Assert.Equal(result, "");
        }
    }

    public
    class AdaCaseWithOptions
    {
        public
        class NonAlphabetsAsHeadOfWord
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.AdaCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "", "");
                var result = StringCase.AdaCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc_123_456def_G_89hi_Jkl_Mn_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.AdaCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "Abc_Def_Ghi_Jk_Lm_No");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.AdaCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc_456def");

                result = StringCase.AdaCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc_456def");

                result = StringCase.AdaCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_Abc_456_Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.AdaCaseWithOptions("", opts);
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
                var result = StringCase.AdaCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "", "");
                var result = StringCase.AdaCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123_456_Def_G89_Hi_Jkl_Mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.AdaCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "Abc_Def_Ghi_Jk_Lm_No");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.AdaCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_Abc456_Def");

                result = StringCase.AdaCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_Abc456_Def");

                result = StringCase.AdaCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_Abc456_Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.AdaCaseWithOptions("", opts);
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
                var result = StringCase.AdaCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "", "");
                var result = StringCase.AdaCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc_123_456_Def_G_89_Hi_Jkl_Mn_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.AdaCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "Abc_Def_Ghi_Jk_Lm_No");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.AdaCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_Abc_456_Def");

                result = StringCase.AdaCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_Abc_456_Def");

                result = StringCase.AdaCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_Abc_456_Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.AdaCaseWithOptions("", opts);
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
                var result = StringCase.AdaCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "", "");
                var result = StringCase.AdaCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123_456def_G89hi_Jkl_Mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.AdaCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "Abc_Def_Ghi_Jk_Lm_No");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.AdaCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.AdaCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.AdaCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_Abc456_Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.AdaCaseWithOptions("", opts);
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
                var result = StringCase.AdaCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "-_", "");
                var result = StringCase.AdaCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, "_", null);
                var result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, false, "-", null);
                result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc__def__ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, false, "_", null);
                result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc_-def_-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, false, "_", null);
                result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc_-_Def_-_Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, "_", null);
                var result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, false, "-", null);
                result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc__def__ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, false, "_", null);
                result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc_-def_-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc_123_456def_G_89hi_Jkl_Mn_12");

                opts = new Options(true, false, "_", null);
                result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc_123-456def_G_89hi_Jkl_Mn_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, ":@$&()/", null);
                var result = StringCase.AdaCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc_~!_Def_#_Ghi_%_Jk_Lm_No_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.AdaCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc_456def");

                result = StringCase.AdaCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc_456def");

                result = StringCase.AdaCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_Abc_456_Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.AdaCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void alphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(true, false, "-b2", null);
                var result = StringCase.AdaCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "Abc_123def");
            }
        }

        public
        class NonAlphabetsAsTailOfWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, true, "-_", null);
                var result = StringCase.AdaCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "-_", "");
                var result = StringCase.AdaCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, "_", null);
                var result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, true, "-", null);
                result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc__Def__Ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, true, "_", null);
                result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc-_Def-_Ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, true, "_", null);
                result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc-_Def-_Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, "_", null);
                var result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, true, "-", null);
                result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc__Def__Ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, true, "_", null);
                result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc-_Def-_Ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123_456_Def_G89_Hi_Jkl_Mn12");

                opts = new Options(false, true, "_", null);
                result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123-456_Def_G89_Hi_Jkl_Mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, ":@$&()/", null);
                var result = StringCase.AdaCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "._Abc~!_Def#_Ghi%_Jk_Lm_No_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.AdaCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_Abc456_Def");

                result = StringCase.AdaCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_Abc456_Def");

                result = StringCase.AdaCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_Abc456_Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, "-_", null);
                var result = StringCase.AdaCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void alphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(false, true, "-b2", null);
                var result = StringCase.AdaCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "Abc123_Def");
            }
        }

        public
        class NonAlphabetsAsWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.AdaCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "-_", "");
                var result = StringCase.AdaCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, "_", null);
                var result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, true, "-", null);
                result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc___Def___Ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, true, "_", null);
                result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc_-_Def_-_Ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, true, "_", null);
                result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc_-_Def_-_Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, "_", null);
                var result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, true, "-", null);
                result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc___Def___Ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, true, "_", null);
                result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc_-_Def_-_Ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc_123_456_Def_G_89_Hi_Jkl_Mn_12");

                opts = new Options(true, true, "_", null);
                result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc_123-456_Def_G_89_Hi_Jkl_Mn_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, ":@$&()/", null);
                var result = StringCase.AdaCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "._Abc_~!_Def_#_Ghi_%_Jk_Lm_No_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.AdaCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_Abc_456_Def");

                result = StringCase.AdaCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_Abc_456_Def");

                result = StringCase.AdaCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_Abc_456_Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.AdaCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void alphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(true, true, "-b2", null);
                var result = StringCase.AdaCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "Abc_123_Def");
            }
        }

        public
        class NonAlphabetsAsPartOfWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.AdaCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "-_", "");
                var result = StringCase.AdaCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, "_", null);
                var result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, false, "-", null);
                result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, false, "_", null);
                result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, false, "_", null);
                result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc-_Def-_Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, "_", null);
                var result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, false, "-", null);
                result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, false, "_", null);
                result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123_456def_G89hi_Jkl_Mn12");

                opts = new Options(false, false, "_", null);
                result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123-456def_G89hi_Jkl_Mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, ":@$&()/", null);
                var result = StringCase.AdaCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc~!_Def#_Ghi%_Jk_Lm_No_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.AdaCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.AdaCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.AdaCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_Abc456_Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.AdaCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void alphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(false, false, "-b2", null);
                var result = StringCase.AdaCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "Abc123def");
            }
        }

        public
        class NonAlphabetsAsHeadOfWordAndWithKeptCharacters
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, false, null, "-_");
                var result = StringCase.AdaCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "", "-_");
                var result = StringCase.AdaCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, false, null, "_");
                result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc__def__ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, false, null, "-");
                result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc_-def_-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, false, null, "-");
                result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc_-_Def_-_Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, false, null, "_");
                result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc__def__ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, false, null, "-");
                result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc_-def_-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc_123_456def_G_89hi_Jkl_Mn_12");

                opts = new Options(true, false, null, "-");
                result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc_123-456def_G_89hi_Jkl_Mn_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, null, ".~!#%?");
                var result = StringCase.AdaCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc_~!_Def_#_Ghi_%_Jk_Lm_No_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.AdaCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc_456def");

                result = StringCase.AdaCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc_456def");

                result = StringCase.AdaCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_Abc_456_Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, "-_");
                var result = StringCase.AdaCaseWithOptions("", opts);
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
                var result = StringCase.AdaCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "", "-_");
                var result = StringCase.AdaCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, null, "-");
                var result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, true, null, "_");
                result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc__Def__Ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, true, null, "-");
                result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc-_Def-_Ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, true, null, "-");
                result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc-_Def-_Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, null, "-");
                var result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, true, null, "_");
                result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc__Def__Ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, true, null, "-");
                result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc-_Def-_Ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123_456_Def_G89_Hi_Jkl_Mn12");

                opts = new Options(false, true, null, "-");
                result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123-456_Def_G89_Hi_Jkl_Mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, null, ".~!#%?");
                var result = StringCase.AdaCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "._Abc~!_Def#_Ghi%_Jk_Lm_No_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.AdaCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_Abc456_Def");

                result = StringCase.AdaCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_Abc456_Def");

                result = StringCase.AdaCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_Abc456_Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, null, "-_");
                var result = StringCase.AdaCaseWithOptions("", opts);
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
                var result = StringCase.AdaCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "", "-_");
                var result = StringCase.AdaCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, null, "-");
                var result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, true, null, "_");
                result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc___Def___Ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, true, null, "-");
                result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc_-_Def_-_Ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, true, null, "-");
                result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc_-_Def_-_Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, null, "-");
                var result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, true, null, "_");
                result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc___Def___Ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(true, true, null, "-");
                result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc_-_Def_-_Ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc_123_456_Def_G_89_Hi_Jkl_Mn_12");

                opts = new Options(true, true, null, "-");
                result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc_123-456_Def_G_89_Hi_Jkl_Mn_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, null, ".~!#%?");
                var result = StringCase.AdaCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "._Abc_~!_Def_#_Ghi_%_Jk_Lm_No_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, null, "-_");
                var result = StringCase.AdaCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_Abc_456_Def");

                result = StringCase.AdaCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_Abc_456_Def");

                result = StringCase.AdaCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_Abc_456_Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, null, "-_");
                var result = StringCase.AdaCaseWithOptions("", opts);
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
                var result = StringCase.AdaCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "", "-_");
                var result = StringCase.AdaCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "Abc_Def_Gh_Ijk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, null, "-");
                var result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, false, null, "_");
                result = StringCase.AdaCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, false, null, "-");
                result = StringCase.AdaCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, false, null, "-");
                result = StringCase.AdaCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc-_Def-_Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, null, "-");
                var result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, false, null, "_");
                result = StringCase.AdaCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");

                opts = new Options(false, false, null, "-");
                result = StringCase.AdaCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123_456def_G89hi_Jkl_Mn12");

                opts = new Options(false, false, null, "-");
                result = StringCase.AdaCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123-456def_G89hi_Jkl_Mn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, null, ".~!#%?");
                var result = StringCase.AdaCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc~!_Def#_Ghi%_Jk_Lm_No_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, null, "-_");
                var result = StringCase.AdaCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.AdaCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.AdaCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_Abc456_Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, null, "-_");
                var result = StringCase.AdaCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }
    }
}
