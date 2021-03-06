import { Injectable, Inject } from '@angular/core';
import { User } from '../interfaces/user';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

currentUser: User;

constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

getCurrentUser () {
  const jsonObj: any = JSON.parse(localStorage.getItem('currentUser'));
  this.currentUser = <User>jsonObj;

  return this.currentUser;
}

submitUserEditForm(editUserForm: any) {
   return this.http.put(this.baseUrl + 'user', editUserForm.value);
}

submitResetPasswordForm(email) {
  return this.http.get<any>(this.baseUrl + 'user/resetPassword?email=' + email);
}

sumbitChangePasswordForm(changePasswordForm: any) {
  return this.http.post(this.baseUrl + 'user/changePassword', changePasswordForm);
}

activateAccount(email, token) {
  return this.http.get<any>(this.baseUrl + 'user/ConfirmEmail?email=' + email + '&token=' + token);
}

}


