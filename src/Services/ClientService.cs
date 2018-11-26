using Entities;
using Entities.DTOs;
using Storage;
using System;
using System.Linq;
using static Support.Constants.Messages;

namespace Services
{
    public class ClientService
    {
        private readonly CreditCardService _creditCardService;

        public ClientService()
        {
            _creditCardService = new CreditCardService();
        }

        public void Save(ClienteDTO client)
        {
            if (client.Cliente.IsNew())
                VerifyIsExist(client.Cliente);

            using(var transaction = Context.Session.BeginTransaction())
            {
                try
                {
                    Context.Session.SaveOrUpdate(client.Cliente);
                    _creditCardService.Save(client.Tarjetas);
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(MSG_CLIENT_SAVE_ERROR, ex.InnerException);
                }
            }
        }

        private void VerifyIsExist(Cliente cliente)
        {
            var exist = Context.Session.Query<Cliente>().Where(c => (c.TipoDocumento == cliente.TipoDocumento && c.NroDocumento == cliente.NroDocumento) || c.Cuil == cliente.Cuil).Count() != 0;
            if (exist)
                throw new Exception(MSG_CLIENT_DUPLICATED);
        }
    }
}
