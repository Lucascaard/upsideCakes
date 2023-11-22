import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

// Imports componentes de Produto
import { CadastrarProdutoComponent } from './components/componentesProduto/cadastrar-produto/cadastrar-produto.component';
import { ListarProdutosComponent } from './components/componentesProduto/listar-produtos/listar-produtos.component';
import { DeletarProdutoComponent } from './components/componentesProduto/deletar-produto/deletar-produto.component';
import { AlterarProdutoComponent } from './components/componentesProduto/alterar-produto/alterar-produto.component';

// Imports componentes de Funcionário
import { CadastrarFuncionarioComponent } from './components/componentesFuncionario/cadastrar-funcionario/cadastrar-funcionario.component';
import { ListarFuncionarioComponent } from './components/componentesFuncionario/listar-funcionario/listar-funcionario.component';
import { AlterarFuncionarioComponent } from './components/componentesFuncionario/alterar-funcionario/alterar-funcionario.component';
import { DeletarFuncionarioComponent } from './components/componentesFuncionario/deletar-funcionario/deletar-funcionario.component';

//Imports components de Gerente
import { CadastrarGerenteComponent } from './components/componentesGerente/cadastrar-gerente/cadastrar-gerente.component';
import { ListarGerenteComponent } from './components/componentesGerente/listar-gerente/listar-gerente.component';
import { AlterarGerenteComponent } from './components/componentesGerente/alterar-gerente/alterar-gerente.component';
import { DeletarGerenteComponent } from './components/componentesGerente/deletar-gerente/deletar-gerente.component';

//Imports components de Pagamento
import { CadastrarPagamentoComponent } from './components/componentesPagamento/cadastrar-pagamento/cadastrar-pagamento.component';
import { AlterarPagamentoComponent } from './components/componentesPagamento/alterar-pagamento/alterar-pagamento.component';
import { DeletarPagamentoComponent } from './components/componentesPagamento/deletar-pagamento/deletar-pagamento.component';
import { ListarPagamentosComponent } from './components/componentesPagamento/listar-pagamento/listar-pagamento.component';
//Imports de componentes de Cliente
import { CadastrarClienteComponent } from './components/componentesCliente/cadastrar-cliente/cadastrar-cliente.component';
import { ListarClienteComponent } from './components/componentesCliente/listar-cliente/listar-cliente.component';
import { AlterarClienteComponent } from './components/componentesCliente/alterar-cliente/alterar-cliente.component';
import { DeletarClienteComponent } from './components/componentesCliente/deletar-cliente/deletar-cliente.component';

//Imports de componentes de Pedido
import { CadastrarPedidoComponent } from './components/componentesPedido/cadastrar-pedido/cadastrar-pedido.component';
import { ListarPedidoComponent } from './components/componentesPedido/listar-pedido/listar-pedido.component';
import { AlterarPedidoComponent } from './components/componentesPedido/alterar-pedido/alterar-pedido.component';
import { DeletarPedidoComponent } from './components/componentesPedido/deletar-pedido/deletar-pedido.component';
// Imports componentes de Filial
import {CadastrarFilialComponent } from './components/filiais/cadastrar-filial/cadastrar-filial.component';
import { AlterarFilialComponent } from './components/filiais/alterar-filial/alterar-filial.component';
import { ListarFilialComponent } from './components/filiais/listar-filial/listar-filial.component';
import { DeletarFilialComponent } from './components/filiais/deletar-filial/deletar-filial.component';
import { CadastrarCardapioComponent } from './components/cardapio/cadastrar-cardapio/cadastrar-cardapio.component';
import { AlterarCardapioComponent } from './components/cardapio/alterar-cardapio/alterar-cardapio.component';
import { ListarCardapioComponent } from './components/cardapio/listar-cardapio/listar-cardapio.component';
import { DeletarCardapioComponent } from './components/cardapio/deletar-cardapio/deletar-cardapio.component';
import { AddItemCardapioComponent } from './components/cardapio/add-item-cardapio/add-item-cardapio/add-item-cardapio.component';

const routes: Routes = [
  //Redirenciona a rota vazia '' para rota /home
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },

  //Rotas de produtos
  { path: 'produtos/cadastrar', component: CadastrarProdutoComponent },
  { path: 'produtos/listar', component: ListarProdutosComponent },
  { path: 'produtos/alterar', component: AlterarProdutoComponent },
  { path: 'produtos/deletar', component: DeletarProdutoComponent },

  //Rotas de pedido
  { path: 'pedido/cadastrar', component: CadastrarPedidoComponent },
  { path: 'pedido/listar', component: ListarPedidoComponent },
  { path: 'pedido/alterar', component: AlterarPedidoComponent },
  { path: 'pedido/deletar', component: DeletarPedidoComponent },

  //Rotas de funcionario
  { path: 'funcionario/cadastrar', component: CadastrarFuncionarioComponent },
  { path: 'funcionario/listar', component: ListarFuncionarioComponent },
  { path: 'funcionario/alterar', component: AlterarFuncionarioComponent },
  { path: 'funcionario/deletar', component: DeletarFuncionarioComponent },

  //Rotas de cliente
  { path: 'cliente/cadastrar', component: CadastrarClienteComponent },
  { path: 'cliente/listar', component: ListarClienteComponent },
  { path: 'cliente/alterar', component: AlterarClienteComponent },
  { path: 'cliente/deletar', component: DeletarClienteComponent },

  //Rotas de Gerente
  { path: 'gerente/cadastrar', component: CadastrarGerenteComponent },
  { path: 'gerente/listar', component: ListarGerenteComponent },
  { path: 'gerente/alterar', component: AlterarGerenteComponent },
  { path: 'gerente/deletar', component: DeletarGerenteComponent },
  
  //Rotas de Pagamento
  { path: 'pagamento/cadastrar', component: CadastrarPagamentoComponent },
  { path: 'pagamento/listar', component: ListarPagamentosComponent },
  { path: 'pagamento/alterar', component: AlterarPagamentoComponent },
  { path: 'pagamento/deletar', component: DeletarPagamentoComponent },

  // Rota de filiais
  { path: 'filial/cadastrar', component: CadastrarFilialComponent },
  { path: 'filial/alterar', component: AlterarFilialComponent },
  { path: 'filial/listar', component: ListarFilialComponent },
  { path: 'filial/excluir', component: DeletarFilialComponent },

  // Rota de cardapio
  { path: 'cardapio/cadastrar', component: CadastrarCardapioComponent },
  { path: 'cardapio/alterar', component: AlterarCardapioComponent },
  { path: 'cardapio/listar', component: ListarCardapioComponent },
  { path: 'cardapio/excluir', component: DeletarCardapioComponent },
  { path: 'cardapio/addItem', component: AddItemCardapioComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
