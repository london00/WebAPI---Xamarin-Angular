import * as _ from "underscore";
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MakeService } from '../services/makes.service';
import { FeaturesService } from '../services/features.service';
import { MakeDTO, Save_VehicleDTO, VehicleFeatureDTO, KeyValuePairDTO, VehicleDTO } from '../DTO/ModelContext';
import { VehicleService } from '../services/vehicle.service';
import { ToastrService } from 'ngx-toastr';
import { HttpErrorResponse } from '@angular/common/http';
import { Observable, forkJoin } from 'rxjs';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css']
})
export class VehicleComponent {
  private featuresService: FeaturesService;
  private vehicleService: VehicleService;
  private toastyService: ToastrService;
  private makeService: MakeService;
  private route: ActivatedRoute;
  private router: Router;

  public vehicle: Save_VehicleDTO;
  public makes: MakeDTO[];
  public models: KeyValuePairDTO[];
  public features: VehicleFeatureDTO[];

  constructor(makeService: MakeService, featuresService: FeaturesService, vehicleService: VehicleService, toastyService: ToastrService, route: ActivatedRoute, router: Router) {
    this.makeService = makeService;
    this.featuresService = featuresService;
    this.vehicleService = vehicleService;
    this.toastyService = toastyService;
    this.route = route;
    this.router = router;

    this.makes = new Array<MakeDTO>();
    this.features = new Array<VehicleFeatureDTO>();
    this.vehicle = new Save_VehicleDTO();

    route.params.subscribe(p => {
      this.vehicle.Id = Number.parseInt(p["id"]);
    });
  }

  ngOnInit() {
    var services = new Array();
    services.push(this.makeService.GetMakes());

    if (this.vehicle.Id) {
      services.push(this.vehicleService.GetVehicle(this.vehicle.Id));
    }


    // Fork join help to make parallel requests. more info: https://medium.com/@swarnakishore/performing-multiple-http-requests-in-angular-4-5-with-forkjoin-74f3ac166d61
    forkJoin(services).subscribe(
      (result) => {
        // Makes
        this.makes = result[0];

        if (this.vehicle.Id) {
          this.SetVehicle(result[1]);
          this.SetMake();
          this.SetFeatures();
        }
      },
      (error: HttpErrorResponse) => {
        if (error.status == 404) {
          // Goes to home page. TODO: Create and go to 404 page error.
          this.router.navigate(["/"]);
        }
      });
  }

  private isFeatureSelected(vehicleFeatureId: number): boolean {
    var vf = this.vehicle.VehicleFeatures.filter((vf) => { return vf.FeatureId == vehicleFeatureId });
    return vf.length > 0;
  }

  private SetVehicle(vehicleDTO: VehicleDTO) {
    // Vehicle
    this.vehicle = new Save_VehicleDTO();
    this.vehicle.Id = vehicleDTO.Id;
    this.vehicle.Contact = vehicleDTO.Contact;
    this.vehicle.IsRegistered = vehicleDTO.IsRegistered;
    this.vehicle.MakeId = vehicleDTO.Make.Id;
    this.vehicle.ModelId = vehicleDTO.Model.Id;
    _.map(vehicleDTO.VehicleFeatures, (vf) => {
      var vehicleFeatureDTO = new VehicleFeatureDTO();
      vehicleFeatureDTO.FeatureId = vf.Id;
      vehicleFeatureDTO.VehicleId = this.vehicle.Id;
      this.vehicle.VehicleFeatures.push(vehicleFeatureDTO);
    });
  }

  private SetMake() {
    var selectedMake = this.makes.find(f => f.Id == this.vehicle.MakeId);
    if (typeof (selectedMake) != "undefined") {
      this.models = selectedMake.Models;
    }
    else {
      this.models = new Array<KeyValuePairDTO>();
    }
  }

  onMakeChange() {
    this.SetMake();

    // Reset model
    this.vehicle.ModelId = 0;
    // Empty features array
    this.vehicle.VehicleFeatures = [];
  }

  SetFeatures() {
    var selectedModel = this.models.find(f => f.Id == this.vehicle.ModelId);
    if (typeof (selectedModel) != "undefined") {
      this.featuresService.GetFeaturesByModel(selectedModel.Id).subscribe(
        result => {
          this.features = result;
        },
        error => {
          console.error("GetFeaturesByModel has failed: " + error);
        }
      );
    }
    else {
      this.features = new Array<VehicleFeatureDTO>();
    }
  }

  onModelChange() {
    this.SetFeatures();

    // Empty features array
    this.vehicle.VehicleFeatures = [];
  }

  /**
   * Listen toogle event from feature checkboxes
   * @param FeatureId Feature checked
   * @param $event Event
   */
  onFeatureToggle(FeatureId: number, $event: any) {
    if ($event.target.checked) {
      var feature = new VehicleFeatureDTO();
      feature.FeatureId = FeatureId;
      feature.VehicleId = this.vehicle.Id;
      this.vehicle.VehicleFeatures.push(feature);
    }
    else {
      var featureIndex = this.vehicle.VehicleFeatures.findIndex(x => x.FeatureId == FeatureId);
      this.vehicle.VehicleFeatures.splice(featureIndex, 1);
    }
  }

  Sumbit() {
    if (this.vehicle.Id) {
      this.vehicleService.Update(this.vehicle).subscribe(
        data => {
          this.toastyService.success("Vehicle has been updated", "Success!!");
        }
      );
    }
    else {
      this.vehicleService.Create(this.vehicle).subscribe(
        data => {
          this.toastyService.success("Vehicle has been created", "Success!!");
        }
      );
    }
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
}
