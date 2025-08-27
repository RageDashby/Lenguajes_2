using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadorEmpresarial
{
    public class Tecnico : Empleado
    {
        public double SueldoBase { get; set; }
        public string Nombre { get; set; }
        public bool Puntualidad { get; set; }
        public bool Asistencia { get; set; }
        public int DiasTrabajados { get; set; }

        private const int PAGO_HORA = 45;
        private const int HORAS_DIARIAS = 9;

        public Tecnico(string nombre, int diasTrabajados, bool puntualidad, bool asistencia)
        {
            Nombre = nombre;
            DiasTrabajados = diasTrabajados;
            Puntualidad = puntualidad;
            Asistencia = asistencia;
            SueldoBase = DiasTrabajados * HORAS_DIARIAS * PAGO_HORA;
        }

        public float CalcularPago()
        {
            double bonoPuntualidad = Puntualidad ? 600 : 0;
            double bonoAsistencia = Asistencia ? 500 : 0;
            double totalBruto = SueldoBase + bonoPuntualidad + bonoAsistencia;
            double isr = totalBruto * 0.30;
            double ispt = totalBruto * 0.18;
            double totalNeto = totalBruto - (isr + ispt);
            return (float)totalNeto;
        }
    }
}
