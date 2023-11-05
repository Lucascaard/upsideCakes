import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastrarGerentesComponent } from './cadastrar-gerentes.component';

describe('CadastrarGerentesComponent', () => {
  let component: CadastrarGerentesComponent;
  let fixture: ComponentFixture<CadastrarGerentesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CadastrarGerentesComponent]
    });
    fixture = TestBed.createComponent(CadastrarGerentesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
