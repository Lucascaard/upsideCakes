import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Produto } from 'src/app/models/Produto';
import { CardapiosService } from 'src/app/services/Cardapio/cardapios.service';

@Component({
  selector: 'app-add-item-cardapio',
  templateUrl: './add-item-cardapio.component.html',
  styleUrls: ['./add-item-cardapio.component.css']
})
export class AddItemCardapioComponent {

  formulario: any;
  tituloFormulario: string = '';

  constructor(private cardapiosService: CardapiosService, private router: Router) { }

  ngOnInit(): void {
    this.tituloFormulario = "Adicionar item ao Cardapio";
    this.formulario = new FormGroup({
      id: new FormControl(null),
      idCardapio: new FormControl(null)
    });
  }

  enviarFormulario(): void {
    const idCardapio = this.formulario.get('idCardapio').value;
    const id = this.formulario.get('id').value;

    console.log(idCardapio)
    console.log(id)
    this.cardapiosService.addItem(id, idCardapio).subscribe(result => {
      alert('Item adicionado com sucesso.');
    });
  }

  voltarParaHome() {
    this.router.navigate(['/home']); 
  }
}
