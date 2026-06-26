import { ChangeDetectionStrategy, Component, inject, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../core/auth/auth.service';

@Component({
  selector: 'app-child-login',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './child-login.component.html',
  styleUrl: './child-login.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ChildLoginComponent {
  private readonly fb = inject(FormBuilder);
  private readonly auth = inject(AuthService);
  private readonly router = inject(Router);

  readonly form = this.fb.nonNullable.group({
    loginHandle: ['', [Validators.required]],
    pin: ['', [Validators.required, Validators.pattern(/^\d{4,6}$/)]],
  });

  readonly submitting = signal(false);
  readonly error = signal<string | null>(null);

  submit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.submitting.set(true);
    this.error.set(null);

    this.auth.childLogin(this.form.getRawValue()).subscribe({
      next: () => {
        const childId = this.auth.user()?.childId;
        void this.router.navigateByUrl(childId ? `/children/${childId}/today` : '/dashboard');
      },
      error: () => {
        this.error.set('That handle or PIN didn’t work. Ask a grown-up for help.');
        this.submitting.set(false);
      },
    });
  }
}
