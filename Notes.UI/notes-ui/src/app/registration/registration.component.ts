import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { SharedService } from '../shared.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {
  registrationForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private service: SharedService, private router: Router, private cookieService: CookieService) { 
    this.registrationForm = this.formBuilder.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {
    const myCookieValue = this.cookieService.get('authCookie');
    if(myCookieValue) {
      this.router.navigateByUrl('/external-site');
    }
  }

  login() {
    this.router.navigateByUrl('/login');
  }

  register(): void {
    if (this.registrationForm.invalid) {
      console.error(this.registrationForm.errors)
        return;
      }

    const name = this.registrationForm.get('name')?.value;
    const surname = this.registrationForm.get('surname')?.value;
    const email = this.registrationForm.get('email')?.value;
    const password = this.registrationForm.get('password')?.value;

    if (!name || !surname || !email || !password) {
        console.error('One or more form values are null or undefined');
        return;
    }
    this.service.registration({name, surname, email, password}).subscribe(
        (response) => {
          console.log('Registration successful:', response);
          if(response) 
          {
            this.cookieService.set('authCookie', 'true');
            this.cookieService.set('userId', response.toString());
            this.router.navigateByUrl('/external-site');
          }
        },
        (error) => {
          console.error('Registration failed:', error);
        }
      );
  }
}