import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletarCardapioComponent } from './deletar-cardapio.component';

describe('DeletarCardapioComponent', () => {
  let component: DeletarCardapioComponent;
  let fixture: ComponentFixture<DeletarCardapioComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeletarCardapioComponent]
    });
    fixture = TestBed.createComponent(DeletarCardapioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
