namespace StringCase.Tests;

public class StringCase_CamelCaseTest
{
    public class CamelCase
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var result = StringCase.CamelCase("abcDefGHIjk");
            Assert.Equal(result, "abcDefGhIjk");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var result = StringCase.CamelCase("AbcDefGHIjk");
            Assert.Equal(result, "abcDefGhIjk");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var result = StringCase.CamelCase("abc_def_ghi");
            Assert.Equal(result, "abcDefGhi");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var result = StringCase.CamelCase("abc-def-ghi");
            Assert.Equal(result, "abcDefGhi");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var result = StringCase.CamelCase("Abc-Def-Ghi");
            Assert.Equal(result, "abcDefGhi");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var result = StringCase.CamelCase("ABC_DEF_GHI");
            Assert.Equal(result, "abcDefGhi");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var result = StringCase.CamelCase("ABC-DEF-GHI");
            Assert.Equal(result, "abcDefGhi");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var result = StringCase.CamelCase("abc123-456defG89HIJklMN12");
            Assert.Equal(result, "abc123456DefG89HiJklMn12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var result = StringCase.CamelCase(":.abc~!@def#$ghi%&jk(lm)no/?");
            Assert.Equal(result, "abcDefGhiJkLmNo");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var result = StringCase.CamelCase("123abc456def");
            Assert.Equal(result, "123Abc456Def");

            result = StringCase.CamelCase("123ABC456DEF");
            Assert.Equal(result, "123Abc456Def");

            result = StringCase.CamelCase("123Abc456Def");
            Assert.Equal(result, "123Abc456Def");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var result = StringCase.CamelCase("");
            Assert.Equal(result, "");
        }
    }

    public class CamelCaseWithOptions
    {
        public class NonAlphabetsAsHeadOfWord
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.CamelCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "", "");
                var result = StringCase.CamelCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123456defG89hiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.CamelCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "abcDefGhiJkLmNo");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.CamelCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.CamelCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.CamelCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.CamelCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public class NonAlphabetsAsTailOfWord
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.CamelCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "", "");
                var result = StringCase.CamelCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123456DefG89HiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.CamelCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "abcDefGhiJkLmNo");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.CamelCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.CamelCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.CamelCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, null, null);
                var result = StringCase.CamelCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public class NonAlphabetsAsWord
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.CamelCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "", "");
                var result = StringCase.CamelCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123456DefG89HiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.CamelCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "abcDefGhiJkLmNo");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.CamelCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.CamelCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.CamelCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, null, null);
                var result = StringCase.CamelCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public class NonAlphabetsPartAsWord
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.CamelCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "", "");
                var result = StringCase.CamelCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abcDefGhi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123456defG89hiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.CamelCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, "abcDefGhiJkLmNo");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.CamelCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.CamelCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.CamelCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, null, null);
                var result = StringCase.CamelCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public class NonAlphabetsAsHeadOfWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, false, "-_", null);
                var result = StringCase.CamelCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "-_", "");
                var result = StringCase.CamelCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, "_", null);
                var result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, false, "-", null);
                result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, false, "_", null);
                result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, false, "_", null);
                result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-Def-Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, "_", null);
                var result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, false, "-", null);
                result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, false, "_", null);
                result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123456defG89hiJklMn12");

                opts = new Options(true, false, "_", null);
                result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456defG89hiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, ":@$&()/", null);
                var result = StringCase.CamelCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc~!Def#Ghi%JkLmNo?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, "-", null);
                var result = StringCase.CamelCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.CamelCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.CamelCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, null);
                var result = StringCase.CamelCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(true, false, "-b2", null);
                var result = StringCase.CamelCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "abc123def");
            }
        }

        public class NonAlphabetsAsTailOfWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, true, "-_", null);
                var result = StringCase.CamelCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "-_", "");
                var result = StringCase.CamelCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, "_", null);
                var result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, true, "-", null);
                result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_Def_Ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, true, "_", null);
                result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-Def-Ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, true, "_", null);
                result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-Def-Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, "_", null);
                var result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, true, "-", null);
                result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_Def_Ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, true, "_", null);
                result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-Def-Ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123456DefG89HiJklMn12");

                opts = new Options(false, true, "_", null);
                result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456DefG89HiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, ":@$&()/", null);
                var result = StringCase.CamelCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".Abc~!Def#Ghi%JkLmNo?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, "-", null);
                var result = StringCase.CamelCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.CamelCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.CamelCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, "-_", null);
                var result = StringCase.CamelCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(false, true, "-b2", null);
                var result = StringCase.CamelCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "abc123Def");
            }
        }

        public class NonAlphabetsAsWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.CamelCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "-_", "");
                var result = StringCase.CamelCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, "_", null);
                var result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, true, "-", null);
                result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_Def_Ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, true, "_", null);
                result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-Def-Ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, true, "_", null);
                result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-Def-Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, "_", null);
                var result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, true, "-", null);
                result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_Def_Ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, true, "_", null);
                result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-Def-Ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, "-", null);
                var result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123456DefG89HiJklMn12");

                opts = new Options(true, true, "_", null);
                result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456DefG89HiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, ":@$&()/", null);
                var result = StringCase.CamelCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".Abc~!Def#Ghi%JkLmNo?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.CamelCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.CamelCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.CamelCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, "-_", null);
                var result = StringCase.CamelCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(true, true, "-b2", null);
                var result = StringCase.CamelCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "abc123Def");
            }
        }

        public class NonAlphabetsAsPartOfWordAndWithSeparators
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.CamelCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "-_", "");
                var result = StringCase.CamelCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, "_", null);
                var result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, false, "-", null);
                result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, false, "_", null);
                result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, false, "_", null);
                result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-Def-Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, "_", null);
                var result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, false, "-", null);
                result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, false, "_", null);
                result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, "-", null);
                var result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123456defG89hiJklMn12");

                opts = new Options(false, false, "_", null);
                result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456defG89hiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, ":@$&()/", null);
                var result = StringCase.CamelCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc~!Def#Ghi%JkLmNo?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.CamelCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.CamelCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.CamelCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, "-_", null);
                var result = StringCase.CamelCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }

            [Fact]
            public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
            {
                var opts = new Options(false, false, "-b2", null);
                var result = StringCase.CamelCaseWithOptions("abc123def", opts);
                Assert.Equal(result, "abc123def");
            }
        }

        public class NonAlphabetsAsHeadOfWordAndWithKeptCharacters
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, false, null, "-_");
                var result = StringCase.CamelCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, false, "", "-_");
                var result = StringCase.CamelCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, false, null, "_");
                result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, false, null, "-");
                result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, false, null, "-");
                result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-Def-Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, false, null, "_");
                result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, false, null, "-");
                result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, false, null, "_");
                var result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123456defG89hiJklMn12");

                opts = new Options(true, false, null, "-");
                result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456defG89hiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, false, null, ".~!#%?");
                var result = StringCase.CamelCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc~!Def#Ghi%JkLmNo?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, false, null, "-");
                var result = StringCase.CamelCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.CamelCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.CamelCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, false, null, "-_");
                var result = StringCase.CamelCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public class NonAlphabetsAsTailOfWordAndWithKeptCharacters
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, true, null, "-_");
                var result = StringCase.CamelCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, true, "", "-_");
                var result = StringCase.CamelCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, true, null, "-");
                var result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, true, null, "_");
                result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_Def_Ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, true, null, "-");
                result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-Def-Ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, true, null, "-");
                result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-Def-Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, true, null, "-");
                var result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, true, null, "_");
                result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_Def_Ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, true, null, "-");
                result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-Def-Ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123456DefG89HiJklMn12");

                opts = new Options(false, true, null, "-");
                result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456DefG89HiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, true, null, ".~!#%?");
                var result = StringCase.CamelCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".Abc~!Def#Ghi%JkLmNo?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, true, null, "_");
                var result = StringCase.CamelCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.CamelCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.CamelCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, true, null, "-_");
                var result = StringCase.CamelCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public class NonAlphabetsAsWordAndWithKeptCharacters
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(true, true, null, "-_");
                var result = StringCase.CamelCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(true, true, "", "-_");
                var result = StringCase.CamelCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(true, true, null, "-");
                var result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, true, null, "_");
                result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_Def_Ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, true, null, "-");
                result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-Def-Ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, true, null, "-");
                result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-Def-Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(true, true, null, "-");
                var result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, true, null, "_");
                result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_Def_Ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(true, true, null, "-");
                result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-Def-Ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(true, true, null, "_");
                var result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123456DefG89HiJklMn12");

                opts = new Options(true, true, null, "-");
                result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456DefG89HiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(true, true, null, ".~!#%?");
                var result = StringCase.CamelCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".Abc~!Def#Ghi%JkLmNo?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(true, true, null, "-_");
                var result = StringCase.CamelCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.CamelCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123Abc456Def");

                result = StringCase.CamelCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(true, true, null, "-_");
                var result = StringCase.CamelCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }

        public class NonAlphabetsAsPartOfWordAndWithKeptCharacters
        {
            [Fact]
            public void ConvertCamelCase()
            {
                var opts = new Options(false, false, null, "-_");
                var result = StringCase.CamelCaseWithOptions("abcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertPascalCase()
            {
                var opts = new Options(false, false, "", "-_");
                var result = StringCase.CamelCaseWithOptions("AbcDefGHIjk", opts);
                Assert.Equal(result, "abcDefGhIjk");
            }

            [Fact]
            public void ConvertSnakeCase()
            {
                var opts = new Options(false, false, null, "-");
                var result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, false, null, "_");
                result = StringCase.CamelCaseWithOptions("abc_def_ghi", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertKebabCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, false, null, "-");
                result = StringCase.CamelCaseWithOptions("abc-def-ghi", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertTrainCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, false, null, "-");
                result = StringCase.CamelCaseWithOptions("Abc-Def-Ghi", opts);
                Assert.Equal(result, "abc-Def-Ghi");
            }

            [Fact]
            public void ConvertMacroCase()
            {
                var opts = new Options(false, false, null, "-");
                var result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, false, null, "_");
                result = StringCase.CamelCaseWithOptions("ABC_DEF_GHI", opts);
                Assert.Equal(result, "abc_def_ghi");
            }

            [Fact]
            public void ConvertCobolCase()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abcDefGhi");

                opts = new Options(false, false, null, "-");
                result = StringCase.CamelCaseWithOptions("ABC-DEF-GHI", opts);
                Assert.Equal(result, "abc-def-ghi");
            }

            [Fact]
            public void ConvertWithKeepingDigits()
            {
                var opts = new Options(false, false, null, "_");
                var result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123456defG89hiJklMn12");

                opts = new Options(false, false, null, "-");
                result = StringCase.CamelCaseWithOptions("abc123-456defG89HIJklMN12", opts);
                Assert.Equal(result, "abc123-456defG89hiJklMn12");
            }

            [Fact]
            public void ConvertWithSymbolsAsSeparators()
            {
                var opts = new Options(false, false, null, ".~!#%?");
                var result = StringCase.CamelCaseWithOptions(":.abc~!@def#$ghi%&jk(lm)no/?", opts);
                Assert.Equal(result, ".abc~!Def#Ghi%JkLmNo?");
            }

            [Fact]
            public void ConvertWhenStartingWithDigit()
            {
                var opts = new Options(false, false, null, "-_");
                var result = StringCase.CamelCaseWithOptions("123abc456def", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.CamelCaseWithOptions("123ABC456DEF", opts);
                Assert.Equal(result, "123abc456def");

                result = StringCase.CamelCaseWithOptions("123Abc456Def", opts);
                Assert.Equal(result, "123Abc456Def");
            }

            [Fact]
            public void ConvertAnEmptyString()
            {
                var opts = new Options(false, false, null, "-_");
                var result = StringCase.CamelCaseWithOptions("", opts);
                Assert.Equal(result, "");
            }
        }
    }
}
