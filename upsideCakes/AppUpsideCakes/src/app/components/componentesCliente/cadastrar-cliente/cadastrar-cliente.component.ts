import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Router } from '@angular/router';
import { ClientesService } from '../../../services/clientes.service';
import { Cliente } from '../../../models/Cliente';

@Component({
  selector: 'app-cadastrar-cliente',
  templateUrl: './cadastrar-cliente.component.html',
  styleUrls: ['./cadastrar-cliente.component.css']
})
export class CadastrarClienteComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private clienteService: ClientesService, private router: Router) { }
  ngOnInit(): void {
    this.tituloFormulario = 'Novo Cliente';

    this.formulario = new FormGroup({
      nome: new FormControl(null),
      cpf: new FormControl(null),
      dataNasc: new FormControl(null),
      endereco: new FormControl(null),
      telefone: new FormControl(null),
      email: new FormControl(null),
    })
  }

  enviarFormulario(): void {
    const cliente: Cliente = this.formulario.value;
    console.log(cliente);
    const observer: Observer<Cliente> = {
      next(_result): void {
        alert('Cliente salvo com sucesso.');
      },
      error(error): void {
        console.log(error);
        alert('Erro ao salvar, consulte o Console');
      },
      complete(): void {
      },
    };
    this.clienteService.cadastrar(cliente).subscribe(observer);
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}
