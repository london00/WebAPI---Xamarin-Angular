import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from '@angular/router';

@Injectable()
export class AuthService {
  private jwtHelper: JwtHelperService;

  constructor(private router: Router) {
    // https://www.npmjs.com/package/@auth0/angular-jwt
    this.jwtHelper = new JwtHelperService();
  }

  public GetToken(): any {
    return localStorage.getItem("token");
  }

  public isAuthenticated() {
    try {
      var token = this.GetToken();
      if (token && !this.jwtHelper.isTokenExpired(token)) {
        return true;
      }
    }
    catch (e) {
      return false;
    }
  }

  public LogOut() {
    localStorage.removeItem("token");
    this.router.navigate(["login"]);
  }
}
