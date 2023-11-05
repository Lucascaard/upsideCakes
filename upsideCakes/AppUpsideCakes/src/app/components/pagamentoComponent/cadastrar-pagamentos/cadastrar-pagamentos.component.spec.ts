import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastrarPagamentosComponent } from './cadastrar-pagamentos.component';

describe('CadastrarPagamentosComponent', () => {
  let component: CadastrarPagamentosComponent;
  let fixture: ComponentFixture<CadastrarPagamentosComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CadastrarPagamentosComponent]
    });
    fixture = TestBed.createComponent(CadastrarPagamentosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
