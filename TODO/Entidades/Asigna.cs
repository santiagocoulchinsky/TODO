using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.Entidades
{
    class Asigna : BaseEntidad
    {
        public int OperarioId { get; set; }
        public Operario Operario { get; set; }
        public int TareaId { get; set; }
        public Tarea Tarea { get; set; }
    }
}
