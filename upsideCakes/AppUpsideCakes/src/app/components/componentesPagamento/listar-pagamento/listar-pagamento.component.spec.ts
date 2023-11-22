import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarPagamentoComponent } from './listar-pagamento.component';

describe('ListarPagamentoComponent', () => {
  let component: ListarPagamentoComponent;
  let fixture: ComponentFixture<ListarPagamentoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListarPagamentoComponent]
    });
    fixture = TestBed.createComponent(ListarPagamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
