namespace ComputerPeripheralsShop.DB
{
    public class User
    {
        public User() { }
        public int User_Id { get; set; }
        public string Login { get; set; }
        public string Password_Hash { get; set; }
        public decimal Balance { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
    }
}
