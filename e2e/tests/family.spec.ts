import { test, expect } from '@playwright/test';
import { RegisterPage } from '../pages/register.page';
import { ParentDashboardPage } from '../pages/parent-dashboard.page';

test.describe('Accounts & family (M1)', () => {
  test('a parent can register, add a child, and see them listed', async ({ page }) => {
    const unique = `${Date.now()}-${Math.floor(Math.random() * 1_000_000)}`;

    const register = new RegisterPage(page);
    await register.goto();
    await register.register({
      displayName: 'David',
      familyName: 'Brown Family',
      email: `e2e.reg.${unique}@example.com`,
      password: 'Sup3rSecret!',
    });

    const dashboard = new ParentDashboardPage(page);
    await dashboard.expectLoaded();
    await expect(page).toHaveURL(/\/dashboard$/);

    await dashboard.addChild({
      firstName: 'Maya',
      grade: '5',
      interests: 'writing, science',
      loginHandle: `maya-${unique}`,
      pin: '1234',
    });

    await expect(dashboard.childRow('Maya')).toBeVisible();
    await expect(dashboard.childRow('Maya')).toContainText('Grade 5');
  });
});
