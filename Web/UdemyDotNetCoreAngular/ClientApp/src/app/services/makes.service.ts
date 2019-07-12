import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MakeDTO } from '../DTO/ModelContext';

@Injectable()
export class MakeService {
  private http: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  public GetMakes(): Observable<MakeDTO[]> {
    return this.http.get<MakeDTO[]>(this.baseUrl + 'api/Makes/GetMakes');
  }
}
