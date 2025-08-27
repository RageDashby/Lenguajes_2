using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadorEmpresarial
{
    public class Confianza : Empleado
    {
        public double SueldoBase { get; set; }
        public string Nombre { get; set; }
        public bool Puntualidad { get; set; }
        public bool Asistencia { get; set; }
        public int DiasTrabajados { get; set; }

        private const int SUELDO_DIARIO = 1100;

        public Confianza(string nombre, int diasTrabajados, bool asistencia)
        {
            Nombre = nombre;
            DiasTrabajados = diasTrabajados;
            Asistencia = asistencia;
            Puntualidad = true; // No aplica, pero se establece por la interfaz
            SueldoBase = DiasTrabajados * SUELDO_DIARIO;
        }

        public float CalcularPago()
        {
            double bonoAsistencia = Asistencia ? 400 : 0;
            double totalBruto = SueldoBase + bonoAsistencia;
            double isr = totalBruto * 0.30;
            double ispt = totalBruto * 0.18;
            double totalNeto = totalBruto - (isr + ispt);
            return (float)totalNeto;
        }
    }
}
