﻿
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
