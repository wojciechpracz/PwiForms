import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { CountryService } from '../services/country.service';
import { RegistrationService } from '../services/registration.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  registrationForm: FormGroup;
  name: FormControl;
  countries: Country[];
  formSubmitted = false;

  constructor(private http: HttpClient, private countryService: CountryService,
    private registrationService: RegistrationService) { }

  ngOnInit() {
    this.countryService.getCountries().subscribe(result => {
      this.countries = result;
    }, error => {
      console.log(error);
    });

    this.registrationForm = new FormGroup({
      name: new FormControl(null, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(15)
      ]),
      surname: new FormControl(null, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(15)
      ]),
      email: new FormControl(null, [
        Validators.required,
        Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$')]),
      street: new FormControl(null, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(15)
      ]),
      postalCode: new FormControl(null, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(15)
      ]),
      city: new FormControl(null, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(15)
      ]),
      countryId: new FormControl(''),
      phone: new FormControl(null, [
        Validators.required,
        Validators.pattern('^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$')
      ]),
      password: new FormControl(null, [
        Validators.required,
        Validators.minLength(3),
        Validators.maxLength(15)
      ])

    });
  }


  onSubmit() {
    if (this.registrationForm.valid) {
      console.log('Wysyłam formularz...');
      this.registrationService.submitRegistrationForm(this.registrationForm).subscribe(res => {
        this.formSubmitted = true;
      });
    }

  }
}
