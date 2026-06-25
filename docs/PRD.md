# North Star — Product Requirements Document (PRD)

**A long-horizon guidance app that helps a child build the habits, projects, and track record that lead to a university scholarship — starting in Grade 5.**

| | |
|---|---|
| **Product name** | North Star |
| **Document owner** | Quinntyne Brown |
| **Status** | Draft v0.1 |
| **Last updated** | 2026-06-25 |
| **Primary platforms** | Web (responsive). Backend: .NET 8 (ASP.NET Core). Frontend: Angular 17. |

---

## 1. Summary

North Star is a parent-and-child product that turns the vague, intimidating goal of "earn a university scholarship" into a daily, playful, year-over-year practice. It starts when the child is in Grade 5 (~age 9) and grows with them through Grade 12.

The app has four pillars:

1. **Study routines & habits** — small daily rituals that compound (reading, math practice, focus blocks), tracked with streaks and gentle accountability.
2. **Projects & interests** — a living portfolio of creative and academic work (science fair, writing, coding, art, music) that becomes scholarship and admissions evidence.
3. **Sports & extracurriculars** — practice logs, teams, and milestones that round out the profile.
4. **Scholarship discovery** — an AI-assisted engine that continuously scans the web for scholarships, awards, contests, and programs the child could one day qualify for, and maps them back to actions to take *now*.

A **parent** co-pilots the experience: they set up the account, configure routines, review progress, and approve outward-facing actions. The **child** gets an age-appropriate, encouraging interface that makes consistency feel like a game, not a chore.

> **Design north star:** *"What can a 9-year-old do this week that their 17-year-old self will thank them for?"*

---

## 2. Problem & opportunity

- Scholarships and competitive admissions reward a **multi-year body of work** — sustained academics, deep interests, leadership, and documented achievement. Most families start thinking about this in Grade 11, which is far too late to build the strongest profiles.
- The scholarship landscape is **fragmented and noisy**: thousands of awards across foundations, universities, contests, and local organizations, each with different criteria and deadlines. Parents can't realistically track them.
- Young children build durable habits through **short, rewarding, repeatable loops** — but most "study apps" are either rote drilling or generic to-do lists, with no connection to a meaningful long-term goal.

**Opportunity:** A single product that (a) makes daily practice rewarding for the child, (b) quietly accumulates a portfolio of evidence, and (c) uses AI to keep a forward-looking map of opportunities — so the family is always doing the *right next thing*.

---

## 3. Goals & non-goals

### 3.1 Goals (what success looks like)
- A child sustains study and interest routines with **multi-week streaks**, mostly self-directed by upper grades.
- By Grade 8, the family has a **documented portfolio** of 10+ projects/achievements with artifacts and reflections.
- The family receives a **curated, deadline-aware feed** of relevant scholarships, contests, and programs — with clear "what to do now" guidance for each.
- Parents feel **in control and informed** without micromanaging.

### 3.2 Non-goals (explicitly out of scope for v1)
- Not a tutoring/curriculum platform — North Star *organizes and motivates* practice; it does not teach math or grade essays.
- Not a college application manager (Common App workflows, transcripts submission) — that is a future, older-age extension.
- Not a social network. No child-to-child messaging or public profiles in v1.
- Not financial-aid/FAFSA processing.
- No automated *application submission* to scholarships in v1 (discovery + tracking only; humans apply).

---

## 4. Users & personas

### Persona A — "Maya," the child (primary user, age 9, Grade 5)
- Motivated by progress, rewards, characters, and praise; short attention span.
- Can read and navigate simple UIs but needs large targets, clear language, and minimal text.
- **Needs:** to know what to do today, to feel proud of streaks/badges, to capture work she's excited about.

### Persona B — "David," the parent/guardian (primary user & account owner)
- Busy; wants high signal, low effort. Sets the strategy, reviews weekly.
- **Needs:** confidence the child is on track, a trustworthy scholarship radar, control over privacy and any outward-facing actions.

### Persona C — "Coach/Mentor" (secondary, future)
- A tutor, coach, or grandparent invited with limited access to encourage and verify activities.

### Persona D — Admin/Operator (internal)
- Manages the scholarship data pipeline, content/resource library, and moderation.

---

## 5. Key user journeys

1. **Onboarding (parent-led):** David creates a family account → adds Maya's profile (grade, interests, strengths) → picks starter routines from templates → sets a weekly review time. Child gets a friendly avatar and first quest.
2. **Daily loop (child):** Maya opens North Star → sees "Today's 3 things" → completes a 15-min reading block and logs a sketch for her art project → earns stars, extends her streak, sees an encouraging message.
3. **Weekly review (parent):** David gets a Sunday digest → sees streaks, new portfolio items, and 3 newly matched scholarships/contests with deadlines → approves entering one age-appropriate art contest.
4. **Project capture:** Maya finishes a volcano science model → adds photos, a one-line "what I learned," and tags it `science`. It enters the portfolio timeline and links to a matched science contest.
5. **Scholarship match:** The AI engine surfaces a national kids' writing contest open to Grade 5 → North Star explains *why it matched*, the deadline, and the next step ("write a 300-word story this month"). David saves it to the plan.

