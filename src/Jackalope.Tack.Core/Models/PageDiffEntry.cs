// PageDiffEntry.cs
// Copyright © 2012–Present Jackalope Technologies, Inc. and Doug Gerard.
// SPDX-License-Identifier: MIT
// Licensed under the MIT License. See the LICENSE file in the repo root.

#region Usings

using Tack.Core.Enums;

#endregion


namespace Tack.Core.Models;

/// <summary>
///     A page that was added or removed between versions.
/// </summary>
public record PageDiffEntry

{
    /// <summary>
    ///     Page URL.
    /// </summary>

    public required string Url { get; init; }


    /// <summary>
    ///     Page title.
    /// </summary>

    public required string Title { get; init; }


    /// <summary>
    ///     Page classification category.
    /// </summary>

    public required ContentCategory Category { get; init; }
}
