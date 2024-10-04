using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using LGG.LenayGestorGatos.Domain.DTOs.Usuario;
using LGG.LenayGestorGatos.Domain.Interfaces.Infraestructure;

namespace LGG.LenayGestorGatos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ApiController
{
    private readonly IFireAuthInfraestructure _fireAuthInfraestructure;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="appController"></param>
    public AuthController(IApiController appController, IFireAuthInfraestructure fireAuthInfraestructure) : base(appController)
    {
        _fireAuthInfraestructure = fireAuthInfraestructure;
    }

    /// <summary>
    /// Consulta un registro de la tabla GI_Persona
    /// </summary>
    [HttpPost("GetPersona")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> GetPersona()
    {
        return Ok(await _appController.PersonaPresenter.GetPersona());
    }

    /// <summary>
    /// Agrega un registro a la tabla GI_Persona
    /// </summary>
    [HttpPost("AddPersona")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> AddPersona([FromBody] PersonaAggregate aggregate)
    {
        return Ok(await _appController.PersonaPresenter.AddPersona(aggregate));
    }

    /// <summary>
    /// Inicia sesión y devuelve un token
    /// </summary>
    /// <remarks>
    /// Sample request: 
    /// 
    ///     POST 
    ///       {
    ///         "email": "user@example.com",
    ///         "password": "password"
    ///       }
    /// </remarks>   
    /// <response code="200">string</response>  
    /// <response code="400">string</response> 
    /// <response code="500">string</response> 
    [HttpPost("SignIn")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public async ValueTask<IActionResult> SignIn([FromBody] SignInRequest request)
    {
        var respuesta = await _fireAuthInfraestructure.SignIn(request.Email, request.Password);
        if (respuesta.TipoError == 0)
        {
            return Ok(respuesta.Mensaje); // Return token
        }
        return BadRequest(respuesta.Mensaje);
    }
}

// DTO for SignIn request
public class SignInRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}
