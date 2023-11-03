import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ProdutosService } from 'src/app/services/produtos.service';
import { Produto } from 'src/app/models/Produto';
import { Observer } from 'rxjs';
import { Router } from '@angular/router';

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

  constructor(private produtoService: ProdutosService, private router: Router) { }
  ngOnInit(): void {
    this.tituloFormulario = 'Alterar Produto';

    this.produtoService.listar().subscribe(produtos => {
      this.produtos = produtos;
      if (this.produtos && this.produtos.length > 0) {
        this.produtoSelecionado = this.produtos[0].id;
        this.formulario.get('produtoSelecionado')?.setValue(this.produtos[0].id);
      }
    })
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      preco: new FormControl(null),
      categoria: new FormControl(null),
      produtoSelecionado: new FormControl(null)
    })
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
    produtoSelecionado.nome = this.formulario.get('nome')?.value;
    produtoSelecionado.preco = this.formulario.get('preco')?.value;
    produtoSelecionado.categoria = this.formulario.get('categoria')?.value;
    console.log(produtoSelecionado);

    const observer: Observer<Produto> = {
      next(_result): void {
        alert('Produto alterado com sucesso.');
      },
      error(error): void {
        console.log(error);
        alert('Erro ao alterar!');
      },
      complete(): void {
      },
    };
 
    // Atualize o produto no seu serviço
    this.produtoService.alterar(produtoSelecionado).subscribe(observer);
  }
  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}
