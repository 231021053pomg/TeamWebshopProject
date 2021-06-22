import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth/auth.service';

@Component({
  selector: 'app-reqister',
  templateUrl: './reqister.component.html',
  styleUrls: ['./reqister.component.css']
})
export class ReqisterComponent implements OnInit {
  form: any = {
    username: null,
    email: null,
    password: null
  };

  isSuccesful = false;
  isSignUpFailed = false;
  errorMessage = "";

  constructor(private authService: AuthService) { }

  ngOnInit(): void { }

  onSubmit(): void {
    const { username, email, password } = this.form;

    this.authService.reqister(username, email, password).subscribe(
      data => {
        console.log(data);
        this.isSuccesful = true;
        this.isSignUpFailed = false;
      },
      err => {
        this.errorMessage = err.error.message;
        this.isSignUpFailed = true;
      }
    );
  }
}
