using CMD.Business;
using CMD.DataAccess.CMDRepository;
using CMD.DataAccess.ICMDRepository;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace CMD.APIService
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ITestService, TestService>();
            container.RegisterType<IAppointmentService, AppointmentService>();
            container.RegisterType<ICommentService, CommentService>();
            container.RegisterType<IFeedbackService, FeedbackService>();
            container.RegisterType<IDoctorService, DoctorService>();
            container.RegisterType<IPatientService, PatientService>();
            container.RegisterType<IVitalsService, VitalsService>();
            container.RegisterType<IPrescriptionService, PrescriptionService>();
            container.RegisterType<IRecommendationService, RecommendationService>();


            container.RegisterType<ITestRepository, TestRepository>();
            container.RegisterType<IAppointmentRepository, AppointmentRepository>();
            container.RegisterType<ICommentRepository, CommentRepository>();
            container.RegisterType<IFeedBackRepository, FeedBackRepository>();
            container.RegisterType<IDoctorRepository, DoctorRepository>();
            container.RegisterType<IPatientRepository, PatientRepository>();
            container.RegisterType<IVitalRepository, VitalRepository>();
            container.RegisterType<IPrescriptionRepository, PrescriptionRepository>();
            container.RegisterType<IRecommendationRepository, RecommendationRepository>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}