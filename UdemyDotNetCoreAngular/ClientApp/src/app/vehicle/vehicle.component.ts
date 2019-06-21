import { Component } from '@angular/core';
import { MakeService, MakeDTO } from '../services/makes.service';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css']
})
export class VehicleComponent {
  public makes: MakeDTO[];
  public makeService: MakeService;

  constructor(makeService: MakeService) {
    this.makeService = makeService;
  }

  ngOnInit() {
    debugger;
    this.makeService.GetMakes().subscribe(result => {
        this.makes = result;
      },
      error => {
        console.error(error);
      }
    );
  }
}
