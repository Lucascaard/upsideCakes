import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Router } from '@angular/router';
import { Gerente } from 'src/app/models/Gerente';
import { GerentesService } from 'src/app/services/gerente.service';

@Component({
  selector: 'app-cadastrar-gerente',
  templateUrl: './cadastrar-gerente.component.html',
  styleUrls: ['./cadastrar-gerente.component.css']
})

export class CadastrarGerenteComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private gerenteService: GerentesService, private router: Router) { }
  ngOnInit(): void {
    this.tituloFormulario = 'Novo Gerente';

    this.formulario = new FormGroup({
      nome: new FormControl(null),
      cpf: new FormControl(null),
      dataNasc: new FormControl(null),
      endereco: new FormControl(null),
      telefone: new FormControl(null),
      email: new FormControl(null),
      login: new FormControl(null),
      senha: new FormControl(null),
      cargo: new FormControl(null)
    })
  }

  enviarFormulario(): void {
    const gerente: Gerente = this.formulario.value;
    console.log(gerente);
    const observer: Observer<Gerente> = {
      next(_result): void {
        alert('Gerente salvo com sucesso.');
      },
      error(error): void {
        console.log(error);
        alert('Erro ao salvar gerente, consulte o Console');
      },
      complete(): void {
      },
    };
    this.gerenteService.cadastrar(gerente).subscribe(observer);
  }

  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}

