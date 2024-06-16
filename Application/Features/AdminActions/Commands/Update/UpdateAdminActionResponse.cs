using Domain.Enums;

namespace Application.Features.AdminActions.Commands.Update
{
    public class UpdateAdminActionResponse
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public ActionType ActionType { get; set; }
        public string Details { get; set; }

    }
}
