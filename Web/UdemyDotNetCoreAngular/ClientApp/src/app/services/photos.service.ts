import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class PhotosService {
  constructor(private http: HttpClient) {
  }

  public Upload(vehicleId: number, photo: any) {
    var formData = new FormData();
    formData.append("file", photo);
    return this.http.post(
      `/api/vehicles/${vehicleId}/photos`,
      formData,
      {
        reportProgress: true,
        observe: 'events'
      }
    );
  }
}
