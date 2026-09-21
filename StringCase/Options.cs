/*
 * Options.cs
 * Copyright (C) 2026 Takayuki Sato. All Rights Reserved.
 */

namespace StringCase;

/// <summary>
/// Is a class that represents options which specifies the ways of case conversion of strings.
/// </summary>
public struct Options
{
    /// <summary>
    /// Specifies whether to treat the beginning of a sequence of non-alphabetical characters as a
    /// word boundary.
    /// </summary>
    public readonly bool SeparateBeforeNonAlphabets;

    /// <summary>
    /// Specifies whether to treat the end of a sequence of non-alphabetical characters as a word
    /// boundary.
    /// </summary>
    public readonly bool SeparateAfterNonAlphabets;

    /// <summary>
    /// Specifies the set of characters to be treated as word separators and removed from the result
    /// string.
    /// </summary>
    public readonly string? Separators;

    /// <summary>
    /// Specifies the set of characters not to be treated as word separators and kept in the result
    /// string.
    /// </summary>
    public readonly string? Keep;

    /// <summary>
    /// The constructor which takes the arguments that specifies the ways of case conversion.
    /// </summary>
    /// <param name="separateBeforeNonAlphabets">The flag that specifies whether to treat the
    ///   beginning of a sequence of non-alphabetical characters as a word boundary.</param>
    /// <param name="separateAfterNonAlphabets">The flag that specifies whether to treat the end of
    ///   a sequence of non-alphabetical characters as a word boundary.</param>
    /// <param name="separators">The symbol characters to be treated as word separators and removed
    ///   from the result string.</param>
    /// <param name="keep">The symbol characters to be treated as word separators and kept in the
    ///   result string.</param>
    public Options(
        bool separateBeforeNonAlphabets = false,
        bool separateAfterNonAlphabets = false,
        string? separators = null,
        string? keep = null
    )
    {
        this.SeparateBeforeNonAlphabets = separateBeforeNonAlphabets;
        this.SeparateAfterNonAlphabets = separateAfterNonAlphabets;
        this.Separators = separators;
        this.Keep = keep;
    }
}
