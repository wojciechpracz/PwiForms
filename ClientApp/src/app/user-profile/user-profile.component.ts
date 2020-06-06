import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../interfaces/user';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserForEdit } from '../interfaces/userForEdit';
import { CountryService } from '../services/country.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  user: User;
  userForEdit: any;
  editEnabled = false;
  countries: Country[];
  currentLanguage: string;

  editUserForm: FormGroup;

  constructor(private userService: UserService, private countryService: CountryService, private translate: TranslateService) { }

  ngOnInit() {
    this.currentLanguage = this.translate.defaultLang;
    this.user = this.userService.getCurrentUser();
    this.countryService.getCountries().subscribe(result => {
      this.countries = result;
    }, error => {
      console.log(error);
    });
    this.setUserForEdit();
    this.editUserForm = new FormGroup({
      id: new FormControl(''),
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
    });
    this.editUserForm.setValue(this.userForEdit);
  }

  toggleEddit() {
    this.editEnabled = !this.editEnabled;
  }

  setUserForEdit() {
    this.userForEdit = {};

    this.userForEdit.id = this.user.id;
    this.userForEdit.name = this.user.name;
    this.userForEdit.surname = this.user.surname;
    this.userForEdit.street = this.user.street;
    this.userForEdit.city = this.user.city;
    this.userForEdit.postalCode = this.user.postalCode;
    this.userForEdit.phone = this.user.phone;
    this.userForEdit.countryId = this.user.countryId;
  }

  setUserFromResponse(userFromResp: any) {
    this.user.id = userFromResp.id;
    this.user.name = userFromResp.name;
    this.user.surname = userFromResp.surname;
    this.user.street = userFromResp.street;
    this.user.city = userFromResp.city;
    this.user.postalCode = userFromResp.postalCode;
    this.user.phone = userFromResp.phone;
    this.user.countryId = userFromResp.countryId;
    this.user.country = userFromResp.country;
  }


  submit() {
    if (this.editUserForm.valid) {
      this.userService.submitUserEditForm(this.editUserForm).subscribe(res => {
        this.setUserFromResponse(res);
        this.setUserForEdit();
      });
      this.user = this.userService.getCurrentUser();
      this.toggleEddit();
    }
  }
}
