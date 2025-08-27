using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadorEmpresarial
{
    public interface Empleado
    {
        double SueldoBase { get; set; }
        string Nombre { get; set; }
        bool Puntualidad { get; set; }
        bool Asistencia { get; set; }
        int DiasTrabajados { get; set; }
        float CalcularPago();
    }
}
