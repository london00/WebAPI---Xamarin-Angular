import { Component } from '@angular/core';
import { MakeService } from '../services/makes.service';
import { FeaturesService } from '../services/features.service';
import { MakeDTO, ModelDTO, FeatureDTO, Save_VehicleDTO, VehicleFeatureDTO } from '../DTO/ModelContext';
import { VehicleService } from '../services/vehicle.service';
import { ToastrService } from 'ngx-toastr';

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

  public vehicle: Save_VehicleDTO;
  public makes: MakeDTO[];
  public models: ModelDTO[];
  public features: FeatureDTO[];

  constructor(makeService: MakeService, featuresService: FeaturesService, vehicleService: VehicleService, toastyService: ToastrService) {
    this.makeService = makeService;
    this.featuresService = featuresService;
    this.vehicleService = vehicleService;
    this.toastyService = toastyService;
    this.makes = new Array<MakeDTO>();
    this.features = new Array<FeatureDTO>();
    this.vehicle = new Save_VehicleDTO();
  }

  ngOnInit() {
    this.makeService.GetMakes().subscribe(result => {
      this.makes = result;
    },
      error => {
        console.error("GetMakes has failed" + error);
      }
    );
  }

  onMakeChange() {
    var selectedMake = this.makes.find(f => f.Id == this.vehicle.MakeId);
    if (typeof (selectedMake) != "undefined") {
      this.models = selectedMake.Models;
    }
    else {
      this.models = new Array<ModelDTO>();
    }

    // Reset model
    this.vehicle.ModelId = 0;
    // Empty features array
    this.vehicle.VehicleFeatures = [];
  }

  onModelChange() {
    var selectedModel = this.models.find(f => f.Id == this.vehicle.ModelId);
    if (typeof (selectedModel) != "undefined") {
      this.featuresService.GetFeaturesByModel(selectedModel.Id).subscribe(result => {
        this.features = result;
      },
        error => {
          console.error("GetFeaturesByModel has failed: " + error);
        }
      );
    }
    else {
      this.features = new Array<FeatureDTO>();
    }

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
      this.vehicle.VehicleFeatures.push(feature);
    }
    else {
      var featureIndex = this.vehicle.VehicleFeatures.findIndex(x => x.FeatureId == FeatureId);
      this.vehicle.VehicleFeatures.splice(featureIndex, 1);
    }
  }

  Sumbit() {
    this.vehicleService.SaveVehicle(this.vehicle).subscribe(
      data => {
        this.toastyService.success("Vehicle has been saved", "Success!!");
        console.log(data);
      },
      error => {
        this.toastyService.error("Check console for more details", "Error!!");
        console.error(error);
      }
    );
  }
}
