import { TestBed } from '@angular/core/testing';

import { TopStatisticsService } from './top-statistics.service';

describe('TopStatisticsService', () => {
  let service: TopStatisticsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TopStatisticsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
