using System.Collections.Generic;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.Domain.Interfaces.Services;

namespace ProjetoModeloDDD.Application.Class
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {

        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService) : base(clienteService) //injeção de dependencia do construtor  base
        {
            _clienteService = clienteService;
        }

        public IEnumerable<Cliente> ObterClientesEspeciais()
        {
            return _clienteService.ObterClientesEspeciais(_clienteService.GetAll());
        }
    }

    //application chama o serviço que chama o repositorio que usa entidade as vezes e devolve tudo
}
