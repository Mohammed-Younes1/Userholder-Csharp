﻿namespace UserholderApp.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        public string Bs { get; set; }
        //public int UsersId { get; set; }
        //public Users Users { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
