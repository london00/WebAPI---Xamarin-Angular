export interface MakeDTO {
  Id: number;
  Name: string;
  Models: KeyValuePairDTO[];
}

export class KeyValuePairDTO {
  Id: number;
  Name: string;
}

export class Save_VehicleDTO {
  Id: number;
  MakeId: number;
  ModelId: number;
  IsRegistered: boolean;
  Contact: ContactInfoDTO;
  VehicleFeatures: Array<VehicleFeatureDTO>;

  constructor() {
    this.VehicleFeatures = new Array<VehicleFeatureDTO>();
    this.Contact = new ContactInfoDTO();
    this.ModelId = 0;
    this.MakeId = 0;
    this.IsRegistered = false;
  }
}

export class ContactInfoDTO {
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
    this.Make = new KeyValuePairDTO();
    this.Model = new KeyValuePairDTO();
    this.Contact = new ContactInfoDTO();
  }

  public Id: number;
  public IsRegistered: boolean;
  public Contact: ContactInfoDTO;
  public LastUpdate: string;
  public Model: KeyValuePairDTO;
  public Make: KeyValuePairDTO;
  public VehicleFeatures: Array<KeyValuePairDTO>;
}


export class VehicleFilters {
  constructor() {
    this.ModelId = 0;
    this.MakeId = 0;
  }

  public ModelId: number;
  public MakeId: number;
}
