using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace big_wallet.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }    
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve possuir 11 caracteres")]
        public string cpf { get; set; }
        public DateOnly date_registration { get; set; }

        public TimeOnly time_registration { get; set; }

    }
}
