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
    
    public partial class TblItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblItem()
        {
            this.KEY_PurchaseItems = new HashSet<KEY_PurchaseItems>();
        }
    
        public int ID { get; set; }
        public Nullable<int> itemType { get; set; }
        public string itemName { get; set; }
        public Nullable<double> price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KEY_PurchaseItems> KEY_PurchaseItems { get; set; }
        public virtual TblSubscription TblSubscription { get; set; }
    }
}
