import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cliente } from '../../../models/Cliente';
import { ClientesService } from '../../../services/clientes.service';

@Component({
  selector: 'app-listar-cliente',
  templateUrl: './listar-cliente.component.html',
  styleUrls: ['./listar-cliente.component.css']
})
export class ListarClienteComponent implements OnInit {
  clientes: Array<Cliente> = [];
  clientesPorId: Array<Cliente> = [];
  mostrarListagemGeral: boolean = false;
  idCliente: string = '';
  tituloFormulario = 'Listar Clientes';

  constructor(private clienteService: ClientesService, private router: Router) { }

  ngOnInit(): void {
    this.clienteService.listar().subscribe(clientes => {
      this.clientes = clientes;
    });
  }

  listarGeral() {
    this.mostrarListagemGeral = true;
    this.clientesPorId = [];
  }

  listarPorId() {
    if (this.idCliente.trim() === '') {
      this.listarGeral();
      return;
    }

    if (this.idCliente !== undefined) {
      this.clienteService.listarPorID(parseInt(this.idCliente)).subscribe(cliente => {
        this.clientesPorId = [cliente];
        this.mostrarListagemGeral = false;
      });
    } else {
      this.clientesPorId = [];
      this.mostrarListagemGeral = false;
    }
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}
