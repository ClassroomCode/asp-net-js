using System.ComponentModel.DataAnnotations;

namespace CS.WebUI.Models;

public record LoginViewModel
(
    [Required]
    string Username = "",
    [Required]
    [DataType(DataType.Password)]
    string Password = "",
    string ReturnUrl = ""
);
