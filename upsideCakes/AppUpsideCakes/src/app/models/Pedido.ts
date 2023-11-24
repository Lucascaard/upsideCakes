import { Produto } from "./Produto"
 
export class Pedido {
    id: Number = 0;
    dataCriacao: Date = new Date('2023-11-11');
    funcionarioID: Number = 0;
    gerenteID: Number = 0;
    produto: Produto = new Produto();
    qtde: Number = 0;
}
