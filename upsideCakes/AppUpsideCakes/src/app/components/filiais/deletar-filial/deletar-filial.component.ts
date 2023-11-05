import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Filial } from 'src/app/models/Filial';
import { FiliaisService } from 'src/app/services/Filial/filiais.service';

@Component({
  selector: 'app-deletar-filial',
  templateUrl: './deletar-filial.component.html',
  styleUrls: ['./deletar-filial.component.css']
})
export class DeletarFilialComponent {

  formulario: any;
  tituloFormulario: string = '';

  constructor(private filiaisService : FiliaisService) { }

  ngOnInit(): void {
    this.tituloFormulario = "Deletar Filial";

    this.formulario = new FormGroup({
      id: new FormControl()
      });
  }

  enviarFormulario(): void {
    const id : Number = Number(this.formulario.get('id').value);
    this.filiaisService.excluir(id).subscribe(result => {
    alert('Filial excluída com sucesso.');
    })
    }
}
