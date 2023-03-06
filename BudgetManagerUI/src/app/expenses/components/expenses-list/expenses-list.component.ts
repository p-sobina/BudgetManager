import { Component, OnInit } from '@angular/core';
import { faCashRegister } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-expenses-list',
  templateUrl: './expenses-list.component.html',
  styleUrls: ['./expenses-list.component.scss']
})
export class ExpensesListComponent implements OnInit {
  faCashRegister = faCashRegister;

  constructor() { }

  ngOnInit(): void {
  }

}
