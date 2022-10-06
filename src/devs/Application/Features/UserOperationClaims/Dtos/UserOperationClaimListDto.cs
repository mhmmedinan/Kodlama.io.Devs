namespace Application.Features.UserOperationClaims.Dtos
{
    public class UserOperationClaimListDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public int OperationClaimId { get; set; }
        public string OperationClaimName { get; set; }

    }
}
