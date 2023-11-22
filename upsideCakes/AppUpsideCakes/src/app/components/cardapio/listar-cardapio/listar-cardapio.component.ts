import { Component, NgModule } from '@angular/core';
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
  cardapioByID: Array<Cardapio> = [];
  showList: boolean = false;
  idCardapio: string = '';
  tituloFormulario = 'Listar Cardápios';

  ngOnInit(): void {
    this.cardapioService.listar().subscribe(cardapios => {
      this.cardapios = cardapios;
    });
  }

  listarGeral() {
    this.showList = true;
    this.cardapioByID = [];
  }

  listarPorId() {
    if (this.idCardapio.trim() === '') {
      this.listarGeral();
      return;
    }

    if (this.idCardapio !== undefined) {
      this.cardapioService.buscarPorID(parseInt(this.idCardapio)).subscribe(cardapio => {
        this.cardapioByID = [cardapio];
        this.showList = false;
      });
    } else {
      this.cardapioByID = [];
      this.showList = false;
    }
  }

  voltarParaHome() {
    this.router.navigate(['/home']); 
    this.showList = false;
  }
}
