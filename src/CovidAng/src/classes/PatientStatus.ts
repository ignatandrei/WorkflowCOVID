import { IdName } from './IdName';

export class PatientStatus {
  public idpatient: number;
  public idstatus: number;
}

export class PatientStatusWithName extends PatientStatus{
  public idstatusNavigation: IdName;
}
