import { ChangeDetectionStrategy, Component, computed, inject, OnInit, signal } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { RoutinesService } from '../../core/routines/routines.service';
import { TodayPlan } from '../../core/models/today.models';

@Component({
  selector: 'app-today',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './today.component.html',
  styleUrl: './today.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TodayComponent implements OnInit {
  private readonly route = inject(ActivatedRoute);
  private readonly routines = inject(RoutinesService);

  readonly plan = signal<TodayPlan | null>(null);
  readonly error = signal<string | null>(null);
  readonly busyId = signal<string | null>(null);

  readonly doneCount = computed(() => this.plan()?.tasks.filter((t) => t.done).length ?? 0);

  private childId = '';

  ngOnInit(): void {
    this.childId = this.route.snapshot.paramMap.get('childId') ?? '';
    this.load();
  }

  complete(routineId: string): void {
    this.busyId.set(routineId);
    this.error.set(null);
    this.routines.complete(routineId).subscribe({
      next: () => {
        this.busyId.set(null);
        this.load();
      },
      error: () => {
        this.busyId.set(null);
        this.error.set('Could not save that. Please try again.');
      },
    });
  }

  private load(): void {
    this.routines.getToday(this.childId).subscribe({
      next: (plan) => this.plan.set(plan),
      error: () => this.error.set('Could not load today’s plan.'),
    });
  }
}
