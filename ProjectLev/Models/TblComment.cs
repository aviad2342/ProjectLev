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
    
    public partial class TblComment
    {
        public int ID { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public System.DateTime sendingDate { get; set; }
        public Nullable<System.DateTime> readingDate { get; set; }
        public Nullable<byte> isOpened { get; set; }
        public string commenterID { get; set; }
        public Nullable<int> messageID { get; set; }
    
        public virtual TblUser TblUser { get; set; }
        public virtual TblMessage TblMessage { get; set; }
    }
}
