using ChapterOi.Controllers;
using ChapterOi.Interfaces;
using ChapterOi.Models;
using ChapterOi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.IdentityModel.Tokens.Jwt;

namespace TesteIntegração
{
    public class loginControllerTest
    {
        [Fact]
        public void LoginController_Retornar_Usuario_Invalido()
        {
            //arrange - preparação
            var repositoryEspelhado = new Mock<IUsuarioRepository>();

            repositoryEspelhado.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns((Usuario)null);

            var controller = new LoginController(repositoryEspelhado.Object);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.Email = "batatinha123@frita.com";
            dadosUsuario.Senha = "fritinha4";

            //act- ação
            var resultado = controller.Login(dadosUsuario);

            //assert - verificação
            Assert.IsType<UnauthorizedObjectResult>(resultado);
        }

        [Fact]
        public void LoginController_Retornar_Token()
        {
            //arrange - preparação

            Usuario usuarioRetornado = new Usuario();
            usuarioRetornado.Email = " email@email.com ";
            usuarioRetornado.Senha = " 1234 ";
            usuarioRetornado.Tipo = " 0 ";
            usuarioRetornado.id = 1;

            var repositoryEspelhado = new Mock<IUsuarioRepository>();

            repositoryEspelhado.Setup(x => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(usuarioRetornado);

            LoginViewModel dadosUsuario = new LoginViewModel();
            dadosUsuario.Email = " batata@email.com ";
            dadosUsuario.Senha = " batata ";

            var controller = new LoginController(repositoryEspelhado.Object);

            string issuervalido = " capítulo.webapi ";

            //act- ação
            OkObjectResult resultado = (OkObjectResult)controller.Login(dadosUsuario);

            string tokenString = resultado.Value.ToString().Split(' ')[3];

            var jwtHandler = new JwtSecurityTokenHandler();

            var tokenJwt = jwtHandler.ReadJwtToken(tokenString);

            //assert - verificação
            Assert.Equal(issuervalido, tokenJwt.Issuer);
        }
    }
}