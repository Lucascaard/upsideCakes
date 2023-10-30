import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProdutosComponent } from './components/componentesProduto/produtos/produtos.component';
import { HomeComponent } from './components/home/home.component';
import { AlterarProdutoComponent } from './components/componentesProduto/alterar-produto/alterar-produto.component';
import { GerentesComponent } from './components/gerente/gerentes/gerentes.component';


const routes: Routes = [
  //Redirenciona a rota vazia '' para rota /home
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },

  //Rotas de produtos
  { path: 'produtos', component: ProdutosComponent },
  { path: 'produtos/alterar/:id', component: AlterarProdutoComponent },

  { path: 'gerentes', component: GerentesComponent}
  //{ path: 'gerentes/alterar/:id', component: AlterarGerentesComponent} 
  //descomentar quando criar as funções
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
