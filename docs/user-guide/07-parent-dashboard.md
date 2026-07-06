# 07 — Parent Dashboard

The parent dashboard at `/dashboard` is the parent's entry point after registration or sign-in
(UI: Register, Login). This document records what the dashboard presents in the current build and
which elements are placeholders pending later milestones.

## Layout

The dashboard presents a sidebar, a header, summary cards, the **Children** card, and a welcome
note (UI: Parent dashboard).

## Header

The header greets the account owner by display name and provides a **Sign out** control (UI: Parent
dashboard). Sign-out returns the parent to the sign-in path.

## Summary cards — placeholders

Four summary cards are present: **Current streak**, **Routines this week**, **Portfolio items**, and
**New matches**. In the current build each card displays a placeholder dash (`—`) rather than a
computed value (UI: Parent dashboard). The aggregated parent figures and weekly digest that populate
these cards are **[Planned: M6]** (PRD, §6.8–§6.9).

## Children card — operable

The **Children** card is the operable area of the dashboard (UI: Children):

- **+ Add child** opens the form for creating a child profile, with the fields and constraints
  listed in [04 — Getting Started Today](04-getting-started-today.md).
- Each existing child is listed with the first initial, the grade, the interests, and a **Today →**
  link to that child's plan.
- When no child exists, the card presents the empty state *"No children yet — add your first to
  begin the journey."*

## Sidebar — partly placeholder

The sidebar presents the navigation items **Overview**, **Scholarships**, **Resources**, and the
child's space. In the current build **Overview** is the active view; the remaining items are
placeholders that do not yet navigate to operable features (UI: Parent dashboard). Their
destinations are **[Planned]** — scholarships at M5 and resources at M6 (PRD, §6.5, §6.6).

## Welcome note

The dashboard includes a welcome note stating that study routines, the portfolio, sports, and the
scholarship finder arrive in subsequent milestones (UI: Parent dashboard). This is consistent with
the availability recorded in [08 — Availability and Roadmap](08-availability-and-roadmap.md).
