import { Injectable } from '@angular/core';
import { NgxUiLoaderService, POSITION, SPINNER } from 'ngx-ui-loader';
import { BehaviorSubject } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class LoaderService {
    private SPINNERS: SPINNER[] = [
        SPINNER.ballSpinClockwise,
        SPINNER.ballSpinClockwiseFadeRotating,
        SPINNER.circle,
        SPINNER.fadingCircle
    ];

    private loaderTextSubject = new BehaviorSubject<string>('');
    public loaderTextAction = this.loaderTextSubject.asObservable();

    loader = {
        hasProgressBar: true,
        loaderId: 'master',
        isMaster: true,
        textPosition: POSITION.centerCenter,
        spinnerType: this.randomSPINNER,
        bgsSize: 50,
    };


    constructor(private ngxUiLoaderService: NgxUiLoaderService) { }

    private get randomSPINNER(): SPINNER {
        return this.SPINNERS[Math.floor((Math.random() * this.SPINNERS.length))];
    }

    get loaderId() { return this.loader.loaderId; }
    set loaderId(value: string) { this.loader.loaderId = value; }

    mudarTexto(text: string) {
        this.loaderTextSubject.next(text);
    }

    iniciarLoader(text = '', onlySpinner = false, loaderId = 'master') {
        this.loaderTextSubject.next(onlySpinner ? '' : text);

        this.loader.loaderId = loaderId;
        this.loader.isMaster = loaderId === 'master';

        this.ngxUiLoaderService.startLoader(this.loader.loaderId);
    }

    encerrarLoader() {
        this.ngxUiLoaderService.stopLoader(this.loader.loaderId);
    }

    iniciarLoaderMaster() {
        this.loaderTextSubject.next('');
        this.ngxUiLoaderService.start();
    }

    encerrarLoaderMaster() {
        this.ngxUiLoaderService.stop();
    }
}
