//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBTutorial5
{
    using System;
    using System.Collections.Generic;
    
    public partial class orderdetails
    {
        public int orderNumber { get; set; }
        public string productCode { get; set; }
        public int quantityOrdered { get; set; }
        public double priceEach { get; set; }
        public short orderLineNumber { get; set; }
    
        public virtual orders orders { get; set; }
        public virtual products products { get; set; }
    }
}
