/*
 * StringCase.cs
 * Copyright (C) 2026 Takayuki Sato. All Rights Reserved.
 */

namespace StringCase;

using System.Text;

/// <summary>
/// Is the class that provides the static methods to convert a string to following cases.
///
/// <ul>
///   <li>Ada_Case</li>
///   <li>camelCase</li>
///   <li>COBOL-CASE</li>
///   <li>kebab-case</li>
///   <li>MACRO_CASE</li>
///   <li>PascalCase</li>
///   <li>snake_case</li>
///   <li>Title Case</li>
///   <li>Train-Case</li>
/// </ul>
/// </summary>
public static class StringCase
{

    private enum ChIs
    {
        FirstOfStr,
        NextOfUpper,
        NextOfContdUpper,
        NextOfSepMark,
        NextOfKeptMark,
        Others,
    }

    /// <summary> 
    /// Converts all ASCII alphabetic characters in the input string to uppercase, inserting the
    /// specified joiner <c>char</c> between word boundaries according to the given options.
    /// It serves as a core engine for transforming input strings into uppercase-based casing
    /// styles, such as MACRO_CASE or COBOL-CASE, using a custom joiner <c>char</c> and
    /// customizable word separation rules defined in <see cref="Options"/>.
    /// <br/><br/>
    /// During conversion, all ASCII lowercase letters are converted to ASCII uppercase letters,
    /// and word boundaries are automatically recognized between casing transitions, such as
    /// between lowercase and uppercase letters or before the final uppercase letter of an acronym
    /// preceding a lowercase sequence. When non-alphanumeric characters are encountered, ASCII
    /// digits are kept by default, while other characters are evaluated against
    /// <see cref="Options"/>. If <c>opts.Separators</c> is non-empty, characters matching
    /// <c>opts.Separators</c> are removed as separators while other non-alphanumeric characters
    /// are kept; otherwise, if <c>opts.Keep</c> is non-empty, specified characters are kept and
    /// all other non-alphanumeric characters are removed.
    /// If neither is specified, all non-alphanumeric characters are treated as separators and
    /// removed.
    /// The fields <c>opts.SeparateBeforeNonAlphabets</c> and <c>opts.SeparateAfterNonAlphabets</c>
    /// further determine whether word boundaries are inserted before or after non-alphabetic
    /// sequences.
    /// <br/><br/>
    /// This static method never throws an exception on any input, returning an empty string when
    /// the input is empty. Casing transformations and word boundary detections apply strictly to
    /// ASCII letters, treating non-ASCII characters as non-alphanumeric. If both
    /// <c>opts.Separators</c> and <c>opts.Keep</c> are specified, <c>opts.Separators</c> takes
    /// precedence and <c>opts.Keep</c> is ignored, while any alphanumeric characters listed in
    /// either field are disregarded.
    /// Additionally, leading and trailing separator characters are trimmed from the result without
    /// producing leading or trailing joiners.
    /// </summary> 
    ///
    /// <param name="input">The input string.</param>
    /// <param name="joiner">A joiner <c>char</c>.</param>
    /// <param name="opts">The <see cref="Options"/> object which holds the fields to customize
    ///   separation rules.</param>
    /// <returns>The converted string.</returns>
    public static string Upperize(string input, char joiner, Options opts)
    {
        return Upperize(input, new Rune(joiner), opts);
    }

