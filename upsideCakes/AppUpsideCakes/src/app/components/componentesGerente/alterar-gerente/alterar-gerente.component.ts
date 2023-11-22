import { Gerente } from 'src/app/models/Gerente';
import { GerentesService } from 'src/app/services/gerente.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-alterar-gerente',
  templateUrl: './alterar-gerente.component.html',
  styleUrls: ['./alterar-gerente.component.css']
})
export class AlterarGerenteComponent implements OnInit {
  gerenteSelecionado: Number | undefined;
  formulario: any;
  tituloFormulario: string = '';
  gerentes: Array<Gerente> | undefined;

  constructor(private gerenteService: GerentesService, private router: Router) { }
  ngOnInit(): void {
    this.tituloFormulario = 'Alterar Gerente!';

    this.gerenteService.listar().subscribe(gerentes => {
      this.gerentes = gerentes;
      if (this.gerentes && this.gerentes.length > 0) {
        this.gerenteSelecionado = this.gerentes[0].id;
        this.formulario.get('gerenteSelecionado')?.setValue(this.gerentes[0].id);
      }
    })
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

  selecionarGerente(event: any) {
    const selectedValue = event.target.value;
    if (selectedValue) {
      this.gerenteSelecionado = parseInt(selectedValue, 10);
    } else {
      console.log('Valor selecionado é inválido:', selectedValue);
    }
  }

  enviarFormulario() {
    // Verificar se o gerente foi selecionado corretamente
    if (this.gerenteSelecionado === undefined || this.gerenteSelecionado === null) {
      alert('Nenhum gerente foi selecionado.');
      return;
    }

    // Recupere os detalhes do gerente selecionado do seu service
    const gerenteSelecionado = this.gerentes?.find(gerente => gerente.id === this.gerenteSelecionado);

    if (!gerenteSelecionado) {
      alert('Gerente selecionado não encontrado.');
      return;
    }

    // Atualize os campos 
    gerenteSelecionado.nome = this.formulario.get('nome')?.value;
    gerenteSelecionado.cpf = this.formulario.get('cpf')?.value;
    gerenteSelecionado.dataNasc = this.formulario.get('dataNasc')?.value;
    gerenteSelecionado.endereco = this.formulario.get('endereco')?.value;
    gerenteSelecionado.telefone = this.formulario.get('telefone')?.value;
    gerenteSelecionado.email = this.formulario.get('email')?.value;
    gerenteSelecionado.login = this.formulario.get('login')?.value;
    gerenteSelecionado.senha = this.formulario.get('senha')?.value;
    gerenteSelecionado.cargo = this.formulario.get('cargo')?.value;

    const observer: Observer<Gerente> = {
      next(_result): void {
        alert('Gerente alterado com sucesso!');
      },
      error(error): void {
        console.log(error);
        alert('Erro ao alterar!');
      },
      complete(): void {
      },
    };

    // Atualizar 
    this.gerenteService.alterar(gerenteSelecionado).subscribe(observer);
  }
  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}

