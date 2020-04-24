
export class AnamnesisPatient {
  constructor(source: AnamnesisPatient = null) {
    
    // tslint:disable-next-line: forin
    for (const x in source) {
      this[ x ] = source[x];
    }
  }
  public idpatient: number;
  public idanamnesis: number;
  public details: string;
  public date: Date;
}

