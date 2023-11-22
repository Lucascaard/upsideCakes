import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pagamento } from '../models/Pagamento';

const HttpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class PagamentoService {

  apiUrl = 'http://localhost:5000/Pagamento';
  constructor(private http: HttpClient) { }

  cadastrar(pagamento: Pagamento): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Pagamento>(url, pagamento, HttpOptions);
  }

  listar(): Observable<Pagamento[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Pagamento[]>(url);
  }

  listarPorID(id: Number): Observable<Pagamento> {
    const url = `${this.apiUrl}/listar/${id}`;
    return this.http.get<Pagamento>(url);
  }

  alterar(pagamento: Pagamento): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Pagamento>(url, pagamento, HttpOptions);
  }

  excluir(id: Number): Observable<any> {
    const url = `${this.apiUrl}/excluir`;
    return this.http.delete<string>(url, HttpOptions);
  }
}
