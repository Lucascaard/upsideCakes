import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Router } from '@angular/router';
import { PedidosService } from '../../../services/pedidos.service';
import { Pedido } from '../../../models/Pedido';
import { Funcionario } from '../../../models/Funcionario';
import { FuncionariosService } from '../../../services/funcionarios.service';
import { GerentesService } from '../../../services/gerente.service';
import { Gerente } from '../../../models/Gerente';
import { ProdutosService } from '../../../services/produtos.service';
import { Produto } from '../../../models/Produto';

@Component({
  selector: 'app-cadastrar-pedido',
  templateUrl: './cadastrar-pedido.component.html',
  styleUrls: ['./cadastrar-pedido.component.css']
})
export class CadastrarPedidoComponent implements OnInit {
  funcionarios: Array<Funcionario> = [];
  gerentes: Array<Gerente> = [];
  produtos: Array<Produto> = [];
  formulario: any;
  formTratado: any;
  tituloFormulario: string = 'Novo Pedido';

  constructor(
    private pedidoService: PedidosService,
    private funcionarioService: FuncionariosService,
    private gerenteService: GerentesService,
    private produtoService: ProdutosService,
    private router: Router) { }

  ngOnInit(): void {

    //Obtem a lista de funcionarios
    this.funcionarioService.listar().subscribe(funcionarios => {
      this.funcionarios = funcionarios;
    });

    //Obtem a lista de funcionarios
    this.gerenteService.listar().subscribe(gerentes => {
      this.gerentes = gerentes;
    })

    //Obtem a lista de produtos
    this.produtoService.listar().subscribe(produtos => {
      this.produtos = produtos;
    })


    this.formulario = new FormGroup({
      dataCriacao: new FormControl(null),
      funcionario: new FormControl(null),
      gerente: new FormControl(null),
      produto: new FormControl(null),
      qtde: new FormControl(null),
    })

    this.formulario.funcionario = parseInt(this.formulario.funcionario);
    this.formulario.gerente = parseInt(this.formulario.gerente);
  }

  enviarFormulario(): void {
    const pedido: Pedido = this.formulario.value;
    console.log(pedido);
    const observer: Observer<Pedido> = {
      next(_result): void {
        alert('Pedido salvo com sucesso.');
      },
      error(error): void {
        console.log(error);
        alert('Erro ao salvar, consulte o Console');
      },
      complete(): void {
      },
    };
    this.pedidoService.cadastrar(pedido).subscribe(observer);
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}
