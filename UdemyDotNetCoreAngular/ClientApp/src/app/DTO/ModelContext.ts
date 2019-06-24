export interface MakeDTO {
  Id: number;
  Name: string;
  Models: ModelDTO[];
}

export interface ModelDTO {
  Id: number;
  Name: string;
  MakeId: number;
}

export interface FeatureDTO {
  Id: number;
  Name: string;
  ModelId: number;
  Model: ModelDTO;
}
