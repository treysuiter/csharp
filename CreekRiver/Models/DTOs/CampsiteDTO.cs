namespace CreekRiver.Models.DTOs;

public class CampsiteDTO
{
    public int Id { get; set; }
    public string Nickname { get; set; }
    public string ImageUrl { get; set; }
    //Since this property contains CampsiteType in the name, 
    //Entity Framework will automatically create a foreign key relationship between the Campsite and CampsiteType tables.
    public int CampsiteTypeId { get; set; }
    public CampsiteTypeDTO CampsiteType { get; set; }
    public List<ReservationDTO> Reservations { get; set; }
}