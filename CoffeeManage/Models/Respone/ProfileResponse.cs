namespace CoffeeManage.Models.Respone
{
    public class ProfileResponse
    {
        public int UserID { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string Avatar { get; set; }

        public DateTime CreatedAt { get; set; }

        public int Status { get; set; }
    }
}
