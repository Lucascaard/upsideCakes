import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { CardapiosService } from 'src/app/services/Cardapio/cardapios.service';

@Component({
  selector: 'app-deletar-cardapio',
  templateUrl: './deletar-cardapio.component.html',
  styleUrls: ['./deletar-cardapio.component.css']
})
export class DeletarCardapioComponent {

  formulario: any;
  tituloFormulario: string = '';

  constructor(private cardapiosService : CardapiosService, private router : Router) { }

  ngOnInit(): void {
    this.tituloFormulario = "Deletar Cardápio";

    this.formulario = new FormGroup({
      id: new FormControl()
      });
  }

  enviarFormulario(): void {
    const id : Number = Number(this.formulario.get('id').value);
    
    this.cardapiosService.excluir(id).subscribe(result => {
    alert('Cardápio excluído com sucesso.');
    })
    }

  voltarParaHome() {
    this.router.navigate(['/home']); 
  }
}
