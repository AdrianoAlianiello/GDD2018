using Entities.DTOs;
using Storage;
using System;

namespace Services
{
    public class UserRegistrationService
    {
        private readonly ClientService _clientService;
        private readonly UserService _userService;

        public UserRegistrationService()
        {
            _clientService = new ClientService();
            _userService = new UserService();
        }

        public void RegisterClient(ClienteRegistracionDTO clientRegistration)
        {
            using (var transaction = Context.Session.BeginTransaction())
            {
                try
                {
                    _userService.CreateUser(clientRegistration.Usuario, clientRegistration.Roles);
                    clientRegistration.ClienteDTO.Cliente.UsuarioId = clientRegistration.Usuario.Id;
                    _clientService.Register(clientRegistration.ClienteDTO);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }
    }
}
