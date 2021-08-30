export class Vehiculo {
    id: string;
    placa: string;
    cc: string;
    tipo: string;
    estado: string;
    dateIn: string;


    constructor(id: string, placa: string, cc: string, tipo: string, estado: string, dateIn: string) {
        this.id = id;
        this.placa = placa;
        this.cc = cc;
        this.tipo = tipo;
        this.estado = estado
        this.dateIn = dateIn;
    }
}
