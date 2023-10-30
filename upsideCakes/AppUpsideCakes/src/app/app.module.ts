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
import { ProdutosComponent } from './components/componentesProduto/produtos/produtos.component';
import { HomeComponent } from './components/home/home.component';
import { AlterarProdutoComponent } from './components/componentesProduto/alterar-produto/alterar-produto.component';
import { GerentesComponent } from './components/gerente/gerentes/gerentes.component';
import { GerentesService} from './services/gerentes.service';
import { Gerente } from './models/Gerente';

@NgModule({
  declarations: [
    AppComponent,
    ProdutosComponent,
    HomeComponent,
    AlterarProdutoComponent,
    GerentesComponent
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
    GerentesService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
