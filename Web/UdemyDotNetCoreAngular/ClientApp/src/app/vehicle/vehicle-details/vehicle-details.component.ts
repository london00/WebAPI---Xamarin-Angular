import { Component, ElementRef, ViewChild } from '@angular/core';
import { VehicleService } from '../../services/vehicle.service';
import { ToastrService } from 'ngx-toastr';
import { ActivatedRoute, Router } from '@angular/router';
import { VehicleDTO, Photo } from '../../DTO/ModelContext';
import { HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { PhotosService } from '../../services/photos.service';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-vehicle-details',
  templateUrl: './vehicle-details.component.html',
  styleUrls: ['./vehicle-details.component.css']
})
/** VehicleDetails component*/
export class VehicleDetailsComponent {
  private vehicleService: VehicleService;
  private toastyService: ToastrService;
  private route: ActivatedRoute;
  private router: Router;

  public vehicle: VehicleDTO;
  private photosService: PhotosService;

  @ViewChild('fileInput') public fileInput: ElementRef;

  public processCompleted: number = 100;

  /** VehicleDetails ctor */
  constructor(vehicleService: VehicleService, photosService: PhotosService, toastyService: ToastrService, route: ActivatedRoute, router: Router, public authService: AuthService) {
    this.toastyService = toastyService;
    this.vehicleService = vehicleService;
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
    var nativeElement: HTMLInputElement = this.fileInput.nativeElement;
    if (nativeElement.files.length > 0) {
      this.photosService.Upload(this.vehicle.Id, nativeElement.files[0]).subscribe(
        (event) => {
          switch (event.type) {
            case HttpEventType.UploadProgress:
              this.processCompleted = Math.round((event["loaded"] / event["total"]) * 100);
              break;
            case HttpEventType.Response:
              var photo = new Photo();
              photo.Id = event.body["Id"];
              photo.FileName = event.body["FileName"];
              this.vehicle.Photos.push(photo);
              nativeElement.value = null;
              break;
          }
        },
        error => {
          this.toastyService.warning(error.error, "Server error");
        }
      );
    }
  }
}
