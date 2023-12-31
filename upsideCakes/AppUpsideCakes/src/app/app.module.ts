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
import { GerentesService } from './services/gerente.service';
import { ClientesService } from './services/clientes.service';
import { PagamentoService } from './services/pagamento.service';
import { PedidosService } from './services/pedidos.service';
import { HomeComponent } from './components/home/home.component';
import { AlterarProdutoComponent } from './components/componentesProduto/alterar-produto/alterar-produto.component';
import { ListarProdutosComponent } from './components/componentesProduto/listar-produtos/listar-produtos.component';
import { CadastrarProdutoComponent } from './components/componentesProduto/cadastrar-produto/cadastrar-produto.component';
import { DeletarProdutoComponent } from './components/componentesProduto/deletar-produto/deletar-produto.component';
import { CadastrarFuncionarioComponent } from './components/componentesFuncionario/cadastrar-funcionario/cadastrar-funcionario.component';
import { ListarFuncionarioComponent } from './components/componentesFuncionario/listar-funcionario/listar-funcionario.component';
import { AlterarFuncionarioComponent } from './components/componentesFuncionario/alterar-funcionario/alterar-funcionario.component';
import { DeletarFuncionarioComponent } from './components/componentesFuncionario/deletar-funcionario/deletar-funcionario.component';
import { AlterarGerenteComponent } from './components/componentesGerente/alterar-gerente/alterar-gerente.component';
import { CadastrarGerenteComponent } from './components/componentesGerente/cadastrar-gerente/cadastrar-gerente.component';
import { DeletarGerenteComponent } from './components/componentesGerente/deletar-gerente/deletar-gerente.component';
import { ListarGerenteComponent } from './components/componentesGerente/listar-gerente/listar-gerente.component';
import { AlterarPagamentoComponent } from './components/componentesPagamento/alterar-pagamento/alterar-pagamento.component';
import { CadastrarPagamentoComponent } from './components/componentesPagamento/cadastrar-pagamento/cadastrar-pagamento.component';
import { DeletarPagamentoComponent } from './components/componentesPagamento/deletar-pagamento/deletar-pagamento.component';
import { ListarPagamentosComponent } from './components/componentesPagamento/listar-pagamento/listar-pagamento.component';
import { CadastrarClienteComponent } from './components/componentesCliente/cadastrar-cliente/cadastrar-cliente.component';
import { ListarClienteComponent } from './components/componentesCliente/listar-cliente/listar-cliente.component';
import { AlterarClienteComponent } from './components/componentesCliente/alterar-cliente/alterar-cliente.component';
import { DeletarClienteComponent } from './components/componentesCliente/deletar-cliente/deletar-cliente.component';
import { CadastrarPedidoComponent } from './components/componentesPedido/cadastrar-pedido/cadastrar-pedido.component';
import { ListarPedidoComponent } from './components/componentesPedido/listar-pedido/listar-pedido.component';
import { AlterarPedidoComponent } from './components/componentesPedido/alterar-pedido/alterar-pedido.component';
import { DeletarPedidoComponent } from './components/componentesPedido/deletar-pedido/deletar-pedido.component';
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
    CadastrarFuncionarioComponent,
    ListarFuncionarioComponent,
    AlterarFuncionarioComponent,
    DeletarFuncionarioComponent,
    CadastrarClienteComponent,
    ListarClienteComponent,
    AlterarClienteComponent,
    DeletarClienteComponent,
    AlterarGerenteComponent,
    CadastrarGerenteComponent,
    DeletarGerenteComponent,
    ListarGerenteComponent,
    AlterarPagamentoComponent,
    CadastrarPagamentoComponent,
    ListarPagamentosComponent,
    DeletarPagamentoComponent,
    AlterarPedidoComponent,
    CadastrarPedidoComponent,
    DeletarPedidoComponent,
    ListarPedidoComponent,
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
    GerentesService,
    ClientesService,
    PagamentoService,
    PedidosService,
    FiliaisService,
    CardapiosService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
