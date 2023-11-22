import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Pagamento } from 'src/app/models/Pagamento';
import { Cliente } from 'src/app/models/Cliente';
import { Pedido } from 'src/app/models/Pedido';
import { Observer } from 'rxjs';
import { Router } from '@angular/router';
import { PagamentoService } from 'src/app/services/pagamento.service';
import { ClientesService } from '../../../services/clientes.service';

@Component({
  selector: 'app-cadastrar-pagamento',
  templateUrl: './cadastrar-pagamento.component.html',
  styleUrls: ['./cadastrar-pagamento.component.css']
})
export class CadastrarPagamentoComponent implements OnInit {
  opcoesPagamento: string[] = ['Dinheiro', 'Cartão de Débito', 'Cartão de Crédito', 'PIX'];
  formulario: any;
  clientes: Array<Cliente> = [];
  tituloFormulario: string = 'Novo Pagamento';

  constructor(
    private pagamentoService: PagamentoService,
    private router: Router,
    private clienteService: ClientesService) { }

  ngOnInit(): void {
    // Pegando a lista de clientes para montar a combo box
    this.clienteService.listar().subscribe(clientes => {
      this.clientes = clientes;
    });
  
    this.formulario = new FormGroup({
        data: new FormControl(null),
        nomeDoCliente: new FormControl(null),
        valor: new FormControl(null),
        formaDePagamento: new FormControl(null),
    })
  }
  
  enviarFormulario(): void {
    const pagamento: Pagamento = this.formulario.value;
    const observer: Observer<Pagamento> = {
      next(_result): void {
        alert('Pagamento salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar!');
      },
      complete(): void {
      },
    };
    this.pagamentoService.cadastrar(pagamento).subscribe(observer);
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}
