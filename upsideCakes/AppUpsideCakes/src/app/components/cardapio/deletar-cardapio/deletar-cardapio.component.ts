import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Observer } from 'rxjs';
import { Cardapio } from 'src/app/models/Cardapio';
import { CardapiosService } from 'src/app/services/Cardapio/cardapios.service';

@Component({
  selector: 'app-deletar-cardapio',
  templateUrl: './deletar-cardapio.component.html',
  styleUrls: ['./deletar-cardapio.component.css']
})
export class DeletarCardapioComponent {

  cardapioSelecionado: Number | undefined;
  formulario: FormGroup = new FormGroup({});
  tituloFormulario: string = '';
  cardapios: Array<Cardapio> | undefined;

  constructor(private cardapiosService : CardapiosService, private router : Router) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Excluir Cardápio';

    this.carregarCardapios();

    this.formulario = new FormGroup({
      cardapioSelecionado: new FormControl(null)
    })
  }

  carregarCardapios() {
    this.cardapiosService.listar().subscribe(cardapios => {
      this.cardapios = cardapios;
      if (this.cardapios && this.cardapios.length > 0) {
        this.cardapioSelecionado = this.cardapios[0].id;
        this.formulario.get('cardapioSelecionado')?.setValue(this.cardapios[0].id);
      }
    });
  }

  selecionarCardapio(event: any) {
    const selectedValue = event.target.value;
    if (selectedValue) {
      this.cardapioSelecionado = parseInt(selectedValue, 10);
      console.log('Cardápio selecionado:', this.cardapioSelecionado);
    } else {
      console.log('Valor selecionado é inválido:', selectedValue);
    }
  }

  enviarFormulario(): void {
    if (this.cardapioSelecionado === undefined || this.cardapioSelecionado === null) {
      alert('Nenhum cardápio selecionado.');
      return;
    }

    const observer: Observer<Cardapio> = {
      next: (_result): void => {
        alert('Cardápio excluído com sucesso.');
        this.carregarCardapios(); // Atualiza a lista de produtos após a exclusão
      },
      error: (error): void => {
        console.log(error);
        alert('Erro ao excluir, consulte o Console!');
      },
      complete: (): void => {
      },
    };

    // Excluir o produto no seu serviço
    this.cardapiosService.excluir(this.cardapioSelecionado).subscribe(observer);
    }

  voltarParaHome() {
    this.router.navigate(['/home']); 
  }
}
