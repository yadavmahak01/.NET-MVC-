using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainClasses
{
    public class Ninja
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ServedInOwiaban { get; set; }
        public Clan Clan { get; set; }
        public int ClanId { get; set; }
        public List<NinjaEquipment> EquipmentOwned { get; set; }
    }
    public class Clan
    {
        public int Id { get; set; }
        public string CalnName { get; set; }
        public List<Ninja> Ninjas { get; set; }
    }
    public class NinjaEquipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public EquipmentType Type { get; set; }
        [Required]//this field is required nd will have 1-many relationship
        public Ninja Ninja { get; set; }
    }

}
