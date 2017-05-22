using CEMEX.API.Infrastructure.Core;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using CEMEX.Data.Infrastructure;
using CEMEX.Data.Repositories;
using CEMEX.Entidades.Seguridad;
using System.Web.Http;
using System.Net.Http;
using CEMEX.API.Models.Seguridad;
using System.Net;
using CEMEX.Data.Extensions.Seguridad;
using System.Web.Configuration;
using AutoMapper;
using CEMEX.API.Infrastructure.Extensions;
using CEMEX.Entidades;

namespace CEMEX.API.Controllers.Seguridad
{
    [RoutePrefix("api/Usuario")]
    public class UsuariosController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Usuario> _usuariosRepository;
        public UsuariosController(IEntityBaseRepository<Usuario> usuariosRepository,
                                  IEntityBaseRepository<Error> errorRepository,
                                  IUnitOfWork unitOfWork)
            : base(errorRepository, unitOfWork)
        {
            _usuariosRepository = usuariosRepository;
        }

        [HttpGet]
        [Route("list")]
        //[Authorize]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                IEnumerable<UsuarioViewModel> _usuariosVM = Mapper.Map<IEnumerable<Usuario>,
                                                                       IEnumerable<UsuarioViewModel>>
                                                                       (_usuariosRepository.GetAll().ToList());

                response = request.CreateResponse(HttpStatusCode.OK, _usuariosVM);

                return response;
            });
        }


        [Route("register")]
        //[Authorize]
        [HttpPost]
        public HttpResponseMessage Register(HttpRequestMessage request, UsuarioViewModel usuarioVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,
                                                      ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                                                     .Select(u => u.ErrorMessage).ToArray());
                } else
                {
                    var _usuario = _usuariosRepository.GetSingleByUserName(usuarioVM.NombreUsuario.Trim(), usuarioVM.Email.Trim());

                    if (_usuario == null)
                    {
                        Usuario newUsuario = new Usuario();
                        newUsuario.UpdateUsuario(usuarioVM);
                        _usuariosRepository.Add(newUsuario);
                        _unitOfWork.Commit();

                        usuarioVM = Mapper.Map<Usuario, UsuarioViewModel>(newUsuario);
                        response = request.CreateResponse(HttpStatusCode.Created, usuarioVM);
                    } else
                    {
                        response = request.CreateResponse(HttpStatusCode.Accepted, "El Nombre de Usuario ya existe.");
                    }
                }

                return response;
            });
        }


        [HttpPost]
        //[AllowAnonymous]
        [Route("authenticate")]
        public HttpResponseMessage Authenticate(HttpRequestMessage request, CredentialViewModel credentialVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest,
                               ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                               .Select(m => m.ErrorMessage).ToArray());
                } else
                {

                    var _usuario = _usuariosRepository.GetSingleByEmailAddress(credentialVM.EmailAddress);

                    if (_usuario == null)
                    {
                        response = request.CreateResponse(HttpStatusCode.Unauthorized);
                    } else
                    {

                        if (string.Equals(EncryptionService.EncriptarPassowrd(credentialVM.Password.Trim(), _usuario.Salt),
                                          _usuario.HashedContraseña.Trim()))
                        {
                            var lifetimeInMinutes = int.Parse(WebConfigurationManager.AppSettings["TokenLifetimeInMinutes"]);
                            var token = CrearToken(_usuario.ID.ToString(), _usuario.NombreUsuario, lifetimeInMinutes);

                            response = request.CreateResponse(HttpStatusCode.OK, new
                            {
                                Token = token,
                                LifetimeInMinutes = lifetimeInMinutes,
                                FullName = _usuario.NombreUsuario
                            });
                        }
                        else
                        {
                            response = request.CreateResponse(HttpStatusCode.Unauthorized);
                        }
                    }
                }

                return response;
            });
        }


        [HttpGet]
        [Route("search/{page:int=0}/{pageSize=4}/{filter?}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int? page, int? pageSize, string filter=null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, ()=>
            {
                HttpResponseMessage response = null;
                List<Usuario> _usuarios = null;
                int totalUsuarios = new int();

                if (!string.IsNullOrEmpty(filter))
                {
                    //filter = filter.Trim().ToLower();
                    //_usuarios = _usuariosRepository.FindBy(c => c.NombreUsuario.ToLower().Contains(filter) || )
                }else
                {
                    _usuarios = _usuariosRepository.GetAll()
                                .OrderBy(u => u.ID)
                                .Skip(currentPage * currentPageSize)
                                .Take(currentPageSize)
                                .ToList();

                    totalUsuarios = _usuariosRepository.GetAll().Count();
                }

                IEnumerable<UsuarioViewModel> _usuariosVM = Mapper.Map<IEnumerable<Usuario>, IEnumerable<UsuarioViewModel>>(_usuarios);

                PaginationSet<UsuarioViewModel> pagedSet = new PaginationSet<UsuarioViewModel>()
                {
                    Page = currentPage,
                    TotalCount = totalUsuarios,
                    TotalPages = (int)Math.Ceiling((decimal)totalUsuarios / currentPageSize),
                    Items = _usuariosVM
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });

        }


        public static string CrearToken(string userId, string fullName, int lifeTimeInMinutes)
        {
            var claimsIdentity = new ClaimsIdentity(new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userId),
                new Claim("name", fullName)
            });

            var now = DateTime.UtcNow;
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Issuer = SecurityConfiguration.TokenIssuer,
                Audience = SecurityConfiguration.TokenAudience,
                SigningCredentials = SecurityConfiguration.SigningCredential,
                IssuedAt = now,
                Expires = now.AddMinutes(lifeTimeInMinutes)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}