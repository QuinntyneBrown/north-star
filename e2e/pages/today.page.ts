import { Locator, Page } from '@playwright/test';

/** Page object for a child's "today's plan" screen. */
export class TodayPage {
  readonly title: Locator;
  readonly streakBadge: Locator;

  constructor(private readonly page: Page) {
    this.title = page.locator('.today__title');
    this.streakBadge = page.locator('.today__badge').first();
  }

  async expectLoaded(): Promise<void> {
    await this.title.waitFor({ state: 'visible' });
  }

  tasks(): Locator {
    return this.page.locator('.today__task');
  }

  doneTasks(): Locator {
    return this.page.locator('.today__task--done');
  }

  async completeFirst(): Promise<void> {
    await this.page.locator('.today__task').first().locator('.today__check').click();
  }
}
