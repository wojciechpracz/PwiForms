import { Component, OnInit } from '@angular/core';
import { User } from '../interfaces/user';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  currentUser: any;

  constructor(private loginService: LoginService) {
    this.loginService.currentUser.subscribe(x => this.currentUser = x);  }
  ngOnInit(): void {
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    const loggedIn = !!token;
    console.log(this.currentUser);
    return loggedIn;
  }
}


