import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MakeDTO, Save_VehicleDTO } from '../DTO/ModelContext';

@Injectable()
export class VehicleService {
  private http: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  public SaveVehicle(vehicle: Save_VehicleDTO) {
    return this.http.post(this.baseUrl + 'api/Vehicles/save', vehicle);
  }
}
