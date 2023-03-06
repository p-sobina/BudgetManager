import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { UserInformations } from './models/userInformations';
import { environment } from 'src/environments/environment';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
    private userSubject: BehaviorSubject<UserInformations | null>;
    public user: Observable<UserInformations | null>;

    constructor(private router: Router, private http: HttpClient) {
        var userJson = null;

        if (localStorage.getItem('user')) {
            userJson = JSON.parse(localStorage.getItem('user')!);
        }

        this.userSubject = new BehaviorSubject<UserInformations | null>(userJson);
        this.user = this.userSubject.asObservable();
    }

    public get userValue(): UserInformations | null {
        return this.userSubject.value;
    }

    login(email: string, password: string) {
        return this.http.post<any>(`${environment.apiUrl}/user/authenticate`, { email, password })
            .pipe(
                map(user => {
                    localStorage.setItem('user', JSON.stringify(user));
                    this.userSubject.next(user);
                    return user;
                })
            );
    }

    logout() {
        localStorage.removeItem('user');
        this.userSubject.next(null);
        this.router.navigate(['/login']);
    }
}