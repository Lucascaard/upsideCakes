import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProdutosComponent } from './components/componentesProduto/produtos/produtos.component';
import { HomeComponent } from './components/home/home.component';
import { AlterarProdutoComponent } from './components/componentesProduto/alterar-produto/alterar-produto.component';

const routes: Routes = [
  //Redirenciona a rota vazia '' para rota /home
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },

  //Rotas de produtos
  { path: 'produtos', component: ProdutosComponent },
  { path: 'produtos/alterar/:id', component: AlterarProdutoComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
