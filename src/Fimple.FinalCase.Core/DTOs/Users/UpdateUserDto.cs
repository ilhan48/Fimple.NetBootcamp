using Fimple.FinalCase.Core.Features.Users.Commands.Update;
using MediatR;

namespace Fimple.FinalCase.Core.DTOs;
public class UpdateUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool Status { get; set; }
}
