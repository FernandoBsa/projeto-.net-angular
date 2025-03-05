import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UsuarioListar } from '../models/Usuario';
import { Response } from '../models/Response';
import { Guid } from 'guid-typescript';


@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  ApiUrl = environment.urlApi;

  constructor(private http : HttpClient) { }
  
  GetUsuarios(): Observable<Response<UsuarioListar[]>>{
    return this.http.get<Response<UsuarioListar[]>>(this.ApiUrl);
  }

  GetUsuarioId(id: Guid): Observable<Response<UsuarioListar>>{
    return this.http.get<Response<UsuarioListar>>(`${this.ApiUrl}/${id}`);	
  }

  CriarUsuario(usuario: UsuarioListar): Observable<Response<UsuarioListar[]>>{
    return this.http.post<Response<UsuarioListar[]>>(this.ApiUrl, usuario);
  }

  EditarUsuario(usuario: UsuarioListar): Observable<Response<UsuarioListar[]>>{
    return this.http.put<Response<UsuarioListar[]>>(this.ApiUrl, usuario);
  }
  DeletarUsuario(id: Guid | undefined): Observable<Response<UsuarioListar[]>>{
    return this.http.delete<Response<UsuarioListar[]>>(`${this.ApiUrl}?id=${id}`);
  }
}