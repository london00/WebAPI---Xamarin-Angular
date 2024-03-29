import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { MakeDTO, Save_VehicleDTO, VehicleDTO, VehicleFilters } from '../DTO/ModelContext';
import * as $ from 'jquery';

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

  public GetVehicles(filter: VehicleFilters): Observable<Array<VehicleDTO>> {
    return this.http.get<Array<VehicleDTO>>(this.baseUrl + 'api/Vehicles/get?' + $.param(filter));
  }

  public Delete(Id: number) {
    return this.http.delete(this.baseUrl + 'api/Vehicles/Delete/' + Id);
  }
}
