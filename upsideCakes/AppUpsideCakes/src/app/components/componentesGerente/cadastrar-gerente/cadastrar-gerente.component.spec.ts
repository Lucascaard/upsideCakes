import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastrarGerenteComponent } from './cadastrar-gerente.component';

describe('CadastrarGerenteComponent', () => {
  let component: CadastrarGerenteComponent;
  let fixture: ComponentFixture<CadastrarGerenteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CadastrarGerenteComponent]
    });
    fixture = TestBed.createComponent(CadastrarGerenteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
