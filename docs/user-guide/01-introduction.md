# 01 — Introduction

## Purpose

North Star turns the long-horizon goal of earning a university scholarship into a daily,
year-over-year practice (PRD, §1). The practice begins when the child is in Grade 5, at
approximately nine years of age, and is designed to continue through Grade 12.

The product is organized around four pillars (PRD, §1):

1. **Study routines and habits** — small daily rituals tracked with streaks and gentle
   accountability.
2. **Projects and interests** — a portfolio of creative and academic work that becomes admissions
   evidence.
3. **Sports and extracurriculars** — practice logs, teams, and milestones.
4. **Scholarship discovery** — an AI-assisted engine that scans for awards, contests, and programs
   the child could one day qualify for.

The guiding question for the product is recorded in the requirements as: *"What can a nine-year-old
do this week that their seventeen-year-old self will thank them for?"* (PRD, §1).

## Audience

This guide addresses two readers:

- **The parent**, who prepares the application, creates the family account, and sets up the child's
  daily practice.
- **The child**, who is the daily user and who, in the current build, completes a short plan of
  study routines.

The roles are defined in [02 — Roles and Vocabulary](02-roles-and-vocabulary.md).

## Scope of the current build

North Star is under active, milestone-based development. The features described in the Product
Requirements Document are delivered in stages (README; PRD, §11). A parent beginning today shall
treat the application as an early build operated from source rather than a hosted service (see
[03 — Prerequisites and Setup](03-prerequisites-and-setup.md)).

The following capabilities are **[Available]** in the current build and are the subject of this
guide:

- A family account owned by a parent, with role-based access (PRD, §6.1).
- One or more child profiles, each with a grade, optional interests, a login handle, and a personal
  identification number (PRD, §6.1).
- Simplified child sign-in by login handle and personal identification number, with no child email
  (PRD, §6.1).
- A daily plan of study routines for each child, with completion, stars, and a daily streak
  (PRD, §6.2).

The following capabilities are **[Planned]** and are not yet operable; they appear in this guide
only to mark the boundary of the current build:

- The projects and interests portfolio — **[Planned: M3]** (PRD, §6.3).
- Sports and extracurricular logging — **[Planned: M4]** (PRD, §6.4).
- The scholarship and opportunity finder — **[Planned: M5]** (PRD, §6.5).
- The resources library, extended gamification, and the parent weekly digest — **[Planned: M6]**
  (PRD, §6.6–§6.9).

The complete mapping of feature areas to status is recorded in
[08 — Availability and Roadmap](08-availability-and-roadmap.md).

## Design intent relevant to a parent

Two design commitments shape how a parent should use the current build:

- **Consistency over intensity.** Routines, streaks, and stars are tuned to reward repetition, and
  missed days are not penalized (PRD, §6.2, §6.7). The parent should favour short, regular sessions
  over long, infrequent ones.
- **Encouragement, not pressure.** The requirements record over-pressuring the child as a named
  risk and direct the design toward encouragement (PRD, §13). The parent should keep sessions
  brief and low-stakes, particularly at the outset.
