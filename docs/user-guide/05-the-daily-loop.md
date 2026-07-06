# 05 — The Daily Loop

The daily loop is the child's recurring practice in the current build: open the plan, complete the
due routines, and observe the reward (PRD, §5, §6.2). This document describes what the plan
presents, the completion action, and the parent guidance that sustains the practice.

## The plan

After the child signs in (see [04 — Getting Started Today](04-getting-started-today.md)), the plan
is shown at `/children/{childId}/today` under the heading **Today's plan**. The plan presents the
following elements (UI: Today):

- **Progress count** — the number of routines done out of the number due, stated as *"N of M
  done."*
- **Streak** — the count of consecutive days of routine activity, stated as *"🔥 N-day streak."*
- **Stars today** — the stars awarded on the current day, stated as *"⭐ N today."*
- **Progress indicator** — a bar reflecting the completion percentage of the plan.
- **Routine list** — one row per due routine, each showing a check control, an icon, the routine
  title, and the stars the routine awards, stated as *"+N ⭐."*

## Completing a routine

The child selects the check control beside a routine. On completion (UI: Today; PRD, §6.2):

1. The routine is marked done and the row is styled as complete.
2. The check control for that routine is disabled, so a routine is completed at most once per day.
3. The stars stated for the routine are awarded and added to the **stars today** count.
4. The progress count and progress indicator advance.
5. The streak reflects the consecutive-day count, beginning at one on the first day of activity.

A routine that is already done **may not** be completed again on the same day; its check control is
disabled. The rules governing routines, stars, and streaks are recorded in
[06 — Routines Reference](06-routines-reference.md).

## Encouragement model

The reward model is tuned for consistency and is not punitive (PRD, §6.2, §6.7):

- A missed day does not remove stars already earned and does not present a penalty.
- Stars and the streak accumulate from repeated completion rather than from the volume of work in
  any single session.

## Parent guidance

The following recommendations apply to the parent during the daily loop:

- The parent **should** keep each session short — on the order of fifteen minutes — consistent with
  the consistency-over-intensity intent (PRD, §6.7).
- The parent **should** co-sit for early sessions and reduce involvement as the child becomes
  self-directed (PRD, §3.1).
- The parent **should not** use the streak or stars as a source of pressure; over-pressuring the
  child is a recorded design risk (PRD, §13).
- The parent **may** preview the same plan from the dashboard by way of the child's **Today →**
  link without signing in as the child (UI: Children).

## Boundaries of the current loop

The daily loop in the current build covers study routines only. Capturing projects to a portfolio,
logging sports, and acting on scholarship matches are part of the wider journeys described in the
requirements (PRD, §5) but are **[Planned]**; their status is recorded in
[08 — Availability and Roadmap](08-availability-and-roadmap.md).
