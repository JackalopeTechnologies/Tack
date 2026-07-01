// JobType.cs
// Copyright © 2012–Present Jackalope Technologies, Inc. and Doug Gerard.
// SPDX-License-Identifier: MIT
// Licensed under the MIT License. See the LICENSE file in the repo root.

namespace Tack.Core.Enums;

/// <summary>
///     Discriminator for jobs surfaced by the unified job view.
/// </summary>
public enum JobType
{
    Scrape,
    DryRunScrape,
    Rechunk,
    Rescrub,
    Reembed,
    RenameLibrary,
    RenameVersion,
    DeleteVersion,
    DeleteLibrary,
    IndexProjectDependencies,
    SubmitUrlCorrection,
    CleanupAuditLog,
    CleanupJobs,
    CleanupOrphans,
    Unknown
}
