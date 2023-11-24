import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Pedido } from '../../../models/Pedido';
import { PedidosService } from '../../../services/pedidos.service';
import { Router } from '@angular/router';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-deletar-pedido',
  templateUrl: './deletar-pedido.component.html',
  styleUrls: ['./deletar-pedido.component.css']
})
export class DeletarPedidoComponent implements OnInit {
  

  pedidoSelecionado: Number | undefined;
  formulario: FormGroup = new FormGroup({});
  tituloFormulario: string = 'Excluir Pedido';
  pedidos: Array<Pedido> | undefined;

  constructor(private pedidoService: PedidosService, private router: Router) { }
  ngOnInit(): void {

    this.carregarPedidos();

    this.formulario = new FormGroup({
      pedidoSelecionado: new FormControl(null)
    })
  }

  carregarPedidos() {
    this.pedidoService.listar().subscribe(pedidos => {
      this.pedidos = pedidos;
      if (this.pedidos && this.pedidos.length > 0) {
        this.pedidoSelecionado = this.pedidos[0].id;
        this.formulario.get('pedidoSelecionado')?.setValue(this.pedidos[0].id);
      }
    });
  }

  selecionarPedido(event: any) {
    const selectedValue = event.target.value;
    if (selectedValue) {
      this.pedidoSelecionado = parseInt(selectedValue, 10);
      console.log('Pedido selecionado:', this.pedidoSelecionado);
    } else {
      console.log('Valor selecionado é inválido:', selectedValue);
    }
  }

  enviarFormulario() {
    // Verifique se um pedido foi selecionado
    if (this.pedidoSelecionado === undefined || this.pedidoSelecionado === null) {
      alert('Nenhum pedido selecionado.');
      return;
    }

    console.log(this.pedidoSelecionado);

    const observer: Observer<Pedido> = {
      next: (_result): void => {
        alert('Pedido excluído com sucesso.');
        this.carregarPedidos(); // Atualiza a lista de pedidos após a exclusão
      },
      error: (error): void => {
        console.log(error);
        alert('Erro ao excluir, consulte o Console!');
      },
      complete: (): void => {
      },
    };

    this.pedidoService.excluir(this.pedidoSelecionado).subscribe(observer);
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }

}
