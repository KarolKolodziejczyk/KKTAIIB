using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface BasketPostionBLL {
        public void AddToBasket(ProductResponseDTO a);
        public void DeleteFromBasket(ProductResponseDTO a);
        public void DeleteFromBasket(int id);
        public void ChangeAmount(ProductResponseDTO a, int amount);
        public void ChangeAmount(int id, int amount);

        public IEnumerable<BasketPositionResponseDTO> GetBasket(UserResponseDTO user);

        public OrderRequestDTO Order(UserResponseDTO user);


    }
}
