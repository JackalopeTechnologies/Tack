// CoreModelsCompileTests.cs
// Copyright © 2012–Present Jackalope Technologies, Inc. and Doug Gerard.
// SPDX-License-Identifier: MIT
// Licensed under the MIT License. See the LICENSE file in the repo root.

#region Usings

using Tack.Core.Enums;
using Tack.Core.Models;
using Xunit;

#endregion

namespace Tack.Tests.Models;

[Trait("Category", "Unit")]
public sealed class CoreModelsCompileTests
{
    [Fact]
    public void SymbolConstructsWithPersistedPropertyNames()
    {
        var symbol = new Symbol
        {
            Name = "XamDataGrid",
            Kind = SymbolKind.Type,
            Container = "Infragistics.Controls"
        };

        Assert.Equal("XamDataGrid", symbol.Name);
        Assert.Equal(SymbolKind.Type, symbol.Kind);
        Assert.Equal("Infragistics.Controls", symbol.Container);
    }

    [Fact]
    public void JobRecordDefaultsStatusToQueued()
    {
        var job = new JobRecord
        {
            Id = "job-1",
            JobType = JobType.Scrape
        };

        Assert.Equal(JobStatus.Queued, job.Status);
    }
}
