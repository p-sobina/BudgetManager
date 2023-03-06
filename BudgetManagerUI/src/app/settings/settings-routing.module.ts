import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersSettingComponent } from './components/users-setting/users-setting.component';

const routes: Routes = [
    {
        path: '',
        pathMatch: 'full',
        redirectTo: 'users'
    },
    {
        path: 'users',
        component: UsersSettingComponent
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SettingsRoutingModule {}