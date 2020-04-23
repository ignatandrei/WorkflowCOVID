import { Room } from "./Room";
import { BedPatient } from "./BedPatient";

export class BedWithRoom {
  constructor(source: BedWithRoom = null) {
    if (source != null) {
      for (const x in source) {
        this[x] = source[x];
      }
    }
  }
  idbed: number;
  idroom: number;
  name: string;
  idroomNavigation: Room;
}

export class BedWithRoomAndPatient extends BedWithRoom {
  constructor(source: BedWithRoom){
    super(source);    
  }
  bedpatient: BedPatient;
}
