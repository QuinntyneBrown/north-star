# North Star — User Guide

North Star is a parent-and-child web application that guides a Grade 5 student toward a
university scholarship through daily study routines, a projects portfolio, activity tracking,
and an AI-assisted scholarship finder (PRD, §1). This guide describes how a parent prepares the
application and how a parent and a nine-year-old child begin daily practice with the features
available in the current build.

This guide is a set of focused documents. The intended starting point for a first session is
[04 — Getting Started Today](04-getting-started-today.md).

## Documents

| # | Document | Purpose |
|---|----------|---------|
| — | [README](README.md) | Index, conventions, and conformance statement (this document). |
| 01 | [Introduction](01-introduction.md) | What North Star is, its purpose, and the scope of the current build. |
| 02 | [Roles and Vocabulary](02-roles-and-vocabulary.md) | The defined roles and the terms used throughout this guide. |
| 03 | [Prerequisites and Setup](03-prerequisites-and-setup.md) | The software prerequisites and the procedure to run the application. |
| 04 | [Getting Started Today](04-getting-started-today.md) | The end-to-end procedure for a parent and child's first session. |
| 05 | [The Daily Loop](05-the-daily-loop.md) | The child's daily practice: the plan, completion, stars, and streak. |
| 06 | [Routines Reference](06-routines-reference.md) | The default routines and the rules governing completion and streaks. |
| 07 | [Parent Dashboard](07-parent-dashboard.md) | The contents of the parent dashboard in the current build. |
| 08 | [Availability and Roadmap](08-availability-and-roadmap.md) | The feature areas available now and those planned for later milestones. |
| 09 | [Safety and Data](09-safety-and-data.md) | The child-data and safety posture relevant to a parent. |
| — | [Glossary](glossary.md) | The controlled vocabulary and single source of term definitions. |
| — | [Troubleshooting](troubleshooting.md) | Symptoms, causes, and resolutions for common conditions. |

## Conventions

**Voice.** This guide is written in a single impersonal voice. The participants are named by
their defined roles — *the parent* and *the child* (see [02 — Roles and Vocabulary](02-roles-and-vocabulary.md)) —
rather than addressed in the second person.

**Normative keywords.** The words **shall**, **should**, and **may** carry normative force:

- **shall**: a requirement; the described condition is necessary for correct operation.
- **should**: a recommendation; departure is permitted where justified.
- **may**: an option that is permitted but not required.

**Terminology.** Defined terms are used precisely. The [Glossary](glossary.md) is the single
source of truth; where this guide and intuition disagree, the glossary prevails.

**Availability tags.** Statements about features carry a tag indicating implementation status:

- **[Available]** — implemented and operable in the current build.
- **[Planned: M*n*]** — specified but not yet implemented; scheduled for the named milestone (see
  [08 — Availability and Roadmap](08-availability-and-roadmap.md)).

**Citations.** Claims are attributed to their source:

- **(PRD, §*n*)** refers to the section of the Product Requirements Document at
  [`docs/PRD.md`](../PRD.md).
- **(README)** refers to the repository `README.md`.
- **(UI: *view*)** refers to an observable condition of the named view in the running application.

**Measurement.** Quantities are stated with units and bounds (for example, a personal
identification number of four to six digits) rather than with informal adjectives.

## Conformance statement

This guide adopts the prose register and document-structure discipline of the
*architecture-description-style-guide*: a single impersonal voice, normative keywords, controlled
vocabulary backed by a glossary, measurable statements, and attributed sources.

This guide is product user guidance, not an architecture description. It therefore does not claim
conformance to ISO/IEC/IEEE 42010:2022 and does not present the Clause 6 architecture-description
content (viewpoints, views, view components, correspondences). The style guide's expression rules
are applied; its architecture-description schema is not.
