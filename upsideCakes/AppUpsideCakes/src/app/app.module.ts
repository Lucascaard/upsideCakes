import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule } from 'ngx-bootstrap/modal';
import { RouterModule } from '@angular/router';

import { ProdutosService } from './services/produtos.service';
import { GerentesService } from './services/gerentes.service';
import { PagamentosService } from './services/pagamentos.service';

import { HomeComponent } from './components/home/home.component';


import { AlterarProdutoComponent } from './components/componentesProduto/alterar-produto/alterar-produto.component';
import { ListarProdutosComponent } from './components/componentesProduto/listar-produtos/listar-produtos.component';
import { CadastrarProdutoComponent } from './components/componentesProduto/cadastrar-produto/cadastrar-produto.component';
import { DeletarProdutoComponent } from './components/componentesProduto/deletar-produto/deletar-produto.component';

import { CadastrarGerentesComponent } from './components/componentesGerente/cadastrar-gerente/cadastrar-gerente.component';
import { ListarGerentesComponent } from './components/componentesGerente/listar-gerentes/listar-gerentes.component';
import { DeletarGerenteComponent } from './components/componentesGerente/deletar-gerente/deletar-gerente.component';
import { AlterarGerenteComponent } from './components/componentesGerente/alterar-gerente/alterar-gerente.component';

/*
import { CadastrarPagamentosComponent } from './components/componentesPagamento/cadastrar-pagamento/cadastrar-pagamento.component';
import { ListarPagamentosComponent } from './components/componentesPagamento/listar-pagamentos/listar-pagamentos.component';
import { DeletarPagamentoComponent } from './components/componentesPagamento/deletar-pagamento/deletar-pagamento.component';
import { AlterarPagamentoComponent } from './components/componentesPagamento/alterar-pagamento/alterar-pagamento.component'; */





@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AlterarProdutoComponent,
    ListarProdutosComponent,
    CadastrarProdutoComponent,
    DeletarProdutoComponent,
    AlterarGerenteComponent,
    ListarGerentesComponent,
    CadastrarGerentesComponent,
    DeletarGerenteComponent
    /*,
    AlterarPagamentoComponent,
    ListarPagamentosComponent,
    CadastrarPagamentosComponent,
    DeletarPagamentoComponent
    */
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    ModalModule.forRoot()
  ],
  providers: [
    HttpClientModule,
    ProdutosService,
    GerentesService,
    PagamentosService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
