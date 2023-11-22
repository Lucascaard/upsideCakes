import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarFilialComponent } from './listar-filial.component';

describe('ListarFilialComponent', () => {
  let component: ListarFilialComponent;
  let fixture: ComponentFixture<ListarFilialComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListarFilialComponent]
    });
    fixture = TestBed.createComponent(ListarFilialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
