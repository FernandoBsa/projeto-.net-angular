import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterModule } from '@angular/router';
import { UsuarioService } from '../../services/usuario.service';
import { Guid } from 'guid-typescript';
import { UsuarioListar } from '../../models/Usuario';

@Component({
  selector: 'app-detalhes',
  imports: [RouterModule],
  templateUrl: './detalhes.component.html',
  styleUrl: './detalhes.component.css'
})
export class DetalhesComponent implements OnInit{

  usuario!: UsuarioListar;
  constructor(private usuarioService: UsuarioService, private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = Guid.parse(this.route.snapshot.paramMap.get('id')!);

    this.usuarioService.GetUsuarioId(id).subscribe(response => {
      this.usuario = response.dados;
    })
    
  }

}
