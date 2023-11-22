import { TestBed } from '@angular/core/testing';

import { CardapiosService } from './cardapios.service';

describe('CardapiosService', () => {
  let service: CardapiosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CardapiosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
