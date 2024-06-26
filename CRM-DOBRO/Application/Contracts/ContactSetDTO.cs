﻿namespace Application.Contracts;

/// <summary>
/// DTO for creating and changing a contact
/// </summary>
public class ContactSetDTO
{
    [DisplayName("Имя")]
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    public required string Name { get; init; }

    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    [DisplayName("Фамилия")]
    public string? Surname { get; init; }

    [DisplayName("Отчество")]
    [MaxLength(50, ErrorMessage = Message.MAX_LENGTH)]
    public string? LastName { get; init; }

    [DisplayName("Номер телефона")]
    [Required(AllowEmptyStrings = false, ErrorMessage = Message.REQUIRED)]
    [MaxLength(15, ErrorMessage = Message.MAX_LENGTH)]
    [Phone(ErrorMessage = Message.PHONE)]
    public required string PhoneNumber { get; init; }

    [MaxLength(20, ErrorMessage = Message.MAX_LENGTH)]
    [EmailAddress(ErrorMessage = Message.EMAIL)]
    public string? Email { get; init; }

}
