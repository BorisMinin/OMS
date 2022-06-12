using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.API.Models.Dtos.ProductDto
{
    /// <summary>
    /// todo: написать комментарий
    /// </summary>
    public class ProductDtoUpdate
    {
        // todo: написать комментарий
        public int? CategoryID { get; set; }
        // todo: написать комментарий
        public string QuantityPerUnit { get; set; }
        // todo: написать комментарий
        public decimal? UnitPrice { get; set; }
        // todo: написать комментарий
        public short? UnitsInStock { get; set; }
        // todo: написать комментарий
        public short? UnitsOnOrder { get; set; }
        // todo: написать комментарий
        public short? ReorderLevel { get; set; }
        // todo: написать комментарий
        public bool Discontinued { get; set; }
    }
}