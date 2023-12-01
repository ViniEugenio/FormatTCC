namespace FormatTCC.Application.Models.ViewModels
{
    public class UserInfoViewModel
    {
        public required Guid Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Name { get; set; }
        public required string SurName { get; set; }
        public required bool Active { get; set; }
    }
}
