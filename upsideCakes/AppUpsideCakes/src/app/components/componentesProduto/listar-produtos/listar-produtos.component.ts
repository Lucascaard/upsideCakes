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
  produtosPorId: Array<Produto> = [];
  mostrarListagemGeral: boolean = false;
  idProduto: string = '';
  tituloFormulario = 'Listar Produtos';

  constructor(private produtoService: ProdutosService, private router: Router) { }

  ngOnInit(): void {
    this.produtoService.listar().subscribe(produtos => {
      this.produtos = produtos;
    });
  }

  listarGeral() {
    this.mostrarListagemGeral = true;
    this.produtosPorId = [];
  }

  listarPorId() {
    if (this.idProduto.trim() === '') {
      this.listarGeral();
      return;
    }

    if (this.idProduto !== undefined) {
      this.produtoService.buscarPorId(parseInt(this.idProduto)).subscribe(produto => {
        this.produtosPorId = [produto];
        this.mostrarListagemGeral = false;
      });
    } else {
      this.produtosPorId = [];
      this.mostrarListagemGeral = false;
    }
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}
