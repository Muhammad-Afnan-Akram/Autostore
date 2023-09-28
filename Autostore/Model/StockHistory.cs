using Microsoft.Data.SqlClient.DataClassification;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Autostore.Model
{
    public enum ForAction
    {
        Purchase,
        Sale
    }
    public class StockHistory
    {
        [Key]
        public int StockHistoryId { get; set; }
        public int StockId { get; set;}
        public ForAction Action { get; set; }
        public int QuantityChanged { get; set; }
        public DateTime DateChanged {  get; set; }
        public string Notes { get; set; }
       
        
      
    }
}