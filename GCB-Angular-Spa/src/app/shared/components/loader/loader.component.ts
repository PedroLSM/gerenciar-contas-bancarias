/* eslint-disable @typescript-eslint/no-explicit-any */
import { Component, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { LoaderService } from './loader.service';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.scss']
})
export class LoaderComponent {

  @Input() loaderId = 'master';

  text$: Observable<string>;

  constructor(private loaderService: LoaderService) {
    this.text$ = this.loaderService.loaderTextAction;
  }

  get loader(): any { return this.loaderService.loader; }

}
