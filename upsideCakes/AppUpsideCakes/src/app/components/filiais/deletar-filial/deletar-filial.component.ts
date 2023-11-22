import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Observer } from 'rxjs';
import { Filial } from 'src/app/models/Filial';
import { FiliaisService } from 'src/app/services/Filial/filiais.service';

@Component({
  selector: 'app-deletar-filial',
  templateUrl: './deletar-filial.component.html',
  styleUrls: ['./deletar-filial.component.css']
})
export class DeletarFilialComponent {

  filialSelecionada: Number | undefined;
  formulario: FormGroup = new FormGroup({});
  tituloFormulario: string = '';
  filiais: Array<Filial> | undefined;

  constructor(private filiaisService : FiliaisService, private router : Router) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Excluir Cardápio';

    this.carregarFiliais();

    this.formulario = new FormGroup({
      filialSelecionada: new FormControl(null)
    })
  }

  carregarFiliais() {
    this.filiaisService.listar().subscribe(filiais => {
      this.filiais = filiais;
      if (this.filiais && this.filiais.length > 0) {
        this.filialSelecionada = this.filiais[0].id;
        this.formulario.get('filialSelecionada')?.setValue(this.filiais[0].id);
      }
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
      alert('Nenhum filial selecionado.');
      return;
    }

    const observer: Observer<Filial> = {
      next: (_result): void => {
        alert('Filial excluída com sucesso.');
        this.carregarFiliais(); // Atualiza a lista de produtos após a exclusão
      },
      error: (error): void => {
        console.log(error);
        alert('Erro ao excluir, consulte o Console!');
      },
      complete: (): void => {
      },
    };

    // Excluir o produto no seu serviço
    this.filiaisService.excluir(this.filialSelecionada).subscribe(observer);
    }

    voltarParaHome() {
      this.router.navigate(['/home']); 
    }
}
