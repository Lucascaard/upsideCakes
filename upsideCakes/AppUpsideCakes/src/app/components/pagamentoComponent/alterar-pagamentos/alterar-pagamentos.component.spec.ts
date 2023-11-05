import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlterarPagamentosComponent } from './alterar-pagamentos.component';

describe('AlterarPagamentosComponent', () => {
  let component: AlterarPagamentosComponent;
  let fixture: ComponentFixture<AlterarPagamentosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AlterarPagamentosComponent]
    });
    fixture = TestBed.createComponent(AlterarPagamentosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
