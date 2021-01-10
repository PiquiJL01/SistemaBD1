using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
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