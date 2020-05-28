import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {

  resetPasswordForm: FormGroup;
  formSubmitted = false;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.resetPasswordForm = new FormGroup({
      email: new FormControl(null, [
        Validators.required,
        Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$')])
    });
  }

  onSubmit() {
    if (this.resetPasswordForm.valid) {
      this.userService.submitResetPasswordForm(this.resetPasswordForm.controls.email.value).subscribe(res => {
        this.formSubmitted = true;
      });
    }
  }

}
