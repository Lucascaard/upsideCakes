import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Cardapio } from 'src/app/models/Cardapio';
import { CardapiosService } from 'src/app/services/Cardapio/cardapios.service';

@Component({
  selector: 'app-alterar-cardapio',
  templateUrl: './alterar-cardapio.component.html',
  styleUrls: ['./alterar-cardapio.component.css']
})
export class AlterarCardapioComponent {

  formulario: any;
  tituloFormulario: string = '';

  constructor(private cardapiosService : CardapiosService, private router : Router) { }

  ngOnInit(): void {
    this.tituloFormulario = "Alterar dados de Cardápio";
    this.formulario = new FormGroup({
      idCardapio: new FormControl(null),
      idProduto: new FormControl(null),
      nome: new FormControl(null),
      preco: new FormControl(null),
      categoria: new FormControl(null)
      });
  }

  enviarFormulario(): void {
    const idCardapio: number = this.formulario.get('idCardapio')?.value;
    const idProduto: number = this.formulario.get('idProduto')?.value;
  
    // Agora, você pode criar o objeto Cardapio com os valores do formulário
    const cardapio: Cardapio = {
      id: idCardapio,
      nome: 'a',
      // Outros campos do cardápio, se houver
      itens: [
        // Adicione o objeto Produto ao array de itens
        {
          id: idProduto,
          nome: this.formulario.get('nome')?.value,
          preco: this.formulario.get('preco')?.value,
          categoria: this.formulario.get('categoria')?.value,
          // Outros campos do produto, se houver
        },
      ],
    };
  
    this.cardapiosService.alterar(idProduto, idCardapio).subscribe(result => {
      alert('Cardápio alterado com sucesso.');
    });
  }

  voltarParaHome() {
    this.router.navigate(['/home']); 
  }
}
