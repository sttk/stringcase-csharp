namespace StringCase.Tests;

public class StringCase_PascalCaseTest
{
    public
    class PascalCase
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var result = StringCase.PascalCase("abcDefGHIjk");
            Assert.Equal(result, "AbcDefGhIjk");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var result = StringCase.PascalCase("AbcDefGHIjk");
            Assert.Equal(result, "AbcDefGhIjk");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var result = StringCase.PascalCase("abc_def_ghi");
            Assert.Equal(result, "AbcDefGhi");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var result = StringCase.PascalCase("abc-def-ghi");
            Assert.Equal(result, "AbcDefGhi");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var result = StringCase.PascalCase("Abc-Def-Ghi");
            Assert.Equal(result, "AbcDefGhi");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var result = StringCase.PascalCase("ABC_DEF_GHI");
            Assert.Equal(result, "AbcDefGhi");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var result = StringCase.PascalCase("ABC-DEF-GHI");
            Assert.Equal(result, "AbcDefGhi");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var result = StringCase.PascalCase("abc123-456defG89HIJklMN12");
            Assert.Equal(result, "Abc123456DefG89HiJklMn12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var result = StringCase.PascalCase(":.abc~!@def#$ghi%&jk(lm)no/?");
            Assert.Equal(result, "AbcDefGhiJkLmNo");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var result = StringCase.PascalCase("123abc456def");
            Assert.Equal(result, "123Abc456Def");

            result = StringCase.PascalCase("123ABC456DEF");
            Assert.Equal(result, "123Abc456Def");

            result = StringCase.PascalCase("123Abc456Def");
            Assert.Equal(result, "123Abc456Def");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var result = StringCase.PascalCase("");
            Assert.Equal(result, "");
        }
    }

    public
    class PascalCaseWithOptions
    {
        public
        class NonAlphabetsAsHeadOfWord
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.PascalCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "", "");
                var result = StringCase.PascalCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123456defG89hiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.PascalCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "AbcDefGhiJkLmNo");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.PascalCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.PascalCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.PascalCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.PascalCaseWithOptions("", opts);
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
                var result = StringCase.PascalCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "", "");
                var result = StringCase.PascalCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123456DefG89HiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.PascalCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "AbcDefGhiJkLmNo");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.PascalCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.PascalCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.PascalCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.PascalCaseWithOptions("", opts);
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
                var result = StringCase.PascalCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "", "");
                var result = StringCase.PascalCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123456DefG89HiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.PascalCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "AbcDefGhiJkLmNo");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.PascalCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.PascalCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.PascalCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.PascalCaseWithOptions("", opts);
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
                var result = StringCase.PascalCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "", "");
                var result = StringCase.PascalCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "AbcDefGhi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123456defG89hiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.PascalCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "AbcDefGhiJkLmNo");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.PascalCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.PascalCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.PascalCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.PascalCaseWithOptions("", opts);
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
                var result = StringCase.PascalCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "-_", "");
                var result = StringCase.PascalCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, "_", null);
                var result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, false, "-", null);
                result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, false, "_", null);
                result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, false, "_", null);
                result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc-Def-Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, "_", null);
                var result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, false, "-", null);
                result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, false, "_", null);
                result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123456defG89hiJklMn12");

                opts = new Options(true, false, "_", null);
                result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123-456defG89hiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, ":@$&()/", null);
                var result = StringCase.PascalCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc~!Def#Ghi%JkLmNo?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.PascalCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.PascalCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.PascalCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.PascalCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(true, false, "-b2", null);
                var result = StringCase.PascalCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "Abc123def");
            }
        }

        public
        class NonAlphabetsAsTailOfWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, true, "-_", null);
                var result = StringCase.PascalCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "-_", "");
                var result = StringCase.PascalCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, "_", null);
                var result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, true, "-", null);
                result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, true, "_", null);
                result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc-Def-Ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, true, "_", null);
                result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc-Def-Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, "_", null);
                var result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, true, "-", null);
                result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, true, "_", null);
                result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc-Def-Ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123456DefG89HiJklMn12");

                opts = new Options(false, true, "_", null);
                result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123-456DefG89HiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, ":@$&()/", null);
                var result = StringCase.PascalCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".Abc~!Def#Ghi%JkLmNo?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.PascalCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.PascalCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.PascalCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, "-_", null);
                var result = StringCase.PascalCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(false, true, "-b2", null);
                var result = StringCase.PascalCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "Abc123Def");
            }
        }

        public
        class NonAlphabetsAsWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.PascalCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "-_", "");
                var result = StringCase.PascalCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, "_", null);
                var result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, true, "-", null);
                result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, true, "_", null);
                result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc-Def-Ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, true, "_", null);
                result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc-Def-Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, "_", null);
                var result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, true, "-", null);
                result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, true, "_", null);
                result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc-Def-Ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123456DefG89HiJklMn12");

                opts = new Options(true, true, "_", null);
                result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123-456DefG89HiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, ":@$&()/", null);
                var result = StringCase.PascalCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".Abc~!Def#Ghi%JkLmNo?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.PascalCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.PascalCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.PascalCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.PascalCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(true, true, "-b2", null);
                var result = StringCase.PascalCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "Abc123Def");
            }
        }

        public
        class NonAlphabetsAsPartOfWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.PascalCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "-_", "");
                var result = StringCase.PascalCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, "_", null);
                var result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, false, "-", null);
                result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, false, "_", null);
                result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, false, "_", null);
                result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc-Def-Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, "_", null);
                var result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, false, "-", null);
                result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, false, "_", null);
                result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123456defG89hiJklMn12");

                opts = new Options(false, false, "_", null);
                result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123-456defG89hiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, ":@$&()/", null);
                var result = StringCase.PascalCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc~!Def#Ghi%JkLmNo?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.PascalCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.PascalCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.PascalCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.PascalCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(false, false, "-b2", null);
                var result = StringCase.PascalCaseWithOptions("abc123def", opts);
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
                var result = StringCase.PascalCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "", "-_");
                var result = StringCase.PascalCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, false, null, "_");
                result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, false, null, "-");
                result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, false, null, "-");
                result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc-Def-Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, false, null, "_");
                result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, false, null, "-");
                result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123456defG89hiJklMn12");

                opts = new Options(true, false, null, "-");
                result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123-456defG89hiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, null, ".~!#%?");
                var result = StringCase.PascalCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc~!Def#Ghi%JkLmNo?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.PascalCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.PascalCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.PascalCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, "-_");
                var result = StringCase.PascalCaseWithOptions("", opts);
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
                var result = StringCase.PascalCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "", "-_");
                var result = StringCase.PascalCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, null, "-");
                var result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, true, null, "_");
                result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, true, null, "-");
                result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc-Def-Ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, true, null, "-");
                result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc-Def-Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, null, "-");
                var result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, true, null, "_");
                result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, true, null, "-");
                result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc-Def-Ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123456DefG89HiJklMn12");

                opts = new Options(false, true, null, "-");
                result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123-456DefG89HiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, null, ".~!#%?");
                var result = StringCase.PascalCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".Abc~!Def#Ghi%JkLmNo?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.PascalCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.PascalCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.PascalCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, null, "-_");
                var result = StringCase.PascalCaseWithOptions("", opts);
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
                var result = StringCase.PascalCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "", "-_");
                var result = StringCase.PascalCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, null, "-");
                var result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, true, null, "_");
                result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, true, null, "-");
                result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc-Def-Ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, true, null, "-");
                result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc-Def-Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, null, "-");
                var result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, true, null, "_");
                result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_Def_Ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(true, true, null, "-");
                result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc-Def-Ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123456DefG89HiJklMn12");

                opts = new Options(true, true, null, "-");
                result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123-456DefG89HiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, null, ".~!#%?");
                var result = StringCase.PascalCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".Abc~!Def#Ghi%JkLmNo?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, null, "-_");
                var result = StringCase.PascalCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.PascalCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.PascalCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, null, "-_");
                var result = StringCase.PascalCaseWithOptions("", opts);
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
                var result = StringCase.PascalCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "", "-_");
                var result = StringCase.PascalCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "AbcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, null, "-");
                var result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, false, null, "_");
                result = StringCase.PascalCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "Abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, false, null, "-");
                result = StringCase.PascalCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "Abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, false, null, "-");
                result = StringCase.PascalCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "Abc-Def-Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, null, "-");
                var result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, false, null, "_");
                result = StringCase.PascalCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "Abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "AbcDefGhi");

                opts = new Options(false, false, null, "-");
                result = StringCase.PascalCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "Abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123456defG89hiJklMn12");

                opts = new Options(false, false, null, "-");
                result = StringCase.PascalCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "Abc123-456defG89hiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, null, ".~!#%?");
                var result = StringCase.PascalCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc~!Def#Ghi%JkLmNo?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, null, "-_");
                var result = StringCase.PascalCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.PascalCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.PascalCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, null, "-_");
                var result = StringCase.PascalCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }
    }
}
