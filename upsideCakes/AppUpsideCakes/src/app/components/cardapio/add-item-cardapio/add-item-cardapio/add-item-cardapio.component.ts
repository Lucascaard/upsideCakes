import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Observer } from 'rxjs';
import { Cardapio } from 'src/app/models/Cardapio';
import { Produto } from 'src/app/models/Produto';
import { CardapiosService } from 'src/app/services/Cardapio/cardapios.service';
import { ProdutosService } from 'src/app/services/produtos.service';

@Component({
  selector: 'app-add-item-cardapio',
  templateUrl: './add-item-cardapio.component.html',
  styleUrls: ['./add-item-cardapio.component.css']
})
export class AddItemCardapioComponent {

  produtoSelecionado: Number | undefined;
  produtos: Array<Produto> | undefined;
  cardapioSelecionado: Number | undefined;
  cardapios: Array<Cardapio> | undefined;
  formulario: any;
  tituloFormulario: string = '';

  constructor(private cardapiosService: CardapiosService, private produtosService: ProdutosService, private router: Router) { }

  ngOnInit(): void {
    this.tituloFormulario = "Adicionar item ao cardápio";

    this.cardapiosService.listar().subscribe(cardapios => {
      this.cardapios = cardapios;
      if (this.cardapios && this.cardapios.length > 0) {
        this.cardapioSelecionado = this.cardapios[0].id;
        this.formulario.get('cardapioSelecionado')?.setValue(this.cardapios[0].id);
      }
    })

    this.produtosService.listar().subscribe(produtos => {
      this.produtos = produtos;
      if (this.produtos && this.produtos.length > 0) {
        this.produtoSelecionado = this.produtos[0].id;
        this.formulario.get('produtoSelecionado')?.setValue(this.produtos[0].id);
      }
    })

    this.formulario = new FormGroup({
      produtoSelecionado: new FormControl(null),
      cardapioSelecionado: new FormControl(null)
      });
  }

  selecionarProduto(event: any) {
    const selectedValue = event.target.value;
    if (selectedValue) {
      this.produtoSelecionado = parseInt(selectedValue, 10);
      console.log('Produto selecionado:', this.produtoSelecionado);
    } else {
      console.log('Valor selecionado é inválido:', selectedValue);
    }
  }

  selecionarCardapio(event: any) {
    const selectedValue = event.target.value;
    if (selectedValue) {
      this.cardapioSelecionado = parseInt(selectedValue, 10);
      console.log('Cardápio selecionado:', this.cardapioSelecionado);
    } else {
      console.log('Valor selecionado é inválido:', selectedValue);
    }
  }

  enviarFormulario(): void {
    if (!this.produtoSelecionado) {
      alert('Produto selecionado não encontrado.');
      return;
    }

    if (!this.cardapioSelecionado) {
      alert('Cardápio selecionado não encontrado.');
      return;
    }

    const produtoSelecionado = this.produtos?.find(produto => produto.id === this.produtoSelecionado);

    const cardapioSelecionado = this.cardapios?.find(cardapio => cardapio.id === this.cardapioSelecionado);

    if (!produtoSelecionado) {
      alert('Produto não encontrado.');
      return;
    }
  
    if (!cardapioSelecionado) {
      alert('Cardápio não encontrado.');
      return;
    }

    console.log(cardapioSelecionado);
    console.log(produtoSelecionado);

    this.cardapiosService.addItem(produtoSelecionado?.id, cardapioSelecionado?.id).subscribe(result => {
      alert('Item adicionado com sucesso.');
    });
  }

  voltarParaHome() {
    this.router.navigate(['/home']); 
  }
}
