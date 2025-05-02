import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { FloatLabelModule } from 'primeng/floatlabel';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { RouterModule } from '@angular/router';
import { Image } from 'primeng/image';
import { MenubarModule } from 'primeng/menubar';
import { TableModule } from 'primeng/table';
import { DrawerModule } from 'primeng/drawer';
import { SelectModule } from 'primeng/select';
import { ToastModule } from 'primeng/toast';

@NgModule({
  imports: [
    CommonModule, 
    FormsModule,
    Image
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    FloatLabelModule,
    PasswordModule,
    ButtonModule,
    InputTextModule,
    Image,
    SelectModule,
    MenubarModule,
    ToastModule,
    RouterModule,
    TableModule,
    DrawerModule
  ],
  providers: [],
})
export class SharedModule { }
