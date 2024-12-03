namespace ufl_worker.Application.DTOs
{
    public class EndWorkDayDto
    {
        public int WorkDayId { get; set; } // ID de la jornada iniciada
        public string Lat { get; set; }    // Latitud del GPS
        public string Lon { get; set; }    // Longitud del GPS
    }
}
