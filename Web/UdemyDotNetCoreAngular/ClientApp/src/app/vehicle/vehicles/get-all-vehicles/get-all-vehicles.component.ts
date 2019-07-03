import { Component, NgZone, Inject } from '@angular/core';
import { VehicleService } from '../../../services/vehicle.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleDTO } from '../../../DTO/ModelContext';

@Component({
  selector: 'app-get-all-vehicles',
  templateUrl: './get-all-vehicles.component.html',
  styleUrls: ['./get-all-vehicles.component.css']
})
/** GetAllVehicles component*/
export class GetAllVehiclesComponent {
  public vehicles: Array<VehicleDTO>;
  /** GetAllVehicles ctor */
  constructor(private vehicleService: VehicleService, private toastyService: ToastrService, private route: ActivatedRoute, private router: Router, private ngZone: NgZone) {
  }

  ngOnInit() {
    this.vehicleService.GetVehicles().subscribe(
      (response) => {
        this.vehicles = response;
      });
  }

  public ClickTable() {
    this.toastyService.error("Example toas", "Test");
  }
}
