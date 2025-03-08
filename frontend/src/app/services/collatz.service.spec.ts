import { TestBed } from '@angular/core/testing';

import { CollatzService } from './collatz.service';

describe('CollatzService', () => {
  let service: CollatzService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CollatzService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
