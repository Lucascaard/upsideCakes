import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
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

    cadastrar(nome: string): Observable<any> {
      const url = `${this.apiUrl}/cadastrar`;
      return this.http.post<Cardapio>(url, httpOptions).pipe(
        catchError((error) => {
          console.error('Erro ao cadastrar cardápio:', error);
          return throwError(error);
        }));
    }

    addItem(id: Number, idCardapio: Number): Observable<any> {
      const url = `${this.apiUrl}/addItem`;
      return this.http.put<Cardapio>(url, httpOptions).pipe(
        catchError((error) => {
          console.error('Erro ao cadastrar item ao cardápio:', error);
          return throwError(error);
        }));
    }

    listar(): Observable<Cardapio[]> {
      const url = `${this.apiUrl}/listar`;
      return this.http.get<Cardapio[]>(url);
    }

    buscarPorID(id: Number): Observable<Cardapio> {
      const url = `${this.apiUrl}/listar/${id}`;
      return this.http.get<Cardapio>(url).pipe(
        catchError((error) => {
          console.error(`Erro ao buscar cardápio com id ${id}:`, error);
          return throwError(error);
        }));
    }

    alterar(idProduto: number, idCardapio: number): Observable<any> {
      const url = `${this.apiUrl}/alterar`;
      return this.http.put<Cardapio>(url, { responseType: 'text' as 'json' });
    }

    excluir(id: Number): Observable<any> {
      const url = `${this.apiUrl}/excluir/${id}`;
      return this.http.delete<string>(url, { responseType: 'text' as 'json' }).pipe(
        catchError((error) => {
          console.error('Erro ao deletar cardápio:', error);
          return throwError(error);
        }));
    }
}
