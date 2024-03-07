using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R24_JesusCG_V1
{
    public class CuentaOro : Cuenta
    {
        // CONSTANTES
        private const float RETIRAR_MAX = 1000;
        private const byte EDAD_MIN = 26;


        public CuentaOro(string titular, double cantidad, DateTime fecha, string numcuenta) : base(titular, cantidad, fecha, numcuenta)
        {

        }

        // MÉTODOS

        /// <summary>
        /// Validación de la Edad 
        /// </summary>
        /// <param name="fecha">Fecha de Nacimiento</param>
        /// <exception cref="OverflowException">Restricciones de edad del producto</exception>
        protected override void ValidarFecha(DateTime fecha)
        {
            // Comprobación de que la fecha es inferior a la actual
            base.ValidarFecha(fecha);

            // Comprobar si es mayor de la edad mínima permitida
            if (fecha > DateTime.Today.AddYears(-EDAD_MIN))
                throw new OverflowException($"No puede crearse la cuenta a menores de {EDAD_MIN} años");
        }
        
        /// <summary>
        /// Retirada de Dinero
        /// </summary>
        /// <param name="importe"></param>
        /// <exception cref="OverflowException"></exception>
        /// <exception cref="ArithmeticException"></exception>
        public override void Retirar(double importe)
        {
            ValidarImporte(importe);

            // Comprobar el límite establecido por el tipo de cuenta
            if (importe > RETIRAR_MAX)
                throw new OverflowException($"No puede retirar un importe superior a {RETIRAR_MAX} euros");

            // Comprobar si tiene saldo
            if (importe > Cantidad) throw new ArithmeticException("No tiene suficiente saldo en la cuenta");

            // Procesar la retirada
            _cantidad -= importe;
        }

    }
}