    /// <summary> 
    /// Converts all ASCII alphabetic characters in the input string to uppercase, inserting the
    /// specified joiner <see cref="Rune"/> between word boundaries according to the given options.
    /// It serves as a core engine for transforming input strings into uppercase-based casing
    /// styles, such as MACRO_CASE or COBOL-CASE, using a custom joiner <see cref="Rune"/> and
    /// customizable word separation rules defined in <see cref="Options"/>.
    /// <br/><br/>
    /// During conversion, all ASCII lowercase letters are converted to ASCII uppercase letters,
    /// and word boundaries are automatically recognized between casing transitions, such as between
    /// lowercase and uppercase letters or before the final uppercase letter of an acronym
    /// preceding a lowercase sequence. When non-alphanumeric characters are encountered, ASCII
    /// digits are kept by
    /// default, while other characters are evaluated against <see cref="Options"/>. If
    /// <c>opts.Separators</c> is non-empty, characters matching <c>opts.Separators</c> are removed
    /// as separators while other non-alphanumeric characters are kept; otherwise, if
    /// <c>opts.Keep</c> is non-empty, specified characters are kept and all other non-alphanumeric
    /// characters are removed.
    /// If neither is specified, all non-alphanumeric characters are treated as separators and
    /// removed.
    /// The fields <c>opts.SeparateBeforeNonAlphabets</c> and <c>opts.SeparateAfterNonAlphabets</c>
    /// further determine whether word boundaries are inserted before or after non-alphabetic
    /// sequences.
    /// <br/><br/>
    /// This static method never throws an exception on any input, returning an empty string when
    /// the input is empty. Casing transformations and word boundary detections apply strictly to
    /// ASCII letters, treating non-ASCII characters as non-alphanumeric. If both
    /// <c>opts.Separators</c> and <c>opts.Keep</c> are specified, <c>opts.Separators</c> takes
    /// precedence and <c>opts.Keep</c> is ignored, while any alphanumeric characters listed in
    /// either field are disregarded.
    /// Additionally, leading and trailing separator characters are trimmed from the result without
    /// producing leading or trailing joiners.
    /// </summary> 
    ///
    /// <param name="input">The input string.</param>
    /// <param name="joiner">A joiner <see cref="Rune"/>.</param>
    /// <param name="opts">The <see cref="Options"/> object which holds the fields to customize
    ///   separation rules.</param>
    /// <returns>The converted string.</returns>
    public static string Upperize(string input, Rune joiner, Options opts)
    {
        var result = new StringBuilder(input.Length);

        var flag = ChIs.FirstOfStr;

        Rune[]? sepChs = null;
        if (!string.IsNullOrEmpty(opts.Separators))
        {
            sepChs = opts.Separators.EnumerateRunes().ToArray();
            Array.Sort(sepChs);
        }

        Rune[]? keptChs = null;
        if (!string.IsNullOrEmpty(opts.Keep))
        {
            keptChs = opts.Keep.EnumerateRunes().ToArray();
            Array.Sort(keptChs);
        }

        foreach (Rune ch in input.EnumerateRunes())
        {
            bool isKeptChar = false;

            if (ch.IsAscii)
            {
                if (Rune.IsUpper(ch))
                {
                    if (flag == ChIs.FirstOfStr)
                    {
                        result.Append(ch);
                        flag = ChIs.NextOfUpper;
                    }
                    else if (flag == ChIs.NextOfUpper
                      || flag == ChIs.NextOfContdUpper
                      || (!opts.SeparateAfterNonAlphabets && flag == ChIs.NextOfKeptMark))
                    {
                        result.Append(ch);
                        flag = ChIs.NextOfContdUpper;
                    }
                    else
                    {
                        result.Append(joiner);
                        result.Append(ch);
                        flag = ChIs.NextOfUpper;
                    }
                    continue;
                }
                else if (Rune.IsLower(ch))
                {
                    if (flag == ChIs.NextOfContdUpper)
                    {
                        char prev = result[result.Length - 1];
                        result.Length--;
                        result.Append(joiner);
                        result.Append(prev);
                        result.Append(Rune.ToUpperInvariant(ch));
                    }
                    else if (flag == ChIs.NextOfSepMark
                      || (opts.SeparateAfterNonAlphabets && flag == ChIs.NextOfKeptMark))
                    {
                        result.Append(joiner);
                        result.Append(Rune.ToUpperInvariant(ch));
                    }
                    else
                    {
                        result.Append(Rune.ToUpperInvariant(ch));
                    }
                    flag = ChIs.Others;
                    continue;
                }
                else if (Rune.IsDigit(ch))
                {
                    isKeptChar = true;
                }
            }

            if (!isKeptChar)
            {
                if (sepChs != null)
                {
                    if (Array.BinarySearch(sepChs, ch) < 0)
                    {
                        isKeptChar = true;
                    }
                }
                else if (keptChs != null)
                {
                    if (Array.BinarySearch(keptChs, ch) >= 0)
                    {
                        isKeptChar = true;
                    }
                }
            }

            if (isKeptChar)
            {
                if (opts.SeparateBeforeNonAlphabets)
                {
                    if (flag == ChIs.FirstOfStr || flag == ChIs.NextOfKeptMark)
                    {
                        result.Append(ch);
                    }
                    else
                    {
                        result.Append(joiner);
                        result.Append(ch);
                    }
                }
                else
                {
                    if (flag != ChIs.NextOfSepMark)
                    {
                        result.Append(ch);
                    }
                    else
                    {
                        result.Append(joiner);
                        result.Append(ch);
                    }
                }
                flag = ChIs.NextOfKeptMark;
            }
            else
            {
                if (flag != ChIs.FirstOfStr)
                {
                    flag = ChIs.NextOfSepMark;
                }
            }
        }

        return result.ToString();
    }

