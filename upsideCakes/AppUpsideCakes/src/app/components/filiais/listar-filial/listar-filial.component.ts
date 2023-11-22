import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Filial } from 'src/app/models/Filial';
import { FiliaisService } from 'src/app/services/Filial/filiais.service';

@Component({
  selector: 'app-listar-filial',
  templateUrl: './listar-filial.component.html',
  styleUrls: ['./listar-filial.component.css']
})
export class ListarFilialComponent {

  constructor(private filialService: FiliaisService, private router: Router) { }

  filiais: Array<Filial> = [];
  filialByID: Array<Filial> = [];
  showList: boolean = false;
  idFilial: string = '';
  tituloFormulario = 'Listar Filiais';

  ngOnInit(): void {
    this.filialService.listar().subscribe(filiais => {
      this.filiais = filiais;
    });
  }

  listarGeral() {
    this.showList = true;
    this.filialByID = [];
  }

  listarPorId() {
    if (this.idFilial.trim() === '') {
      this.listarGeral();
      return;
    }

    if (this.idFilial !== undefined) {
      this.filialService.buscarPorID(parseInt(this.idFilial)).subscribe(filial => {
        this.filialByID = [filial];
        this.showList = false;
      });
    } else {
      this.filialByID = [];
      this.showList = false;
    }
  }

  voltarParaHome() {
    this.router.navigate(['/home']); 
  }
}
