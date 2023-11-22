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
  funcSelecionado: Array<Funcionario> = [];
  mostrarListagemGeral: boolean = false;
  idFuncionario: string = '';
  tituloFormulario = 'Listar Funcionarios';

  constructor(private funcionarioService: FuncionariosService, private router: Router) { }

  ngOnInit(): void {

    //Obtem a lista de funcionarios
    this.funcionarioService.listar().subscribe(funcionarios => {
      this.funcionarios = funcionarios;
    });
  }

  listarGeral() {
    this.mostrarListagemGeral = true;
    this.funcSelecionado = [];
  }

  listarPorId() {
    if (this.idFuncionario.trim() === '') { // verifica se idFuncionario esta vazia
      this.listarGeral();
      return;
    }
    if (this.idFuncionario !== undefined) {
      this.funcionarioService.BuscarPorId(parseInt(this.idFuncionario)).subscribe(funcionario => {
        this.funcSelecionado = [funcionario]; //recebe o funcionario selecionado do back
        this.mostrarListagemGeral = false;
      });
    } else {
      this.funcSelecionado = [];
      this.mostrarListagemGeral = false;
    }
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}
