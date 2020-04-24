import { AnamnesisPatientWithName } from "./AnamnesisPatientWithName";
import { BedWithRoom } from './BedWithRoom';
import { BedPatientWithName } from './BedPatient';
import { DetailsPatient } from './DetailsPatient';
import { DetailsPatientWithName } from "./DetailsPatientWithName";
import { LocationPatient, LocationPatientWithName } from './LocationPatient';
import { PatientStatus, PatientStatusWithName } from './PatientStatus';

export class Patient {
  constructor(source: Patient = null) {
    this.id = 0;
    // tslint:disable-next-line: forin
    for (const x in source) {
      this[ x ] = source[x];
    }
  }
  public id: number;
  public name: string;  

}

export class PatientDetails extends Patient {
  constructor(source: PatientDetails){
    super(source);
  }
  public anamnesisPatient: AnamnesisPatientWithName[];
  public bedPatient: BedPatientWithName[];
  public detailsPatient: DetailsPatientWithName[];
  public locationPatient: LocationPatientWithName[];
  public patientStatus: PatientStatusWithName[];

}
