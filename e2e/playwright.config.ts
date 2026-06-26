import { defineConfig, devices } from '@playwright/test';

const API_URL = process.env.API_URL ?? 'http://localhost:8080';
const WEB_URL = process.env.WEB_URL ?? 'http://localhost:4280';

export default defineConfig({
  testDir: './tests',
  fullyParallel: true,
  forbidOnly: !!process.env.CI,
  retries: process.env.CI ? 1 : 0,
  workers: process.env.CI ? 1 : undefined,
  reporter: [['html', { open: 'never' }], ['list']],
  use: {
    baseURL: WEB_URL,
    trace: 'on-first-retry',
    screenshot: 'only-on-failure',
  },
  projects: [{ name: 'chromium', use: { ...devices['Desktop Chrome'] } }],
  // Launch the API (SQLite in Development) and the Angular dev server. Set
  // NO_WEBSERVER=1 to run against an already-running stack (e.g. docker compose).
  webServer: process.env.NO_WEBSERVER
    ? undefined
    : [
        {
          command: 'dotnet run --project ../backend/src/NorthStar.Api --launch-profile http',
          url: `${API_URL}/health`,
          reuseExistingServer: !process.env.CI,
          timeout: 180_000,
        },
        {
          command: 'npm --prefix ../frontend start -- --port 4280',
          url: WEB_URL,
          reuseExistingServer: !process.env.CI,
          timeout: 180_000,
        },
      ],
});
