import { ChangeDetectionStrategy, Component, inject, OnInit, signal } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { ChildrenService } from '../../../core/children/children.service';
import { ChildProfile } from '../../../core/models/child.models';

@Component({
  selector: 'app-children-panel',
  standalone: true,
  imports: [ReactiveFormsModule, RouterLink],
  templateUrl: './children-panel.component.html',
  styleUrl: './children-panel.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ChildrenPanelComponent implements OnInit {
  private readonly fb = inject(FormBuilder);
  private readonly children = inject(ChildrenService);

  readonly items = signal<ChildProfile[]>([]);
  readonly error = signal<string | null>(null);
  readonly saving = signal(false);
  readonly showForm = signal(false);

  readonly form = this.fb.nonNullable.group({
    firstName: ['', [Validators.required]],
    grade: [5, [Validators.required, Validators.min(1), Validators.max(12)]],
    interests: [''],
    loginHandle: ['', [Validators.required, Validators.minLength(3)]],
    pin: ['', [Validators.required, Validators.pattern(/^\d{4,6}$/)]],
  });

  ngOnInit(): void {
    this.load();
  }

  toggle(): void {
    this.showForm.update((open) => !open);
  }

  submit(): void {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.saving.set(true);
    this.error.set(null);

    this.children.create(this.form.getRawValue()).subscribe({
      next: () => {
        this.saving.set(false);
        this.showForm.set(false);
        this.form.reset();
        this.load();
      },
      error: () => {
        this.saving.set(false);
        this.error.set('Could not add child. The login handle may already be taken.');
      },
    });
  }

  private load(): void {
    this.children.list().subscribe({
      next: (children) => this.items.set(children),
      error: () => this.error.set('Could not load children.'),
    });
  }
}
