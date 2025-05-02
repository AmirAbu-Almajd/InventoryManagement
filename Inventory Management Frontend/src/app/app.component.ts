import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SharedModule } from './shared/shared.module';
import { HomeComponent } from './components/home/home.component';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-root',
  standalone: true,
  providers: [MessageService],
  imports: [SharedModule, HomeComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Test-Config';
}
