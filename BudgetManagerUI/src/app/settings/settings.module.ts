import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersSettingComponent } from './components/users-setting/users-setting.component';
import { SettingsRoutingModule } from './settings-routing.module';
import { MatCardModule } from '@angular/material/card';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';



@NgModule({
  declarations: [
    UsersSettingComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    FontAwesomeModule,
    SettingsRoutingModule
  ]
})
export class SettingsModule { }
