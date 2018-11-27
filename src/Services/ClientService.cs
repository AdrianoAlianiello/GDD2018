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
            using(var transaction = Context.Session.BeginTransaction())
            {
                try
                {
                    SaveClientAndCreditCards(client);
                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(MSG_CLIENT_SAVE_ERROR, ex.InnerException);
                }
            }
        }

        private void SaveClientAndCreditCards(ClienteDTO client)
        {
            if(client.Cliente.IsNew())
            {
                client.Cliente.Activo = true;
                client.Cliente.FechaCreacion = DateTime.Now;
            }

            Context.Session.SaveOrUpdate(client.Cliente);

            foreach (var card in client.Tarjetas)
                card.Tarjeta.ClienteId = client.Cliente.Id;

            _creditCardService.Save(client.Tarjetas);
        }

        public void Register(ClienteDTO client)
        {
            try
            {
                VerifyIsExist(client.Cliente);
                SaveClientAndCreditCards(client);
            }
            catch (Exception ex)
            {
                throw new Exception(MSG_USER_REGISTRATION_ERROR_SAVING_CLIENT);
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
