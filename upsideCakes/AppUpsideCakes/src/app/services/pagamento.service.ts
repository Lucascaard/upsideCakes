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
    const url = `${this.apiUrl}/novopagamento`;
    return this.http.post<Pagamento>(url, pagamento, HttpOptions);
  }

  listar(): Observable<Pagamento[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Pagamento[]>(url);
  }

  alterar(pagamento: Pagamento): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Pagamento>(url, pagamento, { responseType: 'text' as 'json' });
  }

  excluir(id: Number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<string>(url, { responseType: 'text' as 'json' });
  }
}
