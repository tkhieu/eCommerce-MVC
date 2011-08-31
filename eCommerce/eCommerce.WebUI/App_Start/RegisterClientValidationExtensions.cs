using DataAnnotationsExtensions.ClientValidation;

[assembly: WebActivator.PreApplicationStartMethod(typeof(eCommerce.WebUI.App_Start.RegisterClientValidationExtensions), "Start")]
 
namespace eCommerce.WebUI.App_Start {
    public static class RegisterClientValidationExtensions {
        public static void Start() {
            DataAnnotationsModelValidatorProviderExtensions.RegisterValidationExtensions();            

        }
    }
}