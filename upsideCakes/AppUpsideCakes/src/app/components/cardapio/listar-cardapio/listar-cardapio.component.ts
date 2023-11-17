import { Component } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Cardapio } from 'src/app/models/Cardapio';
import { CardapiosService } from 'src/app/services/Cardapio/cardapios.service';

@Component({
  selector: 'app-listar-cardapio',
  templateUrl: './listar-cardapio.component.html',
  styleUrls: ['./listar-cardapio.component.css']
})
export class ListarCardapioComponent {

  constructor(private cardapioService: CardapiosService, private router: Router) { }

  formulario!: FormGroup;

  cardapios: Array<Cardapio> = [];

  cardapioByID: Cardapio | undefined;
  id: number = 0;

  showList: boolean = false;
  showListByID: boolean = false;
  tituloFormulario = '';

  ngOnInit(): void {
    this.tituloFormulario = 'Listar Filiais';
    this.cardapioService.listar().subscribe( cardapio =>{
      this.cardapios = cardapio;
    });

    this.formulario = new FormGroup({
      id: new FormControl()
      });

  }

  listarGeral() {
    this.showList = true;
    this.showListByID = false;
  }

  listarPorID(): void {
    this.cardapioService.listarPorID(this.formulario.value.id).subscribe(cardapio => {
      this.cardapioByID = cardapio;
    this.showListByID = true;
    this.showList = false;
    console.log(this.formulario.value.id);
    console.log(this.cardapioByID);
  })
};

  voltarParaHome() {
    this.router.navigate(['/home']); 
    this.showList = false;
    this.showListByID = false;
  }
}
