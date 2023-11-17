import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pedido } from '../models/Pedido';
const HttpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class PedidosService {

  apiUrl = 'http://localhost:5000/Pedido';
  constructor(private http: HttpClient) { }

  cadastrar(pedido: Pedido): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Pedido>(url, pedido, HttpOptions);
  }

  listar(): Observable<Pedido[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Pedido[]>(url);
  }

  listarPorID(id: Number): Observable<Pedido> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Pedido>(url);
  }

  alterar(produto: Pedido): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Pedido>(url, produto, HttpOptions);
  }

  excluir(id: Number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<string>(url, HttpOptions);
  }
}
