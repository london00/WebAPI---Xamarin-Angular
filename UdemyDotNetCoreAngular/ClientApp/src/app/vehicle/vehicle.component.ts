import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { debug } from 'util';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css']
})
export class VehicleComponent {
  public makes: MakeDTO[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<MakeDTO[]>(baseUrl + 'api/Makes/GetMakes').subscribe(result => {
      this.makes = result;
    }, error => console.error(error));
  }
}

interface MakeDTO {
  Id: number;
  Name: string;
  Models: ModelDTO[];
}

interface ModelDTO {
  Id: number;
  Name: string;
  MakeId: number;
}
