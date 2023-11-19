using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace big_wallet.Models
{
    public class Coin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string id_key { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        

    }

}
