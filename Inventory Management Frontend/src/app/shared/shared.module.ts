import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { FloatLabelModule } from 'primeng/floatlabel';
import { Popover } from 'primeng/popover';
import { InputTextModule } from 'primeng/inputtext';
import { PasswordModule } from 'primeng/password';
import { RouterModule } from '@angular/router';
import { Image } from 'primeng/image';
import { MenubarModule } from 'primeng/menubar';


@NgModule({
  imports: [
    CommonModule, 
    FormsModule,
    ReactiveFormsModule,
    FloatLabelModule,
    PasswordModule,
    ButtonModule,
    RouterModule,
    InputTextModule,
    Popover,
    MenubarModule,
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
    Popover,
    Image,
    MenubarModule,
    RouterModule
  ],
  providers: [],
})
export class SharedModule { }
