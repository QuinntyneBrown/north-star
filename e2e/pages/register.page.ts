import { Locator, Page } from '@playwright/test';

export interface RegisterInput {
  displayName: string;
  familyName: string;
  email: string;
  password: string;
}

/** Page object for the parent self-registration screen. */
export class RegisterPage {
  readonly displayName: Locator;
  readonly familyName: Locator;
  readonly email: Locator;
  readonly password: Locator;
  readonly submit: Locator;

  constructor(private readonly page: Page) {
    this.displayName = page.getByLabel('Your name');
    this.familyName = page.getByLabel('Family name');
    this.email = page.getByLabel('Email');
    this.password = page.getByLabel('Password');
    this.submit = page.getByRole('button', { name: /create account/i });
  }

  async goto(): Promise<void> {
    await this.page.goto('/register');
  }

  async register(input: RegisterInput): Promise<void> {
    await this.displayName.fill(input.displayName);
    await this.familyName.fill(input.familyName);
    await this.email.fill(input.email);
    await this.password.fill(input.password);
    await this.submit.click();
  }
}
