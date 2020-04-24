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
  public comments: string;
}
