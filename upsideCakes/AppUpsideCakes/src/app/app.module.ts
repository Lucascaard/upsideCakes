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
import { AlterarGerentesComponent } from './components/gerenteComponent/alterar-gerentes/alterar-gerentes.component';
import { CadastrarGerentesComponent } from './components/gerenteComponent/cadastrar-gerentes/cadastrar-gerentes.component';
import { DeletarGerentesComponent } from './components/gerenteComponent/deletar-gerentes/deletar-gerentes.component';
import { ListarGerentesComponent } from './components/gerenteComponent/listar-gerentes/listar-gerentes.component';
import { AlterarPagamentosComponent } from './components/pagamentoComponent/alterar-pagamentos/alterar-pagamentos.component';
import { CadastrarPagamentosComponent } from './components/pagamentoComponent/cadastrar-pagamentos/cadastrar-pagamentos.component';
import { ListarPagamentosComponent } from './components/pagamentoComponent/listar-pagamentos/listar-pagamentos.component';
import { DeletarPagamentosComponent } from './components/pagamentoComponent/deletar-pagamentos/deletar-pagamentos.component';




@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AlterarProdutoComponent,
    ListarProdutosComponent,
    CadastrarProdutoComponent,
    DeletarProdutoComponent,
    AlterarGerentesComponent,
    CadastrarGerentesComponent,
    DeletarGerentesComponent,
    ListarGerentesComponent,
    AlterarPagamentosComponent,
    CadastrarPagamentosComponent,
    ListarPagamentosComponent,
    DeletarPagamentosComponent,
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
