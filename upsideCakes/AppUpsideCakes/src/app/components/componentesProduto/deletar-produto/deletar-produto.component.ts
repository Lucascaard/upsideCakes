import { Component, OnInit } from '@angular/core';
import { Produto } from '../../../models/Produto';
import { ProdutosService } from '../../../services/produtos.service';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-deletar-produto',
  templateUrl: './deletar-produto.component.html',
  styleUrls: ['./deletar-produto.component.css']
})
export class DeletarProdutoComponent implements OnInit {
  produtoSelecionado: Number | undefined;
  formulario: FormGroup = new FormGroup({});
  tituloFormulario: string = 'Excluir Produto';
  produtos: Array<Produto> | undefined;

  constructor(private produtoService: ProdutosService, private router: Router) { }
  ngOnInit(): void {

    this.carregarProdutos();

    this.formulario = new FormGroup({
      produtoSelecionado: new FormControl(null)
    })
  }

  carregarProdutos() {
    this.produtoService.listar().subscribe(produtos => {
      this.produtos = produtos;
      if (this.produtos && this.produtos.length > 0) {
        this.produtoSelecionado = this.produtos[0].id;
        this.formulario.get('produtoSelecionado')?.setValue(this.produtos[0].id);
      }
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

  enviarFormulario() {
    // Verifique se um produto foi selecionado
    if (this.produtoSelecionado === undefined || this.produtoSelecionado === null) {
      alert('Nenhum produto selecionado.');
      return;
    }

    const observer: Observer<Produto> = {
      next: (_result): void => {
        alert('Produto excluído com sucesso.');
        this.carregarProdutos(); // Atualiza a lista de produtos após a exclusão
      },
      error: (error): void => {
        console.log(error);
        alert('Erro ao excluir, consulte o Console!');
      },
      complete: (): void => {
      },
    };

    // Excluir o produto no seu serviço
    this.produtoService.excluir(this.produtoSelecionado).subscribe(observer);
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }

}
