import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletarPagamentosComponent } from './deletar-pagamentos.component';

describe('DeletarPagamentosComponent', () => {
  let component: DeletarPagamentosComponent;
  let fixture: ComponentFixture<DeletarPagamentosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeletarPagamentosComponent]
    });
    fixture = TestBed.createComponent(DeletarPagamentosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
