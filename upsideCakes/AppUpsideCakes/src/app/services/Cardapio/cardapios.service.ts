import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cardapio } from 'src/app/models/Cardapio';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class CardapiosService {

  // constructor() { }

  apiUrl = 'http://localhost:5000/Cardapio';
    constructor(private http: HttpClient) { }

    cadastrar(): Observable<any> {
      const url = `${this.apiUrl}/cadastrarCardapio`;
      return this.http.post<Cardapio>(url, httpOptions);
    }

    addItem(id: Number, idCardapio: Number): Observable<any> {
      const url = `${this.apiUrl}/addItem`;
      return this.http.put<Cardapio>(url, httpOptions);
    }

    listar(): Observable<Cardapio[]> {
      const url = `${this.apiUrl}/listar`;
      return this.http.get<Cardapio[]>(url);
    }

    listarPorID(id: Number): Observable<Cardapio> {
      const url = `${this.apiUrl}/listar/${id}`;
      return this.http.get<Cardapio>(url);
    }

    alterar(cardapio: Cardapio): Observable<any> {
      const url = `${this.apiUrl}/alterar`;
      return this.http.put<Cardapio>(url, cardapio, { responseType: 'text' as 'json' });
    }

    excluir(id: Number): Observable<any> {
      const url = `${this.apiUrl}/excluir`;
      return this.http.delete<string>(url, { responseType: 'text' as 'json' });
    }
}
