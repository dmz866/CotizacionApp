using System.Collections.Generic;

namespace CotizacionApp.Core.Utils
{
    public static class Constants
    {
        public static readonly string BANCO_PROVINCIA_END_POINT_URL = "https://www.bancoprovincia.com.ar/Principal/Dolar";
        public static readonly string MONEDA_DOLAR = "dolar";
        public static readonly string MONEDA_REAL = "real";
        public static readonly double COTIZACION_REAL_DOLAR = 0.25; 
        public static readonly List<string> MONEDAS_ACEPTADAS_LIST = new List<string>() { MONEDA_DOLAR, MONEDA_REAL }; // THIS LIST VALUES SHOULD BE RETRIEVED FROM A DATABASE LOOKUP TABLE
        
        // EXCEPTION MESSAGES
        public static readonly string MONEDA_NO_ACEPTADA = "Moneda no valida";
    }
}
