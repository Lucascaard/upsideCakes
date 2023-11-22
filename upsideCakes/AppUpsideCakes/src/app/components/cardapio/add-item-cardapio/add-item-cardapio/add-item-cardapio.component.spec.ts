import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddItemCardapioComponent } from './add-item-cardapio.component';

describe('AddItemCardapioComponent', () => {
  let component: AddItemCardapioComponent;
  let fixture: ComponentFixture<AddItemCardapioComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddItemCardapioComponent]
    });
    fixture = TestBed.createComponent(AddItemCardapioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
