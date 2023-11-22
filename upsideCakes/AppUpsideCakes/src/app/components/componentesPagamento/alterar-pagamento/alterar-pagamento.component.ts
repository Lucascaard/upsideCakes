import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { PagamentoService } from 'src/app/services/pagamento.service';
import { Pagamento } from 'src/app/models/Pagamento';
import { Cliente } from 'src/app/models/Cliente';
import { Pedido } from 'src/app/models/Pedido';
import { Observer } from 'rxjs';
import { Router } from '@angular/router';
import { ClientesService } from '../../../services/clientes.service';

@Component({
  selector: 'app-alterar-pagamento',
  templateUrl: './alterar-pagamento.component.html',
  styleUrls: ['./alterar-pagamento.component.css']
})
export class AlterarPagamentoComponent implements OnInit {
  opcoesPagamento: string[] = ['Dinheiro', 'Cartão de Débito', 'Cartão de Crédito', 'PIX'];
  pagamentoSelecionado: Number | undefined;
  formulario: any;
  tituloFormulario: string = 'Alterar Pagamento';
  pagamentos: Array<Pagamento> = [];
  clientes: Array<Cliente> = [];

  constructor(
    private pagamentoService: PagamentoService,
    private clienteService: ClientesService,
    private router: Router) { }

  ngOnInit(): void {

    // Obtem a lista de pagamentos para poder iterar sobre ela no html
    this.pagamentoService.listar().subscribe(pagamentos => {
      this.pagamentos = pagamentos;
    })

    // Obtem a lista de clientes para poder iterar sobre ela no html
    this.clienteService.listar().subscribe(clientes => {
      this.clientes = clientes;
    })

    this.formulario = new FormGroup({
      idPagamento: new FormControl(null),
      valor: new FormControl(null),
      formaDePagamento: new FormControl(null),
      nomeCliente: new FormControl(null)
    })
  }

  selecionarPagamento(event: any) {
    const selectedValue = event.target.value;
    if (selectedValue) {
      this.pagamentoSelecionado = parseInt(selectedValue, 10);
      console.log('Pagamento selecionado:', this.pagamentoSelecionado);
    } else {
      console.log('Valor selecionado é inválido:', selectedValue);
    }
  }

  enviarFormulario() {
    // ver se algum pagamento foi selecionado
    if (this.pagamentoSelecionado === undefined || this.pagamentoSelecionado === null) {
      alert('Nenhum pagamento selecionado.');
      return;
    }

    // detalhes do pagamento do seu service
    const pagamentoSelecionado = this.pagamentos?.find(pagamento => pagamento.id === this.pagamentoSelecionado);

    if (!pagamentoSelecionado) {
      alert('Pagamento selecionado não encontrado.');
      return;
    }

    // Atualizar o pagamento selecionado
    pagamentoSelecionado.valor = this.formulario.get('valor')?.value;
    pagamentoSelecionado.formaDePagamento = this.formulario.get('formaDePagamento')?.value;
    pagamentoSelecionado.nomeCliente = this.formulario.get('nomeCliente')?.value;

    /*
    // Recupere o cliente selecionado do seu serviço
    const clienteSelecionado = this.clientes?.find(cliente => cliente.id === this.formulario.get('clienteSelecionado')?.value);

    if (!clienteSelecionado) {
      alert('Cliente selecionado não encontrado.');
      return;
    }

    // Atualize o cliente do pagamento selecionado
    pagamentoSelecionado.cliente = clienteSelecionado;

    // Recupere o pedido selecionado do seu serviço
    const pedidoSelecionado = this.pedidos?.find(pedido => pedido.id === this.formulario.get('pedidoSelecionado')?.value);

    if (!pedidoSelecionado) {
      alert('Pedido selecionado não encontrado.');
      return;
    }

    // Atualize o pedido do pagamento selecionado
    pagamentoSelecionado.pedido = pedidoSelecionado;
*/
    console.log(pagamentoSelecionado);

    const observer: Observer<Pagamento> = {
      next(_result): void {
        alert('Pagamento alterado com sucesso.');
      },
      error(error): void {
        console.log(error);
        alert('Erro ao alterar!');
      },
      complete(): void {
      },
    };

    // Atualize o pagamento no service
    this.pagamentoService.alterar(pagamentoSelecionado).subscribe(observer);
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}

