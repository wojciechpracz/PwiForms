import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
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
  constructor(private http: HttpClient, private countryService: CountryService,
    private registrationService: RegistrationService) { }

  ngOnInit() {
    this.countryService.getCountries().subscribe(result => {
      this.countries = result;
    }, error => {
      console.log(error);
    });

    this.registrationForm = new FormGroup({
      name: new FormControl(''),
      surname: new FormControl(''),
      email: new FormControl(''),
      street: new FormControl(''),
      postalCode: new FormControl(''),
      city: new FormControl(''),
      countryId: new FormControl(''),
      phone: new FormControl(''),
      password: new FormControl('')

    });
  }


  onSubmit() {
    this.registrationService.submitRegistrationForm(this.registrationForm).subscribe(res => {
      console.log(res);
    });
  }

}
