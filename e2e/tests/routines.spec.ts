import { test, expect } from '@playwright/test';
import { RegisterPage } from '../pages/register.page';
import { ParentDashboardPage } from '../pages/parent-dashboard.page';
import { TodayPage } from '../pages/today.page';

test.describe('Study routines (M2)', () => {
  test('completing a routine marks it done and grows the streak', async ({ page }) => {
    const unique = `${Date.now()}-${Math.floor(Math.random() * 1_000_000)}`;

    const register = new RegisterPage(page);
    await register.goto();
    await register.register({
      displayName: 'David',
      familyName: 'Brown Family',
      email: `e2e.routines.${unique}@example.com`,
      password: 'Sup3rSecret!',
    });

    const dashboard = new ParentDashboardPage(page);
    await dashboard.expectLoaded();
    await dashboard.addChild({
      firstName: 'Maya',
      grade: '5',
      interests: 'writing',
      loginHandle: `maya-${unique}`,
      pin: '1234',
    });

    await page.getByRole('link', { name: /today/i }).first().click();

    const today = new TodayPage(page);
    await today.expectLoaded();
    await expect(today.tasks()).toHaveCount(3);
    await expect(today.streakBadge).toContainText('0-day streak');

    await today.completeFirst();

    await expect(today.doneTasks()).toHaveCount(1);
    await expect(today.streakBadge).toContainText('1-day streak');
  });
});
