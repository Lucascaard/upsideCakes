import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Pedido } from '../../../models/Pedido';
import { PedidosService } from '../../../services/pedidos.service';

@Component({
  selector: 'app-listar-pedido',
  templateUrl: './listar-pedido.component.html',
  styleUrls: ['./listar-pedido.component.css']
})
export class ListarPedidoComponent implements OnInit {
  pedidos: Array<Pedido> = [];
  pedidosPorId: Array<Pedido> = [];
  mostrarListagemGeral: boolean = false;
  idPedido: string = '';
  tituloFormulario = 'Listar Pedidos';

  constructor(private pedidoService: PedidosService, private router: Router) { }

  ngOnInit(): void {
    this.pedidoService.listar().subscribe(pedidos => {
      this.pedidos = pedidos;
    });
  }

  listarGeral() {
    this.mostrarListagemGeral = true;
    this.pedidosPorId = [];
  }

  listarPorId() {
    if (this.idPedido.trim() === '') {
      this.listarGeral();
      return;
    }

    if (this.idPedido !== undefined) {
      this.pedidoService.listarPorID(parseInt(this.idPedido)).subscribe(pedido => {
        this.pedidosPorId = [pedido];
        this.mostrarListagemGeral = false;
      });
    } else {
      this.pedidosPorId = [];
      this.mostrarListagemGeral = false;
    }
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}
