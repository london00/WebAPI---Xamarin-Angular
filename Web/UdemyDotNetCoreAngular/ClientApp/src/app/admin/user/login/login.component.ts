import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { UserService } from '../../../services/user.service';
import { UserDTO } from '../../../DTO/ModelContext';
import { HttpErrorResponse } from '@angular/common/http';

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
  constructor(private activatedRoute: ActivatedRoute, private toastyService: ToastrService, private userService: UserService, private router: Router) {
    this.loginCredentials.email = this.activatedRoute.snapshot.paramMap.get('email') || "";
  }

  public login() {
    var user = new UserDTO();
    user.Email = this.loginCredentials.email;
    user.Password = this.loginCredentials.password;

    this.userService.Login(user).subscribe(
      (success: any) => {
        localStorage.setItem("token", success.token);
        this.router.navigate(["/"]);
      }
    );
  }
}
