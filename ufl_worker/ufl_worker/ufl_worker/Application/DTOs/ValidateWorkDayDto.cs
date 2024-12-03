namespace ufl_worker.Application.DTOs
{
    public class ValidateWorkDayDto
    {
        public int WorkDayId { get; set; } // ID de la jornada laboral a validar
        public bool IsCounted { get; set; } // Estado de validación (true para validar, false para invalidar)
    }
}
