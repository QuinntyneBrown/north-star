# 09 — Safety and Data

North Star processes children's data, which the requirements treat as the highest-priority
non-functional concern (PRD, §10.1). This document records the safety and data posture relevant to
a parent and distinguishes the design commitments from what the current build implements.

## Design commitments

The requirements record the following commitments for the product (PRD, §7, §10.1, §10.2). They are
stated here as the standard a parent should expect the product to meet:

- Child data **shall** be treated as sensitive and designed to the principles of COPPA and
  applicable equivalents, including GDPR-K, Canada PIPEDA, and the United Kingdom
  Age-Appropriate Design Code: verifiable parental consent, data minimization, purpose limitation,
  and straightforward deletion and export (PRD, §10.1).
- A parental-consent gate **shall** precede activation of a child profile, with granular consent for
  notifications and any outward-facing features (PRD, §10.1).
- The product **shall not** present public child profiles, behavioural advertising or tracking, or
  third-party data sharing for marketing (PRD, §10.1).
- Data **shall** be encrypted in transit and at rest, with least-privilege access and audit logs for
  sensitive actions (PRD, §10.1, §10.2).
- The product **shall** provide data export and a "delete my family" control (PRD, §10.1).
- The scholarship pipeline **shall not** auto-submit applications and **shall** link every
  opportunity to its original source with a confidence and verification indicator (PRD, §7).

## Status in the current build

The current build implements the account and access controls of milestones M0 through M2: an
email-and-password account for the parent, a login-handle-and-personal-identification-number sign-in
for the child, and the role-based boundary between them (PRD, §6.1). The following commitments are
**[Planned]** and a parent shall not assume them in the current build:

- The parental-consent gate is **[Planned]** (PRD, §11, MVP).
- The scholarship pipeline and its source-linking and confidence indicators are **[Planned: M5]**
  (PRD, §7). No outward-facing scholarship action exists to approve in the current build.
- Production-grade persistence, encryption at rest, and audit logging are associated with hardening
  and are **[Planned: M7]** (PRD, §11).

## Local data in the Development build

In the Development environment the application stores data in a local SQLite database that is
recreated on each start, and the data is disposable (README). Two consequences follow for a parent:

- Data entered locally — including a child's first name, grade, interests, login handle, and
  personal identification number — resides only on the computer running the application and is not
  transmitted to a hosted service.
- That data is transient and is not guaranteed to survive a restart of the application programming
  interface (see [03 — Prerequisites and Setup](03-prerequisites-and-setup.md)).

A parent **should** therefore treat the current build as an early trial rather than a system of
record, and **should** enter no more child information than the getting-started procedure requires.

## Credential handling

The child's credentials are a login handle of at least three characters and a personal
identification number of four to six digits (UI: Add child). A parent **should** record these,
**should** choose a personal identification number distinct from any the family uses elsewhere, and
**should** treat the personal identification number as the child's private secret.
