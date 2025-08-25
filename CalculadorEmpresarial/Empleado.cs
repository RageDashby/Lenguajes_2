using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadorEmpresarial
{
    public interface Empleado
    {
        double SueldoBase {  get; set; }
        Boolean Bono {  get; set; }
        int DiasTrabajados { get; set; }
        


    
    }
}
