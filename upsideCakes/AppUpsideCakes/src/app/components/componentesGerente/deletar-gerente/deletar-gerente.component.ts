import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Router } from '@angular/router';
import { Gerente } from 'src/app/models/Gerente';
import { GerentesService } from 'src/app/services/gerentes.service';

@Component({
  selector: 'app-deletar-gerente',
  templateUrl: './deletar-gerente.component.html',
  styleUrls: ['./deletar-gerente.component.css']
})
export class DeletarGerenteComponent implements OnInit {
  gerenteSelecionado: String | undefined;
  formulario: FormGroup = new FormGroup({});
  tituloFormulario: string = '';
  gerentes: Array<Gerente> | undefined;

  constructor(private gerenteService: GerentesService, private router: Router) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Excluir Gerente';

    this.carregarGerentes();

    this.formulario = new FormGroup({
      gerenteSelecionado: new FormControl(null)
    });
  }

  carregarGerentes() {
    this.gerenteService.listar().subscribe(gerentes => {
      this.gerentes = gerentes;
      if (this.gerentes && this.gerentes.length > 0) {
        this.gerenteSelecionado = this.gerentes[0].cpf;
        this.formulario.get('gerenteSelecionado')?.setValue(this.gerentes[0].cpf);
      }
    });
  }

  selecionarGerente(event: any) {
    const selectedValue = event.target.value;
    if (selectedValue) {
      this.gerenteSelecionado = selectedValue;
      console.log('Gerente selecionado:', this.gerenteSelecionado);
    } else {
      console.log('Valor selecionado é inválido:', selectedValue);
    }
  }
  
  enviarFormulario() {
    // Verifique se um gerente foi selecionado
    if (this.gerenteSelecionado === undefined || this.gerenteSelecionado === null) {
      alert('Nenhum gerente selecionado.');
      return;
    }
  
    const observer: Observer<Gerente> = {
      next: (_result): void => {
        alert('Gerente excluído com sucesso.');
        this.carregarGerentes(); // Atualiza a lista de gerentes após a exclusão
      },
      error: (error): void => {
        console.log(error);
        alert('Erro ao excluir, consulte o Console!');
      },
      complete: (): void => {
      },
    };
  
    // Excluir o gerente no service
      this.gerenteService.excluir(Number(this.gerenteSelecionado)).subscribe(observer);
  }
  

  voltarParaHome() {
    this.router.navigate(['/home']);
  }
}
