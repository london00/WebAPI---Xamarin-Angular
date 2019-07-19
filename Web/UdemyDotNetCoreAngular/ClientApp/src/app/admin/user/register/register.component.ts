import { Component } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { UserDTO } from '../../../DTO/ModelContext';
import { ToastrService } from 'ngx-toastr';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
/** Register component*/
export class RegisterComponent {
  public user: UserDTO;
  /** Register ctor */
  constructor(private userService: UserService, private toastyService: ToastrService, private router: Router) {
    this.user = new UserDTO();
  }

  public Register() {
    this.userService.Register(this.user).subscribe(
      success => {
        this.toastyService.success(`User created successfully.  \nWe have sent a confirmation email to ${this.user.Email}. \nPlease confirm your email account.`, "Register");
        this.router.navigate(["/login", this.user.Email]);
      }
    );
  }
}