    /// <summary>
    /// Converts all ASCII alphabetic characters in the input string to lowercase, inserting the
    /// specified joiner <c>char</c> between word boundaries according to the given options. It
    /// serves as a core engine for transforming input strings into lowercase-based casing styles,
    /// such as snake_case or kebab-case, using a custom joiner <c>char</c> and customizable word
    /// separation rules defined in <see cref="Options"/>.
    /// <br/><br/>
    /// During conversion, all ASCII uppercase letters are converted to ASCII lowercase letters,
    /// and word boundaries are automatically recognized between casing transitions, such as
    /// between lowercase and uppercase letters or before the final uppercase letter of an acronym
    /// preceding a lowercase sequence. When non-alphanumeric characters are encountered, ASCII
    /// digits are kept by default, while other characters are evaluated against
    /// <see cref="Options"/>. If <c>opts.Separators</c> is non-empty, characters matching 
    /// <c>opts.Separators</c> are removed as separators while other non-alphanumeric characters
    /// are kept; otherwise, if <c>opts.Keep</c> is non-empty, specified characters are kept and
    /// all other non-alphanumeric characters are removed.
    /// If neither is specified, all non-alphanumeric characters are treated as separators and
    /// removed.
    /// The fields <c>opts.SeparateBeforeNonAlphabets</c> and <c>opts.SeparateAfterNonAlphabets</c>
    /// further determine whether word boundaries are inserted before or after non-alphabetic
    /// sequences.
    /// <br/><br/>
    /// This static method never throws an exception on any input, returning an empty string when
    /// the input is empty. Casing transformations and word boundary detections apply strictly to
    /// ASCII letters, treating non-ASCII characters as non-alphanumeric. If both opts.Separators
    /// and <c>opts.Keep</c> are specified, <c>opts.Separators</c> takes precedence and
    /// <c>opts.Keep</c> is ignored, while any alphanumeric characters listed in either field are
    /// disregarded.
    /// Additionally, leading and trailing separator characters are trimmed from the result without
    /// producing leading or trailing joiners.
    /// </summary>
    ///
    /// <param name="input">The input string.</param>
    /// <param name="joiner"> A joiner <c>char</c>.</param>
    /// <param name="opts"> The <see cref="Options"/> object which holds the fields to customize
    ///   separation rules.</param>
    /// <returns>The converted string.</returns>
    ///
    public static string Lowerize(string input, char joiner, Options opts)
    {
        return Lowerize(input, new Rune(joiner), opts);
    }

    /// <summary> 
    /// Converts all ASCII alphabetic characters in the input string to lowercase, inserting the
    /// specified joiner code point between word boundaries according to the given options. It
    /// serves as a core engine for transforming input strings into lowercase-based casing styles,
    /// such as snake_case or kebab-case, using custom joiner code points and customizable word
    /// separation rules defined in <see cref="Options"/>.
    /// <br/><br/>
    /// During conversion, all ASCII uppercase letters are converted to ASCII lowercase letters,
    /// and word boundaries are automatically recognized between casing transitions, such as
    /// between lowercase and uppercase letters or before the final uppercase letter of an acronym
    /// preceding a lowercase sequence. When non-alphanumeric characters are encountered, ASCII
    /// digits are kept by default, while other characters are evaluated against
    /// <see cref="Options"/>. If <c>opts.Separators</c> is non-empty, characters matching
    /// <c>opts.Separators</c> are removed as separators while other non-alphanumeric characters
    /// are kept; otherwise, if <c>opts.Keep</c> is non-empty, specified characters are kept and
    /// all other non-alphanumeric characters are removed.
    /// If neither is specified, all non-alphanumeric characters are treated as separators and
    /// removed.
    /// The fields <c>opts.SeparateBeforeNonAlphabets</c> and <c>opts.SeparateAfterNonAlphabets</c>
    /// further determine whether word boundaries are inserted before or after non-alphabetic
    /// sequences.
    /// <br/><br/>
    /// This static method never throws an exception on any input, returning an empty string when
    /// the input is empty. Casing transformations and word boundary detections apply strictly to
    /// ASCII letters, treating non-ASCII characters as non-alphanumeric. If both opts.Separators
    /// and <c>opts.Keep</c> are specified, <c>opts.Separators</c> takes precedence and
    /// <c>opts.Keep</c> is ignored, while any alphanumeric characters listed in either field are
    /// disregarded.
    /// Additionally, leading and trailing separator characters are trimmed from the result without
    /// producing leading or trailing joiners.
    /// </summary> 
    ///
    /// <param name="input">The input string.</param>
    /// <param name="joiner">A joiner code point.</param>
    /// <param name="opts">The <see cref="Options"/> object which holds the fields to customize
    ///   separation rules.</param>
    /// <returns>The converted string.</returns>
    public static string Lowerize(string input, Rune joiner, Options opts)
    {
        var result = new StringBuilder(input.Length);

        var flag = ChIs.FirstOfStr;

        Rune[]? sepChs = null;
        if (!string.IsNullOrEmpty(opts.Separators))
        {
            sepChs = opts.Separators.EnumerateRunes().ToArray();
            Array.Sort(sepChs);
        }

        Rune[]? keptChs = null;
        if (!string.IsNullOrEmpty(opts.Keep))
        {
            keptChs = opts.Keep.EnumerateRunes().ToArray();
            Array.Sort(keptChs);
        }

        foreach (Rune ch in input.EnumerateRunes())
        {
            bool isKeptChar = false;

            if (ch.IsAscii)
            {
                if (Rune.IsUpper(ch))
                {
                    if (flag == ChIs.FirstOfStr)
                    {
                        result.Append(Rune.ToLowerInvariant(ch));
                        flag = ChIs.NextOfUpper;
                    }
                    else if (flag == ChIs.NextOfUpper
                      || flag == ChIs.NextOfContdUpper
                      || (!opts.SeparateAfterNonAlphabets && flag == ChIs.NextOfKeptMark))
                    {
                        result.Append(Rune.ToLowerInvariant(ch));
                        flag = ChIs.NextOfContdUpper;
                    }
                    else
                    {
                        result.Append(joiner);
                        result.Append(Rune.ToLowerInvariant(ch));
                        flag = ChIs.NextOfUpper;
                    }
                    continue;
                }
                else if (Rune.IsLower(ch))
                {
                    if (flag == ChIs.NextOfContdUpper)
                    {
                        char prev = result[result.Length - 1];
                        result.Length--;
                        result.Append(joiner);
                        result.Append(prev);
                        result.Append(ch);
                    }
                    else if (flag == ChIs.NextOfSepMark
                        || (opts.SeparateAfterNonAlphabets && flag == ChIs.NextOfKeptMark))
                    {
                        result.Append(joiner);
                        result.Append(ch);
                    }
                    else
                    {
                        result.Append(ch);
                    }
                    flag = ChIs.Others;
                    continue;
                }
                else if (Rune.IsDigit(ch))
                {
                    isKeptChar = true;
                }
            }

            if (!isKeptChar)
            {
                if (sepChs != null)
                {
                    if (Array.BinarySearch(sepChs, ch) < 0)
                    {
                        isKeptChar = true;
                    }
                }
                else if (keptChs != null)
                {
                    if (Array.BinarySearch(keptChs, ch) >= 0)
                    {
                        isKeptChar = true;
                    }
                }
            }

            if (isKeptChar)
            {
                if (opts.SeparateBeforeNonAlphabets)
                {
                    if (flag == ChIs.FirstOfStr || flag == ChIs.NextOfKeptMark)
                    {
                        result.Append(ch);
                    }
                    else
                    {
                        result.Append(joiner);
                        result.Append(ch);
                    }
                }
                else
                {
                    if (flag != ChIs.NextOfSepMark)
                    {
                        result.Append(ch);
                    }
                    else
                    {
                        result.Append(joiner);
                        result.Append(ch);
                    }
                }
                flag = ChIs.NextOfKeptMark;
            }
            else
            {
                if (flag != ChIs.FirstOfStr)
                {
                    flag = ChIs.NextOfSepMark;
                }
            }
        }

        return result.ToString();
    }

