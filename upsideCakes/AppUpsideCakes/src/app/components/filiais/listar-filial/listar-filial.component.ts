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
  showList: boolean = false;
  tituloFormulario = '';

  ngOnInit(): void {
    this.tituloFormulario = 'Listar Filiais';
    this.filialService.listar().subscribe( filial =>{
      this.filiais = filial;
    })
  }

  listarGeral() {
    this.showList = true;
  }

  voltarParaHome() {
    this.router.navigate(['/home']); 
  }
}
