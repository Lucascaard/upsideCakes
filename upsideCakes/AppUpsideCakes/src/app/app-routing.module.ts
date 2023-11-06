import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

// Imports componentes de Produto
import { CadastrarProdutoComponent } from './components/componentesProduto/cadastrar-produto/cadastrar-produto.component';
import { ListarProdutosComponent } from './components/componentesProduto/listar-produtos/listar-produtos.component';
import { DeletarProdutoComponent } from './components/componentesProduto/deletar-produto/deletar-produto.component';
import { AlterarProdutoComponent } from './components/componentesProduto/alterar-produto/alterar-produto.component';

//Imports componentes de Gerente
import { CadastrarGerentesComponent } from './components/componentesGerente/cadastrar-gerente/cadastrar-gerente.component';
import { ListarGerentesComponent } from './components/componentesGerente/listar-gerentes/listar-gerentes.component';
import { DeletarGerenteComponent } from './components/componentesGerente/deletar-gerente/deletar-gerente.component';
import { AlterarGerenteComponent } from './components/componentesGerente/alterar-gerente/alterar-gerente.component';

//Imports componentes de Pagamento
/*
import { CadastrarPagamentosComponent } from './components/componentesPagamento/cadastrar-pagamento/cadastrar-pagamento.component';
import { ListarPagamentosComponent } from './components/componentesPagamento/listar-pagamentos/listar-pagamentos.component';
import { DeletarPagamentoComponent } from './components/componentesPagamento/deletar-pagamento/deletar-pagamento.component';
import { AlterarPagamentoComponent } from './components/componentesPagamento/alterar-pagamento/alterar-pagamento.component';
*/

const routes: Routes = [
  //Redirenciona a rota vazia '' para rota /home
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },

  //Rotas de produtos
  { path: 'produtos/cadastrar', component: CadastrarProdutoComponent },
  { path: 'produtos/listar', component: ListarProdutosComponent },
  { path: 'produtos/alterar', component: AlterarProdutoComponent },
  { path: 'produtos/deletar', component: DeletarProdutoComponent },

  //Rotas de Gerentes
  { path: 'gerente/cadastrar', component: CadastrarGerentesComponent },
  { path: 'gerente/listar', component: ListarGerentesComponent },
  { path: 'gerente/alterar', component: AlterarGerenteComponent },
  { path: 'gerente/deletar', component: DeletarGerenteComponent },

 //Rotas de Pagamento 
 /*
  { path: 'pagamento/cadastrar', component: CadastrarPagamentosComponent },
  { path: 'pagamento/listar', component: ListarPagamentosComponent },
  { path: 'pagamento/alterar', component: AlterarPagamentoComponent },
  { path: 'pagamento/deletar', component: DeletarPagamentoComponent },
 */
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
