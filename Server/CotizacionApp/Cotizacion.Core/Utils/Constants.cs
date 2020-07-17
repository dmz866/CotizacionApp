using System.Collections.Generic;

namespace CotizacionApp.Core.Utils
{
    public static class Constants
    {
        public static readonly string BANCO_PROVINCIA_END_POINT_URL = "https://www.bancoprovincia.com.ar/Principal/Dolar";
        public static readonly string MONEDA_DOLAR = "dolar";
        public static readonly string MONEDA_REAL = "real";
        public static readonly string MONEDA_GROUP = "moneda";
        public static readonly double COTIZACION_REAL_DOLAR = 0.25; 
        
        // EXCEPTION MESSAGES
        public static readonly string MONEDA_NO_ACEPTADA = "Moneda no valida";
        public static readonly string MENSAJE_LIMITE_DOLAR = "El monto limite por mes es 200";
        public static readonly string MENSAJE_LIMITE_REAL = "El monto limite por mes es 300";
    }
}
