import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlterarPagamentoComponent } from './alterar-pagamento.component';

describe('AlterarPagamentoComponent', () => {
  let component: AlterarPagamentoComponent;
  let fixture: ComponentFixture<AlterarPagamentoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AlterarPagamentoComponent]
    });
    fixture = TestBed.createComponent(AlterarPagamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
