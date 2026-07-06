# 08 — Availability and Roadmap

This document maps the feature areas of the Product Requirements Document to their implementation
status in the current build. It is the authority for the **[Available]** and **[Planned]** tags
used throughout this guide. The status reflects the milestone record in the repository (README) and
the release plan (PRD, §11).

## Status at a glance

| Feature area | Status | Milestone | Source |
|--------------|--------|-----------|--------|
| Family account and Owner role | **[Available]** | M0–M1 | PRD, §6.1 |
| Child profiles (grade, interests, login handle, PIN) | **[Available]** | M1 | PRD, §6.1 |
| Child sign-in by login handle and PIN | **[Available]** | M1 | PRD, §6.1 |
| Role-based access (parent / child boundary) | **[Available]** | M1 | PRD, §6.1 |
| Default study routines | **[Available]** | M2 | PRD, §6.2 |
| Today's plan, completion, stars, daily streak | **[Available]** | M2 | PRD, §6.2 |
| Parent-authored or templated routines | **[Planned]** | — | PRD, §6.2 |
| Projects and interests portfolio | **[Planned]** | M3 | PRD, §6.3 |
| Sports and extracurricular logging | **[Planned]** | M4 | PRD, §6.4 |
| Scholarship and opportunity finder (AI) | **[Planned]** | M5 | PRD, §6.5, §7 |
| Resources library | **[Planned]** | M6 | PRD, §6.6 |
| Extended gamification and roadmap | **[Planned]** | M6 | PRD, §6.7 |
| Parent dashboard aggregates and weekly digest | **[Planned]** | M6 | PRD, §6.8–§6.9 |
| Mentor role | **[Planned]** | v2 | PRD, §4, §11 |
| SQL Server persistence and migrations | **[Planned]** | M7 | README; PRD, §11 |

## Milestone record

The milestone record reported in the repository is (README):

- **M0 — Walking skeleton** — complete. Solution, web workspace, end-to-end harness, and the first
  registration-to-token slice.
- **M1 — Accounts and family** — complete. Parent registration, child profiles, child sign-in, and
  role-based access.
- **M2 — Study routines** — complete. Default routines, the daily plan, completion, stars, and the
  daily streak.
- **M3 — Portfolio**, **M4 — Sports**, **M5 — Scholarships (stubbed AI)**, **M6 — Resources,
  gamification, and digest**, **M7 — Hardening** — planned.

## Consequence for a parent today

A parent beginning today operates within milestones M0 through M2: account, child profile, sign-in,
and the daily study-routine loop. The procedure in
[04 — Getting Started Today](04-getting-started-today.md) is confined to these capabilities. The
portfolio, sports, scholarship finder, resources, and weekly digest are not yet operable and shall
not be relied upon until their milestones are delivered.
