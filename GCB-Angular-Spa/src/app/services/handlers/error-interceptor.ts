import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { GenericCommandError, handlerErrorResponse } from '@services/handlers/handlers';
import { HttpStatusCode } from '@services/handlers/http-status-code';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(
        // private router: Router,
    ) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            handlerErrorResponse(),
            catchError<any, any>((err: GenericCommandError) => {
                if (err.statusCode === HttpStatusCode.FORBIDDEN) {
                    err.mensagemErro = 'Você não tem permissão para acessar está funcionalidade.';
                }

                return throwError(() => err);
            })
        );
    }
}
