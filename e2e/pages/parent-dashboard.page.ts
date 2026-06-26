import { Locator, Page } from '@playwright/test';
import { SidebarComponent } from '../components/sidebar.component';

export interface ChildInput {
  firstName: string;
  grade: string;
  interests: string;
  loginHandle: string;
  pin: string;
}

/** Page object for the parent dashboard (the post-login landing screen). */
export class ParentDashboardPage {
  readonly greeting: Locator;
  readonly signOut: Locator;
  readonly sidebar: SidebarComponent;
  readonly addChildButton: Locator;
  readonly saveChildButton: Locator;

  constructor(private readonly page: Page) {
    this.greeting = page.locator('.dashboard__greeting');
    this.signOut = page.getByRole('button', { name: /sign out/i });
    this.sidebar = new SidebarComponent(page);
    this.addChildButton = page.getByRole('button', { name: /add child/i });
    this.saveChildButton = page.getByRole('button', { name: /save child/i });
  }

  async expectLoaded(): Promise<void> {
    await this.greeting.waitFor({ state: 'visible' });
  }

  childRow(firstName: string): Locator {
    return this.page.locator('.children__item', { hasText: firstName });
  }

  async addChild(child: ChildInput): Promise<void> {
    await this.addChildButton.click();
    await this.page.getByLabel('First name').fill(child.firstName);
    await this.page.getByLabel('Grade').fill(child.grade);
    await this.page.getByLabel('Interests').fill(child.interests);
    await this.page.getByLabel('Login handle').fill(child.loginHandle);
    await this.page.getByLabel(/PIN/).fill(child.pin);
    await this.saveChildButton.click();
  }
}
