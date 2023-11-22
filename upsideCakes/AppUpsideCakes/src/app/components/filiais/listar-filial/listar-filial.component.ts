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

  formulario!: FormGroup;

  filiais: Array<Filial> = [];

  filialById: Filial | undefined;

  id: number = 0;

  showList: boolean = false;
  showListByID: boolean = false;
  tituloFormulario = '';

  ngOnInit(): void {
    this.tituloFormulario = 'Listar Filiais';
    this.filialService.listar().subscribe( filial =>{
      this.filiais = filial;
    });

    this.formulario = new FormGroup({
      id: new FormControl()
      });
  }

  listarGeral() {
    this.showList = true;
    this.showListByID = false;
  }

  listarPorID(): void {
    this.filialService.listarPorID(this.formulario.value.id).subscribe(filial => {
      this.filialById = filial;
    this.showListByID = true;
    this.showList = false;
    })
  };

  voltarParaHome() {
    this.router.navigate(['/home']); 
  }
}