    /// <summary>
    /// Converts the input string by capitalizing the first ASCII letter of each word and
    /// lowercasing subsequent letters, inserting the specified joiner <c>char</c> between word
    /// boundaries according to the given options. It serves as a core engine for transforming
    /// input strings into capitalized casing styles, such as Train-Case or PascalCase, using
    /// custom joiner <c>code</c>s and customizable word separation rules defined in
    /// <see cref="Options"/>.
    /// <br/><br/>
    /// During conversion, the initial ASCII letter of each word is converted to ASCII uppercase,
    /// while subsequent ASCII letters in that word are converted to ASCII lowercase. Word
    /// boundaries are automatically recognized at casing transitions, such as between lowercase
    /// and uppercase letters or before the final uppercase letter of an acronym preceding a
    /// lowercase sequence. When non-alphanumeric characters are encountered, ASCII digits are kept
    /// by default, while other characters are evaluated against <see cref="Options"/>. If
    /// <c>opts.Separators</c> is non-empty, characters matching <c>opts.Separators</c> are removed
    /// as separators while other non-alphanumeric characters are kept; otherwise, if
    /// <c>opts.Keep</c> is non-empty, specified characters are kept and all other non-alphanumeric
    /// characters are removed. If neither is specified, all non-alphanumeric characters are
    /// treated as separators and removed. The fields <c>opts.SeparateBeforeNonAlphabets</c> and
    /// <c>opts.SeparateAfterNonAlphabets</c> further determine whether word boundaries are
    /// inserted before or after non-alphabetic sequences.
    /// <br/><br/>
    /// This static method never throws an exception on any input, returning an empty string when
    /// the input is empty. Casing transformations and word boundary detections apply strictly to
    /// ASCII letters, treating non-ASCII characters as non-alphanumeric. If both
    /// <c>opts.Separators</c> and <c>opts.Keep</c> are specified, <c>opts.Separators</c> takes
    /// precedence and <c>opts.Keep</c> is ignored, while any alphanumeric characters listed in
    /// either field are disregarded.
    /// Additionally, leading and trailing separator characters are trimmed from the result without
    /// producing leading or trailing joiners.
    /// </summary>
    ///
    /// <param name="input">The input string.</param>
    /// <param name="joiner">A joiner <c>char</c>.</param>
    /// <param name="opts">The <see cref="Options"/> object which holds the fields to customize
    ///   separation rules.</param>
    /// <returns>The converted string.</returns>
    ///
    public static string Capitalize(string input, char joiner, Options opts)
    {
        return Capitalize(input, new Rune(joiner), opts);
    }

