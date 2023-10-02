namespace PruebaIngresoBibliotecario.Api.Utilidad
{
    public class Respuesta<T>
    {
        public bool Ok { get; set; } = default!;
        public T Value { get; set; } = default!;
        public string MensejeError { get; set; } = default!;

        public Respuesta() 
        { 
            Ok = true;
        }
    }
}
