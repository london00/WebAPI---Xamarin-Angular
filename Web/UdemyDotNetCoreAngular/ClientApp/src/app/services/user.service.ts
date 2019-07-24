import { Injectable, Inject } from '@angular/core';
import { UserDTO } from '../DTO/ModelContext';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class UserService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  public Register(user: UserDTO) {
    return this.http.post(this.baseUrl + 'api/Auth/Register', user);
  }

  public Login(user: UserDTO) {
    return this.http.post(this.baseUrl + 'api/Auth/Login', user);
  }
}
