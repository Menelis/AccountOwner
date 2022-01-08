using Autofac;
using Core.Interfaces.UseCases.AccountTypeUseCases;
using Core.Interfaces.UseCases.AccountUseCases;
using Core.Interfaces.UseCases.CustomerUseCases;
using Core.Interfaces.UseCases.TransactionTypeUseCases;
using Core.UseCases.AccountTypeUseCases;
using Core.UseCases.AccountUseCases;
using Core.UseCases.CustomerUseCases;
using Core.UseCases.TransactionTypesUseCases;

namespace Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // Customer 
            builder.RegisterType<CreateOrUpdateCustomerUseCase>().As<ICreateOrUpdateCustomerUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetAllCustomersUseCase>().As<IGetAllCustomersUseCase>().InstancePerLifetimeScope();


            // Account
            builder.RegisterType<CreateAccountUseCase>().As<ICreateAccountUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<AccountTransferUseCase>().As<IAccountTransferUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetAccountBalancesUseCase>().As<IGetAccountBalancesUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetAccountTranferHistoryUseCase>().As<IGetAccountTranferHistoryUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetAllAccountsUseCase>().As<IGetAllAccountsUseCase>().InstancePerLifetimeScope();

            // Account Type
            builder.RegisterType<GetAllAccountTypesUseCase>().As<IGetAllAccountTypesUseCase>().InstancePerLifetimeScope();

            // Transaction Types
            builder.RegisterType<GetAllTransactionTypesUseCase>().As<IGetAllTransactionTypesUseCase>().InstancePerLifetimeScope();
            
        }
    }
}