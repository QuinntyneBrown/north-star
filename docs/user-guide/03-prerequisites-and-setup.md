# 03 — Prerequisites and Setup

The current build is operated from source on a parent's computer; no hosted service is provided
(README). A parent shall complete the setup in this document before beginning the first session in
[04 — Getting Started Today](04-getting-started-today.md). The setup is performed once; subsequent
sessions reuse the running application.

## Prerequisites

The following software shall be installed (README):

- **.NET SDK** — the version is pinned in [`global.json`](../../global.json); a 9.0.x SDK builds the
  `net8.0` targets.
- **Node.js** — version 20 or later.
- **Docker Desktop** — required only for the full SQL Server stack; it is not required for the
  procedure below.

## Run the application without Docker

In the current build the application programming interface uses SQLite in the Development
environment, so the application runs with no additional infrastructure (README). Two processes are
started.

1. **Start the application programming interface.** From the repository root:

   ```bash
   cd backend && dotnet run --project src/NorthStar.Api
   ```

   The interface serves on `http://localhost:8080`, with its interactive documentation at
   `/swagger` (README).

2. **Start the web application.** In a second terminal, from the repository root:

   ```bash
   cd frontend && npm install && npm start
   ```

   The web application serves on `http://localhost:4200` (README).

When both processes report ready, the parent opens `http://localhost:4200` in a web browser and
proceeds to [04 — Getting Started Today](04-getting-started-today.md).

## Run the application with Docker

A parent may instead run the full stack, backed by SQL Server, with Docker (README):

```bash
docker compose up --build
```

Under this configuration the interface serves on `http://localhost:8080` and the web application
serves on `http://localhost:8081` (README). Where this guide names `http://localhost:4200`, a
parent using Docker shall substitute `http://localhost:8081`.

## Data persistence in the Development build

In the Development environment the interface recreates its SQLite schema on each start, and the
stored data is disposable (README). A parent shall therefore treat data entered into the local
Development build as transient: a family account and child profiles created in one run are not
guaranteed to survive a restart of the interface. Persistent storage backed by SQL Server and
database migrations is **[Planned: M7]** (README; PRD, §11).

This property is relevant to safety and is revisited in
[09 — Safety and Data](09-safety-and-data.md).
