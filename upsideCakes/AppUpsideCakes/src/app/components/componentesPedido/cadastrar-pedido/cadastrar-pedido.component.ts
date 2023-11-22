import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Router } from '@angular/router';
import { PedidosService } from '../../../services/pedidos.service';
import { Pedido } from '../../../models/Pedido';

@Component({
  selector: 'app-cadastrar-pedido',
  templateUrl: './cadastrar-pedido.component.html',
  styleUrls: ['./cadastrar-pedido.component.css']
})
export class CadastrarPedidoComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private pedidoService: PedidosService, private router: Router) { }
  ngOnInit(): void {
    this.tituloFormulario = 'Novo Pedido';

    this.formulario = new FormGroup({
      dataCriacao: new FormControl(null),
      funcionario: new FormControl(null),
      gerente: new FormControl(null),
      produto: new FormControl(null),
      qtde: new FormControl(null),
    })
  }

  enviarFormulario(): void {
    const pedido: Pedido = this.formulario.value;
    console.log(pedido);
    const observer: Observer<Pedido> = {
      next(_result): void {
        alert('Pedido salvo com sucesso.');
      },
      error(error): void {
        console.log(error);
        alert('Erro ao salvar, consulte o Console');
      },
      complete(): void {
      },
    };
    this.pedidoService.cadastrar(pedido).subscribe(observer);
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}
