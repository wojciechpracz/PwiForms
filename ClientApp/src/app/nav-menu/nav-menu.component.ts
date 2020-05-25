import { Component } from '@angular/core';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  constructor(private loginService: LoginService) { }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logout() {
    this.loginService.logout();
  }
}
