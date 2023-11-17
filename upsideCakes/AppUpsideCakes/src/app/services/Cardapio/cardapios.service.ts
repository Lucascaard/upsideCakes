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

    cadastrar(): Observable<any> {
      const url = `${this.apiUrl}/cadastrarCardapio`;
      return this.http.post<Cardapio>(url, httpOptions).pipe(
        catchError((error: HttpErrorResponse) => {
          if (error.status === 404) {
            console.error(`Erro ao cadastrar cardápio.`);
            alert(`Erro ao cadastrar cardápio.`);
            // Pode tratar o erro de NotFound de alguma maneira específica aqui, por exemplo, redirecionar para uma página de erro.
          }
          if ( error.status == 500 || error.status === 503){
            console.error(`Erro interno do servidor ao cadastrar cardápio.`);
            alert(`Erro interno do servidor ao cadastrar cardápio.`);
          }
            return throwError('Algo deu errado ao cadastrar a filial.'); // Retorna um Observable de erro para que o componente também possa tratá-lo.
          
        }));
    }

    addItem(id: Number, idCardapio: Number): Observable<any> {
      const url = `${this.apiUrl}/addItem`;
      return this.http.put<Cardapio>(url, httpOptions).pipe(
        catchError((error: HttpErrorResponse) => {
          if (error.status === 404) {
            console.error(`Erro ao cadastrar cardápio.`);
            alert(`Erro ao cadastrar cardápio.`);
          }
          if ( error.status == 500 || error.status === 503){
            console.error(`Erro interno do servidor ao cadastrar item ao cardápio.`);
            alert(`Erro interno do servidor ao cadastrar item ao cardápio.`);
          }
          if (id == null || idCardapio == null || error.status === 400){
            console.error('Digite um ID válido inserir um item a um cardápio.');
            alert('Digite um ID válido inserir um item a um cardápio.');
          }
            return throwError('Algo deu errado ao cadastrar a filial.');
          
        }));
    }

    listar(): Observable<Cardapio[]> {
      const url = `${this.apiUrl}/listar`;
      return this.http.get<Cardapio[]>(url);
    }

    listarPorID(id: Number): Observable<Cardapio> {
      const url = `${this.apiUrl}/listar/${id}`;
      return this.http.get<Cardapio>(url).pipe(
        catchError((error: HttpErrorResponse) => {
          if (error.status === 404) {
            console.error(`Cardápio com ID ${id} não encontrado.`);
            alert(`Cardápio com ID ${id} não encontrado.`);
          }
          if ( error.status == 500 || error.status === 503){
            console.error('Erro ao buscar cardápio!');
            alert('Erro ao buscar cardápio!');
          }
          if (id == null || error.status === 400){
            console.error('Digite um ID válido para buscar um cardápio.');
            alert('Digite um ID válido para buscar um cardápio.');
          }
            return throwError('Algo deu errado ao buscar o cardápio.');
          
        })
      );;
    }

    alterar(idProduto: number, idCardapio: number): Observable<any> {
      const url = `${this.apiUrl}/alterar`;
      return this.http.put<Cardapio>(url, { responseType: 'text' as 'json' });
    }

    excluir(id: Number): Observable<any> {
      const url = `${this.apiUrl}/excluir/${id}`;
      return this.http.delete<string>(url, { responseType: 'text' as 'json' }).pipe(
        catchError((error: HttpErrorResponse) => {
          if (error.status === 404) {
            console.error(`Erro ao excluir cardápio.`);
            alert(`Erro ao excluir cardápio.`);
          }
          if ( error.status == 500 || error.status === 503){
            console.error(`Erro interno do servidor ao deletar cardápio.`);
            alert(`Erro interno do servidor ao deletar cardápio.`);
          }
          if (id == null || error.status === 400){
            console.error('Digite um ID válido para deletar o cardápio.');
            alert('Digite um ID válido para deletar o cardápio.');
          }
            return throwError('Algo deu errado ao cadastrar a filial.');
          
        }));
    }
}
