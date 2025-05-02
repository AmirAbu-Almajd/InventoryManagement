import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { SharedModule } from '../../../shared/shared.module';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [SharedModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
  activeTab: number = 0;

  tabs: { label: string, header: string }[] = [
    { label: 'Products', header: 'products' },
    { label: 'Product Prices', header: 'prices' },
    { label: 'Stocks', header: 'stocks' },
    { label: 'Sales', header: 'sales' }
  ];
  constructor(private router: Router) { }

  navigateTo(header: string) {
    this.router.navigate(['home', header]);
  }
  changeTabs(tabIndex: number) {
    this.activeTab = tabIndex;
  }
}

