import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Cardapio } from 'src/app/models/Cardapio';
import { CardapiosService } from 'src/app/services/Cardapio/cardapios.service';

@Component({
  selector: 'app-cadastrar-cardapio',
  templateUrl: './cadastrar-cardapio.component.html',
  styleUrls: ['./cadastrar-cardapio.component.css']
})
export class CadastrarCardapioComponent {

    formulario: any;
    tituloFormulario: string = '';

    constructor(private cardapiosService : CardapiosService) { }

    ngOnInit(): void {
      this.tituloFormulario = "Cadastrar Cardapio";
      this.formulario = new FormGroup({});
    }

    enviarFormulario(): void {
      // const cardapio : Cardapio = this.formulario.value;
      this.cardapiosService.cadastrar().subscribe(result => {
      alert('Cardápio criado com sucesso.');
      })
      }
}
