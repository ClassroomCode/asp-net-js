using System.ComponentModel.DataAnnotations;

namespace CS.WebUI.Models;

public record CartViewModel
(
    ShoppingCart? Cart = null,
    [Required]
    string? CustomerName = null,
    [Required]
    [EmailAddress]
    string? Email = null,
    [Required]
    string? CreditCard = null
);
