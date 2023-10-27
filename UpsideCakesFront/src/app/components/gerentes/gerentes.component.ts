import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { GerentesService } from 'src/app/gerentes.service';
import { Gerente } from 'src/app/Gerente';

@Component({
  selector: 'app-gerentes',
  templateUrl: './gerentes.component.html',
  styleUrls: ['./gerentes.component.css']
})
export class GerentesComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  
  constructor(private gerentesService : GerentesService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Gerente';
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      cpf: new FormControl(null),
      endereco: new FormControl(null),
      email: new FormControl(null),
      telefone: new FormControl(null),
      cargo: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const gerente : Gerente = this.formulario.value;
    this.gerentesService.cadastrar(gerente).subscribe(result => {
      alert('Gerente inserido com sucesso.');
    })
  } 
}
