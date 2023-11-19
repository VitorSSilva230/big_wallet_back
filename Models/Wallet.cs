using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace big_wallet.Models
{
    public class Wallet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int id_user { get; set; }
        public string id_key_coin { get; set; }
        public double amount { get; set; }

    }
}
