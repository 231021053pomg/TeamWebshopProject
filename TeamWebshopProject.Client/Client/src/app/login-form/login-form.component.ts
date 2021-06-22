import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {

  loginForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router) { }

  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      email: ['', Validators.email],
      password: ['']
    });
  }

  get f() { return this.loginForm.controls; }

  login() {
    const loginRequest: LoginRequest = {
      email: this.f.email.value,
      password: this.f.password.value
    };

    this.authService.login(loginRequest)
      .subscribe((user) => this.router.navigate(this.authService.INITIAL_PATH));
  }
}
