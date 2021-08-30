import { by, element } from 'protractor';

export class VehiculoPage {
    private linkCrearVehiculo = element(by.id('linkCrearVehiculo'));
    private linkListarVehiculos = element(by.id('linkListarVehiculo'));
    private inputIdVehiculo = element(by.id('idVehiculo'));
    private inputDescripcionVehiculo = element(by.id('descripcionVehiculo'));
    private listaVehiculos = element.all(by.css('ul.vehiculos li'));

    async clickBotonCrearVehiculos() {
        await this.linkCrearVehiculo.click();
    }

    async clickBotonListarVehiculos() {
        await this.linkListarVehiculos.click();
    }

    async ingresarId(idVehiculo) {
        await this.inputIdVehiculo.sendKeys(idVehiculo);
    }

    async ingresarDescripcion(descripcionVehiculo) {
        await this.inputDescripcionVehiculo.sendKeys(descripcionVehiculo);
    }

    async contarVehiculos() {
        return this.listaVehiculos.count();
    }
}
