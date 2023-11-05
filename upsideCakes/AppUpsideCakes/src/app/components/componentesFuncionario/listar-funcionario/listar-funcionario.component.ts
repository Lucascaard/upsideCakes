import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Funcionario } from '../../../models/Funcionario';
import { FuncionariosService } from '../../../services/funcionarios.service';

@Component({
  selector: 'app-listar-funcionario',
  templateUrl: './listar-funcionario.component.html',
  styleUrls: ['./listar-funcionario.component.css']
})
export class ListarFuncionarioComponent implements OnInit {

  funcionarios: Array<Funcionario> = [];
  funcionariosPorNome: Array<Funcionario> = [];
  mostrarListagemGeral: boolean = false;
  nomeFuncionario: string = '';
  tituloFormulario = '';
  opcoesNomes: Array<String> = [];

  constructor(private funcionarioService: FuncionariosService, private router: Router) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Listar Funcionarios';
    this.funcionarioService.listar().subscribe(funcionarios => {
      this.funcionarios = funcionarios;
      this.opcoesNomes = funcionarios.map(funcionario => funcionario.nome);
    });
  }

  listarGeral() {
    this.mostrarListagemGeral = true;
    this.funcionariosPorNome = [];
  }

  listarPorNome() {
    if (this.nomeFuncionario.trim() === '') {
      this.listarGeral();
      return;
    }

    const nomeSelecionado = this.nomeFuncionario;
    const funcionarioSelecionado = this.funcionarios.find(funcionario => funcionario.nome === nomeSelecionado);
    console.log(funcionarioSelecionado); // log 
    if (funcionarioSelecionado !== undefined) {
      this.funcionarioService.listarPorID(funcionarioSelecionado.id).subscribe(funcionario => {
        this.funcionariosPorNome = [funcionario];
        this.mostrarListagemGeral = false;
      });
    } else {
      this.funcionariosPorNome = [];
      this.mostrarListagemGeral = false;
    }
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}
