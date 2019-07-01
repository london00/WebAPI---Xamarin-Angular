export interface MakeDTO {
  Id: number;
  Name: string;
  Models: KeyValuePairDTO[];
}

export interface KeyValuePairDTO {
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

export class VehicleDTO {
  constructor() {
    this.VehicleFeatures = new Array<KeyValuePairDTO>();
  }

  public Id: number;
  public IsRegistered: boolean;
  public Contact: ContactInfo;
  public LastUpdate: string;
  public Model: KeyValuePairDTO;
  public Make: KeyValuePairDTO;
  public VehicleFeatures: Array<KeyValuePairDTO>;
}
