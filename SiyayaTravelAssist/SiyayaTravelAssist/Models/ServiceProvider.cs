//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiyayaTravelAssist.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServiceProvider
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServiceProvider()
        {
            this.VehicleMaintenances = new HashSet<VehicleMaintenance>();
        }
    
        public int ServiceProviderID { get; set; }
        public string ServiceProviderName { get; set; }
        public string Telephone { get; set; }
        public string EmailAddress { get; set; }
        public string PhysicalAddress { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VehicleMaintenance> VehicleMaintenances { get; set; }
    }
}
