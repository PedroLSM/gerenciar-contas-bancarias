import { AfterViewInit, Component, ElementRef, Input, OnInit, ViewEncapsulation } from '@angular/core';

// @ts-ignore
import SimpleBar from 'simplebar/dist/simplebar-core.esm';

import { Options } from 'simplebar';

@Component({
  selector: 'ngx-simplebar',
  host: { 'data-simplebar': 'init' },
  templateUrl: './simplebar.component.html',
  styleUrls: ['./simplebar.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class SimplebarComponent implements OnInit, AfterViewInit {

  @Input('options') options?: Options;

  elRef: ElementRef;
  simpleBar: any;

  constructor(elRef: ElementRef) {
    this.elRef = elRef;
  }

  ngOnInit() { }

  ngAfterViewInit(): void {
    this.simpleBar = new SimpleBar(this.elRef.nativeElement, this.options || {});
  }

  ngOnDestroy() {
    this.simpleBar.unMount();
    this.simpleBar = null;
  }

}
