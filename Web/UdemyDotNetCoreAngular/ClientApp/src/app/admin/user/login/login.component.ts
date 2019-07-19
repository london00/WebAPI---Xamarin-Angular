import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
/** Login component*/
export class LoginComponent {
  public loginCredentials = {
    email: "",
    password: ""
  };

  /** Login ctor */
  constructor(private route: ActivatedRoute, private toastyService: ToastrService) {
    this.loginCredentials.email = this.route.snapshot.paramMap.get('email') || "";
  }
}
