namespace CentroEventos.Aplicacion;

public interface IValidadorEventoDeportivo
{
    bool ValidarDatosVacios(EventoDeportivo evento,out string message);
    bool ValidarCupos(EventoDeportivo evento,out string message);
    bool ValidarFechaDeInicio(EventoDeportivo evento,out string message);
    bool ValidarDuracion(EventoDeportivo evento,out string message);
    bool ValidarResponsable(EventoDeportivo evento,out string message);
}