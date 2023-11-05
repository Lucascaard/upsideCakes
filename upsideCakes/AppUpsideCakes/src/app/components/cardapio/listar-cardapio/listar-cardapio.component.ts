import { Component } from '@angular/core';
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

  cardapios: Array<Cardapio> = [];
  showList: boolean = false;
  tituloFormulario = '';

  ngOnInit(): void {
    this.tituloFormulario = 'Listar Filiais';
    this.cardapioService.listar().subscribe( cardapio =>{
      this.cardapios = cardapio;
    })
  }

  listarGeral() {
    this.showList = true;
  }

  voltarParaHome() {
    this.router.navigate(['/home']); 
  }
}
