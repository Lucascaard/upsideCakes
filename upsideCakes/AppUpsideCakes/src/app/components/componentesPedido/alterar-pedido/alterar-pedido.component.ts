import { Component, OnInit } from '@angular/core';
import { Pedido } from '../../../models/Pedido';
import { PedidosService } from '../../../services/pedidos.service';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-alterar-pedido',
  templateUrl: './alterar-pedido.component.html',
  styleUrls: ['./alterar-pedido.component.css']
})
export class AlterarPedidoComponent implements OnInit {
  pedidoSelecionado: Number | undefined;
  formulario: any;
  tituloFormulario: string = '';
  pedidos: Array<Pedido> | undefined;

  constructor(private pedidoService: PedidosService, private router: Router) { }
  ngOnInit(): void {
    this.tituloFormulario = 'Alterar Produto';

    this.pedidoService.listar().subscribe(pedidos => {
      this.pedidos = pedidos;
      if (this.pedidos && this.pedidos.length > 0) {
        this.pedidoSelecionado = this.pedidos[0].id;
        this.formulario.get('pedidoSelecionado')?.setValue(this.pedidos[0].id);
      }
    })
    this.formulario = new FormGroup({
      dataCriacao: new FormControl(null),
      funcionario: new FormControl(null),
      gerente: new FormControl(null),
      produto: new FormControl(null),
      qtde: new FormControl(null)
    })
  }

  selecionarPedido(event: any) {
    const selectedValue = event.target.value;
    if (selectedValue) {
      this.pedidoSelecionado = parseInt(selectedValue, 10);
    } else {
      console.log('Valor selecionado é inválido:', selectedValue);
    }
  }

  enviarFormulario() {
    // Verifique se um produto foi selecionado
    if (this.pedidoSelecionado === undefined || this.pedidoSelecionado === null) {
      alert('Nenhum pedido selecionado.');
      return;
    }

    // Recupere os detalhes do produto selecionado do seu serviço
    const pedidoSelecionado = this.pedidos?.find(pedido => pedido.id === this.pedidoSelecionado);

    if (!pedidoSelecionado) {
      alert('Produto selecionado não encontrado.');
      return;
    }

    pedidoSelecionado.dataCriacao = this.formulario.get('dataCriacao')?.value;
    pedidoSelecionado.funcionario = this.formulario.get('funcionario')?.value;
    pedidoSelecionado.gerente = this.formulario.get('gerente')?.value;
    pedidoSelecionado.produto = this.formulario.get('produto')?.value;
    pedidoSelecionado.qtde = this.formulario.get('qtde')?.value;

    const observer: Observer<Pedido> = {
      next(_result): void {
        alert('Pedido alterado com sucesso.');
      },
      error(error): void {
        console.log(error);
        alert('Erro ao alterar!');
      },
      complete(): void {
      },
    };

    // Atualize o produto no seu serviço
    this.pedidoService.alterar(pedidoSelecionado).subscribe(observer);
  }
  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}

