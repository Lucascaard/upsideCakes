import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Gerente } from './Gerente';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})

export class GerentesService {
  apiUrl = 'http://localhost:5000/Gerente';
  constructor(private http: HttpClient) { }
  listar(): Observable<Gerente[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Gerente[]>(url);
  }
  buscar(nome: string): Observable<Gerente> {
    const url = `${this.apiUrl}/buscar/${nome}`;
    return this.http.get<Gerente>(url);
  }
  cadastrar(gerente: Gerente): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Gerente>(url, gerente, httpOptions);
  }
  atualizar(gerente: Gerente): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Gerente>(url, gerente, httpOptions);
  }
  excluir(nome: string): Observable<any> {
    const url = `${this.apiUrl}/buscar/${nome}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
