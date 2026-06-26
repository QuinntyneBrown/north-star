# North Star ★

A parent-and-child web app that guides a Grade 5 student toward a university scholarship — through daily study routines, a growing projects portfolio, sports tracking, and an (initially stubbed) AI scholarship finder.

- **Product docs:** [`docs/PRD.md`](docs/PRD.md) · **UI mockups:** [`docs/mocks/index.html`](docs/mocks/index.html) · **Plan:** [`docs/IMPLEMENTATION_PLAN.html`](docs/IMPLEMENTATION_PLAN.html)
- **Backend:** .NET 8, Clean Architecture, SOLID, file-per-type (SQL Server via EF Core 8)
- **Frontend:** Angular 17, standalone + signals, **file-per-type** (separate `.ts`/`.html`/`.scss`), **BEM** CSS
- **e2e:** Playwright with the Page Object Model
- **Method:** ATDD — a failing acceptance test first, then the radically-simplest code to pass it

## Repository layout

```
backend/    .NET 8 solution (Domain / Application / Infrastructure / Api + tests)
frontend/   Angular 17 workspace
e2e/        Playwright + Page Object Model
docs/       PRD, HTML mockups, implementation plan
docker-compose.yml, .github/workflows/ci.yml
```

## Prerequisites

- .NET SDK (pinned via [`global.json`](global.json); a 9.0.x SDK builds the `net8.0` targets)
- Node.js 20+
- Docker Desktop (only for the full SQL Server stack / Testcontainers acceptance tests)

## Run locally (no Docker)

The API uses **SQLite in Development**, so the whole app runs with zero infrastructure.

```bash
# 1) API  → http://localhost:8080  (Swagger at /swagger)
cd backend && dotnet run --project src/NorthStar.Api

# 2) Web  → http://localhost:4200
cd frontend && npm install && npm start
```

Open http://localhost:4200 → **Create a family account**, add a child profile (with a login handle + PIN), then a child can sign in at **/child-login** with that handle and PIN.

> In Development the API recreates its SQLite schema on each start (disposable data), so
> evolving models apply without migrations. Production uses SQL Server; EF migrations land in M7.

## Run with Docker (SQL Server)

```bash
docker compose up --build
# API → http://localhost:8080 , Web → http://localhost:8081
```

## Tests

```bash
# Backend — unit + acceptance (acceptance uses an in-memory SQLite host by default)
cd backend && dotnet test

# Frontend — unit
cd frontend && npm test

# End-to-end — launches the API (SQLite) + Angular dev server, drives Chromium
cd e2e && npm install && npx playwright install chromium && npx playwright test
```

> **Acceptance tests & Testcontainers.** The acceptance host boots the real API in-memory over a
> shared SQLite connection so the ATDD loop runs without Docker. With Docker available, this seam is
> where a `Testcontainers.MsSql` SQL Server is substituted for full production fidelity (CI).
>
> **e2e ports.** The Playwright config serves the Angular app on **4280** (to avoid colliding with a
> stray dev server on 4200). Set `NO_WEBSERVER=1` to run against an already-running stack.

## Conventions

- **Backend:** Clean Architecture (`Api → Infrastructure → Application → Domain`), MediatR use-cases,
  FluentValidation, one public type per file, per-entity EF configurations.
- **Frontend:** standalone components with **separate** `.ts`/`.html`/`.scss` files (enforced in
  `angular.json` schematics), **BEM** class naming, signals, typed reactive forms, lazy routes.
- **ATDD:** acceptance test red → API/domain green → refactor → UI → e2e.

## Milestone status

- **M0 — Walking skeleton ✅** Solution + projects, Angular workspace, e2e, Docker, CI, and the first
  red→green slice: register family owner → login → JWT (Owner role).
- **M1 — Accounts & family ✅** Parent registration UI, child profiles (grade/interests), child PIN
  login, role-based authorization.
- **M2 — Study routines ✅** Default routines per child, a kid-friendly "today's plan" with
  complete buttons, stars, and a daily streak. Backend **20 tests** + **5 Playwright flows** green.
- **M3** Portfolio · **M4** Sports · **M5** Scholarships (stubbed AI) ·
  **M6** Resources/gamification/digest · **M7** Hardening.

See [`docs/IMPLEMENTATION_PLAN.html`](docs/IMPLEMENTATION_PLAN.html) for the full plan.
