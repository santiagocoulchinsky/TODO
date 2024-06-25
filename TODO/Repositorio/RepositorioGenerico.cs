using TODO.Entidades;

namespace TODO.Repositorio
{
    internal class RepositorioGenerico<T> where T : BaseEntidad
    {
        public T Crear(T obj)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Database.EnsureCreated();
                context.Set<T>().Add(obj);
                context.SaveChanges();
            }
            return obj;
        }

        public T Actualizar(T obj)
        {

            using (AppDbContext context = new AppDbContext())
            {
                context.Set<T>().Update(obj);

                context.SaveChanges();
            }

            return obj;

        }

        public T Eliminar(T obj)
        {
            using(AppDbContext context = new AppDbContext())
            {
                context.Database.EnsureCreated();
                context.Set<T>().Remove(obj);
                context.SaveChanges();
            }
            return obj;
        }

        public List<T> VerTodos()
        {
            List<T> tareas;
            
            using (AppDbContext context = new AppDbContext())
            {
                tareas = context.Set<T>().ToList();
            }
            return tareas;
        }

        public T Obtener(int  id)
        {
            T obj;

            using (AppDbContext context = new AppDbContext())
            {
                obj = context.Set<T>().Where(x => x.Id == id).First();
            }
            return obj;
        }

        

    }
}
