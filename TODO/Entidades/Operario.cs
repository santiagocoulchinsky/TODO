
namespace TODO.Entidades
{
    class Operario : BaseEntidad
    {
        public string Nombre {  get; set; }
        public List<Asigna> Tareas { get; set; }
    }
}
