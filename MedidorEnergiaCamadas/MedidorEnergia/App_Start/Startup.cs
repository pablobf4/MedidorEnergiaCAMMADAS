using MedidorEnergia.Identity.Configuração;
using MedidorEnergia.Identity.Modelo;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(MedidorEnergia.App_Start.Startup))]
namespace MedidorEnergia.App_Start
{
    public partial class Startup
    {
        public static IDataProtectionProvider DataProtectionProvider { get; set; }

        
        public void Configuration(IAppBuilder app)
        {
            // Configurar o contexto db, o gerenciador de usuários e o gerenciador de login para usar uma única instância por solicitação
            app.CreatePerOwinContext(() => DependencyResolver.Current.GetService<ApplicationUserManager>());
            // Habilitar o aplicativo para usar um cookie para armazenar informações para o usuário conectado
            // e usar um cookie para armazenar temporariamente informações sobre o login de um usuário com um provedor de login de terceiros
            // Configurar o sinal no cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Permite que o aplicativo valide o carimbo de segurança quando o usuário efetua login.
                    // Este é um recurso de segurança que é usado quando você altera uma senha ou adiciona um login externo à sua conta.
  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            // Permite que o aplicativo armazene temporariamente as informações do usuário ao verificar o segundo fator no processo de autenticação de dois fatores.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "",
            //    ClientSecret = ""
            //});
        }
    }
}