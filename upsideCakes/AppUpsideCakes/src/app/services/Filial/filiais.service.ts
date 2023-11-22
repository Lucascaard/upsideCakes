import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, throwError } from 'rxjs';
import { Filial } from 'src/app/models/Filial';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class FiliaisService {

  apiUrl = 'http://localhost:5000/Filial';
    constructor(private http: HttpClient) { }

    cadastrar(filial : Filial): Observable<any> {
      const url = `${this.apiUrl}/cadastrar`;
      return this.http.post<Filial>(url, filial, httpOptions).pipe(
        catchError((error: HttpErrorResponse) => {
          if (error.status === 404) {
            console.error(`Erro ao cadastrar filial.`);
            alert(`Erro ao cadastrar filial.`);
          }
          if ( error.status == 500 || error.status === 503){
            console.error(`Erro interno do servidor ao cadastrar filial.`);
            alert(`Erro interno do servidor ao cadastrar filial.`);
          }
          if (filial == null || error.status === 400){
            console.error('Digite dados válidos para a filial');
            alert('Digite dados válidos para a filial');
          }
            return throwError('Algo deu errado ao cadastrar a filial.');
          
        }))
    }

    listar(): Observable<Filial[]> {
      const url = `${this.apiUrl}/listar`;
      return this.http.get<Filial[]>(url);
    }

    buscarPorID(id: Number): Observable<Filial> {
      const url = `${this.apiUrl}/listar/${id}`;
      return this.http.get<Filial>(url).pipe(
        catchError((error: HttpErrorResponse) => {
          if (error.status === 404) {
            console.error(`Filial com ID ${id} não encontrado.`);
            alert(`Filial com ID ${id} não encontrado.`);
          }
          if ( error.status == 500 || error.status === 503){
            console.error('Erro ao buscar filial!');
            alert('Erro ao buscar filial!');
          }
          if (id == null || error.status === 400){
            console.error('Digite um ID válido.');
            alert('Digite um ID válido.');
          }
            return throwError('Algo deu errado ao buscar a filial.');
          
        })
      );
    }

    alterar(filial: Filial): Observable<any> {
      const url = `${this.apiUrl}/alterar`;
      return this.http.put<Filial>(url, filial, { responseType: 'text' as 'json' });
    }

    excluir(id: Number): Observable<any> {
      const url = `${this.apiUrl}/excluir/${id}`;
      return this.http.delete<Filial>(url, { responseType: 'text' as 'json' }).pipe(
        catchError((error: HttpErrorResponse) => {
          if (error.status === 404) {
            console.error(`Filial com ID ${id} não encontrado.`);
            alert(`Filial com ID ${id} não encontrado.`);
          }
          if ( error.status == 500 || error.status === 503){
            console.error('Erro interno do servidor ao deletar filial!');
            alert('Erro interno do servidor ao deletar filial!');
          }
          if (id == null || error.status === 400){
            console.error('Digite um ID válido.');
            alert('Digite um ID válido.');
          }
            return throwError('Algo deu errado ao deletar a filial.');
          
        })
      );;
    }
  }
