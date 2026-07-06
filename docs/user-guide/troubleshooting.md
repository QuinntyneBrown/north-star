# Troubleshooting

This document records common conditions in the current build as symptom, cause, and resolution.
Each resolution is stated normatively.

## Account creation reports a conflict

**Symptom.** Registration reports *"Could not create your account. That email may already be in
use."* (UI: Register).

**Cause.** An account already exists for the supplied email address.

**Resolution.** The parent **shall** sign in at `http://localhost:4200/login` with the existing
email and password, or **shall** register with a different email address.

## Adding a child reports a conflict

**Symptom.** Adding a child reports *"Could not add child. The login handle may already be taken."*
(UI: Children).

**Cause.** The supplied login handle is already in use; login handles are unique across the
application.

**Resolution.** The parent **shall** choose a different login handle of at least three characters
and resubmit.

## The child cannot sign in

**Symptom.** Child sign-in reports *"That handle or PIN didn't work. Ask a grown-up for help."*
(UI: Child login).

**Cause.** The login handle or the personal identification number does not match the child profile,
or the personal identification number is not 4 to 6 digits.

**Resolution.** The parent **shall** verify the login handle and the personal identification number
recorded at child creation, confirm the personal identification number is 4 to 6 digits, and
re-enter both. The parent **may** confirm the values from the dashboard **Children** card and the
child's **Today →** link.

## The web page does not load

**Symptom.** The browser does not reach `http://localhost:4200`.

**Cause.** The web application process, the application programming interface process, or both are
not running.

**Resolution.** The parent **shall** confirm both processes are running per
[03 — Prerequisites and Setup](03-prerequisites-and-setup.md): the interface on
`http://localhost:8080` and the web application on `http://localhost:4200`. Under Docker the web
application is served on `http://localhost:8081`.

## The plan or a completion does not save

**Symptom.** The plan reports *"Could not load today's plan."* or a completion reports *"Could not
save that. Please try again."* (UI: Today).

**Cause.** The web application cannot reach the application programming interface.

**Resolution.** The parent **shall** confirm the interface is running on `http://localhost:8080` and
**should** retry the action.

## Entered data is missing after a restart

**Symptom.** A previously created family account or child profile is absent after the application is
restarted.

**Cause.** In the Development environment the interface recreates its SQLite schema on each start and
the data is disposable (README).

**Resolution.** This is the expected behaviour of the Development build. The parent **shall** treat
local data as transient; persistent storage is **[Planned: M7]** (see
[09 — Safety and Data](09-safety-and-data.md)).

## Summary cards show a dash, or sidebar items do not navigate

**Symptom.** The dashboard summary cards display `—`, and the **Scholarships**, **Resources**, and
child-space sidebar items do not open a feature (UI: Parent dashboard).

**Cause.** These elements are placeholders for capabilities scheduled in later milestones.

**Resolution.** No action is required. The status of these features is recorded in
[08 — Availability and Roadmap](08-availability-and-roadmap.md).
