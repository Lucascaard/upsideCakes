import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeletarProdutoComponent } from './deletar-produto.component';

describe('DeletarProdutoComponent', () => {
  let component: DeletarProdutoComponent;
  let fixture: ComponentFixture<DeletarProdutoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DeletarProdutoComponent]
    });
    fixture = TestBed.createComponent(DeletarProdutoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
