import { HttpErrorResponse } from '@angular/common/http';
import { LoaderService } from '@shared/components/loader/loader.service';
import { ToastrService } from 'ngx-toastr';
import { Observable, pipe, throwError } from 'rxjs';
import { catchError, finalize, map } from 'rxjs/operators';
import { HttpStatusCode } from './http-status-code';

export class GenericCommandResponse<T> {
    statusCode?: HttpStatusCode;
    mensagem?: string;
    dados?: T;
}

export class GenericCommandError {
    statusCode?: HttpStatusCode;
    mensagemErro?: string;
    tituloToastr?: string;

    constructor(statusCode: HttpStatusCode, mensagemErro: string, tituloToastr = '') {
        this.mensagemErro = mensagemErro;
        this.statusCode = statusCode;
        this.tituloToastr = tituloToastr;
    }
}


export class HandlerErrorUtils {

    public static handler(error: HttpErrorResponse, defaultMsg = 'Ocorreu um erro inesperado tente novamente.'): GenericCommandError {
        try {
            const err: any = error.error;
            const statusCode = error.status || HttpStatusCode.INTERNAL_SERVER_ERROR;

            if (err == null) { return new GenericCommandError(statusCode, defaultMsg); }

            if (typeof err === 'string') { return new GenericCommandError(statusCode, err); }

            // eslint-disable-next-line @typescript-eslint/dot-notation
            const errorsList = err['dados'];
            const tituloToastr = err['mensagem'];

            if (errorsList) {
                let errorMessage = '';

                for (const value of Object.values(errorsList)) {
                    if (Array.isArray(value)) {
                        for (const message of value) {
                            errorMessage += '\u2022 ' + message + '\n';
                        }
                    }
                }

                return new GenericCommandError(statusCode, errorMessage, tituloToastr);
            }

            const errorMsg = err['mensagem'];
            if (errorMsg && typeof errorMsg === 'string') {
                return new GenericCommandError(statusCode, errorMsg);
            }

            return new GenericCommandError(statusCode, defaultMsg);
        } catch (e) {
            return new GenericCommandError(error.status || HttpStatusCode.INTERNAL_SERVER_ERROR, defaultMsg);
        } finally {
            console.error('handler', error);
        }
    }
}

export function handlerErrorResponse(defaultMsg = 'Ocorreu um erro inesperado tente novamente.', toastr: ToastrService | undefined = undefined) {
    return pipe(
        catchError<any, Observable<GenericCommandError>>((err: HttpErrorResponse) => {
            const error = HandlerErrorUtils.handler(err, defaultMsg);
            toastr?.warning(error.mensagemErro);

            return throwError(error);
        })
    );
}

export function handlerErrorResponseToastr(toastr: ToastrService | undefined = undefined) {
    return pipe<any, any>(
        catchError<GenericCommandError, Observable<GenericCommandError>>((err: GenericCommandError) => {
            toastr?.warning(err?.mensagemErro, err?.tituloToastr);
            return throwError(() => err);
        })
    );
}


export function handlerSuccessResponseToastr<T>(toastr: ToastrService | undefined = undefined) {
    return pipe<any, any>(
        map((response: any) => {
            if (response?.mensagem) { toastr?.success(response?.mensagem); }
            return response.hasOwnProperty('dados') ? response['dados'] : response;
        }),
    );
}

export function closeLoading(loader: LoaderService) {
    return finalize(() => loader.encerrarLoader())
}
