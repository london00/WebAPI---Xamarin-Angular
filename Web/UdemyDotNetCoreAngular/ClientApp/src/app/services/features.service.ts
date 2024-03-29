import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { VehicleFeatureDTO } from '../DTO/ModelContext';

@Injectable()
export class FeaturesService {
  private http: HttpClient;
  private baseUrl: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  public GetFeaturesByModel(ModelId: number): Observable<VehicleFeatureDTO[]> {
    let params = new HttpParams().set("ModelId", ModelId.toString());
    return this.http.get<VehicleFeatureDTO[]>(this.baseUrl + 'api/Features/GetFeaturesByModel', { params: params });
  }
}
