using System.ComponentModel.DataAnnotations;

namespace CreekRiver.Models;

public class Campsite
{
    public int Id { get; set; }
    [Required]
    public string Nickname { get; set; }
    public string ImageUrl { get; set; }
    //Since this property contains CampsiteType in the name, 
    //Entity Framework will automatically create a foreign key relationship between the Campsite and CampsiteType tables.
    public int CampsiteTypeId { get; set; }
    public CampsiteType CampsiteType { get; set; }
    public List<Reservation> Reservations { get; set; }
}