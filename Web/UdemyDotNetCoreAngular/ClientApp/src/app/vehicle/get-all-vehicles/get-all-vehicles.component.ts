import { Component, NgZone, Inject } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleService } from '../../services/vehicle.service';
import { VehicleFilters, MakeDTO, VehicleDTO } from '../../DTO/ModelContext';
import { MakeService } from '../../services/makes.service';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-get-all-vehicles',
  templateUrl: './get-all-vehicles.component.html',
  styleUrls: ['./get-all-vehicles.component.css']
})
/** GetAllVehicles component*/
export class GetAllVehiclesComponent {
  public vehicles: Array<VehicleDTO>;
  public makes: MakeDTO[];
  public filters: VehicleFilters;
  /** GetAllVehicles ctor */
  constructor(private vehicleService: VehicleService, private toastyService: ToastrService, private route: ActivatedRoute, private router: Router, private ngZone: NgZone, private makeService: MakeService, public Auth: AuthService) {
    this.filters = new VehicleFilters();
  }

  ngOnInit() {
    this.makeService.GetMakes().subscribe(
      (response) => {
        this.makes = response;
      });

    this.populateVehicles();
  }

  public populateVehicles() {
    this.vehicleService.GetVehicles(this.filters).subscribe(
      (response) => {
        this.vehicles = response;
      });
  }

  public refreshFilters() {
    this.populateVehicles();
  }

  public resetFilters() {
    this.filters = new VehicleFilters();
    this.populateVehicles();
  }
}
