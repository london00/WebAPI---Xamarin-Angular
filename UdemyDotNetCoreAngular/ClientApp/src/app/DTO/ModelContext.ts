export interface MakeDTO {
  Id: number;
  Name: string;
  Models: ModelDTO[];
}

export interface ModelDTO {
  Id: number;
  Name: string;
}

export interface FeatureDTO {
  Id: number;
  Name: string;
}

export class Save_VehicleDTO {
  Id: number;
  MakeId: number;
  ModelId: number;
  IsRegistered: boolean;
  Contact: ContactInfo;
  VehicleFeatures: Array<VehicleFeatureDTO>;

  constructor() {
    this.VehicleFeatures = new Array<VehicleFeatureDTO>();
    this.Contact = new ContactInfo();
    this.ModelId = 0;
    this.MakeId = 0;
    this.IsRegistered = false;
  }
}

export class ContactInfo {
  Name: string;
  Phone: string;
  Mail: string;
}

export class VehicleFeatureDTO {
  Id: number;
  FeatureId: number;
  VehicleId: number;
}
