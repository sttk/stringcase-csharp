namespace StringCase.Tests;

public class StringCase_MacroCaseTest
{
    public
    class MacroCase
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var result = StringCase.MacroCase("abcDefGHIjk");
            Assert.Equal(result, "ABC_DEF_GH_IJK");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var result = StringCase.MacroCase("AbcDefGHIjk");
            Assert.Equal(result, "ABC_DEF_GH_IJK");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var result = StringCase.MacroCase("abc_def_ghi");
            Assert.Equal(result, "ABC_DEF_GHI");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var result = StringCase.MacroCase("abc-def-ghi");
            Assert.Equal(result, "ABC_DEF_GHI");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var result = StringCase.MacroCase("Abc-Def-Ghi");
            Assert.Equal(result, "ABC_DEF_GHI");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var result = StringCase.MacroCase("ABC_DEF_GHI");
            Assert.Equal(result, "ABC_DEF_GHI");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var result = StringCase.MacroCase("ABC-DEF-GHI");
            Assert.Equal(result, "ABC_DEF_GHI");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var result = StringCase.MacroCase("abc123-456defG89HIJklMN12");
            Assert.Equal(result, "ABC123_456_DEF_G89_HI_JKL_MN12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var result = StringCase.MacroCase(":.abc~!@def#$ghi%&jk(lm)no/?");
            Assert.Equal(result, "ABC_DEF_GHI_JK_LM_NO");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var result = StringCase.MacroCase("123abc456def");
            Assert.Equal(result, "123_ABC456_DEF");

            result = StringCase.MacroCase("123ABC456DEF");
            Assert.Equal(result, "123_ABC456_DEF");

            result = StringCase.MacroCase("123Abc456Def");
            Assert.Equal(result, "123_ABC456_DEF");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var result = StringCase.MacroCase("");
            Assert.Equal(result, "");
        }
    }

    public
    class MacroCaseWithOptions
    {
        public
        class NonAlphabetsAsHeadOfWord
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.MacroCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "", "");
                var result = StringCase.MacroCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC_123_456DEF_G_89HI_JKL_MN_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.MacroCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "ABC_DEF_GHI_JK_LM_NO");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.MacroCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123ABC_456DEF");

                result = StringCase.MacroCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123ABC_456DEF");

                result = StringCase.MacroCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_ABC_456_DEF");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.MacroCaseWithOptions("", opts);
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
                var result = StringCase.MacroCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "", "");
                var result = StringCase.MacroCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC123_456_DEF_G89_HI_JKL_MN12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.MacroCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "ABC_DEF_GHI_JK_LM_NO");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.MacroCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_ABC456_DEF");

                result = StringCase.MacroCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_ABC456_DEF");

                result = StringCase.MacroCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_ABC456_DEF");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.MacroCaseWithOptions("", opts);
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
                var result = StringCase.MacroCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "", "");
                var result = StringCase.MacroCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC_123_456_DEF_G_89_HI_JKL_MN_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.MacroCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "ABC_DEF_GHI_JK_LM_NO");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.MacroCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_ABC_456_DEF");

                result = StringCase.MacroCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_ABC_456_DEF");

                result = StringCase.MacroCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_ABC_456_DEF");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.MacroCaseWithOptions("", opts);
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
                var result = StringCase.MacroCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "", "");
                var result = StringCase.MacroCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC123_456DEF_G89HI_JKL_MN12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.MacroCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "ABC_DEF_GHI_JK_LM_NO");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.MacroCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123ABC456DEF");

                result = StringCase.MacroCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123ABC456DEF");

                result = StringCase.MacroCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_ABC456_DEF");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.MacroCaseWithOptions("", opts);
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
                var result = StringCase.MacroCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "-_", "");
                var result = StringCase.MacroCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, "_", null);
                var result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, false, "-", null);
                result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC__DEF__GHI");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, false, "_", null);
                result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC_-DEF_-GHI");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, false, "_", null);
                result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC_-_DEF_-_GHI");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, "_", null);
                var result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, false, "-", null);
                result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC__DEF__GHI");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, false, "_", null);
                result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC_-DEF_-GHI");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC_123_456DEF_G_89HI_JKL_MN_12");

                opts = new Options(true, false, "_", null);
                result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC_123-456DEF_G_89HI_JKL_MN_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, ":@$&()/", null);
                var result = StringCase.MacroCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".ABC_~!_DEF_#_GHI_%_JK_LM_NO_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.MacroCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123ABC_456DEF");

                result = StringCase.MacroCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123ABC_456DEF");

                result = StringCase.MacroCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_ABC_456_DEF");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.MacroCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(true, false, "-b2", null);
                var result = StringCase.MacroCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "ABC_123DEF");
            }
        }

        public
        class NonAlphabetsAsTailOfWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, true, "-_", null);
                var result = StringCase.MacroCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "-_", "");
                var result = StringCase.MacroCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, "_", null);
                var result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, true, "-", null);
                result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC__DEF__GHI");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, true, "_", null);
                result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC-_DEF-_GHI");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, true, "_", null);
                result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC-_DEF-_GHI");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, "_", null);
                var result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, true, "-", null);
                result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC__DEF__GHI");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, true, "_", null);
                result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC-_DEF-_GHI");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC123_456_DEF_G89_HI_JKL_MN12");

                opts = new Options(false, true, "_", null);
                result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC123-456_DEF_G89_HI_JKL_MN12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, ":@$&()/", null);
                var result = StringCase.MacroCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "._ABC~!_DEF#_GHI%_JK_LM_NO_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.MacroCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_ABC456_DEF");

                result = StringCase.MacroCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_ABC456_DEF");

                result = StringCase.MacroCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_ABC456_DEF");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, "-_", null);
                var result = StringCase.MacroCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(false, true, "-b2", null);
                var result = StringCase.MacroCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "ABC123_DEF");
            }
        }

        public
        class NonAlphabetsAsWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.MacroCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "-_", "");
                var result = StringCase.MacroCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, "_", null);
                var result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, true, "-", null);
                result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC___DEF___GHI");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, true, "_", null);
                result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC_-_DEF_-_GHI");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, true, "_", null);
                result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC_-_DEF_-_GHI");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, "_", null);
                var result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, true, "-", null);
                result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC___DEF___GHI");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, true, "_", null);
                result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC_-_DEF_-_GHI");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC_123_456_DEF_G_89_HI_JKL_MN_12");

                opts = new Options(true, true, "_", null);
                result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC_123-456_DEF_G_89_HI_JKL_MN_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, ":@$&()/", null);
                var result = StringCase.MacroCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "._ABC_~!_DEF_#_GHI_%_JK_LM_NO_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.MacroCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_ABC_456_DEF");

                result = StringCase.MacroCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_ABC_456_DEF");

                result = StringCase.MacroCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_ABC_456_DEF");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.MacroCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(true, true, "-b2", null);
                var result = StringCase.MacroCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "ABC_123_DEF");
            }
        }

        public
        class NonAlphabetsAsPartOfWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.MacroCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "-_", "");
                var result = StringCase.MacroCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, "_", null);
                var result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, false, "-", null);
                result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, false, "_", null);
                result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC-DEF-GHI");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, false, "_", null);
                result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC-_DEF-_GHI");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, "_", null);
                var result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, false, "-", null);
                result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, false, "_", null);
                result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC-DEF-GHI");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC123_456DEF_G89HI_JKL_MN12");

                opts = new Options(false, false, "_", null);
                result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC123-456DEF_G89HI_JKL_MN12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, ":@$&()/", null);
                var result = StringCase.MacroCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".ABC~!_DEF#_GHI%_JK_LM_NO_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.MacroCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123ABC456DEF");

                result = StringCase.MacroCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123ABC456DEF");

                result = StringCase.MacroCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_ABC456_DEF");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.MacroCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(false, false, "-b2", null);
                var result = StringCase.MacroCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "ABC123DEF");
            }
        }

        public
        class NonAlphabetsAsHeadOfWordAndWithKeptCharacters
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, false, null, "-_");
                var result = StringCase.MacroCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "", "-_");
                var result = StringCase.MacroCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, false, null, "_");
                result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC__DEF__GHI");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, false, null, "-");
                result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC_-DEF_-GHI");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, false, null, "-");
                result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC_-_DEF_-_GHI");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, false, null, "_");
                result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC__DEF__GHI");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, false, null, "-");
                result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC_-DEF_-GHI");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC_123_456DEF_G_89HI_JKL_MN_12");

                opts = new Options(true, false, null, "-");
                result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC_123-456DEF_G_89HI_JKL_MN_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, null, ".~!#%?");
                var result = StringCase.MacroCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".ABC_~!_DEF_#_GHI_%_JK_LM_NO_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.MacroCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123ABC_456DEF");

                result = StringCase.MacroCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123ABC_456DEF");

                result = StringCase.MacroCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_ABC_456_DEF");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, "-_");
                var result = StringCase.MacroCaseWithOptions("", opts);
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
                var result = StringCase.MacroCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "", "-_");
                var result = StringCase.MacroCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, null, "-");
                var result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, true, null, "_");
                result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC__DEF__GHI");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, true, null, "-");
                result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC-_DEF-_GHI");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, true, null, "-");
                result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC-_DEF-_GHI");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, null, "-");
                var result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, true, null, "_");
                result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC__DEF__GHI");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, true, null, "-");
                result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC-_DEF-_GHI");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC123_456_DEF_G89_HI_JKL_MN12");

                opts = new Options(false, true, null, "-");
                result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC123-456_DEF_G89_HI_JKL_MN12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, null, ".~!#%?");
                var result = StringCase.MacroCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "._ABC~!_DEF#_GHI%_JK_LM_NO_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.MacroCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_ABC456_DEF");

                result = StringCase.MacroCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_ABC456_DEF");

                result = StringCase.MacroCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_ABC456_DEF");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, null, "-_");
                var result = StringCase.MacroCaseWithOptions("", opts);
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
                var result = StringCase.MacroCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "", "-_");
                var result = StringCase.MacroCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, null, "-");
                var result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, true, null, "_");
                result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC___DEF___GHI");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, true, null, "-");
                result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC_-_DEF_-_GHI");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, true, null, "-");
                result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC_-_DEF_-_GHI");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, null, "-");
                var result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, true, null, "_");
                result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC___DEF___GHI");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(true, true, null, "-");
                result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC_-_DEF_-_GHI");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC_123_456_DEF_G_89_HI_JKL_MN_12");

                opts = new Options(true, true, null, "-");
                result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC_123-456_DEF_G_89_HI_JKL_MN_12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, null, ".~!#%?");
                var result = StringCase.MacroCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "._ABC_~!_DEF_#_GHI_%_JK_LM_NO_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, null, "-_");
                var result = StringCase.MacroCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123_ABC_456_DEF");

                result = StringCase.MacroCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123_ABC_456_DEF");

                result = StringCase.MacroCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_ABC_456_DEF");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, null, "-_");
                var result = StringCase.MacroCaseWithOptions("", opts);
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
                var result = StringCase.MacroCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "", "-_");
                var result = StringCase.MacroCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "ABC_DEF_GH_IJK");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, null, "-");
                var result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, false, null, "_");
                result = StringCase.MacroCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, false, null, "-");
                result = StringCase.MacroCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "ABC-DEF-GHI");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, false, null, "-");
                result = StringCase.MacroCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "ABC-_DEF-_GHI");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, null, "-");
                var result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, false, null, "_");
                result = StringCase.MacroCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC_DEF_GHI");

                opts = new Options(false, false, null, "-");
                result = StringCase.MacroCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "ABC-DEF-GHI");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC123_456DEF_G89HI_JKL_MN12");

                opts = new Options(false, false, null, "-");
                result = StringCase.MacroCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "ABC123-456DEF_G89HI_JKL_MN12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, null, ".~!#%?");
                var result = StringCase.MacroCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".ABC~!_DEF#_GHI%_JK_LM_NO_?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, null, "-_");
                var result = StringCase.MacroCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123ABC456DEF");

                result = StringCase.MacroCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123ABC456DEF");

                result = StringCase.MacroCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123_ABC456_DEF");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, null, "-_");
                var result = StringCase.MacroCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }
    }
}
