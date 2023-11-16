import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Cliente } from '../../../models/Cliente';
import { ClientesService } from '../../../services/clientes.service';
import { Router } from '@angular/router';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-deletar-cliente',
  templateUrl: './deletar-cliente.component.html',
  styleUrls: ['./deletar-cliente.component.css']
})
export class DeletarClienteComponent implements OnInit {
  

  clienteSelecionado: Number | undefined;
  formulario: FormGroup = new FormGroup({});
  tituloFormulario: string = '';
  clientes: Array<Cliente> | undefined;

  constructor(private clienteService: ClientesService, private router: Router) { }
  ngOnInit(): void {
    this.tituloFormulario = 'Excluir Cliente';

    this.carregarClientes();

    this.formulario = new FormGroup({
      clienteSelecionado: new FormControl(null)
    })
  }

  carregarClientes() {
    this.clienteService.listar().subscribe(clientes => {
      this.clientes = clientes;
      if (this.clientes && this.clientes.length > 0) {
        this.clienteSelecionado = this.clientes[0].id;
        this.formulario.get('clienteSelecionado')?.setValue(this.clientes[0].id);
      }
    });
  }

  selecionarCliente(event: any) {
    const selectedValue = event.target.value;
    if (selectedValue) {
      this.clienteSelecionado = parseInt(selectedValue, 10);
      console.log('Cliente selecionado:', this.clienteSelecionado);
    } else {
      console.log('Valor selecionado é inválido:', selectedValue);
    }
  }

  enviarFormulario() {
    // Verifique se um cliente foi selecionado
    if (this.clienteSelecionado === undefined || this.clienteSelecionado === null) {
      alert('Nenhum cliente selecionado.');
      return;
    }

    const observer: Observer<Cliente> = {
      next: (_result): void => {
        alert('Cliente excluído com sucesso.');
        this.carregarClientes(); // Atualiza a lista de clientes após a exclusão
      },
      error: (error): void => {
        console.log(error);
        alert('Erro ao excluir, consulte o Console!');
      },
      complete: (): void => {
      },
    };

    console.log(this.clienteSelecionado);
    this.clienteService.excluir(this.clienteSelecionado).subscribe(observer);
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }

}
