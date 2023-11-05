import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Funcionario } from '../models/Funcionario';
const HttpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class FuncionariosService {

  apiUrl = 'http://localhost:5000/Funcionario';
  constructor(private http: HttpClient) { }

  cadastrar(funcionario: Funcionario): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Funcionario>(url, funcionario, HttpOptions);
  }

  listar(): Observable<Funcionario[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Funcionario[]>(url);
  }

  listarPorID(id: Number): Observable<Funcionario> {
    const url = `${this.apiUrl}/listar/${id}`;
    return this.http.get<Funcionario>(url);
  }

  alterar(produto: Funcionario): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Funcionario>(url, produto, HttpOptions);
  }

  excluir(id: Number): Observable<any> {
    const url = `${this.apiUrl}/excluir`;
    return this.http.delete<string>(url, HttpOptions);
  }
}
