import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { Observable } from "rxjs";
import { filter } from "rxjs/operators";
import { environment } from "src/environments/environment";
import { handlerErrorResponseToastr, handlerSuccessResponseToastr } from "./handlers/handlers";

interface HttpOptions {
    headers?: HttpHeaders | {
        [header: string]: string | string[];
    };
    observe?: 'body';
    params?: HttpParams | {
        [param: string]: string | string[];
    };
    reportProgress?: boolean;
    responseType?: any;
    withCredentials?: boolean;
}

export class ToastOptions {
    showSuccess?: boolean;
    showError?: boolean;

    static show(): ToastOptions {
        return { showError: true, showSuccess: true }
    }

    static hide(): ToastOptions {
        return { showError: false, showSuccess: false }
    }

    static onlySuccess(): ToastOptions {
        return { showError: false, showSuccess: true }
    }

    static onlyError(): ToastOptions {
        return { showError: true, showSuccess: false }
    }
}

@Injectable()
export class ApiBaseService {
    protected apiUrl = environment.gateway;

    constructor(
        protected http: HttpClient,
        protected toastr: ToastrService,
    ) { }

    protected get<T>(path: string = '', options: HttpOptions = {}, toastOptions: ToastOptions = ToastOptions.hide()): Observable<T> {
        return this.http.get<T>(`${this.apiUrl}${path}`, options)
            .pipe(
                handlerSuccessResponseToastr(toastOptions.showSuccess ? this.toastr : undefined),
                handlerErrorResponseToastr(toastOptions.showError ? this.toastr : undefined)
            );
    }

    protected post<T>(path: string = '', body: any, options: HttpOptions = {}, toastOptions: ToastOptions = ToastOptions.show()): Observable<T> {
        return this.http.post<T>(`${this.apiUrl}${path}`, body, options)
            .pipe(
                handlerSuccessResponseToastr(toastOptions.showSuccess ? this.toastr : undefined),
                handlerErrorResponseToastr(toastOptions.showError ? this.toastr : undefined),
                filter<T>(value => !!value)
            );
    }

    protected put<T>(path: string = '', body: any, options: HttpOptions = {}, toastOptions: ToastOptions = ToastOptions.show()): Observable<T> {
        return this.http.put<T>(`${this.apiUrl}${path}`, body, options)
            .pipe(
                handlerSuccessResponseToastr(toastOptions.showSuccess ? this.toastr : undefined),
                handlerErrorResponseToastr(toastOptions.showError ? this.toastr : undefined),
                filter<T>(value => !!value)
            );
    }

    protected delete<T>(path: string = '', options: HttpOptions = {}, toastOptions: ToastOptions = ToastOptions.show()): Observable<T> {
        return this.http.delete<T>(`${this.apiUrl}${path}`, options)
            .pipe(
                handlerSuccessResponseToastr(toastOptions.showSuccess ? this.toastr : undefined),
                handlerErrorResponseToastr(toastOptions.showError ? this.toastr : undefined),
                filter<T>(value => !!value)
            );;
    }
}