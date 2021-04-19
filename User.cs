//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComputerPeripheralsShopModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            this.Order = new HashSet<Order>();
        }

        public User(string login, byte[] password_hash, decimal balance, bool isAdmin, string name, string surname, string address)
        {
            this.Login = login;
            this.Password_hash = password_hash;
            this.Balance = balance;
            this.IsAdmin = isAdmin;
            this.Name = name;
            this.Surname = surname;
            this.Address = address;
        }

        public User(string login, byte[] password_hash, string name, string surname, string address)
        {
            this.Login = login;
            this.Password_hash = password_hash;
            this.Balance = 0;
            this.IsAdmin = false;
            this.Name = name;
            this.Surname = surname;
            this.Address = address;
        }

        public int User_Id { get; set; }
        public string Login { get; set; }
        public byte[] Password_hash { get; set; }
        public decimal Balance { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
