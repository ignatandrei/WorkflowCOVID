import { IdName } from './IdName';

export class LocationPatient {
  public idpatient: number;
  public idlocation: number;
}

export class LocationPatientWithName extends LocationPatient{
  public idlocationNavigation: IdName;
}
