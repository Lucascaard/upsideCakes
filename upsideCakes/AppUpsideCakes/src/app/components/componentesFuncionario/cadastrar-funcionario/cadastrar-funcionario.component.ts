import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Router } from '@angular/router';
import { FuncionariosService } from '../../../services/funcionarios.service';
import { Funcionario } from '../../../models/Funcionario';

@Component({
  selector: 'app-cadastrar-funcionario',
  templateUrl: './cadastrar-funcionario.component.html',
  styleUrls: ['./cadastrar-funcionario.component.css']
})
export class CadastrarFuncionarioComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private funcionarioService: FuncionariosService, private router: Router) { }
  ngOnInit(): void {
    this.tituloFormulario = 'Novo Funcionario';

    this.formulario = new FormGroup({
      nome: new FormControl(null),
      cpf: new FormControl(null),
      dataNasc: new FormControl(null),
      endereco: new FormControl(null),
      telefone: new FormControl(null),
      email: new FormControl(null),
      login: new FormControl(null),
      senha: new FormControl(null),
      cargo: new FormControl(null)
    })
  }

  enviarFormulario(): void {
    const funcionario: Funcionario = this.formulario.value;
    console.log(funcionario);
    const observer: Observer<Funcionario> = {
      next(_result): void {
        alert('Funcionario salvo com sucesso.');
      },
      error(error): void {
        console.log(error);
        alert('Erro ao salvar, consulte o Console');
      },
      complete(): void {
      },
    };
    this.funcionarioService.cadastrar(funcionario).subscribe(observer);
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}
