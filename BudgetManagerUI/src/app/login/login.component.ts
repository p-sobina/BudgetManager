import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../core/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  form!: FormGroup;
  isLoading = false;

  constructor(private formBuilder: FormBuilder, private route: ActivatedRoute, private router: Router, private authenticationService: AuthenticationService) { }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      email: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.form.invalid) {
      return;
    }

    this.isLoading = true;
    this.authenticationService.login(this.form.controls['email'].value, this.form.controls['password'].value)
    .subscribe({
      next: () => {
        var returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
        this.isLoading = false;
        this.router.navigateByUrl(returnUrl);
      },
      error: response => {
        this.isLoading = false;
        alert("Log in failed");
      }
    });
  }
}
