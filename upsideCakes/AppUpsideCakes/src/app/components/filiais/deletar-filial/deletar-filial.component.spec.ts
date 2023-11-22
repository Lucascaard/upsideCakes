import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletarFilialComponent } from './deletar-filial.component';

describe('DeletarFilialComponent', () => {
  let component: DeletarFilialComponent;
  let fixture: ComponentFixture<DeletarFilialComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeletarFilialComponent]
    });
    fixture = TestBed.createComponent(DeletarFilialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
