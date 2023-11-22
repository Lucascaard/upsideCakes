import { Cliente } from "./Cliente";
import { Pedido } from "./Pedido";
export class Pagamento{

    id: Number = 0;
    data: Date = new Date('2023-11-11');
    valor: number | undefined; // Usar 'number' para representar um valor de ponto flutuant
    formaDePagamento: String = '';
    nomeCliente: String = '';
    //  cliente: Cliente | undefined; //inicializa um obj q n é um tipo primitivo
    //pedido: Pedido | undefined;

}
