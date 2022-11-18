import { Component, ViewChild } from "@angular/core";
import { ModalComponent } from "@shared/components/modal/modal.component";

@Component({ template: '' })
export class ModalUtils {
    @ViewChild(ModalComponent, { static: true }) modalComponent !: ModalComponent;
}