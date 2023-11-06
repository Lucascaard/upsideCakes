import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Gerente } from 'src/app/models/Gerente';
import { GerentesService } from 'src/app/services/gerentes.service';

@Component({
  selector: 'app-listar-gerentes',
  templateUrl: './listar-gerentes.component.html',
  styleUrls: ['./listar-gerentes.component.css']
})
export class ListarGerentesComponent implements OnInit {

  gerentes: Array<Gerente> = [];
  gerentesPorNome: Array<Gerente> = [];
  mostrarListagemGeral: boolean = false;
  nomeGerente: string = '';
  tituloFormulario = '';
  opcoesNomes: Array<String> = []; // Opções de nomes de gerentes

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

  voltarParaHome() {
    this.router.navigate(['/home']); 
  }


}
