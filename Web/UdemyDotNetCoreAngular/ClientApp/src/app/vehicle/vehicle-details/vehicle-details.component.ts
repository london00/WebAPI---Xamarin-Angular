import { Component, ElementRef, ViewChild } from '@angular/core';
import { VehicleService } from '../../services/vehicle.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleDTO } from '../../DTO/ModelContext';
import { HttpErrorResponse } from '@angular/common/http';
import { PhotosService } from '../../services/photos.service';

@Component({
    selector: 'app-vehicle-details',
    templateUrl: './vehicle-details.component.html',
    styleUrls: ['./vehicle-details.component.css']
})
/** VehicleDetails component*/
export class VehicleDetailsComponent {
  private vehicle: VehicleDTO;
  private vehicleService: VehicleService;
  private photosService: PhotosService;
  private toastyService: ToastrService;
  private route: ActivatedRoute;
  private router: Router;
  @ViewChild('fileInput') public fileInput: ElementRef;

    /** VehicleDetails ctor */
  constructor(vehicleService: VehicleService, photosService: PhotosService, toastyService: ToastrService, route: ActivatedRoute, router: Router) {
    this.vehicleService = vehicleService;
    this.toastyService = toastyService;
    this.photosService = photosService;
    this.route = route;
    this.router = router;
    this.vehicle = new VehicleDTO();

    route.params.subscribe(p => {
      this.vehicle.Id = Number.parseInt(p["id"]);
    });
  }

  ngOnInit() {
    this.vehicleService.GetVehicle(this.vehicle.Id).subscribe(
      (response) => {
        this.vehicle = response;
      },
      (error: HttpErrorResponse) => {
        if (error.status == 404) {
          // Goes to home page. TODO: Create and go to 404 page error.
          this.router.navigate(["/"]);
        }
      });
  }

  Delete() {
    if (confirm("Are you sure?")) {
      this.vehicleService.Delete(this.vehicle.Id).subscribe(
        data => {
          this.toastyService.success("Vehicle has been deleted", "Success!!");
          this.router.navigate(["/"]);
        });
    }
  }

  UploadPhoto() {
    debugger;
    var nativeElement: HTMLInputElement = this.fileInput.nativeElement;
    this.photosService.Upload(this.vehicle.Id, nativeElement.files[0]).subscribe(
      (response) => {
        debugger;

        console.log(response);
      }
    );
  }
}
