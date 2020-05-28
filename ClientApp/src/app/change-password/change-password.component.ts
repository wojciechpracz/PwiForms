import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {

  newPasswordForm: FormGroup;
  email: string;
  token: string;
  submitted = false;

  constructor(private route: ActivatedRoute, private userService: UserService) { }

  ngOnInit() {
    this.newPasswordForm = new FormGroup({
      'newPassword': new FormControl(''),
      'email': new FormControl(''),
      'token': new FormControl('')
    });

    this.route.queryParams.subscribe(params => {

      this.email = params.email;
      this.token = params.token;

      this.newPasswordForm.controls.email.setValue(this.email);
      this.newPasswordForm.controls.token.setValue(this.token);
      // this.userService.activateAccount(this.email, this.token).subscribe(res => {
      //   this.activated = true;

      });

  }

  onSubmit() {
    this.userService.sumbitChangePasswordForm(this.newPasswordForm.value).subscribe(res => {
      this.submitted = true;
    });
  }

}
