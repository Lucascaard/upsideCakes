import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletarGerentesComponent } from './deletar-gerentes.component';

describe('DeletarGerentesComponent', () => {
  let component: DeletarGerentesComponent;
  let fixture: ComponentFixture<DeletarGerentesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeletarGerentesComponent]
    });
    fixture = TestBed.createComponent(DeletarGerentesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
