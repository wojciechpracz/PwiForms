import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

submitLoginForm(loginForm: FormGroup) {
  return this.http.post(this.baseUrl + 'auth/login', loginForm);
}

}