    /// <summary>
    /// Converts the input string by capitalizing the first ASCII letter of each word and
    /// lowercasing subsequent letters, inserting the specified joiner code point between word
    /// boundaries according to the given options. It serves as a core engine for transforming
    /// input strings into capitalized casing styles, such as Train-Case or PascalCase, using
    /// custom joiner code points and customizable word separation rules defined in
    /// <see cref="Options"/>.
    /// <br/><br/>
    /// During conversion, the initial ASCII letter of each word is converted to ASCII uppercase,
    /// while subsequent ASCII letters in that word are converted to ASCII lowercase. Word
    /// boundaries are automatically recognized at casing transitions, such as between lowercase
    /// and uppercase letters or before the final uppercase letter of an acronym preceding a
    /// lowercase sequence. When non-alphanumeric characters are encountered, ASCII digits are
    /// kept by default, while other characters are evaluated against <see cref="Options"/>. If
    /// <c>opts.Separators</c> is non-empty, characters matching <c>opts.Separators</c> are
    /// removed as separators while other non-alphanumeric characters are kept; otherwise, if
    /// <c>opts.Keep</c> is non-empty, specified characters are kept and all other
    /// non-alphanumeric characters are removed. If neither is specified, all non-alphanumeric
    /// characters are treated as separators and removed. The fields
    /// <c>opts.SeparateBeforeNonAlphabets</c> and <c>opts.SeparateAfterNonAlphabets</c> further
    /// determine whether word boundaries are inserted before or after non-alphabetic sequences.
    /// <br/><br/>
    /// This static method never throws an exception on any input, returning an empty string when
    /// the input is empty. Casing transformations and word boundary detections apply strictly to
    /// ASCII letters, treating non-ASCII characters as non-alphanumeric. If both
    /// <c>opts.Separators</c> and <c>opts.Keep</c> are specified, <c>opts.Separators</c> takes
    /// precedence and <c>opts.Keep</c> is ignored, while any alphanumeric characters listed in
    /// either field are disregarded.
    /// Additionally, leading and trailing separator characters are trimmed from the result without
    /// producing leading or trailing joiners.
    /// </summary>
    ///
    /// <param name="input">The input string.</param>
    /// <param name="joiner">A joiner code point.</param>
    /// <param name="opts">The <see cref="Options"/> object which holds the fields to customize
    ///   separation rules.</param>
    /// <returns>The converted string.</returns>
    public static string Capitalize(string input, Rune joiner, Options opts)
    {
        var result = new StringBuilder(input.Length);

        var flag = ChIs.FirstOfStr;

        Rune[]? sepChs = null;
        if (!string.IsNullOrEmpty(opts.Separators))
        {
            sepChs = opts.Separators.EnumerateRunes().ToArray();
            Array.Sort(sepChs);
        }

        Rune[]? keptChs = null;
        if (!string.IsNullOrEmpty(opts.Keep))
        {
            keptChs = opts.Keep.EnumerateRunes().ToArray();
            Array.Sort(keptChs);
        }

        foreach (Rune ch in input.EnumerateRunes())
        {
            bool isKeptChar = false;

            if (ch.IsAscii)
            {
                if (Rune.IsUpper(ch))
                {
                    if (flag == ChIs.FirstOfStr)
                    {
                        result.Append(ch);
                        flag = ChIs.NextOfUpper;
                    }
                    else if (flag == ChIs.NextOfUpper
                      || flag == ChIs.NextOfContdUpper
                      || (!opts.SeparateAfterNonAlphabets && flag == ChIs.NextOfKeptMark))
                    {
                        result.Append(Rune.ToLowerInvariant(ch));
                        flag = ChIs.NextOfContdUpper;
                    }
                    else
                    {
                        result.Append(joiner);
                        result.Append(ch);
                        flag = ChIs.NextOfUpper;
                    }
                    continue;
                }
                else if (Rune.IsLower(ch))
                {
                    if (flag == ChIs.FirstOfStr)
                    {
                        result.Append(Rune.ToUpperInvariant(ch));
                    }
                    else if (flag == ChIs.NextOfContdUpper)
                    {
                        char prev = result[result.Length - 1];
                        if (char.IsLower(prev))
                        {
                            prev = char.ToUpperInvariant(prev);
                        }
                        result.Length--;
                        result.Append(joiner);
                        result.Append(prev);
                        result.Append(ch);
                    }
                    else if (flag == ChIs.NextOfSepMark
                        || (opts.SeparateAfterNonAlphabets && flag == ChIs.NextOfKeptMark))
                    {
                        result.Append(joiner);
                        result.Append(Rune.ToUpperInvariant(ch));
                    }
                    else
                    {
                        result.Append(ch);
                    }
                    flag = ChIs.Others;
                    continue;
                }
                else if (Rune.IsDigit(ch))
                {
                    isKeptChar = true;
                }
            }

            if (!isKeptChar)
            {
                if (sepChs != null)
                {
                    if (Array.BinarySearch(sepChs, ch) < 0)
                    {
                        isKeptChar = true;
                    }
                }
                else if (keptChs != null)
                {
                    if (Array.BinarySearch(keptChs, ch) >= 0)
                    {
                        isKeptChar = true;
                    }
                }
            }

            if (isKeptChar)
            {
                if (opts.SeparateBeforeNonAlphabets)
                {
                    if (flag == ChIs.FirstOfStr || flag == ChIs.NextOfKeptMark)
                    {
                        result.Append(ch);
                    }
                    else
                    {
                        result.Append(joiner);
                        result.Append(ch);
                    }
                }
                else
                {
                    if (flag != ChIs.NextOfSepMark)
                    {
                        result.Append(ch);
                    }
                    else
                    {
                        result.Append(joiner);
                        result.Append(ch);
                    }
                }
                flag = ChIs.NextOfKeptMark;
            }
            else
            {
                if (flag != ChIs.FirstOfStr)
                {
                    flag = ChIs.NextOfSepMark;
                }
            }
        }

        return result.ToString();
    }

