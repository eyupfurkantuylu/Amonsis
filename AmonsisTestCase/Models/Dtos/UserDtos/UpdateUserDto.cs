namespace AmonsisTestCase.Models.Dtos.UserDtos
{
    public class UpdateUserDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Location { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime CreaDate { get; set; }
    }
}
