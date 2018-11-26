using Entities;
using Entities.DTOs;
using Storage;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CreditCardService
    {
        public void Save(List<TarjetaCreditoDTO> cards)
        {
            Merge(cards);
            foreach (var card in cards.Where(c => c.Tarjeta.IsNew()))
                CreateCreditCard(card);
        }

        private void CreateCreditCard(TarjetaCreditoDTO card)
        {
            Context.Session.SaveOrUpdate(card.Tarjeta);
        }

        private void Merge(List<TarjetaCreditoDTO> cards)
        {
            var currentCards = Context.Session.Query<TarjetaCredito>().Where(tc => tc.ClienteId == cards.First().Tarjeta.ClienteId && tc.Activa);
            foreach(var card in currentCards)
            {
                if(cards.Where(c => c.Tarjeta.Numero == card.Numero).Count() == 0)
                {
                    card.Activa = false;
                    Context.Session.SaveOrUpdate(card);
                }
            }
        }

        public List<TipoTarjetaCredito> GetAllTypes()
        {
            return Context.Session.Query<TipoTarjetaCredito>().OrderBy(t => t.Descripcion).ToList();
        }
    }
}
