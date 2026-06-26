import { test, expect } from '../fixtures/test-fixtures';
import { LoginPage } from '../pages/login.page';
import { ParentDashboardPage } from '../pages/parent-dashboard.page';

test.describe('Authentication (M0 walking skeleton)', () => {
  test('an unauthenticated visit is redirected to the login page', async ({ page }) => {
    await page.goto('/');

    await expect(page).toHaveURL(/\/login$/);
    await expect(page.getByRole('button', { name: /sign in/i })).toBeVisible();
  });

  test('a registered parent can sign in and reach the dashboard', async ({ page, registeredUser }) => {
    const login = new LoginPage(page);
    await login.goto();
    await login.login(registeredUser.email, registeredUser.password);

    const dashboard = new ParentDashboardPage(page);
    await dashboard.expectLoaded();

    await expect(page).toHaveURL(/\/dashboard$/);
    await expect(dashboard.greeting).toContainText(registeredUser.displayName);
    await expect(dashboard.sidebar.brand).toContainText('North Star');
  });

  test('signing in with the wrong password shows an error', async ({ page, registeredUser }) => {
    const login = new LoginPage(page);
    await login.goto();
    await login.login(registeredUser.email, 'WrongPassword!');

    await expect(login.alert).toBeVisible();
    await expect(page).toHaveURL(/\/login$/);
  });
});
