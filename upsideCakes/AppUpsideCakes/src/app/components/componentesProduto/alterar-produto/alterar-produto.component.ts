import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ProdutosService } from 'src/app/services/produtos.service';
import { Produto } from 'src/app/models/Produto';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-alterar-produto',
  templateUrl: './alterar-produto.component.html',
  styleUrls: ['./alterar-produto.component.css']
})
export class AlterarProdutoComponent implements OnInit {
  produtoSelecionado: Number | undefined;
  formulario: any;
  tituloFormulario: string = '';
  produtos: Array<Produto> | undefined;

  constructor(private produtoService: ProdutosService) { }
  ngOnInit(): void {
    this.tituloFormulario = 'Alterar Produto';

    this.produtoService.listar().subscribe(produtos => {
      this.produtos = produtos;

    })
    this.formulario = new FormGroup({
      preco: new FormControl(null),
      categoria: new FormControl(null)
    })
  }

  enviarFormulario() {
    // Verifique se um produto foi selecionado
    if (this.produtoSelecionado === undefined || this.produtoSelecionado === null) {
      alert('Nenhum produto selecionado.');
      return;
    }

    // Recupere os detalhes do produto selecionado do seu serviço
    const produtoSelecionado = this.produtos?.find(produto => produto.id === this.produtoSelecionado);

    if (!produtoSelecionado) {
      alert('Produto selecionado não encontrado.');
      return;
    }

    // Atualize os campos de preço e categoria do produto selecionado
    produtoSelecionado.preco = this.formulario.preco;
    produtoSelecionado.categoria = this.formulario.categoria;

    // Atualize o produto no seu serviço
    this.produtoService.alterar(produtoSelecionado).subscribe(() => {
      alert('Produto atualizado com sucesso.');
    }, error => {
      alert('Erro ao atualizar o produto: ' + error);
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
    console.log('Valor de event.target:', event.target);
  }

}
