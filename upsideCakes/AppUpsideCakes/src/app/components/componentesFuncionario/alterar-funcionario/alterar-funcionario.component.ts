import { Component, OnInit } from '@angular/core';
import { Funcionario } from '../../../models/Funcionario';
import { FuncionariosService } from '../../../services/funcionarios.service';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-alterar-funcionario',
  templateUrl: './alterar-funcionario.component.html',
  styleUrls: ['./alterar-funcionario.component.css']
})
export class AlterarFuncionarioComponent implements OnInit {
  funcionarioSelecionado: Number | undefined;
  formulario: any;
  tituloFormulario: string = '';
  funcionarios: Array<Funcionario> | undefined;

  constructor(private funcionarioService: FuncionariosService, private router: Router) { }
  ngOnInit(): void {
    this.tituloFormulario = 'Alterar Produto';

    this.funcionarioService.listar().subscribe(funcionarios => {
      this.funcionarios = funcionarios;
      if (this.funcionarios && this.funcionarios.length > 0) {
        this.funcionarioSelecionado = this.funcionarios[0].id;
        this.formulario.get('funcionarioSelecionado')?.setValue(this.funcionarios[0].id);
      }
    })
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

  selecionarFuncionario(event: any) {
    const selectedValue = event.target.value;
    if (selectedValue) {
      this.funcionarioSelecionado = parseInt(selectedValue, 10);
    } else {
      console.log('Valor selecionado é inválido:', selectedValue);
    }
  }

  enviarFormulario() {
    // Verifique se um produto foi selecionado
    if (this.funcionarioSelecionado === undefined || this.funcionarioSelecionado === null) {
      alert('Nenhum funcionario selecionado.');
      return;
    }

    // Recupere os detalhes do produto selecionado do seu serviço
    const funcionarioSelecionado = this.funcionarios?.find(funcionario => funcionario.id === this.funcionarioSelecionado);

    if (!funcionarioSelecionado) {
      alert('Produto selecionado não encontrado.');
      return;
    }

    // Atualize os campos de preço e categoria do funcionario selecionado
    funcionarioSelecionado.nome = this.formulario.get('nome')?.value;
    funcionarioSelecionado.cpf = this.formulario.get('cpf')?.value;
    funcionarioSelecionado.dataNasc = this.formulario.get('dataNasc')?.value;
    funcionarioSelecionado.endereco = this.formulario.get('endereco')?.value;
    funcionarioSelecionado.telefone = this.formulario.get('telefone')?.value;
    funcionarioSelecionado.email = this.formulario.get('email')?.value;
    funcionarioSelecionado.login = this.formulario.get('login')?.value;
    funcionarioSelecionado.senha = this.formulario.get('senha')?.value;
    funcionarioSelecionado.cargo = this.formulario.get('cargo')?.value;

    const observer: Observer<Funcionario> = {
      next(_result): void {
        alert('Funcionario alterado com sucesso.');
      },
      error(error): void {
        console.log(error);
        alert('Erro ao alterar!');
      },
      complete(): void {
      },
    };

    // Atualize o produto no seu serviço
    this.funcionarioService.alterar(funcionarioSelecionado).subscribe(observer);
  }
  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}

