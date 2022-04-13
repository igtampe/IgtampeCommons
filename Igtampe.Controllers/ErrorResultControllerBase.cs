﻿using Microsoft.AspNetCore.Mvc;

namespace Igtampe.Controllers {

    /// <summary>Controller base with shortcuts to the errorresult returns</summary>
    public class ErrorResultControllerBase : ControllerBase {
        
        /// <summary>400 Bad Request</summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public BadRequestObjectResult BadRequest(string Message) => base.BadRequest(ErrorResult.BadRequest(Message));

        /// <summary>401 Unauthorized: An invalid session has been provided</summary>
        /// <returns></returns>
        public UnauthorizedObjectResult InvalidSession() => base.Unauthorized(ErrorResult.Reusable.InvalidSession);

        /// <summary>401 Unauthorized</summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public UnauthorizedObjectResult Unauthorized(string Message) => base.Unauthorized(ErrorResult.Unauthorized(Message));

        /// <summary>403 Forbidden: Missing specified roles.<br/><br/>NOTE: Due to Forbid(), these are sent back as 401 Unauthorized</summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public UnauthorizedObjectResult ForbiddenRoles(params string[] Message) => base.Unauthorized(ErrorResult.ForbiddenRoles(string.Join(", ",Message)));

        /// <summary>403 Unauthorized: Some other reason<br/><br/>NOTE: Due to Forbid(), these are sent back as 401 Unauthorized</summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public UnauthorizedObjectResult Forbidden(string Message) => base.Unauthorized(ErrorResult.Forbidden(Message));
        
        /// <summary>404 Not Found</summary>
        /// <param name="Message"></param>
        /// <returns></returns>
        public NotFoundObjectResult NotFound(string Message) => base.NotFound(ErrorResult.NotFound(Message));

        /// <summary>404 Not Found: Identifiable was not found</summary>
        /// <typeparam name="E"></typeparam>
        /// <typeparam name="F"></typeparam>
        /// <param name="Identifiable"></param>
        /// <returns></returns>
        public NotFoundObjectResult NotFoundIdentifiable<E,F>(E Identifiable) where E : Identifiable<F> 
            => NotFoundItem(nameof(E),Identifiable.ID);

        /// <summary>404 Not Found: Object was not found</summary>
        /// <param name="ItemName"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public NotFoundObjectResult NotFoundItem(string ItemName, object? ID)
            => base.NotFound(ErrorResult.NotFound($"{ItemName} with ID '{ID}' was not found"));

    }
}
