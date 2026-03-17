namespace PortalHub.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string  FirstName { get; set; }
        public string MiddleName { get; set; }
        public string  LastName { get; set; }
        public int RoleId { get; set; }
        public string RoleName{ get; set; }
        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
    }
}
