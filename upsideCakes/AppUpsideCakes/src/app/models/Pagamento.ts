import { Cliente } from "./Cliente";
import { Pedido } from "./Pedido";
export class Pagamento{

    id: Number = 0;
    data: Date = new Date('2023-11-11');
    cliente: Cliente | undefined; //inicializa um obj q n é um tipo primitivo
    valor: number | undefined; // Usar 'number' para representar um valor de ponto flutuant
    formaDePagamento: String = '';
    pedido: Pedido | undefined;

}
