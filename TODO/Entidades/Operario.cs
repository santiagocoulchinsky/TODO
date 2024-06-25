using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODO.Entidades
{
    class Operario : BaseEntidad
    {
        //public Operario()
        //{
        //    Tareas = new List<Asigna>();
        //}
        public string Nombre {  get; set; }
        public List<Asigna> Tareas { get; set; }
    }
}
