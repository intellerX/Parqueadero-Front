import { browser, logging } from 'protractor';
import { NavbarPage } from '../page/navbar/navbar.po';
import { AppPage } from '../app.po';
import { VehiculoPage } from '../page/vehiculo/vehiculo.po';

describe('workspace-project Vehiculo', () => {
    let page: AppPage;
    let navBar: NavbarPage;
    let vehiculo: VehiculoPage;

    beforeEach(() => {
        page = new AppPage();
        navBar = new NavbarPage();
        vehiculo = new VehiculoPage();
    });

    it('Deberia crear vehiculo', () => {
        const ID_PRODUCTO = '001';
        const DESCRIPCION_PRODUCTO = 'Vehiculo de pruebas';

        page.navigateTo();
        navBar.clickBotonVehiculos();
        vehiculo.clickBotonCrearVehiculos();
        vehiculo.ingresarId(ID_PRODUCTO);
        vehiculo.ingresarDescripcion(DESCRIPCION_PRODUCTO);

        // Adicionamos las validaciones despues de la creación
        // expect(<>).toEqual(<>);
    });

    it('Deberia listar vehiculos', () => {
        page.navigateTo();
        navBar.clickBotonVehiculos();
        vehiculo.clickBotonListarVehiculos();

        expect(4).toBe(vehiculo.contarVehiculos());
    });
});
