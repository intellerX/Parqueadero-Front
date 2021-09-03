export class Vehiculo {
    id: string;
    Plate: string;
    Cc: number;
    Type: number;
    State: number;
    DateOfIn: string;


    constructor(Plate: string, Cc: number, Type: number, State: number, DateOfIn: string) {
        this.Plate = Plate;
        this.Cc = Cc;
        this.Type = Type;
        this.State = State
        this.DateOfIn = DateOfIn;
    }


}


