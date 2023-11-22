import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Filial } from 'src/app/models/Filial';
import { FiliaisService } from 'src/app/services/Filial/filiais.service';

@Component({
  selector: 'app-cadastrar-filial',
  templateUrl: './cadastrar-filial.component.html',
  styleUrls: ['./cadastrar-filial.component.css']
})
export class CadastrarFilialComponent implements OnInit{

  formulario: any;
  tituloFormulario: string = '';

  constructor(private filiaisService : FiliaisService, private router: Router) { }

  ngOnInit(): void {
    this.tituloFormulario = "Cadastrar Filial";
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

    voltarParaHome() {
      this.router.navigate(['/home']); 
    }
}