    /// <summary>
    /// Converts the input string to camel case with the specified options.
    /// </summary>
    ///
    /// <param name="input">The input string.</param>
    /// <param name="opts">The options which specifies the ways of case conversion.</param>
    /// <returns>A string converted to camel case.</returns>
    public static string CamelCaseWithOptions(string input, Options opts)
    {
        var result = new StringBuilder(input.Length);

        var flag = ChIs.FirstOfStr;

        Rune[]? sepChs = null;
        if (!string.IsNullOrEmpty(opts.Separators))
        {
            sepChs = opts.Separators.EnumerateRunes().ToArray();
            Array.Sort(sepChs);
        }

        Rune[]? keptChs = null;
        if (!string.IsNullOrEmpty(opts.Keep))
        {
            keptChs = opts.Keep.EnumerateRunes().ToArray();
            Array.Sort(keptChs);
        }

        foreach (Rune ch in input.EnumerateRunes())
        {
            bool isKeptChar = false;

            if (ch.IsAscii)
            {
                if (Rune.IsUpper(ch))
                {
                    if (flag == ChIs.FirstOfStr)
                    {
                        result.Append(Rune.ToLowerInvariant(ch));
                        flag = ChIs.NextOfUpper;
                    }
                    else if (flag == ChIs.NextOfUpper
                      || flag == ChIs.NextOfContdUpper
                      || (!opts.SeparateAfterNonAlphabets && flag == ChIs.NextOfKeptMark))
                    {
                        result.Append(Rune.ToLowerInvariant(ch));
                        flag = ChIs.NextOfContdUpper;
                    }
                    else
                    {
                        result.Append(ch);
                        flag = ChIs.NextOfUpper;
                    }
                    continue;
                }
                else if (Rune.IsLower(ch))
                {
                    if (flag == ChIs.NextOfContdUpper)
                    {
                        char prev = result[result.Length - 1];
                        if (char.IsLower(prev))
                        {
                            prev = char.ToUpperInvariant(prev);
                        }
                        result.Length--;
                        result.Append(prev);
                        result.Append(ch);
                    }
                    else if (flag == ChIs.NextOfSepMark
                        || (opts.SeparateAfterNonAlphabets && flag == ChIs.NextOfKeptMark))
                    {
                        result.Append(Rune.ToUpperInvariant(ch));
                    }
                    else
                    {
                        result.Append(ch);
                    }
                    flag = ChIs.Others;
                    continue;
                }
                else if (Rune.IsDigit(ch))
                {
                    isKeptChar = true;
                }
            }

            if (!isKeptChar)
            {
                if (sepChs != null)
                {
                    if (Array.BinarySearch(sepChs, ch) < 0)
                    {
                        isKeptChar = true;
                    }
                }
                else if (keptChs != null)
                {
                    if (Array.BinarySearch(keptChs, ch) >= 0)
                    {
                        isKeptChar = true;
                    }
                }
            }

            if (isKeptChar)
            {
                result.Append(ch);
                flag = ChIs.NextOfKeptMark;
            }
            else
            {
                if (flag != ChIs.FirstOfStr)
                {
                    flag = ChIs.NextOfSepMark;
                }
            }
        }

        return result.ToString();
    }

