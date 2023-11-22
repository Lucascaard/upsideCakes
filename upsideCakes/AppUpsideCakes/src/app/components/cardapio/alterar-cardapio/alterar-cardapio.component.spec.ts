import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlterarCardapioComponent } from './alterar-cardapio.component';

describe('AlterarCardapioComponent', () => {
  let component: AlterarCardapioComponent;
  let fixture: ComponentFixture<AlterarCardapioComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AlterarCardapioComponent]
    });
    fixture = TestBed.createComponent(AlterarCardapioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
