namespace OnlineEdu.WebUI.DTOS.UserDtos
{
    public class ResultUserWithRolesDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}
