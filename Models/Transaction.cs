using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace big_wallet.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int id_user { get; set; }
        public string currency_pair { get; set; }
        public double quantity_base_coin { get; set; }
        public double quantity_acquired_coin { get; set; }
        public string type { get; set; }
        public DateOnly date_transaction { get; set; }
        public TimeOnly time_transaction { get; set; }


    }
}
