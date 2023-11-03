import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Filial } from 'src/app/models/Filial';
import { FiliaisService } from 'src/app/services/Filial/filiais.service';

@Component({
  selector: 'app-filiais',
  templateUrl: './filiais.component.html',
  styleUrls: ['./filiais.component.css']
})
export class FiliaisComponent implements OnInit{

  formulario: any;
  tituloFormulario: string = '';

  constructor(private filiaisService : FiliaisService) { }

  ngOnInit(): void {
    this.formulario = "Nova Filial";
    this.formulario = new FormGroup({
      cep: new FormControl(null),
      cidade: new FormControl(null),
      rua: new FormControl(null)
      });
  }

  enviarFormulario(): void {
    const filial : Filial = this.formulario.value;
    this.filiaisService.cadastrar(filial).subscribe(result => {
    alert('Filial inserida com sucesso.');
    })
    }
}
