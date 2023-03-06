import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ExpensesListComponent } from './components/expenses-list/expenses-list.component';
import { MatCardModule } from '@angular/material/card';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ExpensesRoutingModule } from './expenses-routing.module';



@NgModule({
  declarations: [
    ExpensesListComponent
  ],
  imports: [
    CommonModule,
    MatCardModule,
    FontAwesomeModule,
    ExpensesRoutingModule
  ]
})
export class ExpensesModule { }
