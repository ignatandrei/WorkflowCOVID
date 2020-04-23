import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BedSituationComponent } from './bed-situation.component';

describe('BedSituationComponent', () => {
  let component: BedSituationComponent;
  let fixture: ComponentFixture<BedSituationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BedSituationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BedSituationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
