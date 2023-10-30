
  import { HttpClient, HttpHeaders } from '@angular/common/http';
  import { Injectable } from '@angular/core';
  import { Observable } from 'rxjs';
  import { Produto } from '../models/Produto';
  const HttpOptions = {
    headers: new HttpHeaders({
      'Content-Type' : 'application/json'
    })
  }

  @Injectable({
    providedIn: 'root'
  })
  export class ProdutosService {
    private proximoId = 1;

    apiUrl = 'http://localhost:5000/Produto';
    constructor(private http: HttpClient) { }

    cadastrar(produto : Produto): Observable<any> {
      const url = `${this.apiUrl}/cadastrar`;
      produto.id = this.proximoId++;
      return this.http.post<Produto>(url, produto, HttpOptions);
    }

    listar(): Observable<Produto[]> {
      const url = `${this.apiUrl}/listar`;
      return this.http.get<Produto[]>(url);
    }

    listarPorID(id: Number): Observable<Produto> {
      const url = `${this.apiUrl}/listar/${id}`;
      return this.http.get<Produto>(url);
    }

    alterar(produto: Produto): Observable<any> {
      const url = `${this.apiUrl}/alterar`;
      return this.http.put<Produto>(url, produto, HttpOptions);
    }

    atualizarPreco(id: Number, preco: Number): Observable<Produto> {
      const url = `${this.apiUrl}/alterarpreco/${id}`;
      const body = { preco };
      return this.http.patch<Produto>(url, body);
    }

    excluir(id: Number): Observable<any> {
      const url = `${this.apiUrl}/excluir/${id}`;
      return this.http.delete<string>(url, HttpOptions);
    }
  }