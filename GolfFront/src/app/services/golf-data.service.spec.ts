import { TestBed } from '@angular/core/testing';

import { GolfDataService } from './golf-data.service';

describe('GolfDataService', () => {
  let service: GolfDataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GolfDataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
