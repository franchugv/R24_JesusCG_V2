using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace R24_JesusCG_V1
{
    public abstract class Cuenta
    {
        // MIEMBROS
        protected string _titular;
        protected double _cantidad;
        protected DateTime _fechaNac;
        protected string _numCuenta;

        // CONSTRUCTORS 

        public Cuenta(string titular, double cantidad, DateTime fecha, string numcuenta)
        {
            Titular = titular;
            Ingresar(cantidad);
            FechaNacimiento = fecha;
            NumCuenta = numcuenta;
        }


        // PROPIEDADES
        /// <summary>
        /// Titular de la Cuenta
        /// </summary>
        public virtual string Titular
        {
            get
            {
                return _titular;
            }
            set
            {
                // Validar Cadena de Caracteres: Solo letras y espacios en blanco
                ValidarCadena(value);

                _titular = value;
            }
        }

        /// <summary>
        /// Saldo de la Cuenta
        /// </summary>
        public virtual double Cantidad
        {
            get
            {
                return _cantidad;
            }
        }

        /// <summary>
        /// Fecha de Nacimiento del Titular
        /// </summary>
        public virtual DateTime FechaNacimiento
        {
            get
            {
                return _fechaNac;
            }
            set
            {
                // Validación simple de la cadena
                ValidarFecha(value);

                _fechaNac = value;
            }
        }

        /// <summary>
        /// Número de Cuenta
        /// </summary>
        public string NumCuenta
        {
            get { return _numCuenta; }
            set {
                // Validación del Número de Cuenta
                ValidarNumeroCuenta(value);

                _numCuenta = value;
            }
        }

        // MÉTODOS
        public virtual void Ingresar(double importe)
        {
            // Validar importe
            ValidarImporte(importe);

            _cantidad += importe;
        }

        /// <summary>
        /// Método a implementar en las clases derivadas
        /// </summary>
        /// <param name="importe"></param>
        public abstract void Retirar(double importe);

        /// <summary>
        /// Valida si la cadena cumple con los requisitos especificados
        /// </summary>
        /// <param name="cadena">Cadena de caracteres a validar</param>
        /// <returns>Cadena de caracteres validada</returns>
        /// <exception cref="ArgumentNullException">La cadena es nula o vacía</exception>
        /// <exception cref="FormatException">Cadena Incorrecta</exception>
        protected virtual void ValidarCadena(string cadena)
        {
            // Preparación de la cadena: Eliminación de los espacios en blanco al principio y final
            cadena = cadena.Trim();

            // Comprueba si la cadena es null o vacía
            if (String.IsNullOrEmpty(cadena))
                throw new ArgumentNullException("Error: Cadena Vacía o Nula");

            // Comprueba si se ajusta al formato
            foreach (char caracter in cadena)
            {
                // Se puede mejorar el rendimiento??
                if (!(char.IsLetter(caracter) || char.IsWhiteSpace(caracter)))
                    throw new FormatException("Cadena Incorrecta");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fecha">Fecha de Nacimiento</param>
        /// <exception cref="OverflowException">Supera la fecha actual</exception>
        protected virtual void ValidarFecha(DateTime fecha)
        {
            if (fecha >= DateTime.Now)
                throw new OverflowException("Fecha Incorrecta: La fecha debe ser anterior a la fecha actual");
        }

        /// <summary>
        /// Comprueba que la cantidad sea positiva
        /// </summary>
        /// <param name="valor">Cantidad a validar</param>
        /// <exception cref="OverflowException">Error: Cantidad incorrecta</exception>
        protected static void ValidarImporte(double valor)
        {
            if (valor <= 0) throw new OverflowException("Importe incorrecto");
        }

        /// <summary>
        /// Validación del Número de Cuenta
        /// </summary>
        /// <param name="cuenta">Número de Cuenta</param>
        /// <exception cref="ArgumentException">Error por longitud de cuenta incorrecta</exception>
        /// <exception cref="FormatException">Error por formato de cuenta incorrecto</exception>
        private void ValidarNumeroCuenta(string cuenta)
        {
            const int LONG_CUENTA = 20;

            // Preparación de la Cadena
            cuenta = cuenta.Trim();

            // Comprobación del tamaño
            if (cuenta.Length != LONG_CUENTA)
                throw new ArgumentException("Longitud de la cuenta incorrecta");

            // Comprobación del formato de la cuenta
            foreach (char caracter in cuenta)
            {
                if (!char.IsDigit(caracter))
                    throw new FormatException("Formato del Número de Cuenta Incorrecto");
            }
        }


    }
}
