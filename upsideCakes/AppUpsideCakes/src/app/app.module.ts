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
import { FiliaisComponent } from './components/filiais/filiais.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AlterarProdutoComponent,
    ListarProdutosComponent,
    CadastrarProdutoComponent,
    DeletarProdutoComponent,
    FiliaisComponent
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
    FiliaisService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
