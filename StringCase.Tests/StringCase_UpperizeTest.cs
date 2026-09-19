namespace StringCase.Tests;

public class StringCase_UpperizeTest
{
    public class NonAlphabetsAsHeadOfWord
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Upperize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(true, false, "", "");
            var result = StringCase.Upperize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void convertWithKeepingDigits()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC.123.456DEF.G.89HI.JKL.MN.12");
        }

        [Fact]
        public void convertWithSymbolsAsSeparators()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Upperize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI.JK.LM.NO");
        }

        [Fact]
        public void convertWhenStartingWithDigit()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Upperize("123abc456def", '.', opts);
            Assert.Equal(result, "123ABC.456DEF");

            result = StringCase.Upperize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123ABC.456DEF");

            result = StringCase.Upperize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.ABC.456.DEF");
        }

        [Fact]
        public void convertAnEmptyString()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Upperize("", '.', opts);
            Assert.Equal(result, "");
        }
    }

    public class NonAlphabetsAsTailOfWord
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Upperize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(false, true, "", "");
            var result = StringCase.Upperize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC123.456.DEF.G89.HI.JKL.MN12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Upperize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI.JK.LM.NO");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Upperize("123abc456def", '.', opts);
            Assert.Equal(result, "123.ABC456.DEF");

            result = StringCase.Upperize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123.ABC456.DEF");

            result = StringCase.Upperize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.ABC456.DEF");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Upperize("", '.', opts);
            Assert.Equal(result, "");
        }
    }

    public class NonAlphabetsAsWord
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Upperize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(true, true, "", "");
            var result = StringCase.Upperize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC.123.456.DEF.G.89.HI.JKL.MN.12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Upperize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI.JK.LM.NO");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Upperize("123abc456def", '.', opts);
            Assert.Equal(result, "123.ABC.456.DEF");

            result = StringCase.Upperize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123.ABC.456.DEF");

            result = StringCase.Upperize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.ABC.456.DEF");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Upperize("", '.', opts);
            Assert.Equal(result, "");
        }
    }

    public class NonAlphabetsPartAsWord
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Upperize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(false, false, "", "");
            var result = StringCase.Upperize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC123.456DEF.G89HI.JKL.MN12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Upperize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI.JK.LM.NO");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Upperize("123abc456def", '.', opts);
            Assert.Equal(result, "123ABC456DEF");

            result = StringCase.Upperize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123ABC456DEF");

            result = StringCase.Upperize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.ABC456.DEF");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Upperize("", '.', opts);
            Assert.Equal(result, "");
        }
    }

    public class NonAlphabetsAsHeadOfWordAndWithSeparators
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(true, false, "-_", null);
            var result = StringCase.Upperize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(true, false, "-_", "");
            var result = StringCase.Upperize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(true, false, "_", null);
            var result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, false, "-", null);
            result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC._DEF._GHI");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(true, false, "-", null);
            var result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, false, "_", null);
            result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC.-DEF.-GHI");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(true, false, "-", null);
            var result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, false, "_", null);
            result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC.-.DEF.-.GHI");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(true, false, "_", null);
            var result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, false, "-", null);
            result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC._DEF._GHI");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(true, false, "-", null);
            var result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, false, "_", null);
            result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC.-DEF.-GHI");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(true, false, "-", null);
            var result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC.123.456DEF.G.89HI.JKL.MN.12");

            opts = new Options(true, false, "_", null);
            result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC.123-456DEF.G.89HI.JKL.MN.12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(true, false, ":@$&()/", null);
            var result = StringCase.Upperize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, ".ABC.~!.DEF.#.GHI.%.JK.LM.NO.?");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(true, false, "-", null);
            var result = StringCase.Upperize("123abc456def", '.', opts);
            Assert.Equal(result, "123ABC.456DEF");

            result = StringCase.Upperize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123ABC.456DEF");

            result = StringCase.Upperize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.ABC.456.DEF");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Upperize("", '.', opts);
            Assert.Equal(result, "");
        }

        [Fact]
        public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
        {
            var opts = new Options(true, false, "-b2", null);
            var result = StringCase.Upperize("abc123def", '.', opts);
            Assert.Equal(result, "ABC.123DEF");
        }
    }

    public class NonAlphabetsAsTailOfWordAndWithSeparators
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(false, true, "-_", null);
            var result = StringCase.Upperize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(false, true, "-_", "");
            var result = StringCase.Upperize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(false, true, "_", null);
            var result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, true, "-", null);
            result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC_.DEF_.GHI");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(false, true, "-", null);
            var result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, true, "_", null);
            result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC-.DEF-.GHI");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(false, true, "-", null);
            var result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, true, "_", null);
            result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC-.DEF-.GHI");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(false, true, "_", null);
            var result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, true, "-", null);
            result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC_.DEF_.GHI");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(false, true, "-", null);
            var result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, true, "_", null);
            result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC-.DEF-.GHI");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(false, true, "-", null);
            var result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC123.456.DEF.G89.HI.JKL.MN12");

            opts = new Options(false, true, "_", null);
            result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC123-456.DEF.G89.HI.JKL.MN12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(false, true, ":@$&()/", null);
            var result = StringCase.Upperize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, "..ABC~!.DEF#.GHI%.JK.LM.NO.?");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(false, true, "-", null);
            var result = StringCase.Upperize("123abc456def", '.', opts);
            Assert.Equal(result, "123.ABC456.DEF");

            result = StringCase.Upperize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123.ABC456.DEF");

            result = StringCase.Upperize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.ABC456.DEF");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(false, true, "-_", null);
            var result = StringCase.Upperize("", '.', opts);
            Assert.Equal(result, "");
        }

        [Fact]
        public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
        {
            var opts = new Options(false, true, "-b2", null);
            var result = StringCase.Upperize("abc123def", '.', opts);
            Assert.Equal(result, "ABC123.DEF");
        }
    }

    public class NonAlphabetsAsWordAndWithSeparators
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(true, true, "-_", null);
            var result = StringCase.Upperize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(true, true, "-_", "");
            var result = StringCase.Upperize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(true, true, "_", null);
            var result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, true, "-", null);
            result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC._.DEF._.GHI");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(true, true, "-", null);
            var result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, true, "_", null);
            result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC.-.DEF.-.GHI");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(true, true, "-", null);
            var result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, true, "_", null);
            result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC.-.DEF.-.GHI");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(true, true, "_", null);
            var result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, true, "-", null);
            result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC._.DEF._.GHI");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(true, true, "-", null);
            var result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, true, "_", null);
            result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC.-.DEF.-.GHI");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(true, true, "-", null);
            var result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC.123.456.DEF.G.89.HI.JKL.MN.12");

            opts = new Options(true, true, "_", null);
            result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC.123-456.DEF.G.89.HI.JKL.MN.12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(true, true, ":@$&()/", null);
            var result = StringCase.Upperize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, "..ABC.~!.DEF.#.GHI.%.JK.LM.NO.?");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(true, true, "-_", null);
            var result = StringCase.Upperize("123abc456def", '.', opts);
            Assert.Equal(result, "123.ABC.456.DEF");

            result = StringCase.Upperize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123.ABC.456.DEF");

            result = StringCase.Upperize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.ABC.456.DEF");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(true, true, "-_", null);
            var result = StringCase.Upperize("", '.', opts);
            Assert.Equal(result, "");
        }

        [Fact]
        public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
        {
            var opts = new Options(true, true, "-b2", null);
            var result = StringCase.Upperize("abc123def", '.', opts);
            Assert.Equal(result, "ABC.123.DEF");
        }
    }

    public class NonAlphabetsAsPartOfWordAndWithSeparators
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(false, false, "-_", null);
            var result = StringCase.Upperize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(false, false, "-_", "");
            var result = StringCase.Upperize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(false, false, "_", null);
            var result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, false, "-", null);
            result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC_DEF_GHI");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(false, false, "-", null);
            var result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, false, "_", null);
            result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC-DEF-GHI");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(false, false, "-", null);
            var result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, false, "_", null);
            result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC-.DEF-.GHI");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(false, false, "_", null);
            var result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, false, "-", null);
            result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC_DEF_GHI");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(false, false, "-", null);
            var result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, false, "_", null);
            result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC-DEF-GHI");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(false, false, "-", null);
            var result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC123.456DEF.G89HI.JKL.MN12");

            opts = new Options(false, false, "_", null);
            result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC123-456DEF.G89HI.JKL.MN12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(false, false, ":@$&()/", null);
            var result = StringCase.Upperize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, ".ABC~!.DEF#.GHI%.JK.LM.NO.?");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(false, false, "-_", null);
            var result = StringCase.Upperize("123abc456def", '.', opts);
            Assert.Equal(result, "123ABC456DEF");

            result = StringCase.Upperize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123ABC456DEF");

            result = StringCase.Upperize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.ABC456.DEF");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(false, false, "-_", null);
            var result = StringCase.Upperize("", '.', opts);
            Assert.Equal(result, "");
        }

        [Fact]
        public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
        {
            var opts = new Options(false, false, "-b2", null);
            var result = StringCase.Upperize("abc123def", '.', opts);
            Assert.Equal(result, "ABC123DEF");
        }
    }

    public class NonAlphabetsAsHeadOfWordAndWithKeptCharacters
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(true, false, null, "-_");
            var result = StringCase.Upperize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(true, false, "", "-_");
            var result = StringCase.Upperize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(true, false, null, "-");
            var result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, false, null, "_");
            result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC._DEF._GHI");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(true, false, null, "_");
            var result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, false, null, "-");
            result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC.-DEF.-GHI");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(true, false, null, "_");
            var result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, false, null, "-");
            result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC.-.DEF.-.GHI");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(true, false, null, "-");
            var result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, false, null, "_");
            result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC._DEF._GHI");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(true, false, null, "_");
            var result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, false, null, "-");
            result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC.-DEF.-GHI");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(true, false, null, "_");
            var result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC.123.456DEF.G.89HI.JKL.MN.12");

            opts = new Options(true, false, null, "-");
            result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC.123-456DEF.G.89HI.JKL.MN.12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(true, false, null, ".~!#%?");
            var result = StringCase.Upperize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, ".ABC.~!.DEF.#.GHI.%.JK.LM.NO.?");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(true, false, null, "-");
            var result = StringCase.Upperize("123abc456def", '.', opts);
            Assert.Equal(result, "123ABC.456DEF");

            result = StringCase.Upperize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123ABC.456DEF");

            result = StringCase.Upperize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.ABC.456.DEF");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(true, false, null, "-_");
            var result = StringCase.Upperize("", '.', opts);
            Assert.Equal(result, "");
        }
    }

    public class NonAlphabetsAsTailOfWordAndWithKeptCharacters
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(false, true, null, "-_");
            var result = StringCase.Upperize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(false, true, "", "-_");
            var result = StringCase.Upperize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(false, true, null, "-");
            var result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, true, null, "_");
            result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC_.DEF_.GHI");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(false, true, null, "_");
            var result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, true, null, "-");
            result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC-.DEF-.GHI");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(false, true, null, "_");
            var result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, true, null, "-");
            result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC-.DEF-.GHI");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(false, true, null, "-");
            var result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, true, null, "_");
            result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC_.DEF_.GHI");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(false, true, null, "_");
            var result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, true, null, "-");
            result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC-.DEF-.GHI");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(false, true, null, "_");
            var result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC123.456.DEF.G89.HI.JKL.MN12");

            opts = new Options(false, true, null, "-");
            result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC123-456.DEF.G89.HI.JKL.MN12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(false, true, null, ".~!#%?");
            var result = StringCase.Upperize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, "..ABC~!.DEF#.GHI%.JK.LM.NO.?");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(false, true, null, "_");
            var result = StringCase.Upperize("123abc456def", '.', opts);
            Assert.Equal(result, "123.ABC456.DEF");

            result = StringCase.Upperize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123.ABC456.DEF");

            result = StringCase.Upperize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.ABC456.DEF");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(false, true, null, "-_");
            var result = StringCase.Upperize("", '.', opts);
            Assert.Equal(result, "");
        }
    }

    public class NonAlphabetsAsWordAndWithKeptCharacters
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(true, true, null, "-_");
            var result = StringCase.Upperize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(true, true, "", "-_");
            var result = StringCase.Upperize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(true, true, null, "-");
            var result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, true, null, "_");
            result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC._.DEF._.GHI");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(true, true, null, "_");
            var result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, true, null, "-");
            result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC.-.DEF.-.GHI");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(true, true, null, "_");
            var result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, true, null, "-");
            result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC.-.DEF.-.GHI");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(true, true, null, "-");
            var result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, true, null, "_");
            result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC._.DEF._.GHI");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(true, true, null, "_");
            var result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(true, true, null, "-");
            result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC.-.DEF.-.GHI");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(true, true, null, "_");
            var result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC.123.456.DEF.G.89.HI.JKL.MN.12");

            opts = new Options(true, true, null, "-");
            result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC.123-456.DEF.G.89.HI.JKL.MN.12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(true, true, null, ".~!#%?");
            var result = StringCase.Upperize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, "..ABC.~!.DEF.#.GHI.%.JK.LM.NO.?");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(true, true, null, "-_");
            var result = StringCase.Upperize("123abc456def", '.', opts);
            Assert.Equal(result, "123.ABC.456.DEF");

            result = StringCase.Upperize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123.ABC.456.DEF");

            result = StringCase.Upperize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.ABC.456.DEF");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(true, true, null, "-_");
            var result = StringCase.Upperize("", '.', opts);
            Assert.Equal(result, "");
        }
    }

    public class NonAlphabetsAsPartOfWordAndWithKeptCharacters
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(false, false, null, "-_");
            var result = StringCase.Upperize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(false, false, "", "-_");
            var result = StringCase.Upperize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "ABC.DEF.GH.IJK");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(false, false, null, "-");
            var result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, false, null, "_");
            result = StringCase.Upperize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "ABC_DEF_GHI");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(false, false, null, "_");
            var result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, false, null, "-");
            result = StringCase.Upperize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "ABC-DEF-GHI");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(false, false, null, "_");
            var result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, false, null, "-");
            result = StringCase.Upperize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "ABC-.DEF-.GHI");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(false, false, null, "-");
            var result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, false, null, "_");
            result = StringCase.Upperize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "ABC_DEF_GHI");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(false, false, null, "_");
            var result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC.DEF.GHI");

            opts = new Options(false, false, null, "-");
            result = StringCase.Upperize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "ABC-DEF-GHI");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(false, false, null, "_");
            var result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC123.456DEF.G89HI.JKL.MN12");

            opts = new Options(false, false, null, "-");
            result = StringCase.Upperize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "ABC123-456DEF.G89HI.JKL.MN12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(false, false, null, ".~!#%?");
            var result = StringCase.Upperize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, ".ABC~!.DEF#.GHI%.JK.LM.NO.?");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(false, false, null, "-_");
            var result = StringCase.Upperize("123abc456def", '.', opts);
            Assert.Equal(result, "123ABC456DEF");

            result = StringCase.Upperize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123ABC456DEF");

            result = StringCase.Upperize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.ABC456.DEF");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(false, false, null, "-_");
            var result = StringCase.Upperize("", '.', opts);
            Assert.Equal(result, "");
        }
    }
}
