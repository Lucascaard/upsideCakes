import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletarPagamentoComponent } from './deletar-pagamento.component';

describe('DeletarPagamentoComponent', () => {
  let component: DeletarPagamentoComponent;
  let fixture: ComponentFixture<DeletarPagamentoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeletarPagamentoComponent]
    });
    fixture = TestBed.createComponent(DeletarPagamentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
