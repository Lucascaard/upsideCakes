import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Funcionario } from '../../../models/Funcionario';
import { FuncionariosService } from '../../../services/funcionarios.service';
import { Router } from '@angular/router';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-deletar-funcionario',
  templateUrl: './deletar-funcionario.component.html',
  styleUrls: ['./deletar-funcionario.component.css']
})
export class DeletarFuncionarioComponent implements OnInit {
  

  funcionarioSelecionado: Number | undefined;
  formulario: FormGroup = new FormGroup({});
  tituloFormulario: string = '';
  funcionarios: Array<Funcionario> | undefined;

  constructor(private funcionarioService: FuncionariosService, private router: Router) { }
  ngOnInit(): void {
    this.tituloFormulario = 'Excluir Funcionario';

    this.carregarFuncionarios();

    this.formulario = new FormGroup({
      funcionarioSelecionado: new FormControl(null)
    })
  }

  carregarFuncionarios() {
    this.funcionarioService.listar().subscribe(funcionarios => {
      this.funcionarios = funcionarios;
      if (this.funcionarios && this.funcionarios.length > 0) {
        this.funcionarioSelecionado = this.funcionarios[0].id;
        this.formulario.get('funcionarioSelecionado')?.setValue(this.funcionarios[0].id);
      }
    });
  }

  selecionarFuncionario(event: any) {
    const selectedValue = event.target.value;
    if (selectedValue) {
      this.funcionarioSelecionado = parseInt(selectedValue, 10);
      console.log('Funcionario selecionado:', this.funcionarioSelecionado);
    } else {
      console.log('Valor selecionado é inválido:', selectedValue);
    }
  }

  enviarFormulario() {
    // Verifique se um funcionario foi selecionado
    if (this.funcionarioSelecionado === undefined || this.funcionarioSelecionado === null) {
      alert('Nenhum funcionario selecionado.');
      return;
    }

    const observer: Observer<Funcionario> = {
      next: (_result): void => {
        alert('Funcionario excluído com sucesso.');
        this.carregarFuncionarios(); // Atualiza a lista de funcionarios após a exclusão
      },
      error: (error): void => {
        console.log(error);
        alert('Erro ao excluir, consulte o Console!');
      },
      complete: (): void => {
      },
    };

    console.log(this.funcionarioSelecionado);
    this.funcionarioService.excluir(this.funcionarioSelecionado).subscribe(observer);
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }

}
