import { EventEmitter } from '@angular/core';
import { debounceTime } from 'rxjs/operators';
import { ReenableButton } from './reenable-button';

export class FormError extends ReenableButton {
  private _submitted = new EventEmitter<boolean>();
  public get submitted() { return this._submitted; }

  constructor() {
    super();
  }

  protected limparErro() {
    this._submitted.next(false);
  }

  protected verificarError() {
    this._submitted.next(true);
  }
}
