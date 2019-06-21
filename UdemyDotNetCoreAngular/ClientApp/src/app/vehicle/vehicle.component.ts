import { Component } from '@angular/core';
import { MakeService, MakeDTO, ModelDTO } from '../services/makes.service';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css']
})
export class VehicleComponent {
  public vehicle: any = {};
  public makes: MakeDTO[];
  public makeService: MakeService;
  public models: ModelDTO[];

  constructor(makeService: MakeService) {
    this.makeService = makeService;
    this.makes = new Array<MakeDTO>();
    this.vehicle = {
      make: 0,
      model: 0
    };
  }

  ngOnInit() {
    this.makeService.GetMakes().subscribe(result => {
        this.makes = result;
      },
      error => {
        console.error(error);
      }
    );
  }

  onMakeChange() {
    var selectedMake = this.makes.find(f => f.Id == this.vehicle.make);
    if (typeof (selectedMake) != "undefined") {
      this.models = selectedMake.Models;
    }
    else {
      this.models = new Array<ModelDTO>();
    }

    this.vehicle.model = 0;
  }
}
