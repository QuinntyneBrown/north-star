import { test as base, expect } from '@playwright/test';

const API_URL = process.env.API_URL ?? 'http://localhost:8080';

export interface RegisteredUser {
  email: string;
  password: string;
  displayName: string;
  familyName: string;
}

/**
 * Extends the base test with a `registeredUser` fixture that seeds a unique parent
 * account directly via the API, so UI tests start from a known authenticated identity.
 */
export const test = base.extend<{ registeredUser: RegisteredUser }>({
  registeredUser: async ({ request }, use) => {
    const unique = `${Date.now()}-${Math.floor(Math.random() * 1_000_000)}`;
    const user: RegisteredUser = {
      email: `e2e.${unique}@example.com`,
      password: 'Sup3rSecret!',
      displayName: 'David',
      familyName: 'Brown Family',
    };

    const response = await request.post(`${API_URL}/api/auth/register`, { data: user });
    if (!response.ok()) {
      throw new Error(`Seeding user failed (${response.status()}): ${await response.text()}`);
    }

    await use(user);
  },
});

export { expect };
