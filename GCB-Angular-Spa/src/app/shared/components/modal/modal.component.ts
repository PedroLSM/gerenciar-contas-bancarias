import { Component, Inject, Input } from '@angular/core';
import { LoaderService } from '../loader/loader.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.scss']
})
export class ModalComponent {
  @Input() hiddenClose = false;

  loaderId: string = 'ModalComponent';

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<ModalComponent>,
    private loader: LoaderService,
  ) {
    this.loaderId = this.randomKey();
  }

  private randomKey(): string {
    return Math.random().toString(36).substring(7);
  }

  iniciarLoader(text: string = '') {
    this.loader.iniciarLoader(text, !text, this.loaderId);
  }

  encerrarLoader() {
    this.loader.encerrarLoader();
  }

  dismiss() {
    this.dialogRef.close();
  }

  close(body: any = true) {
    this.dialogRef.close(body);
  }
}

