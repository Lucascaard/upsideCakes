import { Component, OnInit } from '@angular/core';
import { Produto } from '../../../models/Produto';
import { ProdutosService } from '../../../services/produtos.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-listar-produtos',
  templateUrl: './listar-produtos.component.html',
  styleUrls: ['./listar-produtos.component.css']
})
export class ListarProdutosComponent implements OnInit {
  produtos: Array<Produto> = [];
  produtosPorNome: Array<Produto> = [];
  mostrarListagemGeral: boolean = false;
  nomeProduto: string = '';
  tituloFormulario = '';
  opcoesNomes: Array<String> = []; // Opções de nomes de produtos

  constructor(private produtoService: ProdutosService, private router: Router) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Listar Produtos';
    this.produtoService.listar().subscribe(produtos => {
      this.produtos = produtos;
      this.opcoesNomes = produtos.map(produto => produto.nome);
    });
  }

  listarGeral() {
    this.mostrarListagemGeral = true;
    this.produtosPorNome = [];
  }

  listarPorNome() {
    if (this.nomeProduto.trim() === '') {
      this.listarGeral();
      return;
    }

    const nomeSelecionado = this.nomeProduto;
    const produtoSelecionado = this.produtos.find(produto => produto.nome === nomeSelecionado);
    if (produtoSelecionado !== undefined) {
      this.produtoService.listarPorID(produtoSelecionado.id).subscribe(produto => {
        this.produtosPorNome = [produto];
        this.mostrarListagemGeral = false;
      });
    } else {
      this.produtosPorNome = [];
      this.mostrarListagemGeral = false;
    }
  }

  voltarParaHome() {
    this.router.navigate(['/home']); 
  }
}
