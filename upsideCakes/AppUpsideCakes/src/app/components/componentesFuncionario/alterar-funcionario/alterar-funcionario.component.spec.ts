import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlterarFuncionarioComponent } from './alterar-funcionario.component';

describe('AlterarFuncionarioComponent', () => {
  let component: AlterarFuncionarioComponent;
  let fixture: ComponentFixture<AlterarFuncionarioComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AlterarFuncionarioComponent]
    });
    fixture = TestBed.createComponent(AlterarFuncionarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
