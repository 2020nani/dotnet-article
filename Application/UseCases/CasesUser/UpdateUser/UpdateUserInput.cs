using FirstApi.Domain.Entities;
using FirstApi.Domain.ValueObjects;

namespace FirstApi.Application.UseCases.CasesUser.UpdateUser
{
    public class UpdateUserInput
    {
        public int Id {  get; set; }
        public string? Email { get; set; }
        public required string OldPassword { get; set; }
        public string? NewPassword { get; set; }

        public User Convert(User user)
        {
            user.Email = Email is null ? user.Email : Email;
            user.Password = NewPassword is null ? user.Password : NewPassword;
            return user;
        }
    }
}
