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
import { HomeComponent } from './components/home/home.component';
import { AlterarProdutoComponent } from './components/componentesProduto/alterar-produto/alterar-produto.component';
import { ListarProdutosComponent } from './components/componentesProduto/listar-produtos/listar-produtos.component';
import { CadastrarProdutoComponent } from './components/componentesProduto/cadastrar-produto/cadastrar-produto.component';
import { DeletarProdutoComponent } from './components/componentesProduto/deletar-produto/deletar-produto.component';

// Filial
import { FiliaisService } from './services/Filial/filiais.service';
import { CadastrarFilialComponent } from './components/filiais/cadastrar-filial/cadastrar-filial.component';
import { AlterarFilialComponent } from './components/filiais/alterar-filial/alterar-filial.component';
import { ListarFilialComponent } from './components/filiais/listar-filial/listar-filial.component';
import { DeletarFilialComponent } from './components/filiais/deletar-filial/deletar-filial.component';

//Cardapio
import { CardapiosService } from './services/Cardapio/cardapios.service';
import { AlterarCardapioComponent } from './components/cardapio/alterar-cardapio/alterar-cardapio.component';
import { CadastrarCardapioComponent } from './components/cardapio/cadastrar-cardapio/cadastrar-cardapio.component';
import { ListarCardapioComponent } from './components/cardapio/listar-cardapio/listar-cardapio.component';
import { DeletarCardapioComponent } from './components/cardapio/deletar-cardapio/deletar-cardapio.component';
import { AddItemCardapioComponent } from './components/cardapio/add-item-cardapio/add-item-cardapio/add-item-cardapio.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AlterarProdutoComponent,
    ListarProdutosComponent,
    CadastrarProdutoComponent,
    DeletarProdutoComponent,
    CadastrarFilialComponent,
    AlterarFilialComponent,
    ListarFilialComponent,
    DeletarFilialComponent,
    AlterarCardapioComponent,
    CadastrarCardapioComponent,
    ListarCardapioComponent,
    DeletarCardapioComponent,
    AddItemCardapioComponent
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
    FiliaisService,
    CardapiosService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
