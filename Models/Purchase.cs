using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Suppliers.Models
{
    [Table("Purchase")]
    public class Purchase
    {
        /// <summary>
        /// id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }
        /// <summary>
        /// Name of employee
        /// </summary>
        [Column("employee_name")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Name of product purchased
        /// </summary>
        [Column("product_name")]
        public string ProductName { get; set; }

        /// <summary>
        /// Quantity of product
        /// </summary>
        [Column("quantity")]
        public int Quantity { get; set; }

        /// <summary>
        /// Price of product
        /// </summary>
        [Column("price")]
        public decimal Price { get; set; }
        /// <summary>
        /// Date of purchase
        /// </summary>
        [Column("date")]
        public DateTime? Date { get; set; }
    }
}
