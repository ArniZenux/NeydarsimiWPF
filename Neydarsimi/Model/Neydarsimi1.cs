//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Neydarsimi.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Neydarsimi1
    {
        public int nr { get; set; }
        public string byrja { get; set; }
        public string endir { get; set; }
        public string timi_byrja { get; set; }
        public string timi_endir { get; set; }
        public string tegund { get; set; }
    
        public virtual Vinna Vinna { get; set; }
    }
}
