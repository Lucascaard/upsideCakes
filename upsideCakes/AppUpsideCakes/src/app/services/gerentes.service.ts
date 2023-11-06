import { Gerente } from './../models/Gerente';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


const HttpOptions = {
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

  cadastrar(gerente : Gerente): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Gerente>(url, gerente, HttpOptions);
  }

  listar(): Observable<Gerente[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Gerente[]>(url);
  }
//mudei o id pra cpf
  buscar(cpf: string): Observable<Gerente> {
    const url = `${this.apiUrl}/buscar/${cpf}`;
    return this.http.get<Gerente>(url);
  }

  alterar(gerente: Gerente): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Gerente>(url, gerente, { responseType: 'text' as 'json' });
  }

//mudei o id pra cpf
  excluir(cpf: Number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${cpf}`;
    return this.http.delete<string>(url, { responseType: 'text' as 'json' });
  }
}
