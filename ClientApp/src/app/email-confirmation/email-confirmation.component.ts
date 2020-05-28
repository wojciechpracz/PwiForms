import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-email-confirmation',
  templateUrl: './email-confirmation.component.html',
  styleUrls: ['./email-confirmation.component.css']
})
export class EmailConfirmationComponent implements OnInit {

  constructor(private route: ActivatedRoute, private userService: UserService) { }
  email: string;
  token: string;

  activated = false;

  ngOnInit() {
    this.route.queryParams.subscribe(params => {

      this.email = params.email;
      this.token = params.token;

      this.userService.activateAccount(this.email, this.token).subscribe(res => {
        this.activated = true;
      });

    });
  }

}
