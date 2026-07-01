// ContentCategory.cs
// Copyright © 2012–Present Jackalope Technologies, Inc. and Doug Gerard.
// SPDX-License-Identifier: MIT
// Licensed under the MIT License. See the LICENSE file in the repo root.

namespace Tack.Core.Enums;

/// <summary>
///     Classification category for a scraped documentation page.
///     Renamed from DocCategory; members and integer values are unchanged
///     (Overview=0 … Unclassified=6) so existing int-persisted values load unchanged.
/// </summary>
public enum ContentCategory
{
    /// <summary>
    ///     Conceptual overview, architecture explanation, "about" pages.
    /// </summary>
    Overview,

    /// <summary>
    ///     Step-by-step guide, tutorial, "how to do X" content.
    /// </summary>
    HowTo,

    /// <summary>
    ///     Code samples, demos, example projects.
    /// </summary>
    Sample,

    /// <summary>
    ///     Source code — library implementation files (not usage examples).
    /// </summary>
    Code,

    /// <summary>
    ///     API reference — class, method, property, event documentation.
    /// </summary>
    ApiReference,

    /// <summary>
    ///     Release notes, migration guides, changelog.
    /// </summary>
    ChangeLog,

    /// <summary>
    ///     Did not fit other categories or could not be classified.
    /// </summary>
    Unclassified
}
