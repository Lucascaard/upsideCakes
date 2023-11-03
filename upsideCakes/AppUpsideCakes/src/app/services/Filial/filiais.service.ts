import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
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
      return this.http.post<Filial>(url, filial, httpOptions);
    }

    listar(): Observable<Filial[]> {
      const url = `${this.apiUrl}/listar`;
      return this.http.get<Filial[]>(url);
    }

    listarPorID(id: Number): Observable<Filial> {
      const url = `${this.apiUrl}/listar/${id}`;
      return this.http.get<Filial>(url);
    }

    alterar(filial: Filial): Observable<any> {
      const url = `${this.apiUrl}/alterar`;
      return this.http.put<Filial>(url, filial, { responseType: 'text' as 'json' });
    }

    atualizarPreco(id: Number, preco: Number): Observable<Filial> {
      const url = `${this.apiUrl}/alterarpreco/${id}`;
      const body = { preco };
      return this.http.patch<Filial>(url, body);
    }

    excluir(id: Number): Observable<any> {
      const url = `${this.apiUrl}/excluir/${id}`;
      return this.http.delete<string>(url, { responseType: 'text' as 'json' });
    }
  }
