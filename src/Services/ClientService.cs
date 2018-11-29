using Entities;
using Entities.DTOs;
using Entities.Views;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using static Support.Constants.Configuration;
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
            catch
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

        public List<ClienteView> GetAll(ClienteFiltroDTO filters)
        {
            return GetBaseQuery(filters)
                .OrderBy(c => c.Apellido).ThenBy(c => c.Nombre)
                .ToList()
                .Select(c => {
                    return new ClienteView()
                    {
                        Activo = c.Activo,
                        Apellido = c.Apellido,
                        Nombre = c.Nombre,
                        Cuil = c.Cuil.ToString(),
                        TipoDocumento = c.TipoDocumento,
                        NumeroDocumento = c.NroDocumento.ToString(),
                        Email = c.Mail,
                        Id = c.Id,
                        Estado = c.Activo ? CLIENT_ENABLED : CLIENT_DISABLED
                    };
                })
                .ToList();
        }

        private static IQueryable<Cliente> GetBaseQuery(ClienteFiltroDTO filters)
        {
            var query = Context.Session.Query<Cliente>();
            if (!string.IsNullOrEmpty(filters.Nombre))
                query = query.Where(c => c.Nombre.Contains(filters.Nombre));
            if (!string.IsNullOrEmpty(filters.Apellido))
                query = query.Where(c => c.Apellido.Contains(filters.Apellido));
            if (!string.IsNullOrEmpty(filters.Dni))
                query = query.Where(c => c.NroDocumento.ToString() == filters.Dni);
            if (!string.IsNullOrEmpty(filters.Mail))
                query = query.Where(c => c.Mail.Contains(filters.Mail));
            return query;
        }


    }
}
