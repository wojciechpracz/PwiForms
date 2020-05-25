import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class RegistrationService {

constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

submitRegistrationForm(registrationForm: any) {
  return this.http.post(this.baseUrl + 'auth/register', registrationForm.value);
}

}


