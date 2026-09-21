namespace StringCase.Tests;

public class StringCase_CapitalizeTest
{
    public class NonAlphabetsAsHeadOfWord
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Capitalize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(true, false, "", "");
            var result = StringCase.Capitalize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc.123.456def.G.89hi.Jkl.Mn.12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Capitalize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi.Jk.Lm.No");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Capitalize("123abc456def", '.', opts);
            Assert.Equal(result, "123abc.456def");

            result = StringCase.Capitalize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123abc.456def");

            result = StringCase.Capitalize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.Abc.456.Def");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Capitalize("", '.', opts);
            Assert.Equal(result, "");
        }
    }

    public class NonAlphabetsAsTailOfWord
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Capitalize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(false, true, "", "");
            var result = StringCase.Capitalize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc123.456.Def.G89.Hi.Jkl.Mn12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Capitalize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi.Jk.Lm.No");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Capitalize("123abc456def", '.', opts);
            Assert.Equal(result, "123.Abc456.Def");

            result = StringCase.Capitalize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123.Abc456.Def");

            result = StringCase.Capitalize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.Abc456.Def");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(false, true, null, null);
            var result = StringCase.Capitalize("", '.', opts);
            Assert.Equal(result, "");
        }
    }

    public class NonAlphabetsAsWord
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Capitalize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(true, true, "", "");
            var result = StringCase.Capitalize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc.123.456.Def.G.89.Hi.Jkl.Mn.12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Capitalize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi.Jk.Lm.No");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Capitalize("123abc456def", '.', opts);
            Assert.Equal(result, "123.Abc.456.Def");

            result = StringCase.Capitalize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123.Abc.456.Def");

            result = StringCase.Capitalize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.Abc.456.Def");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(true, true, null, null);
            var result = StringCase.Capitalize("", '.', opts);
            Assert.Equal(result, "");
        }
    }

    public class NonAlphabetsPartAsWord
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Capitalize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(false, false, "", "");
            var result = StringCase.Capitalize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc123.456def.G89hi.Jkl.Mn12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Capitalize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi.Jk.Lm.No");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Capitalize("123abc456def", '.', opts);
            Assert.Equal(result, "123abc456def");

            result = StringCase.Capitalize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123abc456def");

            result = StringCase.Capitalize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.Abc456.Def");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(false, false, null, null);
            var result = StringCase.Capitalize("", '.', opts);
            Assert.Equal(result, "");
        }
    }

    public class NonAlphabetsAsHeadOfWordAndWithSeparators
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(true, false, "-_", null);
            var result = StringCase.Capitalize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(true, false, "-_", "");
            var result = StringCase.Capitalize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(true, false, "_", null);
            var result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, false, "-", null);
            result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc._def._ghi");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(true, false, "-", null);
            var result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, false, "_", null);
            result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc.-def.-ghi");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(true, false, "-", null);
            var result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, false, "_", null);
            result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc.-.Def.-.Ghi");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(true, false, "_", null);
            var result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, false, "-", null);
            result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc._def._ghi");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(true, false, "-", null);
            var result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, false, "_", null);
            result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc.-def.-ghi");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(true, false, "-", null);
            var result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc.123.456def.G.89hi.Jkl.Mn.12");

            opts = new Options(true, false, "_", null);
            result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc.123-456def.G.89hi.Jkl.Mn.12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(true, false, ":@$&()/", null);
            var result = StringCase.Capitalize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, ".abc.~!.Def.#.Ghi.%.Jk.Lm.No.?");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(true, false, "-", null);
            var result = StringCase.Capitalize("123abc456def", '.', opts);
            Assert.Equal(result, "123abc.456def");

            result = StringCase.Capitalize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123abc.456def");

            result = StringCase.Capitalize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.Abc.456.Def");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(true, false, null, null);
            var result = StringCase.Capitalize("", '.', opts);
            Assert.Equal(result, "");
        }

        [Fact]
        public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
        {
            var opts = new Options(true, false, "-b2", null);
            var result = StringCase.Capitalize("abc123def", '.', opts);
            Assert.Equal(result, "Abc.123def");
        }
    }

    public class NonAlphabetsAsTailOfWordAndWithSeparators
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(false, true, "-_", null);
            var result = StringCase.Capitalize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(false, true, "-_", "");
            var result = StringCase.Capitalize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(false, true, "_", null);
            var result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, true, "-", null);
            result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc_.Def_.Ghi");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(false, true, "-", null);
            var result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, true, "_", null);
            result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc-.Def-.Ghi");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(false, true, "-", null);
            var result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, true, "_", null);
            result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc-.Def-.Ghi");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(false, true, "_", null);
            var result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, true, "-", null);
            result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc_.Def_.Ghi");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(false, true, "-", null);
            var result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, true, "_", null);
            result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc-.Def-.Ghi");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(false, true, "-", null);
            var result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc123.456.Def.G89.Hi.Jkl.Mn12");

            opts = new Options(false, true, "_", null);
            result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc123-456.Def.G89.Hi.Jkl.Mn12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(false, true, ":@$&()/", null);
            var result = StringCase.Capitalize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, "..Abc~!.Def#.Ghi%.Jk.Lm.No.?");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(false, true, "-", null);
            var result = StringCase.Capitalize("123abc456def", '.', opts);
            Assert.Equal(result, "123.Abc456.Def");

            result = StringCase.Capitalize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123.Abc456.Def");

            result = StringCase.Capitalize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.Abc456.Def");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(false, true, "-_", null);
            var result = StringCase.Capitalize("", '.', opts);
            Assert.Equal(result, "");
        }

        [Fact]
        public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
        {
            var opts = new Options(false, true, "-b2", null);
            var result = StringCase.Capitalize("abc123def", '.', opts);
            Assert.Equal(result, "Abc123.Def");
        }
    }

    public class NonAlphabetsAsWordAndWithSeparators
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(true, true, "-_", null);
            var result = StringCase.Capitalize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(true, true, "-_", "");
            var result = StringCase.Capitalize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(true, true, "_", null);
            var result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, true, "-", null);
            result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc._.Def._.Ghi");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(true, true, "-", null);
            var result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, true, "_", null);
            result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc.-.Def.-.Ghi");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(true, true, "-", null);
            var result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, true, "_", null);
            result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc.-.Def.-.Ghi");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(true, true, "_", null);
            var result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, true, "-", null);
            result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc._.Def._.Ghi");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(true, true, "-", null);
            var result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, true, "_", null);
            result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc.-.Def.-.Ghi");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(true, true, "-", null);
            var result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc.123.456.Def.G.89.Hi.Jkl.Mn.12");

            opts = new Options(true, true, "_", null);
            result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc.123-456.Def.G.89.Hi.Jkl.Mn.12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(true, true, ":@$&()/", null);
            var result = StringCase.Capitalize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, "..Abc.~!.Def.#.Ghi.%.Jk.Lm.No.?");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(true, true, "-_", null);
            var result = StringCase.Capitalize("123abc456def", '.', opts);
            Assert.Equal(result, "123.Abc.456.Def");

            result = StringCase.Capitalize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123.Abc.456.Def");

            result = StringCase.Capitalize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.Abc.456.Def");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(true, true, "-_", null);
            var result = StringCase.Capitalize("", '.', opts);
            Assert.Equal(result, "");
        }

        [Fact]
        public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
        {
            var opts = new Options(true, true, "-b2", null);
            var result = StringCase.Capitalize("abc123def", '.', opts);
            Assert.Equal(result, "Abc.123.Def");
        }
    }

    public class NonAlphabetsAsPartOfWordAndWithSeparators
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(false, false, "-_", null);
            var result = StringCase.Capitalize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(false, false, "-_", "");
            var result = StringCase.Capitalize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(false, false, "_", null);
            var result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, false, "-", null);
            result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc_def_ghi");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(false, false, "-", null);
            var result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, false, "_", null);
            result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc-def-ghi");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(false, false, "-", null);
            var result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, false, "_", null);
            result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc-.Def-.Ghi");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(false, false, "_", null);
            var result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, false, "-", null);
            result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc_def_ghi");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(false, false, "-", null);
            var result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, false, "_", null);
            result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc-def-ghi");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(false, false, "-", null);
            var result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc123.456def.G89hi.Jkl.Mn12");

            opts = new Options(false, false, "_", null);
            result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc123-456def.G89hi.Jkl.Mn12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(false, false, ":@$&()/", null);
            var result = StringCase.Capitalize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, ".abc~!.Def#.Ghi%.Jk.Lm.No.?");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(false, false, "-_", null);
            var result = StringCase.Capitalize("123abc456def", '.', opts);
            Assert.Equal(result, "123abc456def");

            result = StringCase.Capitalize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123abc456def");

            result = StringCase.Capitalize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.Abc456.Def");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(false, false, "-_", null);
            var result = StringCase.Capitalize("", '.', opts);
            Assert.Equal(result, "");
        }

        [Fact]
        public void AlphabetsAndNumbersInSeparatorsAreNoEffect()
        {
            var opts = new Options(false, false, "-b2", null);
            var result = StringCase.Capitalize("abc123def", '.', opts);
            Assert.Equal(result, "Abc123def");
        }
    }

    public class NonAlphabetsAsHeadOfWordAndWithKeptCharacters
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(true, false, null, "-_");
            var result = StringCase.Capitalize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(true, false, "", "-_");
            var result = StringCase.Capitalize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(true, false, null, "-");
            var result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, false, null, "_");
            result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc._def._ghi");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(true, false, null, "_");
            var result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, false, null, "-");
            result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc.-def.-ghi");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(true, false, null, "_");
            var result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, false, null, "-");
            result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc.-.Def.-.Ghi");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(true, false, null, "-");
            var result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, false, null, "_");
            result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc._def._ghi");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(true, false, null, "_");
            var result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, false, null, "-");
            result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc.-def.-ghi");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(true, false, null, "_");
            var result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc.123.456def.G.89hi.Jkl.Mn.12");

            opts = new Options(true, false, null, "-");
            result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc.123-456def.G.89hi.Jkl.Mn.12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(true, false, null, ".~!#%?");
            var result = StringCase.Capitalize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, ".abc.~!.Def.#.Ghi.%.Jk.Lm.No.?");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(true, false, null, "-");
            var result = StringCase.Capitalize("123abc456def", '.', opts);
            Assert.Equal(result, "123abc.456def");

            result = StringCase.Capitalize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123abc.456def");

            result = StringCase.Capitalize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.Abc.456.Def");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(true, false, null, "-_");
            var result = StringCase.Capitalize("", '.', opts);
            Assert.Equal(result, "");
        }
    }

    public class NonAlphabetsAsTailOfWordAndWithKeptCharacters
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(false, true, null, "-_");
            var result = StringCase.Capitalize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(false, true, "", "-_");
            var result = StringCase.Capitalize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(false, true, null, "-");
            var result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, true, null, "_");
            result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc_.Def_.Ghi");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(false, true, null, "_");
            var result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, true, null, "-");
            result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc-.Def-.Ghi");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(false, true, null, "_");
            var result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, true, null, "-");
            result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc-.Def-.Ghi");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(false, true, null, "-");
            var result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, true, null, "_");
            result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc_.Def_.Ghi");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(false, true, null, "_");
            var result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, true, null, "-");
            result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc-.Def-.Ghi");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(false, true, null, "_");
            var result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc123.456.Def.G89.Hi.Jkl.Mn12");

            opts = new Options(false, true, null, "-");
            result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc123-456.Def.G89.Hi.Jkl.Mn12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(false, true, null, ".~!#%?");
            var result = StringCase.Capitalize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, "..Abc~!.Def#.Ghi%.Jk.Lm.No.?");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(false, true, null, "_");
            var result = StringCase.Capitalize("123abc456def", '.', opts);
            Assert.Equal(result, "123.Abc456.Def");

            result = StringCase.Capitalize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123.Abc456.Def");

            result = StringCase.Capitalize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.Abc456.Def");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(false, true, null, "-_");
            var result = StringCase.Capitalize("", '.', opts);
            Assert.Equal(result, "");
        }
    }

    public class NonAlphabetsAsWordAndWithKeptCharacters
    {
        [Fact]
        public void convertCamelCase()
        {
            var opts = new Options(true, true, null, "-_");
            var result = StringCase.Capitalize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void convertPascalCase()
        {
            var opts = new Options(true, true, "", "-_");
            var result = StringCase.Capitalize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void convertSnakeCase()
        {
            var opts = new Options(true, true, null, "-");
            var result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, true, null, "_");
            result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc._.Def._.Ghi");
        }

        [Fact]
        public void convertKebabCase()
        {
            var opts = new Options(true, true, null, "_");
            var result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, true, null, "-");
            result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc.-.Def.-.Ghi");
        }

        [Fact]
        public void convertTrainCase()
        {
            var opts = new Options(true, true, null, "_");
            var result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, true, null, "-");
            result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc.-.Def.-.Ghi");
        }

        [Fact]
        public void convertMacroCase()
        {
            var opts = new Options(true, true, null, "-");
            var result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, true, null, "_");
            result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc._.Def._.Ghi");
        }

        [Fact]
        public void convertCobolCase()
        {
            var opts = new Options(true, true, null, "_");
            var result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(true, true, null, "-");
            result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc.-.Def.-.Ghi");
        }

        [Fact]
        public void convertWithKeepingDigits()
        {
            var opts = new Options(true, true, null, "_");
            var result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc.123.456.Def.G.89.Hi.Jkl.Mn.12");

            opts = new Options(true, true, null, "-");
            result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc.123-456.Def.G.89.Hi.Jkl.Mn.12");
        }

        [Fact]
        public void convertWithSymbolsAsSeparators()
        {
            var opts = new Options(true, true, null, ".~!#%?");
            var result = StringCase.Capitalize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, "..Abc.~!.Def.#.Ghi.%.Jk.Lm.No.?");
        }

        [Fact]
        public void convertWhenStartingWithDigit()
        {
            var opts = new Options(true, true, null, "-_");
            var result = StringCase.Capitalize("123abc456def", '.', opts);
            Assert.Equal(result, "123.Abc.456.Def");

            result = StringCase.Capitalize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123.Abc.456.Def");

            result = StringCase.Capitalize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.Abc.456.Def");
        }

        [Fact]
        public void convertAnEmptyString()
        {
            var opts = new Options(true, true, null, "-_");
            var result = StringCase.Capitalize("", '.', opts);
            Assert.Equal(result, "");
        }
    }

    public class NonAlphabetsAsPartOfWordAndWithKeptCharacters
    {
        [Fact]
        public void ConvertCamelCase()
        {
            var opts = new Options(false, false, null, "-_");
            var result = StringCase.Capitalize("abcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertPascalCase()
        {
            var opts = new Options(false, false, "", "-_");
            var result = StringCase.Capitalize("AbcDefGHIjk", '.', opts);
            Assert.Equal(result, "Abc.Def.Gh.Ijk");
        }

        [Fact]
        public void ConvertSnakeCase()
        {
            var opts = new Options(false, false, null, "-");
            var result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, false, null, "_");
            result = StringCase.Capitalize("abc_def_ghi", '.', opts);
            Assert.Equal(result, "Abc_def_ghi");
        }

        [Fact]
        public void ConvertKebabCase()
        {
            var opts = new Options(false, false, null, "_");
            var result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, false, null, "-");
            result = StringCase.Capitalize("abc-def-ghi", '.', opts);
            Assert.Equal(result, "Abc-def-ghi");
        }

        [Fact]
        public void ConvertTrainCase()
        {
            var opts = new Options(false, false, null, "_");
            var result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, false, null, "-");
            result = StringCase.Capitalize("Abc-Def-Ghi", '.', opts);
            Assert.Equal(result, "Abc-.Def-.Ghi");
        }

        [Fact]
        public void ConvertMacroCase()
        {
            var opts = new Options(false, false, null, "-");
            var result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, false, null, "_");
            result = StringCase.Capitalize("ABC_DEF_GHI", '.', opts);
            Assert.Equal(result, "Abc_def_ghi");
        }

        [Fact]
        public void ConvertCobolCase()
        {
            var opts = new Options(false, false, null, "_");
            var result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc.Def.Ghi");

            opts = new Options(false, false, null, "-");
            result = StringCase.Capitalize("ABC-DEF-GHI", '.', opts);
            Assert.Equal(result, "Abc-def-ghi");
        }

        [Fact]
        public void ConvertWithKeepingDigits()
        {
            var opts = new Options(false, false, null, "_");
            var result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc123.456def.G89hi.Jkl.Mn12");

            opts = new Options(false, false, null, "-");
            result = StringCase.Capitalize("abc123-456defG89HIJklMN12", '.', opts);
            Assert.Equal(result, "Abc123-456def.G89hi.Jkl.Mn12");
        }

        [Fact]
        public void ConvertWithSymbolsAsSeparators()
        {
            var opts = new Options(false, false, null, ".~!#%?");
            var result = StringCase.Capitalize(":.abc~!@def#$ghi%&jk(lm)no/?", '.', opts);
            Assert.Equal(result, ".abc~!.Def#.Ghi%.Jk.Lm.No.?");
        }

        [Fact]
        public void ConvertWhenStartingWithDigit()
        {
            var opts = new Options(false, false, null, "-_");
            var result = StringCase.Capitalize("123abc456def", '.', opts);
            Assert.Equal(result, "123abc456def");

            result = StringCase.Capitalize("123ABC456DEF", '.', opts);
            Assert.Equal(result, "123abc456def");

            result = StringCase.Capitalize("123Abc456Def", '.', opts);
            Assert.Equal(result, "123.Abc456.Def");
        }

        [Fact]
        public void ConvertAnEmptyString()
        {
            var opts = new Options(false, false, null, "-_");
            var result = StringCase.Capitalize("", '.', opts);
            Assert.Equal(result, "");
        }
    }
}
