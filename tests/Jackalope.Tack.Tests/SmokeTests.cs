// SmokeTests.cs
// Copyright © 2012–Present Jackalope Technologies, Inc. and Doug Gerard.
// SPDX-License-Identifier: MIT
// Licensed under the MIT License. See the LICENSE file in the repo root.

using Tack.Core;

namespace Tack.Tests;

/// <summary>
///     Track 1 smoke tests: prove the test host runs and that the Tack.Core
///     package skeleton is referenceable. Replaced by real coverage in later
///     tracks.
/// </summary>
public sealed class SmokeTests
{
    private const string ExpectedCorePackageId = "Jackalope.Tack.Core";

    [Fact]
    public void CorePackageMarkerExposesExpectedPackageId()
    {
        string res = TackCorePackageMarker.PackageId;
        Assert.Equal(ExpectedCorePackageId, res);
    }
}
