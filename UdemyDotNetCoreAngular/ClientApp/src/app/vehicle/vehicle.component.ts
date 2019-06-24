import { Component } from '@angular/core';
import { MakeService } from '../services/makes.service';
import { FeaturesService } from '../services/features.service';
import { MakeDTO, ModelDTO, FeatureDTO } from '../DTO/ModelContext';

@Component({
  selector: 'app-vehicle',
  templateUrl: './vehicle.component.html',
  styleUrls: ['./vehicle.component.css']
})
export class VehicleComponent {
  public vehicle: any = {};
  public makes: MakeDTO[];
  public makeService: MakeService;
  public featuresService: FeaturesService;
  public models: ModelDTO[];
  public features: FeatureDTO[];

  constructor(makeService: MakeService, featuresService: FeaturesService) {
    this.makeService = makeService;
    this.featuresService = featuresService;
    this.makes = new Array<MakeDTO>();
    this.features = new Array<FeatureDTO>();
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
        console.error("GetMakes has failed" + error);
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

  onModelChange() {
    var selectedModel = this.models.find(f => f.Id == this.vehicle.model);
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
  }
}
