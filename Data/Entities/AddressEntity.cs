using System.ComponentModel.DataAnnotations;

namespace AddressProvider.Data.Entities;

public class AddressEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = null!;

    [Required]
    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    [Required]
    public string PostalCode { get; set; } = null!;

    [Required]
    public string City { get; set; } = null!;

    [Required]
    public string Country { get; set; } = null!;

}
