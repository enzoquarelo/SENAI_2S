using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.senai.Domains
{
    [Table(nameof(Evento))]

    public class Evento
    {
        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();


    }
}
