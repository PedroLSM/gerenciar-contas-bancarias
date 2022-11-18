import { Component, Inject } from "@angular/core";

@Component({ template: '' })
export class ListUtils {
    fieldId = 'id';

    constructor(@Inject('field') field: string = 'id') {
        this.fieldId = field;
    }

    trackByFn(_: number, item: any): number {
        return item[this.fieldId];
    }
}