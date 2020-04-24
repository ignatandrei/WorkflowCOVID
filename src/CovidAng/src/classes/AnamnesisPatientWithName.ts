import { Anamnesis } from './Anamnesis';
import { AnamnesisPatient } from './AnamnesisPatient';
export class AnamnesisPatientWithName extends AnamnesisPatient {
  constructor(source: AnamnesisPatientWithName) {
    super(source);
  }
  public idanamnesisNavigation: Anamnesis;
}
