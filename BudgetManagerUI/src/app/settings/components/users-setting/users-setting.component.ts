import { Component, OnInit } from '@angular/core';
import { faSlidersH } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-users-setting',
  templateUrl: './users-setting.component.html',
  styleUrls: ['./users-setting.component.scss']
})
export class UsersSettingComponent implements OnInit {
  faSlidersH = faSlidersH;

  constructor() { }

  ngOnInit(): void {
  }

}
