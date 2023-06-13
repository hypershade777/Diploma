import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private service: SharedService, private router: Router, private cookieService: CookieService) { 
    this.loginForm = this.fb.group({
        email: ['', [Validators.required, Validators.email]],
        password: ['', Validators.required]
      });
  }

  ngOnInit(): void {
    const myCookieValue = this.cookieService.get('authCookie');
    if(myCookieValue) {
      this.router.navigateByUrl('/external-site');
    }
  }

  login(): void {
    if (this.loginForm.valid) {
        const email = this.loginForm.get('email')?.value;
        const password = this.loginForm.get('password')?.value;

        this.service.login({email, password}).subscribe(
            (response) => {
              console.log('Login successful:', response);
              if(response) 
              {
                this.cookieService.set('authCookie', 'true');
                this.cookieService.set('userId', response.toString());
                this.router.navigateByUrl('/external-site');
              }
            },
            (error) => {
              console.error('Login failed:', error);
            }
          );
    }
  }

  register() {
    this.router.navigateByUrl('/register');
  }

}