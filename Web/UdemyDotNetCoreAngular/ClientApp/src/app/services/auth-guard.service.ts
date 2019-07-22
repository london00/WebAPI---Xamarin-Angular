import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { JwtHelperService } from "@auth0/angular-jwt";

@Injectable()
export class AuthGuard implements CanActivate {
  private jwtHelper: JwtHelperService;

  constructor(private router: Router) {
    // https://www.npmjs.com/package/@auth0/angular-jwt
    this.jwtHelper = new JwtHelperService();
  }

  canActivate() {
    try {
      var token = localStorage.getItem("token");
      if (token && !this.jwtHelper.isTokenExpired(token)) {
        return true;
      }
      this.router.navigate(["login"]);

    }
    catch (e) {
      console.log("Invalid token");
    }
    
    return false;
  }
}
