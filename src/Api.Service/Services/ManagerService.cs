using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Manager;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services.Odoo.Configuration.New;
using Api.Service.Services.Odoo.Docker.Compose.New;
using Api.Service.Services.Odoo.Docker.Launch.CRM;

namespace Api.Service.Services
{
    public class ManagerService : IManagerService
    {
        private IRepository<ManagerEntity> _repository2;
        public ManagerService(IRepository<ManagerEntity> repository)
        {
            _repository2 = repository;
        }
        public async Task<bool> Delete(Guid id)
        {
            return await _repository2.DeleteAsync(id);
        }

        public async Task<ManagerEntity> Get(Guid id)
        {
            return await _repository2.SelectAsync(id);
        }

        public async Task<IEnumerable<ManagerEntity>> GetAll()
        {
            return await _repository2.SelectAsync();
        }

        public async Task<ManagerEntity> Post(ManagerEntity manager)
        {
            return await _repository2.InsertAsync(manager);
        }

        public async Task<ManagerEntity> Put(ManagerEntity manager)
        {

            //Odoo Configuration (Logfile & Conf)
            Newconfiguration newconfiguration = new Newconfiguration(manager.Email.ToString());
            //Image: apeninos / asasaas_odoo:version11.0
            //Compose Configuration
            Newcompose newcompose = new Newcompose(manager.Email.ToString(),
                                                manager.Crm_PORT.ToString(),
                                     "apeninos/asasaas_odoo:version11.0");
            //New Launch
            NewlaunchCRM newlaunch = new NewlaunchCRM(manager.Email.ToString());
            return await _repository2.UpdateAsync(manager);
        }
    }
}
