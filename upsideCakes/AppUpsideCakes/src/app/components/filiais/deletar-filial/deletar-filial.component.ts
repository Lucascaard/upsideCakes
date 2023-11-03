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
      idFilial: new FormControl()
      });
  }

  enviarFormulario(): void {
    const idFilial : Number = this.formulario.get('idFilial').value;
    this.filiaisService.excluir(idFilial).subscribe(result => {
    alert('Filial excluída com sucesso.');
    })
    }
}
