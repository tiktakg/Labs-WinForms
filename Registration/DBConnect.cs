using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Registration
{
    
    public class roles
    {
        [Key]
        public int id_role { get; set; }
        public string name_role { get; set; }

    }

    public class user_data
    {
        [Key]
        public int id_user { get; set; }
        public string login_user { get; set; }
        public string password_user { get; set; }
        public int id_role { get; set; }

    }
    public class DBContext : DbContext
    {
        public DBContext() : base("DbConnect")
        {
        }
       
        public DbSet<user_data> user_data { get; set; } = null;
        public DbSet<roles> Roles { get; set; } = null;

    }   
}