    /// <summary> 
    /// Converts the input string to camel case.
    /// <br/><br/>
    /// It treats the end of a sequence of non-alphabetical characters as a word boundary, but not
    /// the beginning.
    /// </summary> 
    ///
    /// <param name="input">The input string.</param>
    /// <returns>A string converted to camel case.</returns>
    public static string CamelCase(string input)
    {
        return CamelCaseWithOptions(input, new Options(false, true, null, null));
    }

    /// <summary>
    /// Converts the input string to cobol case with the specified options.
    /// </summary>
    ///
    /// <param name="input">The input string.</param>
    /// <param name="opts">The options which specifies the ways of case conversion.</param>
    /// <returns>A string converted to cobol case.</returns>
    public static string CobolCaseWithOptions(string input, Options opts)
    {
        return Upperize(input, '-', opts);
    }

    /// <summary>
    /// Converts the input string to cobol case.
    /// <br/><br/>
    /// It treats the end of a sequence of non-alphabetical characters as a word boundary, but not
    /// the beginning.
    /// </summary>
    ///
    /// <param name="input">The input string.</param>
    /// <returns>A string converted to cobol case.</returns>
    public static string CobolCase(string input)
    {
        return Upperize(input, '-', new Options(false, true, null, null));
    }

    /// <summary> 
    /// Converts the input string to kebab case with the specified options.
    /// </summary> 
    ///
    /// <param name="input">The input string.</param>
    /// <param name="opts">The options which specifies the ways of case conversion.</param>
    /// <returns>A string converted to kebab case.</returns>
    public static string KebabCaseWithOptions(string input, Options opts)
    {
        return Lowerize(input, '-', opts);
    }

    /// <summary> 
    /// Converts the input string to kebab case.
    /// <br/><br/>
    /// It treats the end of a sequence of non-alphabetical characters as a word boundary, but not
    /// the beginning.
    /// </summary> 
    ///
    /// <param name="input">The input string.</param>
    /// <returns>A string converted to kebab case.</returns>
    public static string KebabCase(string input)
    {
        return Lowerize(input, '-', new Options(false, true, null, null));
    }

    /// <summary>
    /// Converts the input string to macro case with the specified options.
    /// </summary>
    ///
    /// <param name="input">The input string.</param>
    /// <param name="opts">The options which specifies the ways of case conversion.</param>
    /// <returns>A string converted to macro case.</returns>
    public static string MacroCaseWithOptions(string input, Options opts)
    {
        return Upperize(input, '_', opts);
    }

    /// <summary>
    /// Converts the input string to macro case.
    /// <br/><br/>
    /// It treats the end of a sequence of non-alphabetical characters as a word boundary, but not
    /// the beginning.
    /// </summary>
    ///
    /// <param name="input">The input string.</param>
    /// <returns>A string converted to macro case.</returns>
    public static string MacroCase(string input)
    {
        return Upperize(input, '_', new Options(false, true, null, null));
    }

    /// <summary>
    /// Converts the input string to pascal case with the specified options.
    /// </summary>
    ///
    /// <param name="input">The input string.</param>
    /// <param name="opts">The options which specifies the ways of case conversion.</param>
    /// <returns>A string converted to pascal case.</returns>
    public static string PascalCaseWithOptions(string input, Options opts)
    {
        var result = new StringBuilder(input.Length);

        var flag = ChIs.FirstOfStr;

        Rune[]? sepChs = null;
        if (!string.IsNullOrEmpty(opts.Separators))
        {
            sepChs = opts.Separators.EnumerateRunes().ToArray();
            Array.Sort(sepChs);
        }

        Rune[]? keptChs = null;
        if (!string.IsNullOrEmpty(opts.Keep))
        {
            keptChs = opts.Keep.EnumerateRunes().ToArray();
            Array.Sort(keptChs);
        }

        foreach (Rune ch in input.EnumerateRunes())
        {
            bool isKeptChar = false;

            if (ch.IsAscii)
            {
                if (Rune.IsUpper(ch))
                {
                    if (flag == ChIs.NextOfUpper
                      || flag == ChIs.NextOfContdUpper
                      || (!opts.SeparateAfterNonAlphabets && flag == ChIs.NextOfKeptMark))
                    {
                        result.Append(Rune.ToLowerInvariant(ch));
                        flag = ChIs.NextOfContdUpper;
                    }
                    else
                    {
                        result.Append(ch);
                        flag = ChIs.NextOfUpper;
                    }
                    continue;
                }
                else if (Rune.IsLower(ch))
                {
                    if (flag == ChIs.FirstOfStr)
                    {
                        result.Append(Rune.ToUpperInvariant(ch));
                    }
                    else if (flag == ChIs.NextOfContdUpper)
                    {
                        char prev = result[result.Length - 1];
                        if (char.IsLower(prev))
                        {
                            prev = char.ToUpperInvariant(prev);
                        }
                        result.Length--;
                        result.Append(prev);
                        result.Append(ch);
                    }
                    else if (flag == ChIs.NextOfSepMark
                      || (opts.SeparateAfterNonAlphabets && flag == ChIs.NextOfKeptMark))
                    {
                        result.Append(Rune.ToUpperInvariant(ch));
                    }
                    else
                    {
                        result.Append(ch);
                    }
                    flag = ChIs.Others;
                    continue;
                }
                else if (Rune.IsDigit(ch))
                {
                    isKeptChar = true;
                }
            }

            if (!isKeptChar)
            {
                if (sepChs != null)
                {
                    if (Array.BinarySearch(sepChs, ch) < 0)
                    {
                        isKeptChar = true;
                    }
                }
                else if (keptChs != null)
                {
                    if (Array.BinarySearch(keptChs, ch) >= 0)
                    {
                        isKeptChar = true;
                    }
                }
            }

            if (isKeptChar)
            {
                result.Append(ch);
                flag = ChIs.NextOfKeptMark;
            }
            else
            {
                if (flag != ChIs.FirstOfStr)
                {
                    flag = ChIs.NextOfSepMark;
                }
            }
        }

        return result.ToString();
    }

