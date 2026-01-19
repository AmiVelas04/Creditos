using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcoiris.Formularios.SubClases
{
    public class Cuenta : IEquatable<Cuenta>
    {
        public string NomCuenta { get; set; }
        public decimal Valor { get; set; }
        public bool tipo { get; set; }

        // Implementación de IEquatable<Cuenta>
        public bool Equals(Cuenta other)
        {
            if (other is null) return false;

            // Compara ambas propiedades para determinar igualdad
            return this.NomCuenta == other.NomCuenta;
                
        }

        // Sobrescribir Equals(object) para compatibilidad
        public override bool Equals(object obj)
        {
            return Equals(obj as Cuenta);
        }

        // Sobrescribir GetHashCode() - IMPORTANTE para colecciones
        public override int GetHashCode()
        {
            // Combina los hash codes de ambas propiedades
            return GetHashCode();
        }

        // Sobrescribir ToString() para mostrar en el ListBox
        public override string ToString()
        {
            return $"{NomCuenta} - Q{Valor}";
        }

        // Opcional: Sobrecargar operadores == y !=
        public static bool operator ==(Cuenta left, Cuenta right)
        {
            if (left is null) return right is null;
            return left.Equals(right);
        }

        public static bool operator !=(Cuenta left, Cuenta right)
        {
            return !(left == right);
        }
    }
}
