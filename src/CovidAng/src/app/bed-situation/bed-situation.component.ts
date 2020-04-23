import { Component, OnInit } from '@angular/core';
import { SearchBedService } from 'src/services/search-bed.service';
import { BedWithRoomAndPatient } from 'src/classes/BedWithRoom';

@Component({
  selector: 'app-bed-situation',
  templateUrl: './bed-situation.component.html',
  styleUrls: ['./bed-situation.component.css'],
})
export class BedSituationComponent implements OnInit {
  public roomsId: Map<number, BedWithRoomAndPatient[]>;
  public patients: number[];
  constructor(private sbs: SearchBedService) {
    this.roomsId = new Map<number, BedWithRoomAndPatient[]>();
  }
  public nrPatientRooms(items: BedWithRoomAndPatient[]): number {
    if ((items?.length ?? 0) < 1) {
      return 0;
    }

    return items.filter(it => (it.bedPatient?.length ?? 0) > 0).length;
  }
  ngOnInit(): void {
    this.sbs.AllBedsWithPatients().subscribe((it) => {
      this.patients = [];
      // tslint:disable-next-line: prefer-for-of
      for (let index = 0; index < it.length; index++) {
        const element = it[index];
        const bed = element.bedPatient;
        const nrPat = +(element.bedPatient?.length ?? 0);

        if ( nrPat > 0) {
            this.patients.push(element.bedPatient[0].idpatient);
        }

        if (!this.roomsId.has(element.idroom)) {
          this.roomsId.set(element.idroom, []);
        }

        this.roomsId
          .get(element.idroom)
          .push(new BedWithRoomAndPatient(element));
      }
    });
  }
}
