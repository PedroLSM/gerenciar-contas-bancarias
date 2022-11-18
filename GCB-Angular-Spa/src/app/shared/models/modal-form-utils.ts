import { Component, ViewChild } from "@angular/core";
import { ModalComponent } from "@shared/components/modal/modal.component";
import { FormUtils } from "./form-utils";

@Component({ template: '' })
export class ModalFormUtils extends FormUtils {
    @ViewChild(ModalComponent, { static: false }) modalComponent !: ModalComponent;

    constructor() {
        super();
    }
}