using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UiPath.CodedWorkflows;
using UiPath.CodedWorkflows.Interfaces;
using UiPath.Activities.Contracts;
using NWUTechTrendsTelemetryPortalUserAcceptanceTesting;

[assembly: WorkflowRunnerServiceAttribute(typeof(NWUTechTrendsTelemetryPortalUserAcceptanceTesting.WorkflowRunnerService))]
namespace NWUTechTrendsTelemetryPortalUserAcceptanceTesting
{
    public class WorkflowRunnerService
    {
        private readonly ICodedWorkflowServices _services;
        public WorkflowRunnerService(ICodedWorkflowServices services)
        {
            _services = services;
        }

        /// <summary>
        /// Invokes the Main.xaml
        /// </summary>
        public void Main(string Email, string Password)
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"Main.xaml", new Dictionary<string, object>{{"Email", Email}, {"Password", Password}}, default, default, default, GetAssemblyName());
        }

        /// <summary>
        /// Invokes the Login.cs
        /// </summary>
        public void Login()
        {
            var result = _services.WorkflowInvocationService.RunWorkflow(@"Login.cs", new Dictionary<string, object>{}, default, default, default, GetAssemblyName());
        }

        private string GetAssemblyName()
        {
            var assemblyProvider = _services.Container.Resolve<ILibraryAssemblyProvider>();
            return assemblyProvider.GetLibraryAssemblyName(GetType().Assembly);
        }
    }
}