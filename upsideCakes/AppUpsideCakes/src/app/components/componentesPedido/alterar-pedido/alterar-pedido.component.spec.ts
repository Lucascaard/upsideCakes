import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AlterarPedidoComponent } from './alterar-pedido.component';

describe('AlterarPedidoComponent', () => {
  let component: AlterarPedidoComponent;
  let fixture: ComponentFixture<AlterarPedidoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AlterarPedidoComponent]
    });
    fixture = TestBed.createComponent(AlterarPedidoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
