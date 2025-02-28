import { Component, OnInit } from '@angular/core';
import { UsuarioService } from '../../services/usuario.service';
import { UsuarioListar } from '../../models/Usuario';
import { response } from 'express';
import { Guid } from 'guid-typescript';
import { CadastroComponent } from '../cadastro/cadastro.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-home',
  imports: [RouterModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {

  usuarios: UsuarioListar[] = [];
  usuariosGeral: UsuarioListar[] = [];

  constructor(private usuarioService: UsuarioService) { }

  ngOnInit(): void {

    this.usuarioService.GetUsuarios().subscribe(response => {
      this.usuarios = response.dados;
      this.usuariosGeral = response.dados;
    })
  }


  search(event: Event){
    const target = event.target as HTMLInputElement;
    const value = target.value.toLocaleLowerCase();

    this.usuarios = this.usuariosGeral.filter(usuario => {
      return usuario.nomeCompleto.toLocaleLowerCase().includes(value);
    })
  }

  deletar(id: Guid | undefined){
    this.usuarioService.DeletarUsuario(id).subscribe(response => {
      window.location.reload();
      //this.usuarios = response.dados;
    })
  }
}
