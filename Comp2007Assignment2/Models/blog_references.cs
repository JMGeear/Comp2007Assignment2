//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Comp2007Assignment2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class blog_references
    {
        public int referenceID { get; set; }
        public Nullable<int> blogID { get; set; }
        public int bookID { get; set; }
        public int chapterID { get; set; }
        public int verseID { get; set; }
    
        public virtual blog blog { get; set; }
    }
}