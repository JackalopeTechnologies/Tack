// ContentCategoryValuesTests.cs
// Copyright © 2012–Present Jackalope Technologies, Inc. and Doug Gerard.
// SPDX-License-Identifier: MIT
// Licensed under the MIT License. See the LICENSE file in the repo root.

#region Usings

using Tack.Core.Enums;
using Xunit;

#endregion

namespace Tack.Tests.Enums;

[Trait("Category", "Unit")]
public sealed class ContentCategoryValuesTests
{
    [Theory]
    [InlineData(ContentCategory.Overview, 0)]
    [InlineData(ContentCategory.HowTo, 1)]
    [InlineData(ContentCategory.Sample, 2)]
    [InlineData(ContentCategory.Code, 3)]
    [InlineData(ContentCategory.ApiReference, 4)]
    [InlineData(ContentCategory.ChangeLog, 5)]
    [InlineData(ContentCategory.Unclassified, 6)]
    public void ContentCategoryHasHistoricalIntValue(ContentCategory category, int expected)
    {
        int actual = (int) category;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ContentCategoryHasExactlySevenMembers()
    {
        int count = Enum.GetValues<ContentCategory>().Length;
        Assert.Equal(7, count);
    }
}
