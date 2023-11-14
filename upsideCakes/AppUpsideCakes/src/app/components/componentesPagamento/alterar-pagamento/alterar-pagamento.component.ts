import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { PagamentoService } from 'src/app/services/pagamento.service';
import { Pagamento } from 'src/app/models/Pagamento';
import { Cliente } from 'src/app/models/Cliente';
import { Pedido } from 'src/app/models/Pedido';
import { Observer } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-alterar-pagamento',
  templateUrl: './alterar-pagamento.component.html',
  styleUrls: ['./alterar-pagamento.component.css']
})
export class AlterarPagamentoComponent implements OnInit {
  pagamentoSelecionado: Number | undefined;
  formulario: any;
  tituloFormulario: string = '';
  pagamentos: Array<Pagamento> | undefined;
  clientes: Array<Cliente> | undefined;
  pedidos: Array<Pedido> | undefined;

  constructor(private pagamentoService: PagamentoService, private router: Router) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Alterar Pagamento';

    this.pagamentoService.listar().subscribe(pagamentos => {
      this.pagamentos = pagamentos;
      if (this.pagamentos && this.pagamentos.length > 0) {
        this.pagamentoSelecionado = this.pagamentos[0].id;
        this.formulario.get('pagamentoSelecionado')?.setValue(this.pagamentos[0].id);
      }
    });

    // Recupere a lista de clientes do seu serviço
    this.clienteService.listar().subscribe(clientes => {
      this.clientes = clientes;
    });

    // Recupere a lista de pedidos do seu serviço
    this.pedidoService.listar().subscribe(pedidos => {
      this.pedidos = pedidos;
    });

    this.formulario = new FormGroup({
      valor: new FormControl(null),
      formaDePagamento: new FormControl(null),
      clienteSelecionado: new FormControl(null),
      pedidoSelecionado: new FormControl(null),
      pagamentoSelecionado: new FormControl(null)
    });
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
    // Verifique se um pagamento foi selecionado
    if (this.pagamentoSelecionado === undefined || this.pagamentoSelecionado === null) {
      alert('Nenhum pagamento selecionado.');
      return;
    }

    // Recupere os detalhes do pagamento selecionado do seu serviço
    const pagamentoSelecionado = this.pagamentos?.find(pagamento => pagamento.id === this.pagamentoSelecionado);

    if (!pagamentoSelecionado) {
      alert('Pagamento selecionado não encontrado.');
      return;
    }

    // Atualize os campos de valor e forma de pagamento do pagamento selecionado
    pagamentoSelecionado.valor = this.formulario.get('valor')?.value;
    pagamentoSelecionado.formaDePagamento = this.formulario.get('formaDePagamento')?.value;

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

    // Atualize o pagamento no seu serviço
    this.pagamentoService.alterar(pagamentoSelecionado).subscribe(observer);
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}

