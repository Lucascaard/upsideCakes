import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Pagamento } from 'src/app/models/Pagamento';
import { Cliente } from 'src/app/models/Cliente';
import { Pedido } from 'src/app/models/Pedido';
import { Observer } from 'rxjs';
import { Router } from '@angular/router';
import { PagamentoService } from 'src/app/services/pagamento.service';
import { ClientesService } from 'src/app/services/clientes.service';
// import { PedidosService } from 'src/app/services/pedidos.service';

@Component({
  selector: 'app-cadastrar-pagamento',
  templateUrl: './cadastrar-pagamento.component.html',
  styleUrls: ['./cadastrar-pagamento.component.css']
})
export class CadastrarPagamentoComponent implements OnInit {
  formulario: any;
  clientes: Array<Cliente> | undefined;
  pedidos: Array<Pedido> | undefined;
  tituloFormulario: string = '';

  constructor(
    private clienteService: ClientesService,
   // private pedidoService: PedidosService,
    private pagamentoService: PagamentoService,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.formulario = new FormGroup({
      data: new FormControl(null),
      clientes: new FormControl(null),
      valor: new FormControl(null),
      formaDePagamento: new FormControl(null),
      pedidos: new FormControl(null)
    
    });

    // Carregar lista de clientes e pedidos do serviço
    this.clienteService.listar().subscribe(clientes => {
      this.clientes = clientes;
    });

   /* this.pedidoService.listar().subscribe(pedidos => {
      this.pedidos = pedidos;
    });*/
  }

  enviarFormulario() {
    const pagamento: Pagamento = {
      data: this.formulario.get('data')?.value,
      //clientes: this.formulario.get('clientes')?.value,
      valor: this.formulario.get('valor')?.value,
      formaDePagamento: this.formulario.get('formaDePagamento')?.value,
      //pedidos: this.formulario.get('pedidos')?.value
    };

    console.log(pagamento);

    const observer: Observer<Pagamento> = {
      next(_result): void {
        alert('Pagamento cadastrado com sucesso.');
      },
      error(error): void {
        console.log(error);
        alert('Erro ao cadastrar pagamento!');
      },
      complete(): void {
      },
    };

    // Chamar o serviço para cadastrar o pagamento
    this.pagamentoService.cadastrar(pagamento).subscribe(observer);
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}
