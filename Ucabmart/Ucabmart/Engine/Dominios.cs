using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ucabmart.Engine
{
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
}