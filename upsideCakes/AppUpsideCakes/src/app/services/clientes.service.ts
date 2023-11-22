import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from '../models/Cliente';
const HttpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class ClientesService {

  apiUrl = 'http://localhost:5000/Cliente';
  constructor(private http: HttpClient) { }

  cadastrar(cliente: Cliente): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Cliente>(url, cliente, HttpOptions);
  }

  listar(): Observable<Cliente[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Cliente[]>(url);
  }

  listarPorID(id: Number): Observable<Cliente> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Cliente>(url);
  }

  alterar(produto: Cliente): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Cliente>(url, produto, HttpOptions);
  }

  excluir(id: Number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<string>(url, HttpOptions);
  }
}
