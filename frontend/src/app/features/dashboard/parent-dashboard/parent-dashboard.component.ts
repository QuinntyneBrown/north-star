import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { AuthService } from '../../../core/auth/auth.service';
import { ChildrenPanelComponent } from '../../children/children-panel/children-panel.component';

@Component({
  selector: 'app-parent-dashboard',
  standalone: true,
  imports: [ChildrenPanelComponent],
  templateUrl: './parent-dashboard.component.html',
  styleUrl: './parent-dashboard.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class ParentDashboardComponent {
  private readonly auth = inject(AuthService);
  readonly user = this.auth.user;

  logout(): void {
    this.auth.logout();
  }
}
