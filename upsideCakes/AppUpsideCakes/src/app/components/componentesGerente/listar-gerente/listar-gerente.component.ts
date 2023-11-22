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
  gerentesPorId: Array<Gerente> = [];
  mostrarListagemGeral: boolean = false;
  idGerente: string = '';
  tituloFormulario = 'Listar Gerentes';

  constructor(private gerenteService: GerentesService, private router: Router) { }

  ngOnInit(): void {
    this.gerenteService.listar().subscribe(gerentes => {
      this.gerentes = gerentes;
    });
  }

  listarGeral() {
    this.mostrarListagemGeral = true;
    this.gerentesPorId = [];
  }

  listarPorId() {
    if (this.idGerente.trim() === '') {
      this.listarGeral();
      return;
    }

    if (this.idGerente !== undefined) {
      this.gerenteService.buscarPorId(parseInt(this.idGerente)).subscribe(gerente => {
        this.gerentesPorId = [gerente];
        this.mostrarListagemGeral = false;
      });
    } else {
      this.gerentesPorId = [];
      this.mostrarListagemGeral = false;
    }
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}
