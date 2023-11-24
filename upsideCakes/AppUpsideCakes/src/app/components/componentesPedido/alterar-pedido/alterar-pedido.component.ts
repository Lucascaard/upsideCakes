import { Component, OnInit } from '@angular/core';
import { Pedido } from '../../../models/Pedido';
import { PedidosService } from '../../../services/pedidos.service';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Funcionario } from '../../../models/Funcionario';
import { Produto } from '../../../models/Produto';
import { Gerente } from '../../../models/Gerente';
import { FuncionariosService } from '../../../services/funcionarios.service';
import { GerentesService } from '../../../services/gerente.service';
import { ProdutosService } from '../../../services/produtos.service';

@Component({
  selector: 'app-alterar-pedido',
  templateUrl: './alterar-pedido.component.html',
  styleUrls: ['./alterar-pedido.component.css']
})
export class AlterarPedidoComponent implements OnInit {
  funcionarios: Array<Funcionario> = [];
  gerentes: Array<Gerente> = [];
  produtos: Array<Produto> = [];
  pedidos: Array<Pedido> = [];
  pedidoSelecionado: Number | undefined;
  formulario: any;
  tituloFormulario: string = 'Alterar Pedido';

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

    this.pedidoService.listar().subscribe(pedidos => {
      this.pedidos = pedidos;
      if (this.pedidos && this.pedidos.length > 0) {
        this.pedidoSelecionado = this.pedidos[0].id;
        this.formulario.get('pedidoSelecionado')?.setValue(this.pedidos[0].id);
      }
    })
    this.formulario = new FormGroup({
      funcionario: new FormControl(null),
      gerente: new FormControl(null),
      produto: new FormControl(null),
      qtde: new FormControl(null)
    })
  }

  selecionarPedido(event: any) {
    const selectedValue = event.target.value;
    if (selectedValue) {
      this.pedidoSelecionado = parseInt(selectedValue, 10);
    } else {
      console.log('Valor selecionado é inválido:', selectedValue);
    }
  }

  enviarFormulario() {
    // Verifique se um produto foi selecionado
    if (this.pedidoSelecionado === undefined || this.pedidoSelecionado === null) {
      alert('Nenhum pedido selecionado.');
      return;
    }

    // Recupere os detalhes do produto selecionado do seu serviço
    const objPedido = this.pedidos?.find(pedido => pedido.id === this.pedidoSelecionado);
    console.log(objPedido);

    if (!objPedido) {
      alert('Produto selecionado não encontrado.');
      return;
    }

    objPedido.funcionarioID = parseInt(this.formulario.get('funcionario')?.value);
    objPedido.gerenteID = parseInt(this.formulario.get('gerente')?.value);
    objPedido.produto = this.formulario.get('produto')?.value;
    objPedido.qtde = parseInt(this.formulario.get('qtde')?.value);
    const observer: Observer<Pedido> = {
      next(_result): void {
        alert('Pedido alterado com sucesso.');
      },
      error(error): void {
        console.log(error);
        alert('Erro ao alterar!');
      },
      complete(): void {
      },
    };

    // Atualize o produto no seu serviço
    this.pedidoService.alterar(objPedido).subscribe(observer);
  }
  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}

