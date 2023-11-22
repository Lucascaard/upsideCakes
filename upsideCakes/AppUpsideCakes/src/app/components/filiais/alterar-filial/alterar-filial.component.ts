import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Observer } from 'rxjs';
import { Filial } from 'src/app/models/Filial';
import { FiliaisService } from 'src/app/services/Filial/filiais.service';

@Component({
  selector: 'app-alterar-filial',
  templateUrl: './alterar-filial.component.html',
  styleUrls: ['./alterar-filial.component.css']
})
export class AlterarFilialComponent {

  filialSelecionada: Number | undefined;
  filiais: Array<Filial> | undefined;
  formulario: any;
  tituloFormulario: string = '';

  constructor(private filiaisService : FiliaisService, private router: Router) { }

  ngOnInit(): void {
    this.tituloFormulario = "Alterar dados de Filial";

    this.filiaisService.listar().subscribe(filiais => {
      this.filiais = filiais;
      if (this.filiais && this.filiais.length > 0) {
        this.filialSelecionada = this.filiais[0].id;
        this.formulario.get('filialSelecionada')?.setValue(this.filiais[0].id);
      }
    })

    this.formulario = new FormGroup({
      filialSelecionada: new FormControl(null),
      cep: new FormControl(null),
      cidade: new FormControl(null),
      rua: new FormControl(null)
      });
  }

  selecionarFilial(event: any) {
    const selectedValue = event.target.value;
    if (selectedValue) {
      this.filialSelecionada = parseInt(selectedValue, 10);
      console.log('Filial selecionada:', this.filialSelecionada);
    } else {
      console.log('Valor selecionado é inválido:', selectedValue);
    }
  }

  enviarFormulario(): void {

    if (this.filialSelecionada === undefined || this.filialSelecionada === null) {
      alert('Nenhuma filial selecionada.');
      return;
    }

    const filialSelecionada = this.filiais?.find(filial => filial.id === this.filialSelecionada);

    if (!filialSelecionada) {
      alert('Filial selecionada não encontrada.');
      return;
    }

    filialSelecionada.cep = this.formulario.get('cep')?.value;
    filialSelecionada.rua = this.formulario.get('rua')?.value;
    filialSelecionada.cidade = this.formulario.get('cidade')?.value;

    const observer: Observer<Filial> = {
      next(_result): void {
        alert('Filial alterada com sucesso.');
      },
      error(error): void {
        console.log(error);
        alert('Erro ao alterar!');
      },
      complete(): void {
      },
    };

    this.filiaisService.alterar(filialSelecionada).subscribe(result => {
    alert('Filial alterada com sucesso.');
    })
    }

  voltarParaHome() {
    this.router.navigate(['/home']); 
  }
}
