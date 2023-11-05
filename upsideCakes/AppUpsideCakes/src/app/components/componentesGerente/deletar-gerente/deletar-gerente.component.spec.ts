import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletarGerenteComponent } from './deletar-gerente.component';

describe('DeletarGerenteComponent', () => {
  let component: DeletarGerenteComponent;
  let fixture: ComponentFixture<DeletarGerenteComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeletarGerenteComponent]
    });
    fixture = TestBed.createComponent(DeletarGerenteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
