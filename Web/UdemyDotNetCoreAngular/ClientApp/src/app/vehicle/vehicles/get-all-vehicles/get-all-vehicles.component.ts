import { Component, NgZone, Inject } from '@angular/core';
import { VehicleService } from '../../../services/vehicle.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleDTO, MakeDTO } from '../../../DTO/ModelContext';
import { MakeService } from '../../../services/makes.service';

@Component({
  selector: 'app-get-all-vehicles',
  templateUrl: './get-all-vehicles.component.html',
  styleUrls: ['./get-all-vehicles.component.css']
})
/** GetAllVehicles component*/
export class GetAllVehiclesComponent {
  public vehicles: Array<VehicleDTO>;
  public vehiclesComplete: Array<VehicleDTO>;
  public makes: MakeDTO[];
  public filters: any;
  /** GetAllVehicles ctor */
  constructor(private vehicleService: VehicleService, private toastyService: ToastrService, private route: ActivatedRoute, private router: Router, private ngZone: NgZone, private makeService: MakeService) {
    this.filters = {
      MakeId: 0
    };
  }

  ngOnInit() {
    this.makeService.GetMakes().subscribe(
      (response) => {
        this.makes = response;
      });

    this.vehicleService.GetVehicles().subscribe(
      (response) => {
        this.vehicles = response;
        this.vehiclesComplete = response;
      });
  }

  public refreshFilters() {
    this.vehicles = this.vehiclesComplete.filter((v) => {
      return this.filters.MakeId == 0 || v.Make.Id == this.filters.MakeId
    })
  }

  public resetFilters() {
    this.vehicles = this.vehiclesComplete;
    this.filters = {
      MakeId: 0
    };
  }
}
