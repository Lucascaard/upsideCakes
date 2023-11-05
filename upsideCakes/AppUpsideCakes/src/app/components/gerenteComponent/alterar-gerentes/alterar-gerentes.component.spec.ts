import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlterarGerentesComponent } from './alterar-gerentes.component';

describe('AlterarGerentesComponent', () => {
  let component: AlterarGerentesComponent;
  let fixture: ComponentFixture<AlterarGerentesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AlterarGerentesComponent]
    });
    fixture = TestBed.createComponent(AlterarGerentesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
