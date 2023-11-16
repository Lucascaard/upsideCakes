import { Component, OnInit } from '@angular/core';
import { Cliente } from '../../../models/Cliente';
import { ClientesService } from '../../../services/clientes.service';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-alterar-cliente',
  templateUrl: './alterar-cliente.component.html',
  styleUrls: ['./alterar-cliente.component.css']
})
export class AlterarClienteComponent implements OnInit {
  clienteSelecionado: Number | undefined;
  formulario: any;
  tituloFormulario: string = '';
  clientes: Array<Cliente> | undefined;

  constructor(private clienteService: ClientesService, private router: Router) { }
  ngOnInit(): void {
    this.tituloFormulario = 'Alterar Produto';

    this.clienteService.listar().subscribe(clientes => {
      this.clientes = clientes;
      if (this.clientes && this.clientes.length > 0) {
        this.clienteSelecionado = this.clientes[0].id;
        this.formulario.get('clienteSelecionado')?.setValue(this.clientes[0].id);
      }
    })
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      cpf: new FormControl(null),
      dataNasc: new FormControl(null),
      endereco: new FormControl(null),
      telefone: new FormControl(null),
      email: new FormControl(null),
    })
  }

  selecionarCliente(event: any) {
    const selectedValue = event.target.value;
    if (selectedValue) {
      this.clienteSelecionado = parseInt(selectedValue, 10);
    } else {
      console.log('Valor selecionado é inválido:', selectedValue);
    }
  }

  enviarFormulario() {
    // Verifique se um produto foi selecionado
    if (this.clienteSelecionado === undefined || this.clienteSelecionado === null) {
      alert('Nenhum cliente selecionado.');
      return;
    }

    // Recupere os detalhes do produto selecionado do seu serviço
    const clienteSelecionado = this.clientes?.find(cliente => cliente.id === this.clienteSelecionado);

    if (!clienteSelecionado) {
      alert('Produto selecionado não encontrado.');
      return;
    }

    // Atualize os campos de preço e categoria do cliente selecionado
    clienteSelecionado.nome = this.formulario.get('nome')?.value;
    clienteSelecionado.cpf = this.formulario.get('cpf')?.value;
    clienteSelecionado.dataNasc = this.formulario.get('dataNasc')?.value;
    clienteSelecionado.endereco = this.formulario.get('endereco')?.value;
    clienteSelecionado.telefone = this.formulario.get('telefone')?.value;
    clienteSelecionado.email = this.formulario.get('email')?.value;

    const observer: Observer<Cliente> = {
      next(_result): void {
        alert('Cliente alterado com sucesso.');
      },
      error(error): void {
        console.log(error);
        alert('Erro ao alterar!');
      },
      complete(): void {
      },
    };

    // Atualize o produto no seu serviço
    this.clienteService.alterar(clienteSelecionado).subscribe(observer);
  }
  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}

