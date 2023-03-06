import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../core/authentication.service';
import { Role } from '../core/models/role';
import { UserInformations } from '../core/models/userInformations';

@Component({
  selector: 'app-navigation-bar',
  templateUrl: './navigation-bar.component.html',
  styleUrls: ['./navigation-bar.component.scss']
})
export class NavigationBarComponent implements OnInit {
  userInformations$: Observable<UserInformations | null> | undefined;
  roles = Role;

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit(): void {
    this.userInformations$ = this.authenticationService.user;
  }

  logout() {
    this.authenticationService.logout();
  }
}
