import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastrarFilialComponent } from './cadastrar-filial.component';

describe('CadastrarFilialComponent', () => {
  let component: CadastrarFilialComponent;
  let fixture: ComponentFixture<CadastrarFilialComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CadastrarFilialComponent]
    });
    fixture = TestBed.createComponent(CadastrarFilialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
