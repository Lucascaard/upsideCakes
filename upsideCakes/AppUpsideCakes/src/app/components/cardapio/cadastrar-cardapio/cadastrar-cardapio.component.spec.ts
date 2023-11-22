import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastrarCardapioComponent } from './cadastrar-cardapio.component';

describe('CadastrarCardapioComponent', () => {
  let component: CadastrarCardapioComponent;
  let fixture: ComponentFixture<CadastrarCardapioComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CadastrarCardapioComponent]
    });
    fixture = TestBed.createComponent(CadastrarCardapioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
