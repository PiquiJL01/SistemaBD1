﻿namespace Ucabmart.Engine
{
    public enum CodigoPermiso : int
    {
        nulo = 0,
        Productos = 1,
        Tienda = 2,
        Nomina = 3,
        Proveedores = 4,
        Clientes = 5,
        Roles = 6
    }

    public enum NumeroTelefono
    {
        Pais,
        Area,
        Numero
    }

    public enum TipoAlmacen
    {
        Congelador,
        General,
        Refrigerador
    }

    public enum TipoCalidad
    {
        Alta,
        Baja,
        Regular
    }

    public enum TipoLugar
    {
        Direccion,
        Estado,
        Municipio,
        Pais,
        Parroquia
    }

    public enum TipoTarjeta
    {
        AmericanExpress,
        Debito,
        DinersClub,
        Discovery,
        Maestro,
        MasterCard,
        Visa
    }

    public enum TipoTelefono
    {
        Fijo,
        Movil
    }

    public enum TipoTurno
    {
        Diurno,
        Matutino,
        Vespertino,
        Nocturno
    }

    public enum TipoZona
    {
        Congelador,
        General,
        Refrigerador
    }
}