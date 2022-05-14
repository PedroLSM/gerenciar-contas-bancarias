import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from './shared.module';
import { NavbarComponent } from '../components/navigation/navbar/navbar.component';
import { SidenavComponent } from '../components/navigation/sidenav/sidenav.component';
import { BodyComponent } from '../components/navigation/body/body.component';

@NgModule({
  declarations: [
    NavbarComponent,
    SidenavComponent,
    BodyComponent,
  ],
  imports: [
    CommonModule,
    SharedModule,
  ],
  exports: [
    NavbarComponent,
    SidenavComponent,
    BodyComponent,
  ],
  providers: [],
})
export class NavigationModule { }
