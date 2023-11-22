import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlterarFilialComponent } from './alterar-filial.component';

describe('AlterarFilialComponent', () => {
  let component: AlterarFilialComponent;
  let fixture: ComponentFixture<AlterarFilialComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AlterarFilialComponent]
    });
    fixture = TestBed.createComponent(AlterarFilialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
