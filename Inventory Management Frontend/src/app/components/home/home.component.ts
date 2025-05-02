import { Component } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { NavbarComponent } from './navbar/navbar.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [SharedModule, NavbarComponent], 
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  activeTab = undefined;

  setActiveTab(event: any){
      this.activeTab = event;
  }
}
