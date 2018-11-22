using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class MenuCard
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
        public bool Active { get; set; }
        public int Order { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }
    }
}
