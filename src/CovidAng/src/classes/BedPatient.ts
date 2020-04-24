import { IdName } from './IdName';
import { BedWithRoom } from './BedWithRoom';

export class BedPatient {
  public idpatient: number;
  public idbed: number;
}
export class BedPatientWithName extends BedPatient{
  public idbedNavigation: BedWithRoom;
}