import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup } from '@angular/forms';
import { map } from 'rxjs/operators';
import { User } from '../interfaces/user';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

private currentUserSubject: BehaviorSubject<any>;
public currentUser: Observable<any>;

constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  this.currentUserSubject = new BehaviorSubject<any>(JSON.parse(localStorage.getItem('user')));
  this.currentUser = this.currentUserSubject.asObservable();
 }

 public get currentUserValue() {
  return this.currentUserSubject.value;
}

submitLoginForm(loginForm: FormGroup) {
  return this.http.post<any>(this.baseUrl + 'auth/login', loginForm).pipe(
    map((response: any) => {
      const user = response;
      if (user) {
        localStorage.setItem('token', user.token);
        localStorage.setItem('currentUser', JSON.stringify(user));
        this.currentUserSubject.next(user);
        return user;
      }
    })
  );
}

logout() {
  localStorage.removeItem('user');
  localStorage.removeItem('token');
  this.currentUserSubject.next(null);
}

}
