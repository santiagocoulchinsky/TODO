
using TODO.Enumeraciones;

namespace TODO.Entidades
{
    class Tarea : BaseEntidad
    {
        public Tarea()
        {
            Estado = EstadoTarea.Pendiente;
            Operarios = new List<Asigna>();
        }
        public void Fin()
        {
            Estado = EstadoTarea.Terminada;
        }

        public void Desmarcar()
        {
            Estado = EstadoTarea.Pendiente;
        }

        public string Title { get; set; }
        public string Description { get; set; } 
        public EstadoTarea Estado {  get; set; }
        public List<Asigna> Operarios { get;}
    }
}
