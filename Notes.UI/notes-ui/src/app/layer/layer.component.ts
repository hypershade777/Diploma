import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-layer',
  templateUrl: './layer.component.html',
  styleUrls: ['./layer.component.scss']
})
export class ExternalRedirectButtonComponent implements OnInit {

  constructor(private router: Router, private cookieService: CookieService) { }

  ngOnInit(): void {
    const myCookieValue = this.cookieService.get('authCookie');
    if(!myCookieValue && myCookieValue !== 'true') {
      this.router.navigateByUrl('/');
    }
  }

  logout() {
    this.cookieService.delete('authCookie');
    this.cookieService.delete('userId');
    this.router.navigateByUrl('/');
  }

  redirectToExternalSite() {
    window.location.href = 'https://localhost:7225/swagger/index.html';
  }
}