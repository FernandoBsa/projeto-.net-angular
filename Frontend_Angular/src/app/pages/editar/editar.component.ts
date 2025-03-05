import { Component, OnInit } from '@angular/core';
import { FormularioComponent } from "../../componentes/formulario/formulario.component";
import { UsuarioService } from '../../services/usuario.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UsuarioListar } from '../../models/Usuario';
import { Guid } from 'guid-typescript';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-editar',
  imports: [FormularioComponent, CommonModule],
  templateUrl: './editar.component.html',
  styleUrl: './editar.component.css'
})
export class EditarComponent implements OnInit{

  btnAcao = "Editar";
  descricaoTitulo = "Editar Usuário";
  usuario!: UsuarioListar;

  constructor(private usuarioService: UsuarioService, private router: Router, private activatedRouter: ActivatedRoute) { }

  ngOnInit() {
    const id = Guid.parse(this.activatedRouter.snapshot.paramMap.get('id')!);

    this.usuarioService.GetUsuarioId(id).subscribe((response) => {
      this.usuario = response.dados;
    });
  }

  editarUsuario(usuario: UsuarioListar){
    this.usuarioService.EditarUsuario(usuario).subscribe(reponse => {
      this.router.navigate(['/']);
    });
  }

}
