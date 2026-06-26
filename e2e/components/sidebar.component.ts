import { Locator, Page } from '@playwright/test';

/** Reusable component object for the app shell's navigation sidebar. */
export class SidebarComponent {
  readonly root: Locator;
  readonly brand: Locator;

  constructor(page: Page) {
    this.root = page.locator('.ns-shell__sidebar');
    this.brand = this.root.locator('.ns-brand__name');
  }

  item(label: string | RegExp): Locator {
    return this.root.getByText(label);
  }
}
