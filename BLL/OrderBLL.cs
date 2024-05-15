using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace BibliotekaKlasModel
{
    public interface OrderBLL 
    {
        public IEnumerable<OrderResponseDTO> GetAllOrders();
        public IEnumerable<OrderResponseDTO> GetOrderByUser(UserResponseDTO user);
        public OrderResponseDTO GetOrderById(int id);
        public IEnumerable<OrderPositionResponseDTO> GetPositions(int id);
    }
}
