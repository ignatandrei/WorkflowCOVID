import { Component, OnInit } from '@angular/core';
import { SearchBedService } from 'src/services/search-bed.service';
import { BedWithRoomAndPatient } from 'src/classes/BedWithRoom';

@Component({
  selector: 'app-bed-situation',
  templateUrl: './bed-situation.component.html',
  styleUrls: ['./bed-situation.component.css']
})
export class BedSituationComponent implements OnInit {
  public roomsId: Map<number, BedWithRoomAndPatient[]>;
  constructor(private sbs: SearchBedService) {
this.roomsId = new  Map<number, BedWithRoomAndPatient[]>();
  }

  ngOnInit(): void {
    this.sbs.AllBedsWithPatients().subscribe(it => {
      for (let index = 0; index < it.length; index++) {
        const element = it[index];
        if (!this.roomsId.has(element.idroom)) {
          this.roomsId.set(element.idroom, []);
        }

        this.roomsId.get(element.idroom).push(new BedWithRoomAndPatient(element)); 


      }

    });
  }

}
