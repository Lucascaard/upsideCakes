import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Gerente } from '../models/Gerente';

const HttpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class GerentesService{

  apiUrl = 'http://localhost:5000/Gerente';
  constructor(private http: HttpClient) { }

  cadastrar(gerente : Gerente): Observable<any>{
    const url = `${this.apiUrl}/cadastrar`;

    console.log(url);
    console.log(gerente);
    console.log(HttpOptions);

    return this.http.post<Gerente>(url, gerente, HttpOptions);
  }

  listar(): Observable<Gerente[]>{
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Gerente[]>(url);  
  }

  buscarPorID(id: Number): Observable<Gerente> {
    const url = `${this.apiUrl}/listar/${id}`;
    return this.http.get<Gerente>(url);
  }

  alterar(gerente: Gerente): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Gerente>(url, gerente, HttpOptions);
  }

  excluir(id: Number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<string>(url, HttpOptions);
  }


}
