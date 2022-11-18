/* eslint-disable @typescript-eslint/explicit-module-boundary-types */
/* eslint-disable @typescript-eslint/no-empty-function */
import { EventEmitter } from '@angular/core';
import { Utils } from './utils';

export class ReenableButton extends Utils {
  public reenableButton = new EventEmitter<boolean>(false);

  constructor() {
    super();
  }

  public habilidarBotao() { this.reenableButton.next(false); }
  public desabilidarBotao() { this.reenableButton.next(true); }
}