---

## 6. Feature requirements

Priorities use MoSCoW: **M**ust / **S**hould / **C**ould (for v1 unless noted).

### 6.1 Accounts, profiles & roles — **M**
- Family account owned by a parent (account owner). One or more **child profiles**. Roles: Owner (parent), Child, Mentor (invited, limited).
- Child sign-in is simplified (parent-managed PIN/avatar login); no email required for a child.
- Profile captures: grade, birth year, interests, strengths, goals, and consent settings.
- Parent can switch into a child's view; child cannot access parent-only areas (scholarships approvals, settings, billing).

### 6.2 Study routines & habits — **M**
- **Routine templates** by grade band (e.g., "Read 20 minutes," "Math facts x10," "Free-write," "Tidy + plan tomorrow").
- Daily **"Today's plan"** (the 3 things) with check-off, optional timer/focus mode, and quick notes.
- **Streaks**, weekly completion %, and **badges/stars** for milestones; gentle, never punitive (missed days don't shame).
- Reminders/notifications (parent-configurable quiet hours).
- Weekly habit summary feeding the parent digest.

### 6.3 Projects & interests portfolio — **M**
- Create a **project** with type (creative/academic/STEM/arts/service), description, and status (idea → in progress → done).
- Attach **artifacts**: photos, files, links, and short reflections ("what I learned," "what was hard").
- **Portfolio timeline** view across years; filter/tag by interest; "showcase" flag for best work.
- Auto-suggests linking projects to matched contests/scholarships.

### 6.4 Sports & extracurriculars — **S** (M for log; advanced stats later)
- Track **activities/teams**, practice/game logs, hours, and personal milestones (e.g., "swam 50m," "first goal").
- Season summaries that contribute to the overall profile and parent digest.

### 6.5 Scholarship & opportunity discovery (AI) — **M** (engine), **S** (advanced personalization)
- A continuously updated **catalog** of scholarships, awards, contests, grants, and enrichment programs.
- **AI-assisted ingestion**: crawl/scrape configured sources, then use an LLM to extract structured fields (eligibility, age/grade, region, amount, deadline, requirements, link) and normalize them.
- **Matching**: rank opportunities for each child by eligibility + interests + horizon ("eligible now" vs. "prepare for later").
- For each match: a plain-language **"why this matched"**, the **deadline**, and a **"do this now" next step** that can be added to the plan/portfolio.
- **Save / track / dismiss**; saved items get deadline reminders. Parent approval required before any outward action.
- **Safety & trust:** every item links to its **original source**; flag/verify status; never auto-submit applications; surface confidence and "needs review" for low-confidence extractions. (See §7.)

### 6.6 Resources library — **S**
- Curated articles, activities, reading lists, printables, and "challenges" mapped to interests and grade.
- Searchable/filterable; "add to plan" action.

### 6.7 Progress, milestones & gamification — **M**
- Long-horizon **roadmap** (Grade 5 → 12) with milestones per pillar; visualize "how far we've come."
- Stars/badges, levels, and celebratory moments — tuned to encourage *consistency over intensity*.

### 6.8 Parent dashboard & digest — **M**
- At-a-glance: streaks, weekly completion, new portfolio items, sport logs, and new scholarship matches with deadlines.
- **Weekly digest** (in-app + optional email).
- Controls: routine config, approvals queue, privacy/consent, notifications, members/roles.

### 6.9 Notifications — **S**
- Child: gentle daily nudge + celebration moments.
- Parent: weekly digest, urgent deadlines, approval requests.
- Channels: in-app + email (push as a later mobile feature). Respect quiet hours.

---

## 7. AI & scholarship pipeline (deep dive)

The scholarship engine is the product's most differentiated and most risk-sensitive component. Design it as a **pipeline with a human-in-the-loop**, not a black box.

```
Sources ──> Fetcher/Crawler ──> Raw store ──> AI Extraction (LLM) ──>
  Normalizer/Dedupe ──> Validation & Confidence ──> Catalog ──>
    Matching Engine (per child) ──> Feed + Reminders
                                   ▲
                       Human review / moderation
```

**Stages**
1. **Sources** — a curated, configurable list (foundation sites, contest aggregators, university award pages, government/regional programs, vetted aggregators/APIs). Respect each site's `robots.txt` and Terms of Service; prefer official APIs/feeds where available; throttle politely; cache.
2. **Fetcher** — scheduled background jobs fetch HTML/PDF/feeds. Store raw + fetch metadata for provenance and re-processing.
3. **AI extraction** — an LLM (latest Claude model, e.g. Opus 4.8 for hard extraction, a faster model for bulk) converts unstructured pages into a structured `Opportunity` schema (below). Use strict output schemas/tool-calling and citations back to the source text.
4. **Normalize & dedupe** — canonicalize amounts/currencies, dates, regions, and grade/age bands; merge duplicates across sources.
5. **Validation & confidence** — rule checks (valid deadline in the future, working link, plausible amount) + model confidence. Low-confidence or high-impact items go to a **review queue** before publishing.
6. **Matching** — per-child ranking using eligibility filters (age/grade/region/citizenship) and interest/strength affinity; classify horizon: **Eligible now / Prepare now, apply later / Aspirational**.
7. **Delivery** — feed, saved list, deadline reminders, and "do this now" suggestions.

**`Opportunity` extracted schema (illustrative)**
- `title`, `provider`, `type` (scholarship | contest | grant | program | award)
- `description`, `eligibility` (age/grade, region, citizenship, criteria)
- `amount` (value, currency, in-kind?), `deadline`, `recurrence`
- `requirements` (what to submit), `effortLevel`, `tags/interests`
- `sourceUrl`, `fetchedAt`, `extractionConfidence`, `reviewStatus`

**Guardrails**
- **Provenance always:** every field traceable to a source URL/snapshot.
- **No auto-submission** of applications; no scraping behind logins or paywalls; honor robots/ToS; rate-limit.
- **Child-safety filter:** exclude anything age-inappropriate; only surface opportunities relevant to the child's band.
- **Human moderation** for low confidence and before anything is recommended as a "next action."
- **Transparency to families:** show source, last-verified date, and a confidence/"verify before applying" note. Treat all matches as *leads to verify*, not guarantees.

---

## 8. Technical architecture

### 8.1 High-level
- **Frontend:** Angular 17 SPA (standalone components, signals, typed reactive forms, Angular Router, lazy-loaded feature modules). Responsive; "kid" and "parent" theme variants. PWA-ready for installable/offline-light use.
- **Backend:** .NET 8 / ASP.NET Core Web API (minimal APIs or controllers), organized by feature (vertical slices) with MediatR-style handlers or clean layering. Auth via ASP.NET Core Identity + JWT/refresh tokens; role-based authorization (Owner/Child/Mentor).
- **Background processing:** .NET hosted services / a job scheduler (e.g., Hangfire or Quartz.NET) for the scholarship pipeline (fetch → extract → match → notify).
- **Data:** SQL Server / PostgreSQL via EF Core 8. Blob storage (Azure Blob/S3) for portfolio artifacts. Optional vector store/`pgvector` for semantic matching/search.
- **AI integration:** Server-side calls to the Claude API (Anthropic SDK) with strict tool/schema outputs for extraction and matching; the latest models (e.g., Opus 4.8 for quality, a faster Claude for bulk). Keep keys server-side only.
- **Notifications/email:** transactional email provider; in-app notification service.
- **Observability:** structured logging, health checks, metrics; pipeline run dashboards for the operator.

### 8.2 Suggested service/module boundaries (backend)
- `Identity & Family` (accounts, profiles, roles, consent)
- `Routines` (templates, daily plans, streaks)
- `Portfolio` (projects, artifacts, reflections)
- `Activities` (sports/extracurriculars)
- `Opportunities` (catalog, ingestion pipeline, matching) — heaviest service
- `Resources` (curated library)
- `Notifications` (digest, reminders, approvals)
- `Gamification` (badges, milestones, roadmap)

### 8.3 Angular app structure (frontend)
- `core/` (auth, http interceptors, guards, models)
- `shared/` (design system components: cards, progress, badges, buttons)
- `features/` — `dashboard-child`, `dashboard-parent`, `routines`, `portfolio`, `sports`, `scholarships`, `resources`, `settings`
- Theming via CSS variables; kid vs. parent shells.

### 8.4 Key API surface (illustrative)
- `POST /api/families`, `POST /api/families/{id}/children`
- `GET /api/children/{id}/today` (today's plan), `POST /api/routines/{id}/complete`
- `GET/POST /api/children/{id}/projects`, `POST /api/projects/{id}/artifacts`
- `GET/POST /api/children/{id}/activities`
- `GET /api/children/{id}/opportunities` (matched feed), `POST /api/opportunities/{id}/save|dismiss`
- `GET /api/children/{id}/digest`
- Admin: `POST /api/admin/sources`, `GET /api/admin/review-queue`

---

## 9. Data model (high level)

- **Family** 1—* **User** (role) ; **Family** 1—* **ChildProfile**
- **ChildProfile** 1—* **Routine** 1—* **RoutineLog** (daily completion)
- **ChildProfile** 1—* **Project** 1—* **Artifact**; Project *—* **Tag/Interest**
- **ChildProfile** 1—* **Activity** (sport/extracurricular) 1—* **ActivityLog**
- **Opportunity** *—* **ChildProfile** via **OpportunityMatch** (score, horizon, status: matched/saved/dismissed)
- **Source** 1—* **FetchRun** 1—* **RawDocument** → **Opportunity** (provenance)
- **Badge/Milestone**, **Notification**, **Resource**, **ConsentRecord**

---

## 10. Non-functional requirements

### 10.1 Privacy, safety & compliance (highest priority — children's data)
- Treat all child data as sensitive. Design to **COPPA** (US) and applicable equivalents (e.g., GDPR-K, Canada PIPEDA, UK Age-Appropriate Design Code) principles: **verifiable parental consent**, data minimization, purpose limitation, and easy deletion/export.
- **Parental consent gate** before any child profile is active; granular consent for notifications and any outward-facing features.
- No public child profiles, no ads/behavioral tracking, no third-party data sharing for marketing.
- Encryption in transit (TLS) and at rest; least-privilege access; audit logs for sensitive actions.
- Clear, plain-language privacy policy; data export and "delete my family" controls.

### 10.2 Security
- ASP.NET Core Identity, hashed credentials, refresh-token rotation, RBAC, input validation, anti-CSRF for cookie flows, rate limiting on auth and pipeline endpoints. Secrets in a vault; AI keys never client-side.

### 10.3 Accessibility & age-appropriateness
- WCAG 2.2 AA target; large touch targets and simple language for the child UI; readable contrast; reduced-motion support; screen-reader labels.

### 10.4 Performance & reliability
- Child "today" view loads fast (<1.5s on typical home connections); pipeline jobs are resilient/retriable and idempotent; graceful degradation if AI/source is unavailable (serve last good catalog).

### 10.5 Internationalization (future-ready)
- Region/currency-aware opportunities; structure for future localization.

---

## 11. Release plan / roadmap

### MVP (v1) — "Daily habit + portfolio + scholarship radar"
- Family/child accounts, roles, consent gate.
- Study routines (templates, today's plan, streaks, badges).
- Portfolio (projects + artifacts + reflections, timeline).
- Scholarship pipeline v1 (curated sources, AI extraction, review queue, matched feed, save/dismiss, deadline reminders) — **discovery only**.
- Parent dashboard + weekly digest.
- Kid + parent web UIs (responsive).

### v1.1
- Sports/extracurricular logging; resources library; richer gamification roadmap; email digest polish.

### v2
- Mentor role; PWA/mobile push; semantic matching (vector search); more sources; printable plans; multi-child analytics; older-grade "application prep" toolkit.

---

## 12. Success metrics
- **Engagement:** child weekly active days; median streak length; routines completion %.
- **Portfolio growth:** projects/artifacts added per term.
- **Scholarship value:** matches surfaced, saved, and acted on; deadlines hit; family-reported relevance rating.
- **Parent trust:** weekly digest open rate; retention at 3/6/12 months; NPS.
- **Pipeline quality:** extraction accuracy (sampled), % auto-published vs. review-queue, duplicate rate, broken-link rate.

---

## 13. Risks & open questions
- **Scraping legality/ToS & rate limits** — mitigate with curated sources, official APIs/feeds, robots/ToS compliance, and caching. *Open: which aggregators offer APIs/licensing?*
- **AI extraction errors** — mitigate with schemas, confidence thresholds, and human review. *Open: acceptable confidence bar for auto-publish?*
- **Children's privacy regulation** — requires legal review per region before launch. *Open: launch regions for v1?*
- **Over-pressuring kids** — design for encouragement and consistency, not anxiety; parent controls on intensity. *Open: how to measure "healthy" engagement vs. pressure?*
- **Long time-to-value** (scholarships are years away) — counter with near-term wins: contests, badges, weekly progress.
- **Motivation decay** — gamification must stay fresh; plan content/quest refreshes.

---

## 14. Appendix — mockups
HTML mockups live in `docs/mocks/` (open `docs/mocks/index.html`):
- `dashboard-child.html` — the child's daily home ("Today's 3 things," streak, stars)
- `dashboard-parent.html` — parent overview, digest, approvals
- `routines.html` — study routines & habit tracking
- `portfolio.html` — projects & interests portfolio timeline
- `scholarships.html` — AI scholarship/opportunity finder
- `sports.html` — sports & extracurricular logging
- `resources.html` — curated resources library

*Mockups are static, illustrative, and use placeholder data.*
