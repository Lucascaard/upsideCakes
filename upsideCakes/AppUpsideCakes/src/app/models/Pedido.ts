import { Funcionario } from "./Funcionario";
import { Gerente } from "./Gerente";
import { Produto } from "./Produto"
 
export class Pedido {
    id: Number = 0;
    dataCriacao: Date = new Date('2023-11-11');
    funcionario: Funcionario = new Funcionario();
    gerente: Gerente = new Gerente();
    produto: Produto[] = [];
    qtde: Number = 0;
}