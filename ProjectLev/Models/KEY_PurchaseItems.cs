//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectLev.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KEY_PurchaseItems
    {
        public int purchaseID { get; set; }
        public int itemID { get; set; }
        public Nullable<double> pricePerItem { get; set; }
        public Nullable<int> quantity { get; set; }
    
        public virtual TblItem TblItem { get; set; }
        public virtual TblPurchase TblPurchase { get; set; }
    }
}