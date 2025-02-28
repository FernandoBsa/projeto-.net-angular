import { Guid } from 'guid-typescript';

export interface UsuarioListar{
    id?: Guid;
    nomeCompleto: string;
    email: string;
    cargo: string;
    salario: number;
    situacao: boolean;
    cpf: string;
    senha: string;
}