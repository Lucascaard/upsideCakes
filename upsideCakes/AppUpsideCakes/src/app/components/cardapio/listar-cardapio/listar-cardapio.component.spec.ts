import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarCardapioComponent } from './listar-cardapio.component';

describe('ListarCardapioComponent', () => {
  let component: ListarCardapioComponent;
  let fixture: ComponentFixture<ListarCardapioComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListarCardapioComponent]
    });
    fixture = TestBed.createComponent(ListarCardapioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
