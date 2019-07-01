import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MakeDTO, Save_VehicleDTO, VehicleDTO } from '../DTO/ModelContext';

@Injectable()
export class VehicleService {
  private http: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  public Create(vehicle: Save_VehicleDTO) {
    return this.http.post(this.baseUrl + 'api/Vehicles/save', vehicle);
  }

  public Update(vehicle: Save_VehicleDTO) {
    return this.http.put(this.baseUrl + 'api/Vehicles/Update/' + vehicle.Id, vehicle);
  }

  public GetVehicle(id: number): Observable<VehicleDTO> {
    return this.http.get<VehicleDTO>(this.baseUrl + 'api/Vehicles/get/' + id);
  }
}
