import { Component, OnInit } from '@angular/core';
import { Pagamento } from '../../../models/Pagamento';
import { PagamentoService } from '../../../services/pagamento.service';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-deletar-pagamento',
  templateUrl: './deletar-pagamento.component.html',
  styleUrls: ['./deletar-pagamento.component.css']
})
export class DeletarPagamentoComponent implements OnInit {
  pagamentoSelecionado: Number | undefined;
  formulario: FormGroup = new FormGroup({});
  tituloFormulario: string = 'Excluir Pagamento';
  pagamentos: Array<Pagamento> | undefined;

  constructor(private pagamentoService: PagamentoService, private router: Router) { }

  ngOnInit(): void {

    this.carregarPagamentos();

    this.formulario = new FormGroup({
      pagamentoSelecionado: new FormControl(null)
    })
  }

  carregarPagamentos() {
    this.pagamentoService.listar().subscribe(pagamentos => {
      this.pagamentos = pagamentos;
      if (this.pagamentos && this.pagamentos.length > 0) {
        this.pagamentoSelecionado = this.pagamentos[0].id;
        this.formulario.get('pagamentoSelecionado')?.setValue(this.pagamentos[0].id);
      }
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
    
    if (this.pagamentoSelecionado === undefined || this.pagamentoSelecionado === null) {
      alert('Nenhum pagamento selecionado.');
      return;
    }

    const observer: Observer<Pagamento> = {
      next: (_result): void => {
        alert('Pagamento excluído com sucesso.');
        this.carregarPagamentos(); 
      },
      error: (error): void => {
        console.log(error);
        alert('Erro ao excluir, consulte o Console!');
      },
      complete: (): void => {
      },
    };

    this.pagamentoService.excluir(this.pagamentoSelecionado).subscribe(observer);
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }

}
