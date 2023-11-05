import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';

// Imports componentes de Produto
import { CadastrarProdutoComponent } from './components/componentesProduto/cadastrar-produto/cadastrar-produto.component';
import { ListarProdutosComponent } from './components/componentesProduto/listar-produtos/listar-produtos.component';
import { DeletarProdutoComponent } from './components/componentesProduto/deletar-produto/deletar-produto.component';
import { AlterarProdutoComponent } from './components/componentesProduto/alterar-produto/alterar-produto.component';
import { CadastrarFuncionarioComponent } from './components/componentesFuncionario/cadastrar-funcionario/cadastrar-funcionario.component';
import { ListarFuncionarioComponent } from './components/componentesFuncionario/listar-funcionario/listar-funcionario.component';
import { AlterarFuncionarioComponent } from './components/componentesFuncionario/alterar-funcionario/alterar-funcionario.component';
import { DeletarFuncionarioComponent } from './components/componentesFuncionario/deletar-funcionario/deletar-funcionario.component';

const routes: Routes = [
  //Redirenciona a rota vazia '' para rota /home
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },

  //Rotas de produtos
  { path: 'produtos/cadastrar', component: CadastrarProdutoComponent },
  { path: 'produtos/listar', component: ListarProdutosComponent },
  { path: 'produtos/alterar', component: AlterarProdutoComponent },
  { path: 'produtos/deletar', component: DeletarProdutoComponent },

  //Rotas de funcionario
  { path: 'funcionario/cadastrar', component: CadastrarFuncionarioComponent },
  { path: 'funcionario/listar', component: ListarFuncionarioComponent },
  { path: 'funcionario/alterar', component: AlterarFuncionarioComponent },
  { path: 'funcionario/deletar', component: DeletarFuncionarioComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
