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
    
    public partial class Order
    {
        public int Order_Id { get; set; }
        public int User_Id { get; set; }
        public int Order_List_Id { get; set; }
        public System.DateTime Order_Date { get; set; }
        public decimal Total_Price { get; set; }
        public int Items_Number { get; set; }
    
        public virtual Order_List Order_List { get; set; }
        public virtual User User { get; set; }
    }
}