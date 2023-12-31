import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ProdutosService } from 'src/app/services/produtos.service';
import { Produto } from 'src/app/models/Produto';
import { Observer } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastrar-produto',
  templateUrl: './cadastrar-produto.component.html',
  styleUrls: ['./cadastrar-produto.component.css']
})
export class CadastrarProdutoComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = 'Novo Produto';

  constructor(private produtoService: ProdutosService, private router: Router) { }
  ngOnInit(): void {

    this.formulario = new FormGroup({
      nome: new FormControl(null),
      preco: new FormControl(null),
      categoria: new FormControl(null)
    })
  }

  enviarFormulario(): void {
    const produto: Produto = this.formulario.value;
    const observer: Observer<Produto> = {
      next(_result): void {
        alert('Produto salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar!');
      },
      complete(): void {
      },
    };
    this.produtoService.cadastrar(produto).subscribe(observer);
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}
