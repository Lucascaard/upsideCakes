import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Gerente } from 'src/app/models/Gerente';
import { GerentesService } from 'src/app/services/gerente.service';

@Component({
  selector: 'app-listar-gerente',
  templateUrl: './listar-gerente.component.html',
  styleUrls: ['./listar-gerente.component.css']
})
export class ListarGerenteComponent implements OnInit {

  gerentes: Array<Gerente> = [];
  gerentesPorNome: Array<Gerente> = [];
  mostrarListagemGeral: boolean = false;
  nomeGerente: string = '';
  tituloFormulario = '';
  opcoesNomes: Array<String> = [];

  constructor(private gerenteService: GerentesService, private router: Router) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Listar Gerentes';
    this.gerenteService.listar().subscribe(gerentes => {
      this.gerentes = gerentes;
      this.opcoesNomes = gerentes.map(gerente => gerente.nome);
    });
  }

  listarGeral() {
    this.mostrarListagemGeral = true;
    this.gerentesPorNome = [];
  }
/*
  listarPorNome() {
    if (this.nomeGerente.trim() === '') {
      this.listarGeral();
      return;
    }

    const nomeSelecionado = this.nomeGerente;
    const gerenteSelecionado = this.gerentes.find(gerente => gerente.nome === nomeSelecionado);
    console.log(gerenteSelecionado); // log 
    if (gerenteSelecionado !== undefined) {
      this.gerenteService.listarPorID(gerenteSelecionado.id).subscribe(gerente => {
        this.gerentesPorNome = [gerente];
        this.mostrarListagemGeral = false;
      });
    } else {
      this.gerentesPorNome = [];
      this.mostrarListagemGeral = false;
    }
  }
*/
  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}
