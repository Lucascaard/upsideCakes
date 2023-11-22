import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Gerente } from '../models/Gerente';

const HttpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class GerentesService {

  apiUrl = 'http://localhost:5000/Gerente';
  constructor(private http: HttpClient) { }

  cadastrar(gerente: Gerente): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Gerente>(url, gerente, HttpOptions);
  }

  listar(): Observable<Gerente[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Gerente[]>(url);
  }

  buscarPorId(id: Number): Observable<Gerente> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Gerente>(url);
  }

  alterar(gerente: Gerente): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Gerente>(url, gerente, { responseType: 'text' as 'json' });
  }

  excluir(id: Number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<string>(url, { responseType: 'text' as 'json' });
  }
}
