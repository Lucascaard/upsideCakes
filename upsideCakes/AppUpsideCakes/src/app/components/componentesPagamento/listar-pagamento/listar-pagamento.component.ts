import { Component, OnInit } from '@angular/core';
import { Pagamento } from '../../../models/Pagamento';
import { PagamentoService } from '../../../services/pagamento.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-listar-pagamento',
  templateUrl: './listar-pagamento.component.html',
  styleUrls: ['./listar-pagamento.component.css']
})


export class ListarPagamentosComponent implements OnInit {
  pagamentos: Array<Pagamento> = [];
  //pagamentosPorCliente: Array<Pagamento> = [];
  mostrarListagemGeral: boolean = false;
  nomeCliente: string = '';
  tituloFormulario = '';
  opcoesNomes: Array<String> = []; // Opções de nomes de clientes

  constructor(private pagamentoService: PagamentoService, private router: Router) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Listar Pagamentos';
    this.pagamentoService.listar().subscribe(pagamentos => {
      this.pagamentos = pagamentos;
      //this.opcoesNomes = pagamentos.map(pagamento => pagamento.cliente?.nome || '');
    });
  }

  listarGeral() {
    this.mostrarListagemGeral = true;
  }
/*
  listarPorCliente() {
    if (this.nomeCliente.trim() === '') {
      this.listarGeral();
      return;
    }

    const nomeSelecionado = this.nomeCliente;
    const pagamentosSelecionados = this.pagamentos.filter(pagamento => pagamento.cliente?.nome === nomeSelecionado);
    if (pagamentosSelecionados.length > 0) {
      this.pagamentosPorCliente = pagamentosSelecionados;
      this.mostrarListagemGeral = false;
    } else {
      this.pagamentosPorCliente = [];
      this.mostrarListagemGeral = false;
    }
  }
*/
  voltarParaHome() {
    this.router.navigate(['/home']);
  }

}
