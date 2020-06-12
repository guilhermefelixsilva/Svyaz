using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces;
using Api.Domain.Interfaces.Services.Manager;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services.Odoo.Configuration.New.CRM;
using Api.Service.Services.Odoo.Configuration.New.Faturamento;
using Api.Service.Services.Odoo.Configuration.New.Site;
using Api.Service.Services.Odoo.Configuration.New.Vendas;
using Api.Service.Services.Odoo.Docker.Compose.New.CRM;
using Api.Service.Services.Odoo.Docker.Compose.New.Faturamento;
using Api.Service.Services.Odoo.Docker.Compose.New.Site;
using Api.Service.Services.Odoo.Docker.Compose.New.Vendas;
using Api.Service.Services.Odoo.Docker.Launch.CRM;
using Api.Service.Services.Odoo.Docker.Launch.Faturamento;
using Api.Service.Services.Odoo.Docker.Launch.Site;
using Api.Service.Services.Odoo.Docker.Launch.Vendas;

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
            #region CRM IMPLEMENTATION

            var repository2up = await _repository2.UpdateAsync(manager);

            if (manager.Crm_START == true)
            {

                //-----------------------------------------------------------
                //New LAUNCH TO CRM MODULE
                //Odoo Configuration (Logfile & Conf)
                NewconfigurationCRM newconfigurationCRM = new NewconfigurationCRM(manager.Email.ToString());
                //Image: apeninos / asasaas_odoo:version11.0
                //Compose Configuration
                NewcomposeCRM newcomposeCRM = new NewcomposeCRM(manager.Email.ToString(),
                                                    manager.Crm_PORT.ToString(),
                                         "apeninos/asasaas_odoo:version11.0");
                //New Launch
                NewlaunchCRM newlaunchCRM = new NewlaunchCRM(manager.Email.ToString());
            }
            #endregion

            #region FATURAMENTO IMPLEMENTATION

            if (manager.Faturamento_START == true)
            {
                //-----------------------------------------------------------
                //New LAUNCH TO CRM MODULE
                //Odoo Configuration (Logfile & Conf)
                NewconfigurationFaturamento newconfigurationFaturamento = new NewconfigurationFaturamento(manager.Email.ToString());
                //Image: apeninos / asasaas_odoo:version11.0
                //Compose Configuration
                NewcomposeFaturamento newcomposeFaturamento = new NewcomposeFaturamento(manager.Email.ToString(),
                                                    manager.Faturamento_PORT.ToString(),
                                         "apeninos/asasaas_odoo:version11.0");
                //New Launch
                NewlaunchFaturamento newlaunchFaturamento = new NewlaunchFaturamento(manager.Email.ToString());
            }
            #endregion

            #region SITE IMPLEMENTATION

            if (manager.Site_START == true)
            {
                //-----------------------------------------------------------
                //New LAUNCH TO CRM MODULE
                //Odoo Configuration (Logfile & Conf)
                NewconfigurationSite newconfigurationSite = new NewconfigurationSite(manager.Email.ToString());
                //Image: apeninos / asasaas_odoo:version11.0
                //Compose Configuration
                NewcomposeSite newcomposeSite = new NewcomposeSite(manager.Email.ToString(),
                                                    manager.Site_PORT.ToString(),
                                         "apeninos/asasaas_odoo:version11.0");
                //New Launch
                NewlaunchSite newlaunchSite = new NewlaunchSite(manager.Email.ToString());
            }
            #endregion

            #region VENDAS IMPLEMENTATION
            if (manager.Vendas_START == true)
            {
                //-----------------------------------------------------------
                //New LAUNCH TO CRM MODULE
                //Odoo Configuration (Logfile & Conf)
                NewconfigurationVendas newconfigurationVendas = new NewconfigurationVendas(manager.Email.ToString());
                //Image: apeninos / asasaas_odoo:version11.0
                //Compose Configuration
                NewcomposeVendas newcomposeVendas = new NewcomposeVendas(manager.Email.ToString(),
                                                    manager.Vendas_PORT.ToString(),
                                         "apeninos/asasaas_odoo:version11.0");
                //New Launch
                NewlaunchVendas newlaunchVendas = new NewlaunchVendas(manager.Email.ToString());
            }
            #endregion

            return repository2up;

        }
    }
}