    /// <summary>
    /// Converts the input string to pascal case.
    /// <br/><br/>
    /// It treats the end of a sequence of non-alphabetical characters as a word boundary, but not
    /// the beginning.
    /// </summary>
    ///
    /// @param input The input string.
    /// @return A string converted to pascal case.
    public static string PascalCase(string input)
    {
        return PascalCaseWithOptions(input, new Options(false, true, null, null));
    }

    /// <summary> 
    /// Converts the input string to snake case with the specified options.
    /// </summary> 
    ///
    /// <param name="input">The input string.</param>
    /// <param name="opts">The options which specifies the ways of case conversion.</param>
    /// <returns>A string converted to snake case.</returns>
    public static string SnakeCaseWithOptions(string input, Options opts)
    {
        return Lowerize(input, '_', opts);
    }

    /// <summary> 
    /// Converts the input string to snake case.
    /// <br/><br/>
    /// It treats the end of a sequence of non-alphabetical characters as a word boundary, but not
    /// the beginning.
    /// </summary> 
    ///
    /// <param name="input">The input string.</param>
    /// <returns>A string converted to snake case.</returns>
    public static string SnakeCase(string input)
    {
        return Lowerize(input, '_', new Options(false, true, null, null));
    }

    /// <summary>
    /// Converts the input string to train case with the specified options.
    /// </summary>
    ///
    /// <param name="input">The input string.</param>
    /// <param name="opts">The options which specifies the ways of case conversion.</param>
    /// <returns>A string converted to train case.</returns>
    ///
    public static string TrainCaseWithOptions(string input, Options opts)
    {
        return Capitalize(input, '-', opts);
    }

    /// <summary>
    /// Converts the input string to train case.
    /// <br/><br/>
    /// It treats the end of a sequence of non-alphabetical characters as a word boundary, but not
    /// the beginning.
    /// </summary>
    ///
    /// <param name="input">The input string.</param>
    /// <returns>A string converted to train case.</returns>
    ///
    public static string TrainCase(string input)
    {
        return Capitalize(input, '-', new Options(false, true, null, null));
    }

    /// <summary>
    /// Converts the input string to Ada case with the specified options.
    /// </summary>
    ///
    /// <param name="input">The input string.</param>
    /// <param name="opts">The options which specifies the ways of case conversion.</param>
    /// <returns>A string converted to Ada case.</returns>
    public static string AdaCaseWithOptions(string input, Options opts)
    {
        return Capitalize(input, '_', opts);
    }

    /// <summary>
    /// Converts the input string to Ada case.
    /// <br/><br/>
    /// It treats the end of a sequence of non-alphabetical characters as a word boundary, but not
    /// the beginning.
    /// </summary>
    ///
    /// <param name="input">The input string.</param>
    /// <returns>A string converted to Ada case.</returns>
    public static string AdaCase(string input)
    {
        return Capitalize(input, '_', new Options(false, true, null, null));
    }

    /// <summary>
    /// Converts the input string to title case with the specified options.
    /// </summary>
    ///
    /// <param name="input">The input string.</param>
    /// <param name="opts">The options which specifies the ways of case conversion.</param>
    /// <returns>A string converted to title case.</returns>
    public static string TitleCaseWithOptions(string input, Options opts)
    {
        return Capitalize(input, ' ', opts);
    }

    /// <summary>
    /// Converts the input string to title case.
    /// <br/><br/>
    /// It treats the end of a sequence of non-alphabetical characters as a word boundary, but not
    /// the beginning.
    /// </summary>
    ///
    /// <param name="input">The input string.</param>
    /// <returns>A string converted to title case.</returns>
    public static string TitleCase(string input)
    {
        return Capitalize(input, ' ', new Options(false, true, null, null));
    }
}
