//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppPOS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Bundle
    {
        public int Id { get; set; }
        public Nullable<int> Parent { get; set; }
        public Nullable<int> Product { get; set; }
        public string descr { get; set; }
    }
}
