import { TestBed } from '@angular/core/testing';

import { CreateDeleteService } from './create-delete.service';

describe('CreateDeleteService', () => {
  let service: CreateDeleteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CreateDeleteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
