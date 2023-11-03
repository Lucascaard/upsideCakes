import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Filial } from 'src/app/models/Filial';
import { FiliaisService } from 'src/app/services/Filial/filiais.service';

@Component({
  selector: 'app-alterar-filial',
  templateUrl: './alterar-filial.component.html',
  styleUrls: ['./alterar-filial.component.css']
})
export class AlterarFilialComponent {

  formulario: any;
  tituloFormulario: string = '';

  constructor(private filiaisService : FiliaisService) { }

  ngOnInit(): void {
    this.tituloFormulario = "Alterar dados de Filial";
    this.formulario = new FormGroup({
      id: new FormControl(null),
      cep: new FormControl(null),
      cidade: new FormControl(null),
      rua: new FormControl(null)
      });
  }

  enviarFormulario(): void {
    const filial : Filial = this.formulario.value;
    this.filiaisService.alterar(filial).subscribe(result => {
    alert('Filial alterada com sucesso.');
    })
    }
}
