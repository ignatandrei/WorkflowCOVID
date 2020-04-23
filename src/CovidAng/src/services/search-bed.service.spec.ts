import { TestBed } from '@angular/core/testing';

import { SearchBedService } from './search-bed.service';

describe('SearchBedService', () => {
  let service: SearchBedService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SearchBedService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
