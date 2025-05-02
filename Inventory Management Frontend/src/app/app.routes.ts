import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full', // Ensures the redirection only matches the root URL
    },
    {
        path: 'home', loadChildren: () => import('./components/home/home.routes').then(e => e.routes)
    }
];
