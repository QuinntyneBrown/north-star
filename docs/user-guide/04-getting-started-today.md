# 04 — Getting Started Today

This document is the end-to-end procedure for a parent and a nine-year-old child's first session.
It uses only **[Available]** features. Completion of the five steps below establishes a family
account, a child profile, and the child's first completed routine, in approximately fifteen
minutes.

## Precondition

The application shall be running and reachable in a web browser at `http://localhost:4200` (or
`http://localhost:8081` under Docker). The setup procedure is described in
[03 — Prerequisites and Setup](03-prerequisites-and-setup.md).

## Step 1 — Create the family account

The parent navigates to `http://localhost:4200/register` and supplies the account fields
(UI: Register; PRD, §6.1):

| Field | Constraint |
|-------|------------|
| Display name | Required; at most 80 characters. |
| Family name | Required; at most 80 characters. |
| Email | Required; a valid email address. The account owner authenticates with this address. |
| Password | Required; at least 8 characters. |

On success the parent is taken to the parent dashboard at `/dashboard`. The contents of the
dashboard are described in [07 — Parent Dashboard](07-parent-dashboard.md).

A subsequent return to the application is made at `http://localhost:4200/login` using the same
email and password.

## Step 2 — Add the child profile

On the dashboard, within the **Children** card, the parent selects **+ Add child** and supplies the
profile fields (UI: Add child; PRD, §6.1):

| Field | Constraint |
|-------|------------|
| First name | Required. |
| Grade | Required; an integer from 1 to 12. The value for a nine-year-old beginning in Grade 5 is `5`. |
| Interests | Optional; a comma-separated list, for example `writing, science, art`. |
| Login handle | Required; at least 3 characters; unique across the application. The child uses this to sign in. |
| PIN | Required; 4 to 6 digits. The child uses this to sign in. |

The parent selects **Save child**. On success the child appears in the **Children** list with the
grade and interests, and a **Today →** link to the child's plan.

The login handle and the personal identification number are the child's credentials. The parent
**should** record them and **should** choose a personal identification number distinct from any the
family uses elsewhere.

> **Provisioning of routines.** Creating a child profile provisions three default study routines
> for that child (PRD, §6.2). The routines are listed in
> [06 — Routines Reference](06-routines-reference.md). No further configuration is required before
> the first session.

## Step 3 — Open the child's plan

There are two paths to the child's plan:

- **Child sign-in.** The child navigates to `http://localhost:4200/child-login` and supplies the
  login handle and the personal identification number. On success the child is taken to the plan at
  `/children/{childId}/today` (UI: Child login).
- **Parent preview.** From the dashboard, the parent selects the child's **Today →** link to open
  the same plan (UI: Children).

For a first session the parent **should** sit beside the child, sign in by the child path together,
and hand over the device once the plan is shown.

## Step 4 — Complete the first routine together

On the plan, the child selects the check control beside one routine — for example
`Read for 20 minutes`. On completion (UI: Today; PRD, §6.2):

- The routine is marked done and its check control is disabled.
- The number of stars stated for that routine is awarded and reflected in the **stars today** count.
- The completed count and the progress indicator advance.
- The daily streak begins at one day.

The child **should** complete at least one routine in the first session so that the streak begins
and the reward is observed. The mechanics of the plan are described in
[05 — The Daily Loop](05-the-daily-loop.md).

## Step 5 — Establish the daily time

The practice depends on repetition (PRD, §6.2, §6.7). The parent **should** agree a consistent
daily time of approximately fifteen minutes with the child and **should** return to Step 3 each day.
Configurable reminders and a weekly parent digest are **[Planned: M6]** (PRD, §6.9); until then the
parent maintains the schedule.

## First-fifteen-minutes checklist

The following conditions hold when the first session is complete:

- [ ] A family account exists, reachable at `/login`.
- [ ] A child profile exists with grade `5`, a login handle, and a personal identification number.
- [ ] The login handle and personal identification number are recorded by the parent.
- [ ] The child has signed in at `/child-login` and viewed the plan.
- [ ] At least one routine is marked done, stars are awarded, and the streak reads one day.
- [ ] A daily time for the practice is agreed.
