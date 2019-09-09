using LeanWork.AppService.Interfaces;
using LeanWork.AppService.Service;
using LeanWork.Domain.Interfaces.Repositories;
using LeanWork.Domain.Interfaces.Services;
using LeanWork.Domain.Services;
using LeanWork.Persistence.Connection;
using LeanWork.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace LeanWork.Infrastructure.CrossCutting.IoC
{
    public class InjectorContainer
    {
        public IServiceCollection ObterScopo(IServiceCollection interfaceService)
        {
            #region AppService

            interfaceService.AddScoped(typeof(ICandidatoAppService), typeof(CandidatoAppService));
            interfaceService.AddScoped(typeof(ICandidatoTecnologiaAppService), typeof(CandidatoTecnologiaAppService));
            interfaceService.AddScoped(typeof(ICandidatoVagaAppService), typeof(CandidatoVagaAppService));
            interfaceService.AddScoped(typeof(IEmpresaAppService), typeof(EmpresaAppService));
            interfaceService.AddScoped(typeof(IEmpresaTecnologiaAppService), typeof(EmpresaTecnologiaAppService));
            interfaceService.AddScoped(typeof(IEmpresaVagaAppService), typeof(EmpresaVagaAppService));
            interfaceService.AddScoped(typeof(ITecnologiaAppService), typeof(TecnologiaAppService));
            interfaceService.AddScoped(typeof(IVagaAppService), typeof(VagaAppService));
            interfaceService.AddScoped(typeof(IVagaTecnologiaAppService), typeof(VagaTecnologiaAppService));

            #endregion

            #region Service

            interfaceService.AddScoped(typeof(ICandidatoService), typeof(CandidatoService));
            interfaceService.AddScoped(typeof(ICandidatoTecnologiaService), typeof(CandidatoTecnologiaService));
            interfaceService.AddScoped(typeof(ICandidatoVagaService), typeof(CandidatoVagaService));
            interfaceService.AddScoped(typeof(IEmpresaService), typeof(EmpresaService));
            interfaceService.AddScoped(typeof(IEmpresaTecnologiaService), typeof(EmpresaTecnologiaService));
            interfaceService.AddScoped(typeof(IEmpresaVagaService), typeof(EmpresaVagaService));
            interfaceService.AddScoped(typeof(ITecnologiaService), typeof(TecnologiaService));
            interfaceService.AddScoped(typeof(IVagaService), typeof(VagaService));
            interfaceService.AddScoped(typeof(IVagaTecnologiaService), typeof(VagaTecnologiaService));

            #endregion

            #region Repository

            interfaceService.AddScoped(typeof(ICandidatoRepository), typeof(CandidatoRepository));
            interfaceService.AddScoped(typeof(ICandidatoTecnologiaRepository), typeof(CandidatoTecnologiaRepository));
            interfaceService.AddScoped(typeof(ICandidatoVagaRepository), typeof(CandidatoVagaRepository));
            interfaceService.AddScoped(typeof(IEmpresaRepository), typeof(EmpresaRepository));
            interfaceService.AddScoped(typeof(IEmpresaTecnologiaRepository), typeof(EmpresaTecnologiaRepository));
            interfaceService.AddScoped(typeof(IEmpresaVagaRepository), typeof(EmpresaVagaRepository));
            interfaceService.AddScoped(typeof(ITecnologiaRepository), typeof(TecnologiaRepository));
            interfaceService.AddScoped(typeof(IVagaRepository), typeof(VagaRepository));
            interfaceService.AddScoped(typeof(IVagaTecnologiaRepository), typeof(VagaTecnologiaRepository));
            interfaceService.AddScoped(typeof(IConnectionDB), typeof(ConnectionDB));

            #endregion

            return interfaceService;
        }
    }
}
