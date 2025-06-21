import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})

export class SidebarComponent {
  @Input() sidebarOptions: {
    section: string,
    items: {
      label: string,
      icon: string,
      route: string,
      action?: () => void
    }[]
  }[] = [];
}